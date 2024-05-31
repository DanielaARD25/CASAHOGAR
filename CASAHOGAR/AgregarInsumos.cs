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
