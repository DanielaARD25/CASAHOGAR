using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Microsoft.VisualBasic;

namespace CASAHOGAR
{
    public partial class Ventas : Form
    {
        //IMPRIMIR
        private DataGridViewPrinter dataGridViewPrinter;
        Form1 form1;

        public Ventas()
        {
            InitializeComponent();
            //IMPRIMIR
            dataGridViewPrinter = new DataGridViewPrinter(dgvVentas);
        }

        public string Conexion()
        {
            string connectionString = @"Data Source=THE-MARAUDERS-M\TBD_DARD_23;Initial Catalog=CASAHOGAR;Integrated Security=True";
            return connectionString;
        }

        private void Ventas_Load(object sender, EventArgs e)
        {
            ActualizarDataGridView();
            Refresh();

            dgvVentas.CellClick += dgvVentas_CellClick;

        }

        public void ActualizarDataGridView()
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                dgvVentas.DataSource = datos.VistaVentasPorDia();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarVentas agregarVentas = new AgregarVentas();
            agregarVentas.Show();
            this.Close();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();

            DateTime fechaSeleccionada = Convert.ToDateTime(dgvVentas.SelectedRows[0].Cells["Fecha de Venta"].Value.ToString());
            if (fechaSeleccionada == DateTime.Today)
            {
                // Verificar si hay una fila seleccionada en el DataGridView
                if (dgvVentas.SelectedRows.Count > 0)
                {
                    // Obtener la fecha de la venta seleccionada
                    //DateTime fechaSeleccionada = Convert.ToDateTime(dgvVentas.SelectedRows[0].Cells["Fecha de Venta"].Value.ToString());

                    // Solicitar la contraseña al usuario
                    string contraseñaIngresada = Microsoft.VisualBasic.Interaction.InputBox("Por favor, ingresa tu contraseña para confirmar la eliminación:", "Confirmar Eliminación", "");

                    // Verificar si la contraseña ingresada coincide con la contraseña del usuario actual
                    if (contraseñaIngresada == SesionUsuario.ContraseñaUsuario)
                    {
                        // Confirmar con el usuario antes de eliminar
                        DialogResult result = MessageBox.Show("¿Estás seguro de que deseas eliminar todas las ventas realizadas en la fecha " + fechaSeleccionada + "?",
                                                                "Confirmar Eliminación",
                                                                MessageBoxButtons.YesNo,
                                                                MessageBoxIcon.Question);

                        // Si el usuario confirma la eliminación
                        if (result == DialogResult.Yes)
                        {
                            // Realizar la eliminación de las ventas por fecha
                            try
                            {
                                // Llamar a un método en tu clase de acceso a datos para eliminar las ventas por fecha
                                datos.EliminarVentasPorFecha(fechaSeleccionada);

                                // Actualizar el DataGridView después de la eliminación
                                try
                                {
                                    ActualizarDataGridView();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show("Error al actualizar el DataGridView después de la eliminación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Error al eliminar las ventas por fecha: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta. No tienes permiso para eliminar las ventas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Has excedido el tiempo límite para eliminar el registro.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            ActualizarDataGridView();
        }

        private void btnImprimir_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog Ruta = new SaveFileDialog();

            // Establecer propiedades del SaveFileDialog
            Ruta.Filter = "Archivos PDF (*.pdf)|*.pdf"; // Filtro para mostrar solo archivos PDF
            Ruta.Title = "Guardar PDF"; // Título del diálogo
            Ruta.FileName = "ReporteVentas.pdf"; // Nombre del archivo
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
            PdfWriter.GetInstance(document, new FileStream(FileName, FileMode.Create));
            document.Open();

            using (MemoryStream ms = new MemoryStream())
            {
                Bitmap bitmap = CASAHOGAR.Properties.Resources.VENTAS;
                bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Seek(0, SeekOrigin.Begin);

                iTextSharp.text.Image png = iTextSharp.text.Image.GetInstance(ms);
                png.ScalePercent(32f);
                png.Alignment = iTextSharp.text.Image.ALIGN_CENTER;
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
            Chunk text = new Chunk("Reporte de Ventas por Dia", FontFactory.GetFont("Soberana Sans", 8, iTextSharp.text.Font.BOLD));
            P2.Add(text);
            document.Add(P2);

            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" "));

            Paragraph P6 = new Paragraph();
            P6.Alignment = Element.ALIGN_JUSTIFIED;
            P6.Font = FontFactory.GetFont("Arial", 9);
            

            //*** SE CAMBIA DESCRIPCIÓN DE ACUERDO A TABLA
            P6.Add("En este reporte se detalla la cantidad de ventas realizadas en el dia seleccionado.");
            document.Add(P6);
            document.Add(new Paragraph(" "));

            float TotalWidth = PageSize.A4.Rotate().Width;

            float Columnwidth = TotalWidth / NumeroColumnas;

            PdfPTable tabla = new PdfPTable(NumeroColumnas);

            //*** AJUSTA EL TAMAÑO SEGÚN LA CANTIDAD DE COLUMNAS QUE TENGA LA VISTA DE LA TABLA QUE TE TOCÓ, EJ SI SON 6 COLUMNAS, LE PONES 6 VALORES
            tabla.SetWidthPercentage(new float[] { 56, Columnwidth, 56, 56, Columnwidth, Columnwidth}, PageSize.A4.Rotate());
            
            //*** CAMBIAS LOS NOMBRES SEGÚN LOS QUE ESTÁN EN LA VISTA DE TU TABLA Y SI HAY MÁS COLUMNAS, LAS AGREGAS, SI HAY MENOS, SE LAS QUITAS
            PdfPCell celda1 = new PdfPCell(new Paragraph("Fecha de Venta", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda2 = new PdfPCell(new Paragraph("Cantidad Vendida Total", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            PdfPCell celda3 = new PdfPCell(new Paragraph("Total del dia", FontFactory.GetFont("Arial", 9, iTextSharp.text.Font.BOLD)));
            
            //***  AGREGAS SEGÚN LAS CELDAS QUE HICISTE
            tabla.AddCell(celda1);
            tabla.AddCell(celda2);
            tabla.AddCell(celda3);

            foreach (DataRow item in VistaVentas.Rows)
            {
                //*** SI HICISTE 8 CELDAS, AGREGAS 8 DE ESTOS CODIGUITOS
                PdfPCell celda7 = new PdfPCell(new Paragraph(item[0].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda7);

                PdfPCell celda8 = new PdfPCell(new Paragraph(item[1].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda8);

                PdfPCell celda9 = new PdfPCell(new Paragraph(item[2].ToString(), FontFactory.GetFont("Arial", 9)));
                tabla.AddCell(celda9);
            }
            document.Add(tabla);
            
            document.Close();
            Process prc = new System.Diagnostics.Process();
            prc.StartInfo.FileName = FileName;
            prc.Start();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();

            FormularioPrincipal principal = new FormularioPrincipal();
            principal.Show();
        }

        private void dgvVentas_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            //string conectionString;
            //conectionString = Conexion();
            //// Obtengo el ID de la venta editada.
            //int idVenta = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["ID Venta"].Value);
            //// Obtengo los nuevos valores editados.
            //int idProducto = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["ID Producto"].Value);
            //int cantidadVendida = Convert.ToInt32(dgvVentas.Rows[e.RowIndex].Cells["Cantidad Vendida"].Value.ToString());
            //decimal montoPagado = Convert.ToDecimal(dgvVentas.Rows[e.RowIndex].Cells["Monto Pagado"].Value.ToString());
            //DateTime fechaVenta = Convert.ToDateTime(dgvVentas.Rows[e.RowIndex].Cells["Fecha de Venta"].Value.ToString());

            //// Actualizo la base de datos con los nuevos valores de la venta.
            //try
            //{
            //    // Establezco una conexión con la base de datos.
            //    using (SqlConnection connection = new SqlConnection(conectionString))
            //    {
            //        connection.Open();
            //        // Construyo la consulta SQL para actualizar los datos de la venta.
            //        string query = "UPDATE Ventas SET idProducto = @IdProducto, cantidadVendida = @CantidadVendida, montoPagado = @MontoPagado, fechaVenta = @FechaVenta WHERE idVenta = @IdVenta";
            //        SqlCommand command = new SqlCommand(query, connection);
            //        command.Parameters.AddWithValue("@IdVenta", idVenta);
            //        command.Parameters.AddWithValue("@IdProducto", idProducto);
            //        command.Parameters.AddWithValue("@CantidadVendida", cantidadVendida);
            //        command.Parameters.AddWithValue("@MontoPagado", montoPagado);
            //        command.Parameters.AddWithValue("@FechaVenta", fechaVenta);
            //        // Ejecuto la consulta.
            //        command.ExecuteNonQuery();

            //        MessageBox.Show("Datos de la venta actualizados correctamente", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    // Muestro un mensaje de error en caso de que ocurra una excepción durante la actualización.
            //    MessageBox.Show("Error al actualizar los datos de la venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }


        void buscar()
        {
            // Obtener la cadena de conexión
            string connectionString = Conexion();

            // Crear una conexión a la base de datos
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Abrir la conexión
                    connection.Open();

                    // Crear un adaptador de datos y especificar el procedimiento almacenado
                    SqlDataAdapter da = new SqlDataAdapter("buscar", connection);
                    da.SelectCommand.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros al procedimiento almacenado
                    da.SelectCommand.Parameters.Add("@FechaVenta", SqlDbType.DateTime).Value = dateTimePicker1.Value;

                    // Crear un DataTable para almacenar los resultados
                    DataTable dt = new DataTable();

                    // Llenar el DataTable con los resultados de la consulta
                    da.Fill(dt);

                    // Asignar el DataTable al DataGridView
                    dgvVentas.DataSource = dt;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar ventas: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            buscar();
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {

                ActualizarDataGridView();


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Refresh();
        }

        private void dgvVentas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgvVentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void dgvVentas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dgvVentas.Rows[e.RowIndex];
                DateTime selectedDate = Convert.ToDateTime(selectedRow.Cells["Fecha de Venta"].Value.ToString());
                VentasDia ventasPorFechaForm = new VentasDia(selectedDate);
                ventasPorFechaForm.Show();
            }
        }
    }
}
