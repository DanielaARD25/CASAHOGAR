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
    public partial class MobiliarioEquipo : Form
    {
        public MobiliarioEquipo()
        {
            InitializeComponent();
        }

        public string Conexion()
        {
            string connectionString = @"Data Source=THE-MARAUDERS-M\TBD_DARD_23;Initial Catalog=CASAHOGAR;Integrated Security=True";
            return connectionString;
        }

        private void MobiliarioEquipo_Load(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {

                dgvMobEquipo.DataSource = datos.VistaMobiliario();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }


        private void btnAgregar_Click(object sender, EventArgs e)
        {
            MobiliarioEquipo mobiliarioEquipo = new MobiliarioEquipo();
            mobiliarioEquipo.Show();
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            // Verificar si hay una fila seleccionada en el DataGridView
            if (dgvMobEquipo.SelectedRows.Count > 0)
            {
                // Obtener el valor del ID de la fila seleccionada
                string idSeleccionado = dgvMobEquipo.SelectedRows[0].Cells["ID Mobiliario"].Value.ToString();

                // Confirmar con el usuario antes de eliminar
                DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar el registro de mobiliario y equipo con ID " + idSeleccionado + "? Toma en cuenta que el registro se borrará en otros espacios donde también se usaba ",
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
                        datos.EliminarRegistroMobiliario(idSeleccionado);

                        // Actualizar el DataGridView después de la eliminación
                        try
                        {
                            dgvMobEquipo.DataSource = datos.VistaMobiliario();
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


        private void dgvMobEquipo_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            string conectionString;
            conectionString = Conexion();
            // Obtengo el ID del empleado editado.
            int idMobiliario = Convert.ToInt32(dgvMobEquipo.Rows[e.RowIndex].Cells["ID Mobiliario"].Value);
            // Obtengo los nuevos valores editados.
            string nombreMobiliario = dgvMobEquipo.Rows[e.RowIndex].Cells["Mobiliario"].Value.ToString();
            int cantidadDisponible = Convert.ToInt32(dgvMobEquipo.Rows[e.RowIndex].Cells["Cantidad Disponible"].Value.ToString());
            string descripcionMobiliario = dgvMobEquipo.Rows[e.RowIndex].Cells["Descripción"].Value.ToString();
            string estadoArticulo = dgvMobEquipo.Rows[e.RowIndex].Cells["Estado"].Value.ToString();

            // Actualizo la base de datos con los nuevos valores del empleado.
            try
            {
                // Establezco una conexión con la base de datos.
                using (SqlConnection connection = new SqlConnection(conectionString))
                {
                    connection.Open();
                    // Construyo la consulta SQL para actualizar los datos del empleado.
                    string query = "UPDATE MobiliarioEquipo SET nombreMobiliario = @NombreMobiliario, cantidadDisponible = @CantidadDisponible, descripcionMobiliario = @DescripcionMobiliario, estadoArticulo = @EstadoArticulo WHERE idMobiliario = @IdMobiliario";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@IdMobiliario", idMobiliario);
                    command.Parameters.AddWithValue("@NombreMobiliario", nombreMobiliario);
                    command.Parameters.AddWithValue("@CantidadDisponible", cantidadDisponible);
                    command.Parameters.AddWithValue("@DescripcionMobiliario", descripcionMobiliario);
                    command.Parameters.AddWithValue("@EstadoArticulo", estadoArticulo);
                    // Ejecuto la consulta.
                    command.ExecuteNonQuery();

                    MessageBox.Show("Datos del mobiliario actualizados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                // Muestro un mensaje de error en caso de que ocurra una excepción durante la actualización.
                MessageBox.Show("Error al actualizar los datos del mobiliario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            CasaHogar datos = new CasaHogar();
            int columnas = 0;

            table = datos.VistaMobiliario(); // *** MODIFICAR VISTA DEPENDIENDO DE LA TABLA QUE LES TOCÓ

            columnas = table.Columns.Count;

            SaveFileDialog Ruta = new SaveFileDialog();

            // Establecer propiedades del SaveFileDialog
            Ruta.Filter = "Archivos PDF (*.pdf)|*.pdf"; // Filtro para mostrar solo archivos PDF
            Ruta.Title = "Guardar PDF"; // Título del diálogo
            Ruta.FileName = "ReporteMobiliarioEquipo.pdf"; // **** CAMBIAR NOMAS EL NOMBRE DEPENDIENDO DE LA TABLA EJ. ReporteDonantes
            Ruta.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments); // Directorio inicial (Mis documentos)

            // Mostrar el diálogo para que el usuario seleccione la ubicación del archivo
            if (Ruta.ShowDialog() == DialogResult.OK)
            {

                GeneraPdf(columnas, table, Ruta.FileName);
            }
        }

        private void GeneraPdf(int NumeroColumnas, DataTable VistaVentas, string RutaArchivo)
        {
            string FileName = RutaArchivo;
            Document document = new Document(PageSize.A4.Rotate(), 50, 50, 25, 25);
            PdfWriter.GetInstance(document, new FileStream(FileName, FileMode.Create));
            document.Open();

            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(@"C:\Users\danwe\Desktop\Daniela\TEC\SEMESTRE 6\ING DE SOFTWARE\REVISAR\CASAHOGAR_ETAPA2\CASAHOGAR_DISEÑO_ETAPA4 Edición\CASAHOGAR_DISEÑO_ETAPA2\ReporteEncabezado.png");
            //*** SI QUIEREN CAMBIAR LA RUTA DE LA IMAGEN, CAMBIENLA, SINO NO
            jpg.ScalePercent(32f);
            jpg.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
            document.Add(jpg);


            Paragraph Parrafo = new Paragraph();
            Parrafo.Alignment = Element.ALIGN_RIGHT;
            Parrafo.Font = FontFactory.GetFont("Arial", 8);
            Parrafo.Font.SetStyle(iTextSharp.text.Font.BOLD);
            Parrafo.Font.SetStyle(iTextSharp.text.Font.UNDEFINED);

            Parrafo.Add("Departamento: Mobiliario y Equipo"); //*** CAMBIAR DEPARTAMENTO SEGÚN LA TABLA QUE LES TOCÓ
            document.Add(Parrafo);


            Paragraph P2 = new Paragraph();
            P2.Alignment = Element.ALIGN_RIGHT;
            P2.Font = FontFactory.GetFont("Arial", 8);

            //***NOMBRE DE REPORTE SE CAMBIA Ej Reporte de Productos
            Chunk text = new Chunk("Reporte de Mobiliario y Equipo", FontFactory.GetFont("Soberana Sans", 8, iTextSharp.text.Font.BOLD));
            P2.Add(text);
            document.Add(P2);

            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

            Paragraph P6 = new Paragraph();
            P6.Alignment = Element.ALIGN_JUSTIFIED;
            P6.Font = FontFactory.GetFont("Arial", 9);


            //*** SE CAMBIA DESCRIPCIÓN DE ACUERDO A TABLA
            P6.Add("En este reporte se detalla la cantidad de Mobiliario y Equipo.");
            document.Add(P6);
            document.Add(new Paragraph(" "));

            float TotalWidth = PageSize.A4.Rotate().Width;

            float Columnwidth = TotalWidth / NumeroColumnas;

            PdfPTable tabla = new PdfPTable(NumeroColumnas);

            //*** AJUSTA EL TAMAÑO SEGÚN LA CANTIDAD DE COLUMNAS QUE TENGA LA VISTA DE LA TABLA QUE TE TOCÓ, EJ SI SON 6 COLUMNAS, LE PONES 6 VALORES
            tabla.SetWidthPercentage(new float[] { 56, Columnwidth, 56, 56, Columnwidth }, PageSize.A4.Rotate());

            //*** CAMBIAS LOS NOMBRES SEGÚN LOS QUE ESTÁN EN LA VISTA DE TU TABLA Y SI HAY MÁS COLUMNAS, LAS AGREGAS, SI HAY MENOS, SE LAS QUITAS
            PdfPCell celda1 = new PdfPCell(new Paragraph("ID Mobiliario", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda2 = new PdfPCell(new Paragraph("Mobiliario", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda3 = new PdfPCell(new Paragraph("Cantidad Disponible", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda4 = new PdfPCell(new Paragraph("Descripción", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda5 = new PdfPCell(new Paragraph("Estado", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));

            //***  AGREGAS SEGÚN LAS CELDAS QUE HICISTE
            tabla.AddCell(celda1);
            tabla.AddCell(celda2);
            tabla.AddCell(celda3);
            tabla.AddCell(celda4);
            tabla.AddCell(celda5);

            foreach (DataRow item in VistaVentas.Rows)
            {
                //*** SI HICISTE 8 CELDAS, AGREGAS 8 DE ESTOS CODIGUITOS

                PdfPCell celda6 = new PdfPCell(new Paragraph(item[0].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda6);

                PdfPCell celda7 = new PdfPCell(new Paragraph(item[1].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda7);

                PdfPCell celda8 = new PdfPCell(new Paragraph(item[2].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda8);

                PdfPCell celda9 = new PdfPCell(new Paragraph(item[3].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda9);

                PdfPCell celda10 = new PdfPCell(new Paragraph(item[4].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda10);

            }
            document.Add(tabla);

            document.Close();
            Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = FileName;
            prc.Start();
        }
    }
}
