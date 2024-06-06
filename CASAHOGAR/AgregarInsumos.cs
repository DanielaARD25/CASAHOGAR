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
    public partial class AgregarInsumos : Form
    {
        public AgregarInsumos()
        {
            InitializeComponent();
        }
        private void LimpiarControles()
        {
            txtNombreInsumo.Clear();
            txtUnidadMedidaInsumo.Clear();
            rtxtDescripciónInsumo.Clear();
            nupCantidadDisponible.Value = 0;
            nupCantidadMinima.Value = 0;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                // Verificar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(txtNombreInsumo.Text))
                {
                    MessageBox.Show("Por favor, ingresa el nombre del insumo.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nupCantidadDisponible.Value <= 0)
                {
                    MessageBox.Show("Por favor, ingresa una cantidad disponible válida.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (nupCantidadMinima.Value <= 0)
                {
                    MessageBox.Show("Por favor, ingresa una cantidad mínima válida.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtUnidadMedidaInsumo.Text))
                {
                    MessageBox.Show("Por favor, ingresa la unidad de medida del insumo.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Agregar el insumo
                datos.AltaInsumos(txtNombreInsumo.Text, nupCantidadDisponible.Value, nupCantidadMinima.Value, txtUnidadMedidaInsumo.Text, rtxtDescripciónInsumo.Text);

                MessageBox.Show("Insumo agregado", "Informativo", MessageBoxButtons.OK);

                // Limpiar los controles
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro de insumo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Insumos insumos = new Insumos();
            insumos.Show();
            this.Close();
        }
    }
}
