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
    public partial class EliminarProducto : Form
    {
        public EliminarProducto()
        {
            InitializeComponent();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;
            SqlParameter parameter1 = null;
            
            try
            {
                using (SqlConnection conexion = new SqlConnection(Constantes.cadenaConexion))
                {
                    conexion.Open();

                    command = new SqlCommand("USP_EliminarProducto", conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    parameter1 = new SqlParameter("@IdProducto", SqlDbType.Int);
                    parameter1.Value = Convert.ToInt32(txtIdProducto.Text);
                                        
                    command.Parameters.Add(parameter1);
                    
                    command.ExecuteNonQuery();

                    MessageBox.Show("Eliminación Exitosa");
                }
            }
            catch (Exception ex)
            {
                //throw ex;
                MessageBox.Show("Error, comunicarse con el Administrador");
            }
            finally
            {
                command = null;
                parameter1 = null;                
            }
        }
    }
}
