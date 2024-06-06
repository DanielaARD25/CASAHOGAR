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
    public partial class AgregarMobEquipo : Form
    {
        public AgregarMobEquipo()
        {
            InitializeComponent();
        }

        private void LimpiarControles()
        {
            txtEstadoMobiliario.Clear();
            txtNombreMobiliario.Clear();
            nupCantidadDisponible.Value = 0;
            rtxtDescripcion.Clear();
        }

        private void txtNombreMobiliario_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtCantidadDisponibleMobiliario_TextChanged(object sender, EventArgs e)
        {

        }

        private void rtxtDescripcion_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                // Verificar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(txtNombreMobiliario.Text))
                {
                    MessageBox.Show("Por favor, ingresa el nombre del mobiliario.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nupCantidadDisponible.Value <= 0)
                {
                    MessageBox.Show("Por favor, ingresa una cantidad disponible válida.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtEstadoMobiliario.Text))
                {
                    MessageBox.Show("Por favor, ingresa el estado del mobiliario.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Agregar el mobiliario
                datos.AltaMobiliarioEquipo(txtNombreMobiliario.Text, Convert.ToInt32(nupCantidadDisponible.Value), rtxtDescripcion.Text, txtEstadoMobiliario.Text);

                MessageBox.Show("Mobiliario agregado", "Informativo", MessageBoxButtons.OK);

                // Limpiar los controles
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro de mobiliario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            MobiliarioEquipo equipo = new MobiliarioEquipo();
            equipo.Show();
            this.Close();
        }
    }
}
