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
    public partial class AgregarProductos : Form
    {
        public AgregarProductos()
        {
            InitializeComponent();
        }



        private void LimpiarControles()
        {
            nupPrecio.Value = 0;

        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            CasaHogar datos = new CasaHogar();
            try
            {
                // Verificar si el campo de texto contiene un valor válido
                if (!int.TryParse(nupPrecio.Text, out int precio) || precio <= 0)
                {
                    MessageBox.Show("Por favor, ingresa un precio unitario válido.", "Valor inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Agregar el precio del producto
                datos.AltaProductos(precio);

                MessageBox.Show("Precio agregado", "Informativo", MessageBoxButtons.OK);

                // Limpiar los controles
                LimpiarControles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al agregar el registro de precio: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            productos.Show();
            this.Close();
        }
    }
}
