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
    public partial class AgregarUsuarios : Form
    {
        public AgregarUsuarios()
        {
            InitializeComponent();
        }

        private void LimpiarControles()
        {
            txtNombreUsuario.Clear();
            txtConttrasenaUsuario.Clear();
            cbxEsAdministrador.Checked = false;
        }

        private void botones1_Click(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Show();
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                datos.AltaUsuarios(txtNombreUsuario.Text, txtConttrasenaUsuario.Text, cbxEsAdministrador.Checked);

                MessageBox.Show("Usuario agregado", "Informativo", MessageBoxButtons.OK);

                // Limpiar los controles
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro de usuario: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
