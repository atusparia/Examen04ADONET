using DAO2;
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

namespace Examen04ADONET
{
    public partial class AgregarProducto : Form
    {
        public AgregarProducto()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;
            SqlParameter parameter1 = null;
            SqlParameter parameter2 = null;
            SqlParameter parameter3 = null;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Constantes.cadenaConexion))
                {
                    conexion.Open();

                    command = new SqlCommand("USP_InsertarProducto", conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    parameter1 = new SqlParameter("@Nombre", SqlDbType.NVarChar,100);
                    parameter1.Value = txtNombre.Text;

                    parameter2 = new SqlParameter("@Precio", SqlDbType.Decimal);
                    parameter2.Value = Convert.ToDecimal(txtPrecio.Text);

                    parameter3 = new SqlParameter("@Stock", SqlDbType.Int);
                    parameter3.Value = Convert.ToInt32(txtStock.Text);

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);
                    command.Parameters.Add(parameter3);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Registro Exitoso");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command = null;
                parameter1 = null;
                parameter2 = null;
                parameter3 = null;
            }
        }
    }
}
