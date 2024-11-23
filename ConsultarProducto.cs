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
    public partial class ConsultarProducto : Form
    {
        public ConsultarProducto()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;
            SqlParameter parameter1 = null;            
            List<Producto> productos = null;

            try
            {
                productos = new List<Producto>();

                using (SqlConnection conexion = new SqlConnection(Constantes.cadenaConexion))
                {
                    conexion.Open();

                    command = new SqlCommand("USP_BuscarProducto", conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    parameter1 = new SqlParameter("@Nombre", SqlDbType.NVarChar, 100);
                    parameter1.Value = txtNombre.Text;

                    command.Parameters.Add(parameter1);                    

                    SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = reader["IdProducto"].ToString(),
                            Nombre = Convert.ToString(reader["Nombre"]),
                            Precio = Convert.ToString(reader["Precio"]),
                            Stock = Convert.ToString(reader["Stock"]),
                            FechaCreacion = Convert.ToString(reader["FechaCreacion"]),
                            Eliminado = Convert.ToString(reader["Eliminado"]),
                        });
                    }

                    dgvProductos.DataSource = productos;
                }
            }
            catch (Exception ex)
            {
                throw ex;
                //MessageBox.Show("Error, comunicarse con el Administrador");
            }
            finally
            {
                command = null;
                parameter1 = null;                
                productos = null;
            }
        }
    }
}
