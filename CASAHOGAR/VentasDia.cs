using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;

namespace CASAHOGAR
{
    public partial class VentasDia : Form
    {
        private DateTime fechaSeleccionada;
        CasaHogar conexion = new CasaHogar();
        Ventas ventas;
        
        //string cadena = cone.Conexion();
        public VentasDia(DateTime fecha)
        {
            InitializeComponent();
            CasaHogar datos = new CasaHogar();
            fechaSeleccionada = fecha;
            dgvVentas.DataSource = datos.VistaVentas(fechaSeleccionada);
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void VentasDia_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
            Refresh();
        }

        public void ActualizarDataGridView()
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                dgvVentas.DataSource = null; // Primero limpiamos la fuente de datos
                dgvVentas.Rows.Clear(); // Limpiamos las filas existentes

                // Llenamos nuevamente el DataGridView con los datos actualizados
                dgvVentas.DataSource = datos.VistaVentas(fechaSeleccionada);

                // Opcionalmente, podríamos ajustar las columnas si es necesario
                // dgvVentas.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al actualizar el DataGridView: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            //buscar();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            SaveFileDialog Ruta = new SaveFileDialog();

            // Establecer propiedades del SaveFileDialog
            Ruta.Filter = "Archivos PDF (*.pdf)|*.pdf"; // Filtro para mostrar solo archivos PDF
            Ruta.Title = "Guardar PDF"; // Título del diálogo
            Ruta.FileName = "ReporteVentasPorDia.pdf"; // Nombre del archivo
            Ruta.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Directorio inicial (Mis documentos)

            // Mostrar el diálogo para que el usuario seleccione la ubicación del archivo
            if (Ruta.ShowDialog() == DialogResult.OK)
            {
                // Crear un DataTable a partir de los datos del DataGridView
                DataTable table = new DataTable();

                // Agregar columnas al DataTable
                foreach (DataGridViewColumn column in dgvVentas.Columns)
                {
                    table.Columns.Add(column.HeaderText, column.ValueType);
                }

                // Agregar filas al DataTable
                foreach (DataGridViewRow row in dgvVentas.Rows)
                {
                    if (row.IsNewRow) continue; // Omitir la fila nueva (vacía)
                    DataRow dataRow = table.NewRow();
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        dataRow[cell.ColumnIndex] = cell.Value;
                    }
                    table.Rows.Add(dataRow);
                }

                // Llamar al método GeneraPdf con los datos del DataGridView
                int columnas = table.Columns.Count;
                GeneraPdf(columnas, table, Ruta.FileName);
            }
        }

        private void GeneraPdf(int NumeroColumnas, DataTable VistaVentas, string RutaArchivo)
        {
            string FileName = RutaArchivo;
            Document document = new Document(PageSize.A4.Rotate(), 50, 50, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FileName, FileMode.Create));
            document.Open();

            using (MemoryStream ms = new MemoryStream())
            {
                // Cargar la imagen desde los recursos
                Bitmap bitmap = CASAHOGAR.Properties.Resources.VENTAS;
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);

                // Obtener la imagen de iTextSharp
                iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(ms);

                // Obtener el tamaño de la página
                var pageSize = document.PageSize;

                // Calcular la escala para ajustar la imagen al ancho de la página, manteniendo la relación de aspecto
                float pageWidth = pageSize.Width - document.LeftMargin - document.RightMargin;
                float pageHeight = pageSize.Height - document.TopMargin - document.BottomMargin;
                float scaleX = pageWidth / png.Width;
                float scaleY = pageHeight / png.Height;
                float scale = Math.Min(scaleX, scaleY);

                // Aplicar la escala a la imagen
                png.ScalePercent(scale * 100);

                // Centrar la imagen
                png.Alignment = iTextSharp.text.Image.ALIGN_CENTER;

                // Añadir la imagen al documento
                document.Add(png);
            }

            Paragraph Parrafo = new Paragraph();
            Parrafo.Alignment = Element.ALIGN_RIGHT;
            Parrafo.Font = FontFactory.GetFont("Arial", 8);
            Parrafo.Font.SetStyle(iTextSharp.text.Font.BOLD);
            Parrafo.Font.SetStyle(iTextSharp.text.Font.UNDEFINED);

            Parrafo.Add("Departamento: Ventas"); //*** CAMBIAR DEPARTAMENTO SEGÚN LA TABLA QUE LES TOCÓ
            document.Add(Parrafo);


            Paragraph P2 = new Paragraph();
            P2.Alignment = Element.ALIGN_RIGHT;
            P2.Font = FontFactory.GetFont("Arial", 8);

            //***NOMBRE DE REPORTE SE CAMBIA Ej Reporte de Productos
            Chunk text = new Chunk("Reporte de Ventas", FontFactory.GetFont("Soberana Sans", 8, iTextSharp.text.Font.BOLD));
            P2.Add(text);
            document.Add(P2);

            Paragraph P3 = new Paragraph();
            P2.Alignment = Element.ALIGN_RIGHT;
            P2.Font = FontFactory.GetFont("Arial", 8);


            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

            Paragraph P6 = new Paragraph();
            P6.Alignment = Element.ALIGN_JUSTIFIED;
            P6.Font = FontFactory.GetFont("Arial", 9);


            //*** SE CAMBIA DESCRIPCIÓN DE ACUERDO A TABLA
            P6.Add("En este reporte se detalla la cantidad de ventas.");
            document.Add(P6);
            document.Add(new Paragraph(" "));

            float TotalWidth = PageSize.A4.Rotate().Width;

            float Columnwidth = TotalWidth / NumeroColumnas;

            PdfPTable tabla = new PdfPTable(NumeroColumnas);

            //*** AJUSTA EL TAMAÑO SEGÚN LA CANTIDAD DE COLUMNAS QUE TENGA LA VISTA DE LA TABLA QUE TE TOCÓ, EJ SI SON 6 COLUMNAS, LE PONES 6 VALORES
            tabla.SetWidthPercentage(new float[] { Columnwidth, Columnwidth, Columnwidth, 56, Columnwidth, Columnwidth, Columnwidth}, PageSize.A4.Rotate());

            //*** CAMBIAS LOS NOMBRES SEGÚN LOS QUE ESTÁN EN LA VISTA DE TU TABLA Y SI HAY MÁS COLUMNAS, LAS AGREGAS, SI HAY MENOS, SE LAS QUITAS
            PdfPCell celda1 = new PdfPCell(new Paragraph("Id Venta", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda2 = new PdfPCell(new Paragraph("Id Precio", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda3 = new PdfPCell(new Paragraph("Precio", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda4 = new PdfPCell(new Paragraph("Descripción", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda5 = new PdfPCell(new Paragraph("Cantidad Vendida", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda6 = new PdfPCell(new Paragraph("Monto Pagado", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda7 = new PdfPCell(new Paragraph("Fecha de Venta", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));

            //***  AGREGAS SEGÚN LAS CELDAS QUE HICISTE
            tabla.AddCell(celda1);
            tabla.AddCell(celda2);
            tabla.AddCell(celda3);
            tabla.AddCell(celda4);
            tabla.AddCell(celda5);
            tabla.AddCell(celda6);
            tabla.AddCell(celda7);

            foreach (DataRow item in VistaVentas.Rows)
            {
                //*** SI HICISTE 8 CELDAS, AGREGAS 8 DE ESTOS CODIGUITOS
                PdfPCell celda8 = new PdfPCell(new Paragraph(item[0].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda8);

                PdfPCell celda9 = new PdfPCell(new Paragraph(item[1].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda9);

                PdfPCell celda10 = new PdfPCell(new Paragraph(item[2].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda10);

                PdfPCell celda11 = new PdfPCell(new Paragraph(item[3].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda11);

                PdfPCell celda12 = new PdfPCell(new Paragraph(item[4].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda12);

                PdfPCell celda13 = new PdfPCell(new Paragraph(item[5].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda13);

                PdfPCell celda14 = new PdfPCell(new Paragraph(item[6].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda14);

            }
            document.Add(tabla);

            // Agregar la fecha en la esquina inferior derecha
            PdfPTable footer = new PdfPTable(1);
            footer.TotalWidth = document.PageSize.Width - document.LeftMargin - document.RightMargin;
            footer.DefaultCell.Border = iTextSharp.text.Rectangle.NO_BORDER;
            footer.AddCell(new PdfPCell(new Phrase(DateTime.Now.ToString("dd/MM/yyyy"), FontFactory.GetFont("Arial", 8)))
            {
                Border = iTextSharp.text.Rectangle.NO_BORDER,
                HorizontalAlignment = Element.ALIGN_RIGHT
            });
            footer.WriteSelectedRows(0, -1, document.LeftMargin, document.BottomMargin - 10, writer.DirectContent);


            document.Close();
            Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = FileName;
            prc.Start();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                dgvVentas.DataSource = datos.VistaVentas(fechaSeleccionada);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarVentas agregarVentas = new AgregarVentas();
            agregarVentas.dtpFechaVenta.Value = fechaSeleccionada;
            agregarVentas.Show();
            this.Close();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            // Obtener la fecha actual
            DateTime fechaActual = DateTime.Today;

            // Calcular la fecha límite como una semana antes de la fecha actual
            DateTime fechaLimite = fechaActual.AddDays(-7);

            //DateTime fechaSeleccionada = Convert.ToDateTime(dgvVentas.SelectedRows[0].Cells["Fecha de Venta"].Value.ToString());
            if (dgvVentas.SelectedRows.Count > 0)
            {
                // Verificar si hay una fila seleccionada en el DataGridView
                if ( fechaSeleccionada >= fechaLimite && fechaSeleccionada <= fechaActual)
                {
                    // Obtener el valor del ID de la fila seleccionada
                    string idSeleccionado = dgvVentas.SelectedRows[0].Cells["ID Venta"].Value.ToString();
                        // Confirmar con el usuario antes de eliminar
                        DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro de venta con ID " + idSeleccionado + "?",
                                                                "Confirmar Eliminación",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question);

                        // Si el usuario confirma la eliminación
                        if (result == DialogResult.Yes)
                        {
                            // Realizar la eliminación del registro utilizando el ID obtenido
                            try
                            {
                                // Llamar a un método en tu clase de acceso a datos para eliminar el registro por su ID
                                datos.EliminarRegistroVentas(idSeleccionado);

                                // Actualizar el DataGridView después de la eliminación
                                try
                                {
                                    ventas = new Ventas();
                                    ActualizarDataGridView();
                                    ventas.ActualizarDataGridView();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error al actualizar el DataGridView después de la eliminación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al eliminar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                }
                else
                {
                    MessageBox.Show("No puedes eliminar ventas fuera del plazo de una semana desde la fecha de venta.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            
        }

    }
}
