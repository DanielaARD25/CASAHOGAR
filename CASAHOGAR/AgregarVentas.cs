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
        Ventas ventas = new Ventas();
        VentasDia ventasDia;
        //private DateTime fechaSeleccionada;
        public AgregarVentas()
        {
            InitializeComponent();
        }


        private void LimpiarControles()
        {
            cbxIdPrecio.SelectedIndex = -1;
            cbxPrecio.SelectedIndex = -1;
            rtxtDescripcion.Clear();
            txtCantidadVentaProducto.Clear();
            dtpFechaVenta.Value = DateTime.Now;
        }

        private void cbxIdProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxIdPrecio.SelectedIndex;
            cbxPrecio.SelectedIndex = selectedIndex;
        }

        private void LlenarPrecios()
        {
            DataTable data = new DataTable();
            CasaHogar datos = new CasaHogar();

            data = datos.ObtenerPrecio();

            foreach (DataRow row in data.Rows)
            {
                cbxIdPrecio.Items.Add(row["idPrecio"].ToString());
                cbxPrecio.Items.Add(row["precioUnitarioProducto"].ToString());
            }
        }
        private void cbxNombreProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxPrecio.SelectedIndex;
            cbxIdPrecio.SelectedIndex = selectedIndex;
        }

        private void AgregarVentas_Load(object sender, EventArgs e)
        {
            LlenarPrecios();
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
                    int idPrecio= Convert.ToInt32(item.SubItems[0].Text);
                    int precio = Convert.ToInt32(item.SubItems[1].Text);
                    string descripcion = item.SubItems[2].Text;
                    int cantidad = Convert.ToInt32(item.SubItems[3].Text);
                    decimal totalCantidadProductos = Convert.ToDecimal(item.SubItems[4].Text);
                    DateTime fechaCompra = Convert.ToDateTime(item.SubItems[5].Text);

                    datos.AltaVentas(idPrecio, descripcion, cantidad, totalCantidadProductos, fechaCompra);
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


        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if(cbxIdPrecio.SelectedIndex == -1 && cbxPrecio.SelectedIndex == -1)
            {
                MessageBox.Show("Debe ingresar un precio.");
            }

            if (txtCantidadVentaProducto.Text == "" && txtCantidadVentaProducto.Text == " ")
            {
                MessageBox.Show("Debe ingresar una cantidad.");
            }

            else
            {
                int idPrecio = Convert.ToInt32(cbxIdPrecio.Text);
                int precio = Convert.ToInt32(cbxPrecio.Text);
                string descripcion = rtxtDescripcion.Text;
                int cantidad = Convert.ToInt32(txtCantidadVentaProducto.Text);
                DateTime fechaCompra = dtpFechaVenta.Value;

                //Calculos del total de productos y cantidad
                decimal totalCantidadProductos = cantidad * precio;

                ListViewItem fila = new ListViewItem(idPrecio.ToString());
                fila.SubItems.Add(precio.ToString());
                fila.SubItems.Add(descripcion.ToString());
                fila.SubItems.Add(Convert.ToString(cantidad));
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
