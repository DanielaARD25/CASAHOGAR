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
    public partial class AgregarDonantes : Form
    {
        public AgregarDonantes()
        {
            InitializeComponent();
        }

        private void LimpiarControles()
        {
            txtNombreDonante.Clear();
            txtApellidoDonante.Clear();
            txtTelefonoDonante.Clear();
            txtEmailDonante.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                datos.AltaDonantes(txtNombreDonante.Text, txtApellidoDonante.Text, txtTelefonoDonante.Text, txtEmailDonante.Text);
                MessageBox.Show("Donante agregado", "Informativo", MessageBoxButtons.OK);

                // Limpiar los controles después de actualizar el stock
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro de donante: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botones1_Click(object sender, EventArgs e)
        {
            Donantes donantes = new Donantes();
            donantes.Show();
            this.Close();
        }
    }
}
