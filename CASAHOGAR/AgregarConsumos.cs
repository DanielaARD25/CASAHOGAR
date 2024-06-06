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
        private Dictionary<string, string> nombreToUnidadMedida;
        public AgregarConsumos()
        {
            InitializeComponent();
            nombreToUnidadMedida = new Dictionary<string, string>();

            // Asignar el evento
            cbxNombreInsumo.SelectedIndexChanged += new EventHandler(cbxNombreInsumo_SelectedIndexChanged);
        }

        private void cbxNombreInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxNombreInsumo.SelectedIndex;
            if (selectedIndex >= 0)
            {
                cbxIdInsumo.SelectedIndex = selectedIndex;

                string nombreInsumo = cbxNombreInsumo.SelectedItem.ToString();

                if (nombreToUnidadMedida.TryGetValue(nombreInsumo, out string unidadMedida))
                {
                    txtUnidadMedidaInsumo.Text = unidadMedida;
                }
            }
        }

        private void LlenarInsumo()
        {
            DataTable data = new DataTable();
            CasaHogar datos = new CasaHogar();

            data = datos.ObtenerInsumos();

            foreach (DataRow row in data.Rows)
            {
                string nombreInsumo = row["nombreInsumo"].ToString();
                string idInsumo = row["idInsumo"].ToString();
                string unidadMedida = row["unidadMedida"].ToString();

                cbxNombreInsumo.Items.Add(nombreInsumo);
                cbxIdInsumo.Items.Add(idInsumo);
                nombreToUnidadMedida[nombreInsumo] = unidadMedida;
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
            if (selectedIndex >= 0)
            {
                cbxNombreInsumo.SelectedIndex = selectedIndex;

                // Obtener el ID del insumo seleccionado
                int idInsumo = Convert.ToInt32(cbxIdInsumo.SelectedItem);

                // Obtener la cantidad disponible asociada al ID del insumo
                string cantidades = ObtenerCantidades(idInsumo);

                // Mostrar la cantidad disponible en lblCantidadDisponible
                lblCantidadDisponible.Text = cantidades;

                // Obtener el nombre del insumo seleccionado
                string nombreInsumo = cbxNombreInsumo.SelectedItem.ToString();

                // Obtener la unidad de medida del insumo seleccionado
                if (nombreToUnidadMedida.TryGetValue(nombreInsumo, out string unidadMedida))
                {
                    txtUnidadMedidaInsumo.Text = unidadMedida;
                }
            }
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
                // Verificar que todos los campos estén llenos
                if (cbxIdInsumo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un ID de insumo.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (cbxNombreInsumo.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona un nombre de insumo.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtCantidadConsumida.Text))
                {
                    MessageBox.Show("Por favor, ingresa la cantidad consumida.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUnidadMedidaInsumo.Text))
                {
                    MessageBox.Show("Por favor, ingresa la unidad de medida.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

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
