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
    public partial class Consumos : Form
    {
        public Consumos()
        {
            InitializeComponent();
        }

        public string Conexion()
        {
            string connectionString = @"Data Source=THE-MARAUDERS-M\TBD_DARD_23;Initial Catalog=CASAHOGAR;Integrated Security=True";
            return connectionString;
        }

        private void Consumos_Load(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {

                dgvConsumos.DataSource = datos.VistaConsumos();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Refresh();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarConsumos agregarConsumos = new AgregarConsumos();
            agregarConsumos.Show();
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgvConsumos.SelectedRows.Count > 0)
            {
                // Obtener el valor del ID de la fila seleccionada
                string idSeleccionado = dgvConsumos.SelectedRows[0].Cells["ID Consumo"].Value.ToString();

                // Confirmar con el usuario antes de eliminar
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro de consumos con ID " + idSeleccionado + "? Toma en cuenta que el registro se borrará en otros espacios donde también se usaba ",
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
                        datos.EliminarRegistroConsumos(idSeleccionado);

                        // Actualizar el DataGridView después de la eliminación
                        try
                        {
                            dgvConsumos.DataSource = datos.VistaConsumos();
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void dgvConsumos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            // Obtengo el ID del consumo editado.
            int idConsumo = Convert.ToInt32(dgvConsumos.Rows[e.RowIndex].Cells["ID Consumo"].Value);
            // Obtengo los nuevos valores editados.
            int idInsumo = Convert.ToInt32(dgvConsumos.Rows[e.RowIndex].Cells["ID Insumo"].Value);
            decimal cantidadConsumida = Convert.ToDecimal(dgvConsumos.Rows[e.RowIndex].Cells["Cantidad Consumida"].Value);
            decimal cantidadDisponible = Convert.ToDecimal(dgvConsumos.Rows[e.RowIndex].Cells["Cantidad Disponible"].Value);
            string unidadMedida = dgvConsumos.Rows[e.RowIndex].Cells["Unidad de Medida"].Value.ToString();

            // Validar cantidad disponible antes de actualizar
            if (cantidadConsumida <= 0)
            {
                MessageBox.Show("La cantidad consumida no puede ser cero o negativa.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                datos.ActualizarCantidades(idInsumo, idConsumo, cantidadConsumida, cantidadDisponible, unidadMedida);
                MessageBox.Show("Datos actualizados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (InvalidOperationException ex)
            {
                // Capturar los errores lanzados por RAISERROR
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                // Capturar otros tipos de errores
                MessageBox.Show("Error al actualizar los datos del consumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            CasaHogar datos = new CasaHogar();
            int columnas = 0;

            table = datos.VistaConsumos(); // *** Modificar según el nombre de tu método para obtener los datos

            columnas = table.Columns.Count;

            SaveFileDialog Ruta = new SaveFileDialog();

            // Establecer propiedades del SaveFileDialog
            Ruta.Filter = "Archivos PDF (*.pdf)|*.pdf"; // Filtro para mostrar solo archivos PDF
            Ruta.Title = "Guardar PDF"; // Título del diálogo
            Ruta.FileName = "ReporteConsumos.pdf"; // *** Cambiar el nombre del archivo según tu necesidad
            Ruta.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Directorio inicial (Mis documentos)

            // Mostrar el diálogo para que el usuario seleccione la ubicación del archivo
            if (Ruta.ShowDialog() == DialogResult.OK)
            {
                GeneraPdf(columnas, table, Ruta.FileName);
            }
        }
        private void GeneraPdf(int NumeroColumnas, DataTable VistaConsumos, string RutaArchivo)
        {
            string FileName = RutaArchivo;
            Document document = new Document(PageSize.A4.Rotate(), 50, 50, 25, 25);
            PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(FileName, FileMode.Create));
            document.Open();

            using (MemoryStream ms = new MemoryStream())
            {
                // Cargar la imagen desde los recursos
                Bitmap bitmap = CASAHOGAR.Properties.Resources.CONSUMOS;
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

            Parrafo.Add("Departamento: Consumos"); // *** Cambiar departamento según tu necesidad
            document.Add(Parrafo);

            Paragraph P2 = new Paragraph();
            P2.Alignment = Element.ALIGN_RIGHT;
            P2.Font = FontFactory.GetFont("Arial", 8);

            Chunk text = new Chunk("Reporte de Consumos", FontFactory.GetFont("Soberana Sans", 8, iTextSharp.text.Font.BOLD));
            P2.Add(text);
            document.Add(P2);

            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

            Paragraph P6 = new Paragraph();
            P6.Alignment = Element.ALIGN_JUSTIFIED;
            P6.Font = FontFactory.GetFont("Arial", 9);

            P6.Add("En este reporte se detalla la cantidad de consumos realizados."); // *** Cambiar descripción según tu necesidad
            document.Add(P6);
            document.Add(new Paragraph(" "));

            float TotalWidth = PageSize.A4.Rotate().Width;

            float Columnwidth = TotalWidth / NumeroColumnas;

            PdfPTable tabla = new PdfPTable(NumeroColumnas);

            // *** Ajustar el tamaño según la cantidad de columnas que tenga la vista de la tabla de consumos
            tabla.SetWidthPercentage(new float[] { 56, Columnwidth, 56, 56, Columnwidth, Columnwidth }, PageSize.A4.Rotate());

            // *** Cambiar los nombres de las columnas según tu necesidad
            PdfPCell celda1 = new PdfPCell(new Paragraph("ID Consumo", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda2 = new PdfPCell(new Paragraph("ID Insumo", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda3 = new PdfPCell(new Paragraph("Insumo", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda4 = new PdfPCell(new Paragraph("Cantidad Consumida", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda5 = new PdfPCell(new Paragraph("Cantidad Disponible", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda6 = new PdfPCell(new Paragraph("Unidad de Medida", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));

            // *** Agregar las celdas según las columnas definidas
            tabla.AddCell(celda1);
            tabla.AddCell(celda2);
            tabla.AddCell(celda3);
            tabla.AddCell(celda4);
            tabla.AddCell(celda5);
            tabla.AddCell(celda6);

            foreach (DataRow item in VistaConsumos.Rows)
            {
                // *** Agregar las celdas según los datos de la tabla de consumos
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

    }
}
