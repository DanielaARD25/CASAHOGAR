using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASAHOGAR
{
    public partial class AgregarVentas : Form
    {
        private Dictionary<int, List<decimal>> preciosUnitarios = new Dictionary<int, List<decimal>>();
        Ventas ventas = new Ventas();
        VentasDia ventasDia;
        //private DateTime fechaSeleccionada;
        public AgregarVentas()
        {
            InitializeComponent();
        }


        private void LimpiarControles()
        {
            cbxIdProducto.SelectedIndex = -1;
            cbxNombreProducto.SelectedIndex = -1;
            txtCantidadVentaProducto.Clear();
            lblPrecio.Text = "";
            dtpFechaVenta.Value = DateTime.Now;
        }

        private void LlenarProductos()
        {
            DataTable data = new DataTable();
            CasaHogar datos = new CasaHogar();

            data = datos.ObtenerProductos();

            foreach (DataRow row in data.Rows)
            {
                cbxNombreProducto.Items.Add(row["nombreProducto"].ToString());
                cbxIdProducto.Items.Add(row["idProducto"].ToString());
            }
        }

        private void cbxIdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxIdProducto.SelectedIndex;
            cbxNombreProducto.SelectedIndex = selectedIndex;

            // Obtener el ID del insumo seleccionado
            int idProducto = Convert.ToInt32(cbxIdProducto.SelectedItem);

            // Obtener la cantidad disponible asociada al ID del insumo
            string precios = ObtenerPreciosUnitarios(idProducto);

            // Mostrar la cantidad disponible en txtCantidadDisponibleInsumo
            lblPrecio.Text = precios;
        }

        private void cbxNombreProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxNombreProducto.SelectedIndex;
            cbxIdProducto.SelectedIndex = selectedIndex;
        }

        private void AgregarVentas_Load(object sender, EventArgs e)
        {
            LlenarProductos();

            LlenarPrecio();

            lblPrecio.Text = "$" + (0).ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                DateTime fechaSeleccionada = dtpFechaVenta.Value;
                ventasDia = new VentasDia(fechaSeleccionada);
                foreach (ListViewItem item in lvRegistroVentas.Items)
                {
                    int idProducto = Convert.ToInt32(item.SubItems[0].Text);
                    string producto = item.SubItems[1].Text;
                    int cantidad = Convert.ToInt32(item.SubItems[2].Text);
                    decimal precio = Convert.ToDecimal(item.SubItems[3].Text);
                    decimal totalCantidadProductos = Convert.ToDecimal(item.SubItems[4].Text);
                    DateTime fechaCompra = Convert.ToDateTime(item.SubItems[5].Text);

                    datos.AltaVentas(idProducto, producto, cantidad, totalCantidadProductos, fechaCompra);
                    //fechaSeleccionada = fechaCompra.Date;
                    ventasDia.ActualizarDataGridView();
                    ventas.ActualizarDataGridView();


                }
                
                // Limpiar los controles y el ListView después de agregar a la base de datos
                LimpiarControles();
                lvRegistroVentas.Items.Clear();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar los registros de venta: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            // Verificar si el formulario de ventas ya está abierto
            bool formularioVentasAbierto = false;
            foreach (Form formularioAbierto in Application.OpenForms)
            {
                if (formularioAbierto is Ventas)
                {
                    formularioVentasAbierto = true;
                    break;
                }
            }

            // Si el formulario de ventas ya está abierto, cerrar este formulario
            if (formularioVentasAbierto)
            {
                this.Close();
            }
            else // Si el formulario de ventas no está abierto, abrirlo y luego cerrar este formulario
            {
                Ventas ventas = new Ventas();
                ventas.Show();
                this.Close();
            }
        }

        private void LlenarPrecio()
        {
            try
            {
                DataTable data = new DataTable();
                CasaHogar datos = new CasaHogar();

                data = datos.ObtenerPrecio();

                preciosUnitarios.Clear(); // Limpiar el diccionario antes de llenarlo

                foreach (DataRow row in data.Rows)
                {
                    int idProducto = Convert.ToInt32(row["idProducto"]);
                    int precio = Convert.ToInt32(row["precioUnitarioProducto"]);

                    if (preciosUnitarios.ContainsKey(idProducto))
                    {
                        preciosUnitarios[idProducto].Add(precio);
                    }
                    else
                    {
                        List<decimal> precios = new List<decimal>();
                        precios.Add(precio);
                        preciosUnitarios.Add(idProducto, precios);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las precios: " + ex.Message);
            }
        }

        private string ObtenerPreciosUnitarios(int precio)
        {
            if (preciosUnitarios.ContainsKey(precio))
            {
                List<decimal> PreciosU = preciosUnitarios[precio];
                return string.Join(",", PreciosU);
            }
            else
            {
                return string.Empty;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(cbxIdProducto.SelectedIndex == -1 && cbxNombreProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar un producto.");
            }

            if (txtCantidadVentaProducto.Text == "" && txtCantidadVentaProducto.Text == " ")
            {
                MessageBox.Show("Debe ingresar una cantidad.");
            }

            else
            {
                int idProducto = Convert.ToInt32(cbxIdProducto.Text);
                string nombreProducto = cbxNombreProducto.Text;
                int cantidad = Convert.ToInt32(txtCantidadVentaProducto.Text);
                decimal precio = Convert.ToDecimal(lblPrecio.Text);
                DateTime fechaCompra = dtpFechaVenta.Value;

                //Calculos del total de productos y cantidad
                decimal totalCantidadProductos = cantidad * precio;

                ListViewItem fila = new ListViewItem(idProducto.ToString());
                fila.SubItems.Add(nombreProducto.ToString());
                fila.SubItems.Add(Convert.ToString(cantidad));
                fila.SubItems.Add(Convert.ToString(precio));
                fila.SubItems.Add(Convert.ToString(totalCantidadProductos));
                fila.SubItems.Add(Convert.ToString(fechaCompra));

                lvRegistroVentas.Items.Add(fila);
                LimpiarControles();
                //btnCancelar_Click(sender, e);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Verificar si hay elementos en el ListView
            if (lvRegistroVentas.Items.Count > 0)
            {
                // Eliminar el último elemento del ListView
                lvRegistroVentas.Items.RemoveAt(lvRegistroVentas.Items.Count - 1);
            }
            else
            {
                MessageBox.Show("No hay registros para eliminar.", "Informativo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Limpiar los controles
            LimpiarControles();
        }
    }
}
