using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


namespace CASAHOGAR
{
    public partial class MenosInsumos : Form
    {
        public MenosInsumos()
        {
            InitializeComponent();
        }

        private void MenosInsumos_Load(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {

                dgvMenosInsumos.DataSource = datos.VistaInsumosMinimos();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Refresh();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            SaveFileDialog Ruta = new SaveFileDialog();

            // Establecer propiedades del SaveFileDialog
            Ruta.Filter = "Archivos PDF (*.pdf)|*.pdf"; // Filtro para mostrar solo archivos PDF
            Ruta.Title = "Guardar PDF"; // Título del diálogo
            Ruta.FileName = "ReporteMenosInsumos.pdf"; // Nombre del archivo
            Ruta.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Directorio inicial (Mis documentos)

            // Mostrar el diálogo para que el usuario seleccione la ubicación del archivo
            if (Ruta.ShowDialog() == DialogResult.OK)
            {
                // Crear un DataTable a partir de los datos del DataGridView
                DataTable table = new DataTable();

                // Agregar columnas al DataTable
                foreach (DataGridViewColumn column in dgvMenosInsumos.Columns)
                {
                    table.Columns.Add(column.HeaderText, column.ValueType);
                }

                // Agregar filas al DataTable
                foreach (DataGridViewRow row in dgvMenosInsumos.Rows)
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
            Document document = new Document(PageSize.A4, 50, 50, 25, 25);
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

            Parrafo.Add("Departamento: Insumos"); //*** CAMBIAR DEPARTAMENTO SEGÚN LA TABLA QUE LES TOCÓ
            document.Add(Parrafo);


            Paragraph P2 = new Paragraph();
            P2.Alignment = Element.ALIGN_RIGHT;
            P2.Font = FontFactory.GetFont("Arial", 8);

            //***NOMBRE DE REPORTE SE CAMBIA Ej Reporte de Productos
            Chunk text = new Chunk("Reporte de menores insumos.", FontFactory.GetFont("Soberana Sans", 8, iTextSharp.text.Font.BOLD));
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
            P6.Add("En este reporte se detalla los insumos que contienen menos de la cantidad mínima requerida.");
            document.Add(P6);
            document.Add(new Paragraph(" "));

            float TotalWidth = PageSize.A4.Rotate().Width;

            float Columnwidth = TotalWidth / NumeroColumnas;

            PdfPTable tabla = new PdfPTable(NumeroColumnas);

            //*** AJUSTA EL TAMAÑO SEGÚN LA CANTIDAD DE COLUMNAS QUE TENGA LA VISTA DE LA TABLA QUE TE TOCÓ, EJ SI SON 6 COLUMNAS, LE PONES 6 VALORES
            tabla.SetWidthPercentage(new float[] { Columnwidth, Columnwidth, Columnwidth, 56, Columnwidth}, PageSize.A4.Rotate());

            //*** CAMBIAS LOS NOMBRES SEGÚN LOS QUE ESTÁN EN LA VISTA DE TU TABLA Y SI HAY MÁS COLUMNAS, LAS AGREGAS, SI HAY MENOS, SE LAS QUITAS
            PdfPCell celda1 = new PdfPCell(new Paragraph("Id Insumo", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda2 = new PdfPCell(new Paragraph("Nombre", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda3 = new PdfPCell(new Paragraph("Cantidad disponible", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda4 = new PdfPCell(new Paragraph("Unidad de medida", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda5 = new PdfPCell(new Paragraph("Descripción", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));

            //***  AGREGAS SEGÚN LAS CELDAS QUE HICISTE
            tabla.AddCell(celda1);
            tabla.AddCell(celda2);
            tabla.AddCell(celda3);
            tabla.AddCell(celda4);
            tabla.AddCell(celda5);

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
    }
}
