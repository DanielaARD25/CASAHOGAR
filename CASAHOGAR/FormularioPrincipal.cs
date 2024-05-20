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
    public partial class FormularioPrincipal : Form
    {
        public FormularioPrincipal()
        {
            InitializeComponent();
        }

        private void FormularioPrincipal_Load(object sender, EventArgs e)
        {

        }
        private void botones1_Click(object sender, EventArgs e)
        {
            Donantes donantes = new Donantes();
            donantes.Show();
            this.Hide();
        }

        private void btnDonaciones_Click_1(object sender, EventArgs e)
        {
            Donaciones donacions = new Donaciones();
            donacions.Show();
            this.Hide();
        }

        private void btnVentas_Click_1(object sender, EventArgs e)
        {
            Ventas ventas = new Ventas();
            ventas.Show();
            this.Hide();
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            Productos productos = new Productos();
            productos.Show();
            this.Hide();
        }

        private void btnEmpleados_Click_1(object sender, EventArgs e)
        {
            Empleados empleados = new Empleados();
            empleados.Show();
            this.Hide();
        }

        private void btnMobiliario_Click(object sender, EventArgs e)
        {
            MobiliarioEquipo mobiliarioEquipo = new MobiliarioEquipo();
            mobiliarioEquipo.Show();
            this.Hide();
        }

        private void btnConsumos_Click_1(object sender, EventArgs e)
        {
            Consumos consumos = new Consumos();
            consumos.Show();
            this.Hide();
        }

        private void btnInsumos_Click_1(object sender, EventArgs e)
        {
            Insumos insumos = new Insumos();
            insumos.Show();
            this.Hide();
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            Usuarios usuarios = new Usuarios();
            usuarios.Show();
            this.Hide();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

            this.Close();

            Form1 form = new Form1();
            form.Show();
        }
    }
}
