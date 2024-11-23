using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen04ADONET
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void btnAgregarProducto_Click(object sender, EventArgs e)
        {
            AgregarProducto agregarProducto = new AgregarProducto();
            agregarProducto.ShowDialog();
        }

        private void btnConsultarProducto_Click(object sender, EventArgs e)
        {
            ConsultarProducto consultarProducto = new ConsultarProducto();
            consultarProducto.ShowDialog();
        }

        private void btnActualizarProducto_Click(object sender, EventArgs e)
        {
            ActualizarProducto actualizarProducto = new ActualizarProducto();
            actualizarProducto.ShowDialog();
        }

        private void btnEliminarProducto_Click(object sender, EventArgs e)
        {
            EliminarProducto eliminarProducto = new EliminarProducto();
            eliminarProducto.ShowDialog();
        }
    }
}
