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
            txtTelefonoDonante.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                // Verificar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(txtNombreDonante.Text))
                {
                    MessageBox.Show("Por favor, ingresa el nombre del donante.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefonoDonante.Text))
                {
                    MessageBox.Show("Por favor, ingresa el teléfono del donante.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Agregar el donante
                datos.AltaDonantes(txtNombreDonante.Text, txtTelefonoDonante.Text);
                MessageBox.Show("Donante agregado", "Informativo", MessageBoxButtons.OK);

                // Limpiar los controles después de agregar el donante
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
