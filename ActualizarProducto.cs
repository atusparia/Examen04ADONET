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
    public partial class ActualizarProducto : Form
    {
        public ActualizarProducto()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            SqlCommand command = null;
            SqlParameter parameter1 = null;
            SqlParameter parameter2 = null;
            SqlParameter parameter3 = null;
            SqlParameter parameter4 = null;

            try
            {
                using (SqlConnection conexion = new SqlConnection(Constantes.cadenaConexion))
                {
                    conexion.Open();

                    command = new SqlCommand("USP_ActualizarProducto", conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    parameter1 = new SqlParameter("@IdProducto", SqlDbType.Int);
                    parameter1.Value = Convert.ToInt32(txtIdProducto.Text);

                    parameter2 = new SqlParameter("@Nombre", SqlDbType.NVarChar, 100);
                    parameter2.Value = txtNombre.Text;

                    parameter3 = new SqlParameter("@Precio", SqlDbType.Decimal);
                    parameter3.Value = Convert.ToDecimal(txtPrecio.Text);

                    parameter4 = new SqlParameter("@Stock", SqlDbType.Int);
                    parameter4.Value = Convert.ToInt32(txtStock.Text);

                    command.Parameters.Add(parameter1);
                    command.Parameters.Add(parameter2);
                    command.Parameters.Add(parameter3);
                    command.Parameters.Add(parameter4);

                    command.ExecuteNonQuery();

                    MessageBox.Show("Actualización Exitosa");
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
                parameter2 = null;
                parameter3 = null;
                parameter4 = null;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
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

                    command = new SqlCommand("USP_BuscarProductoPorId", conexion);
                    command.CommandType = CommandType.StoredProcedure;

                    parameter1 = new SqlParameter("@IdProducto", SqlDbType.Int);
                    parameter1.Value = Convert.ToInt32(txtIdProducto.Text);

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
                            Stock = Convert.ToString(reader["Stock"])                            
                        });
                    }
                                        
                    txtNombre.Text = productos[0].Nombre;
                    txtPrecio.Text = productos[0].Precio;
                    txtStock.Text = productos[0].Stock;
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
                productos = null;
            }
        }
    }
}
