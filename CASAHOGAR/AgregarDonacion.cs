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
    public partial class AgregarDonacion : Form
    {
        public AgregarDonacion()
        {
            InitializeComponent();
        }

        private void btnSalirAgregarDonacion_Click(object sender, EventArgs e)
        {
            this.Close();
            Donaciones donaciones = new Donaciones();
            donaciones.Show();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxIdDonante.SelectedIndex;
            cbxNombreDonante.SelectedIndex = selectedIndex;
        }

        private void LlenarDonante()
        {
            DataTable data = new DataTable();
            CasaHogar datos = new CasaHogar();

            data = datos.ObtenerDonantes();

            foreach (DataRow row in data.Rows)
            {
                cbxIdDonante.Items.Add(row["idDonante"].ToString());
                cbxNombreDonante.Items.Add(row["nombre"].ToString());
            }
        }

        private void AgregarDonacion_Load(object sender, EventArgs e)
        {
            LlenarDonante();
        }

        private void cbxNombreDonante_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = cbxNombreDonante.SelectedIndex;
            cbxIdDonante.SelectedIndex = selectedIndex;
        }

        private void LimpiarControles()
        {
            cbxIdDonante.SelectedIndex = -1;
            cbxNombreDonante.SelectedIndex = -1;
            txtCantidadDonada.Clear();
            txtProductoDonado.Clear();
            dtpFechaDonacion.Value = DateTime.Today;
        }

        private void botones1_Click(object sender, EventArgs e)
        {
            Donaciones donaciones = new Donaciones();
            donaciones.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                // Obtener los valores seleccionados en los ComboBox
                int idDonante = Convert.ToInt32(cbxIdDonante.SelectedItem.ToString());
                string nombreDonante = cbxNombreDonante.SelectedItem.ToString();

                datos.AltaDonaciones(txtProductoDonado.Text, Convert.ToInt32(txtCantidadDonada.Text), dtpFechaDonacion.Value, idDonante, nombreDonante);

                MessageBox.Show("Donación agregada", "Informativo", MessageBoxButtons.OK);

                // Limpiar los controles después de actualizar el stock
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro de donación: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
