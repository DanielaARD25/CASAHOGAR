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
    public partial class Insumos : Form
    {
        MenosInsumos menos;
        public Insumos()
        {
            InitializeComponent();
        }

        private void Insumos_Load(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {

                dgvInsumos.DataSource = datos.VistaInsumos();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void btnEliminarInsumo_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarInsumos agregarInsumos = new AgregarInsumos();
            agregarInsumos.Show();
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgvInsumos.SelectedRows.Count > 0)
            {
                // Obtener el valor del ID de la fila seleccionada
                string idSeleccionado = dgvInsumos.SelectedRows[0].Cells["ID Insumo"].Value.ToString();

                // Confirmar con el usuario antes de eliminar
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro de insumos con ID " + idSeleccionado + "? Toma en cuenta que el registro se borrará en otros espacios donde también se usaba ",
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
                        datos.EliminarRegistroInsumos(idSeleccionado);

                        // Actualizar el DataGridView después de la eliminación
                        try
                        {
                            dgvInsumos.DataSource = datos.VistaInsumos();
                            this.Refresh();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString());
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
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

            FormularioPrincipal principal = new FormularioPrincipal();
            principal.Show();
        }

        private void dgvInsumos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            // Obtengo el ID del empleado editado.
            int idInsumo = Convert.ToInt32(dgvInsumos.Rows[e.RowIndex].Cells["ID Insumo"].Value);
            // Obtengo los nuevos valores editados.
            string nombreInsumo = dgvInsumos.Rows[e.RowIndex].Cells["Nombre"].Value.ToString();
            decimal cantidadDisponible = Convert.ToDecimal(dgvInsumos.Rows[e.RowIndex].Cells["Cantidad Disponible"].Value.ToString());
            decimal cantidadMinima = Convert.ToDecimal(dgvInsumos.Rows[e.RowIndex].Cells["Cantidad Minima"].Value.ToString());
            string unidadMedida = dgvInsumos.Rows[e.RowIndex].Cells["Unidad de Medida"].Value.ToString();
            string descripcionProducto = dgvInsumos.Rows[e.RowIndex].Cells["Descripción"].Value.ToString();

            try
            {
                datos.ActualizarInsumos(idInsumo, nombreInsumo, cantidadDisponible, cantidadMinima, unidadMedida, descripcionProducto);

                // Mensaje de éxito
                MessageBox.Show("Datos actualizados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error al actualizar el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            CasaHogar datos = new CasaHogar();
            int columnas = 0;

            // Utilizar la vista de insumos proporcionada
            table = datos.VistaInsumos();

            columnas = table.Columns.Count;

            SaveFileDialog Ruta = new SaveFileDialog();

            // Establecer propiedades del SaveFileDialog
            Ruta.Filter = "Archivos PDF (*.pdf)|*.pdf";
            Ruta.Title = "Guardar PDF";
            Ruta.FileName = "ReporteInsumos.pdf"; // Cambiar el nombre del archivo dependiendo de la tabla de insumos
            Ruta.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            // Mostrar el diálogo para que el usuario seleccione la ubicación del archivo
            if (Ruta.ShowDialog() == DialogResult.OK)
            {
                GeneraPdf(columnas, table, Ruta.FileName);
            }
        }

        private void GeneraPdf(int NumeroColumnas, DataTable VistaInsumos, string RutaArchivo)
        {
            string FileName = RutaArchivo;
            Document document = new Document(PageSize.A4.Rotate(), 50, 50, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FileName, FileMode.Create));
            document.Open();

            using (MemoryStream ms = new MemoryStream())
            {
                // Cargar la imagen desde los recursos
                Bitmap bitmap = CASAHOGAR.Properties.Resources.INSUMOS;
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

            Parrafo.Add("Departamento: Insumos"); // Cambiar el departamento según la tabla de insumos
            document.Add(Parrafo);

            Paragraph P2 = new Paragraph();
            P2.Alignment = Element.ALIGN_RIGHT;
            P2.Font = FontFactory.GetFont("Arial", 8);

            Chunk text = new Chunk("Reporte de Insumos", FontFactory.GetFont("Soberana Sans", 8, iTextSharp.text.Font.BOLD));
            P2.Add(text);
            document.Add(P2);

            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

            Paragraph P6 = new Paragraph();
            P6.Alignment = Element.ALIGN_JUSTIFIED;
            P6.Font = FontFactory.GetFont("Arial", 9);

            P6.Add("En este reporte se detalla la lista de insumos disponibles."); // Cambiar la descripción según la tabla de insumos
            document.Add(P6);
            document.Add(new Paragraph(" "));

            float TotalWidth = PageSize.A4.Rotate().Width;
            float Columnwidth = TotalWidth / NumeroColumnas;

            PdfPTable tabla = new PdfPTable(NumeroColumnas);

            // Ajustar el tamaño según la cantidad de columnas de la vista de insumos
            tabla.SetWidthPercentage(new float[] { Columnwidth, Columnwidth, 56, 56, Columnwidth, 56}, PageSize.A4.Rotate());

            // Cambiar los nombres de las celdas según la vista de insumos
            PdfPCell celda1 = new PdfPCell(new Paragraph("Id Insumo", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda2 = new PdfPCell(new Paragraph("Nombre", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda3 = new PdfPCell(new Paragraph("Cantidad Disponible", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda4 = new PdfPCell(new Paragraph("Cantidad Minima", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda5 = new PdfPCell(new Paragraph("Unidad de Medida", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda6 = new PdfPCell(new Paragraph("Descripción", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));

            tabla.AddCell(celda1);
            tabla.AddCell(celda2);
            tabla.AddCell(celda3);
            tabla.AddCell(celda4);
            tabla.AddCell(celda5);
            tabla.AddCell(celda6);

            foreach (DataRow item in VistaInsumos.Rows)
            {
                PdfPCell celda7 = new PdfPCell(new Paragraph(item[0].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda7);

                PdfPCell celda8 = new PdfPCell(new Paragraph(item[1].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda8);

                PdfPCell celda9 = new PdfPCell(new Paragraph(item[2].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda9);

                PdfPCell celda10 = new PdfPCell(new Paragraph(item[3].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda10);

                PdfPCell celda11 = new PdfPCell(new Paragraph(item[4].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda11);

                PdfPCell celda12 = new PdfPCell(new Paragraph(item[5].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda12);

            }
            document.Add(tabla);

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

        private void botones1_Click(object sender, EventArgs e)
        {
            menos = new MenosInsumos();
            menos.Show();
        }

        private void Insumos_Shown(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            this.Shown -= Insumos_Shown; // Deshabilitar temporalmente el evento
            try
            {
                // Obtener los datos de insumos y asignarlos al DataGridView
                DataTable insumos = datos.VistaInsumos();
                dgvInsumos.DataSource = insumos;

                //-------------------------------------INSUMOS EN CEROS ------------------------------------
                // Verificar si algún insumo tiene cantidad 0
                var insumosSinCantidad = insumos.AsEnumerable()
                                                .Where(row => Convert.ToDecimal(row["Cantidad Disponible"]) == 0)
                                                .ToList();

                if (insumosSinCantidad.Any())
                {
                    // Crear el mensaje con los nombres de los insumos con cantidad 0
                    string mensaje = "Los siguientes insumos tienen cantidad 0:\n" +
                                     string.Join("\n", insumosSinCantidad.Select(row => row["Nombre"].ToString()));

                    // Mostrar el mensaje en un MessageBox
                    MessageBox.Show(mensaje, "Insumos en Cero", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                this.Shown += Insumos_Shown; // Rehabilitar el evento
            }
        }
    }
}

