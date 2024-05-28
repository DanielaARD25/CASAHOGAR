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
    public partial class AgregarConsumos : Form
    {
        private Dictionary<int, List<int>> cantidadesDisponibles = new Dictionary<int, List<int>>();
        public AgregarConsumos()
        {
            InitializeComponent();
        }

        private void cbxNombreInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            int selectedIndex = cbxNombreInsumo.SelectedIndex;
            cbxIdInsumo.SelectedIndex = selectedIndex;

            string nombreInsumo = cbxNombreInsumo.SelectedItem.ToString();

            string unidadMedida = datos.ObtenerUnidadMedidaPorNombre(nombreInsumo);
            txtUnidadMedidaInsumo.Text = unidadMedida;
        }

        private void LlenarInsumo()
        {
            DataTable data = new DataTable();
            CasaHogar datos = new CasaHogar();

            data = datos.ObtenerInsumos();

            foreach (DataRow row in data.Rows)
            {
                cbxNombreInsumo.Items.Add(row["nombreInsumo"].ToString());
                cbxIdInsumo.Items.Add(row["idInsumo"].ToString());
            }
        }

        private void AgregarConsumos_Load(object sender, EventArgs e)
        {
            LlenarInsumo();
            LlenarCantidades();
            cbxIdInsumo.KeyPress += cbxIdInsumo_KeyPress;
        }

        private void cbxIdInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            int selectedIndex = cbxIdInsumo.SelectedIndex;
            cbxNombreInsumo.SelectedIndex = selectedIndex;

            // Obtener el ID del insumo seleccionado
            int idInsumo = Convert.ToInt32(cbxIdInsumo.SelectedItem);

            // Obtener la cantidad disponible asociada al ID del insumo
            string cantidades = ObtenerCantidades(idInsumo);

            // Mostrar la cantidad disponible en txtCantidadDisponibleInsumo
            lblCantidadDisponible.Text = cantidades;

            string unidadMedida = datos.ObtenerUnidadMedida(idInsumo);
            txtUnidadMedidaInsumo.Text = unidadMedida;
        }

        private string ObtenerCantidades(int idInsumo)
        {
            if (cantidadesDisponibles.ContainsKey(idInsumo))
            {
                List<int> codigosPostales = cantidadesDisponibles[idInsumo];
                return string.Join(",", codigosPostales);
            }
            else
            {
                return string.Empty;
            }
        }

        private void LlenarCantidades()
        {
            try
            {
                DataTable data = new DataTable();
                CasaHogar datos = new CasaHogar();

                data = datos.ObtenerCantidad();

                cantidadesDisponibles.Clear(); // Limpiar el diccionario antes de llenarlo

                foreach (DataRow row in data.Rows)
                {
                    int idInsumo = Convert.ToInt32(row["idInsumo"]);
                    int cantidad = Convert.ToInt32(row["cantidadDisponible"]);

                    if (cantidadesDisponibles.ContainsKey(idInsumo))
                    {
                        cantidadesDisponibles[idInsumo].Add(cantidad);
                    }
                    else
                    {
                        List<int> cantidades = new List<int>();
                        cantidades.Add(cantidad);
                        cantidadesDisponibles.Add(idInsumo, cantidades);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener las cantidades: " + ex.Message);
            }
        }

        private void LimpiarControles()
        {
            cbxIdInsumo.SelectedIndex = -1;
            cbxNombreInsumo.SelectedIndex = -1;
            txtUnidadMedidaInsumo.Clear();
            lblCantidadDisponible.Text = "";
            txtCantidadConsumida.Clear();

        }


        private void txtCantidadDisponibleInsumo_TextChanged(object sender, EventArgs e)
        {

        }


        private void btnSalir_Click(object sender, EventArgs e)
        {
            Consumos consumos = new Consumos();
            consumos.Show();
            this.Close();
        }

        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                // Obtener los valores seleccionados en los ComboBox
                int idInsumo = Convert.ToInt32(cbxIdInsumo.SelectedItem);
                string insumo = cbxNombreInsumo.SelectedItem.ToString();

                datos.AltaConsumos(idInsumo, insumo, Convert.ToDecimal(txtCantidadConsumida.Text), Convert.ToDecimal(lblCantidadDisponible.Text), txtUnidadMedidaInsumo.Text);

                MessageBox.Show("Consumo agregado", "Informativo", MessageBoxButtons.OK);

                // Limpiar los controles después de actualizar el stock
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro de consumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtCantidadDisponibleInsumo_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void cbxIdInsumo_Enter(object sender, EventArgs e)
        {
        }

        private void cbxIdInsumo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                VerificarValorEnComboBox();
                // Esto evita que el "ding" suene cuando se presiona Enter
                e.Handled = true;
            }
        }

        private void VerificarValorEnComboBox()
        {
            bool itemEncontrado = false;

            foreach (var item in cbxIdInsumo.Items)
            {
                if (item.ToString() == cbxIdInsumo.Text)
                {
                    itemEncontrado = true;
                    break;
                }
            }

            if (!itemEncontrado)
            {
                MessageBox.Show("El id de Insumo no existe, intenta otro");
                // Puedes opcionalmente limpiar el texto o seleccionar el primer ítem, por ejemplo:
                cbxIdInsumo.Text = string.Empty;
            }
        }

        private void txtUnidadMedidaInsumo_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
