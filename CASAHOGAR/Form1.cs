using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CASAHOGAR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnIngresar2_Click(object sender, EventArgs e)
        {
            ////Mostrar el formulario principal
            //FormularioPrincipal principal = new FormularioPrincipal();
            //principal.Show();
            //this.Hide();


            //Validar que los campos de usuario y contraseña no estén vacíos
            if (string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtContrasena.Text))
            {
                MessageBox.Show("Por favor, ingresa un usuario y una contraseña", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Salir del método si los campos están vacíos
            }

            //Obtener el usuario ingresado por el usuario desde el TextBox correspondiente
            string usuarioIngresado = txtUsuario.Text;
            string contraseñaIngresada = txtContrasena.Text;

            //Utilizar la cadena de conexión proporcionada
            string connectionString = @"Data Source=THE-MARAUDERS-M\TBD_DARD_23;Initial Catalog=CASAHOGAR;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    //Consulta para obtener el usuario y la contraseña correspondientes al usuario ingresado
                    string query = "SELECT contraseñaUsuario FROM Usuarios WHERE NombreUsuario = @NombreUsuario";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@NombreUsuario", usuarioIngresado);

                    //Ejecutar la consulta
                    string contraseñaEnDB = command.ExecuteScalar() as string;

                    if (contraseñaEnDB != null && contraseñaEnDB.Equals(contraseñaIngresada))
                    { 
                        FormularioPrincipal formularioPrincipal = new FormularioPrincipal();
                        formularioPrincipal.Show();
                        this.Hide();
                    }
                    else
                    {
                        //Si las credenciales no son válidas, muestra un mensaje de error.
                        MessageBox.Show("Usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    //Maneja cualquier error de conexión o consulta
                    MessageBox.Show("Error al conectar con la base de datos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
