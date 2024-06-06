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
    public partial class AgregarEmpleados : Form
    {
        public AgregarEmpleados()
        {
            InitializeComponent();
        }

        private void LimpiarControles()
        {
            txtApellidoEmpleado.Clear();
            txtEmailEmpeado.Clear();
            txtHorarioLaboral.Clear();
            txtNombreEmpleado.Clear();
            txtPuestoTrabajo.Clear();
            txtTelefonoEmpleado.Clear();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                // Verificar que todos los campos estén llenos
                if (string.IsNullOrWhiteSpace(txtNombreEmpleado.Text))
                {
                    MessageBox.Show("Por favor, ingresa el nombre del empleado.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtApellidoEmpleado.Text))
                {
                    MessageBox.Show("Por favor, ingresa el apellido del empleado.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtTelefonoEmpleado.Text))
                {
                    MessageBox.Show("Por favor, ingresa el teléfono del empleado.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtHorarioLaboral.Text))
                {
                    MessageBox.Show("Por favor, ingresa el horario laboral del empleado.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (string.IsNullOrWhiteSpace(txtPuestoTrabajo.Text))
                {
                    MessageBox.Show("Por favor, ingresa el puesto de trabajo del empleado.", "Campo obligatorio", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Agregar el empleado
                datos.AltaEmpleados(txtNombreEmpleado.Text, txtApellidoEmpleado.Text, txtTelefonoEmpleado.Text,
                    txtEmailEmpeado.Text, txtHorarioLaboral.Text, txtPuestoTrabajo.Text);

                MessageBox.Show("Empleado agregado", "Informativo", MessageBoxButtons.OK);

                // Limpiar los controles después de agregar el empleado
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro de empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void botones1_Click(object sender, EventArgs e)
        {
            Empleados empleados = new Empleados();
            empleados.Show();
            this.Close();
        }
    }
}
