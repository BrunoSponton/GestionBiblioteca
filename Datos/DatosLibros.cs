using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class DatosLibros : DatosConexionBD
    {
        public int AbmLibros(string accion, Libro objLibro)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "INSERT INTO Libros (Titulo, Autor, Genero, Stock) VALUES (@Titulo, @Autor, @Genero, @Stock);";
            }
            else if (accion == "Modificar")
            {
                orden = "UPDATE Libros SET Titulo = @Titulo, Autor = @Autor, Genero = @Genero, Stock = @Stock WHERE LibroID = @LibroID;";
            }
            else if (accion == "Baja")
            {
                orden = "DELETE FROM Libros WHERE LibroID = @LibroID;";
            }

            using (SqlCommand cmd = new SqlCommand(orden, conexion))
            {
                // Agregar parámetros
                cmd.Parameters.AddWithValue("@Titulo", objLibro.Titulo);
                cmd.Parameters.AddWithValue("@Autor", objLibro.Autor);
                cmd.Parameters.AddWithValue("@Genero", objLibro.Genero);
                cmd.Parameters.AddWithValue("@Stock", objLibro.Stock);
                cmd.Parameters.AddWithValue("@LibroID", objLibro.LibroID);

                try
                {
                    AbrirConexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al tratar de guardar, borrar o modificar libros", e);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return resultado;
        }

        public DataSet ListadoLibros(string cual)
        {
            string orden = string.Empty;

            if (cual != "Todos")
                orden = "SELECT * FROM Libros WHERE LibroID = @LibroID;";
            else
                orden = "SELECT * FROM Libros;";

            using (SqlCommand cmd = new SqlCommand(orden, conexion))
            {
                if (cual != "Todos")
                    cmd.Parameters.AddWithValue("@LibroID", int.Parse(cual));

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    AbrirConexion();
                    da.Fill(ds);
                }
                catch (Exception e)
                {
                    throw new Exception("Error al listar libros", e);
                }
                finally
                {
                    CerrarConexion();
                }

                return ds;
            }
        }

        //FUNCIONA PARA ACTUALIZAR EL STOCK UNA VEZ QUE FUE RESTADO -1 AL REALIZAR EL PRESTAMO
        public bool ActualizarStock(int libroID, int cantidad)
        {
            string consulta = "UPDATE Libros SET Stock = Stock + @Cantidad WHERE LibroID = @LibroID";

            using (SqlConnection conexion = new SqlConnection("server=BRUNO\\SQLEXPRESS; database=BIBLIOTECA; integrated security=true")) // Usar using para la conexión
            {
                try
                {
                    conexion.Open();

                    using (SqlCommand cmd = new SqlCommand(consulta, conexion))
                    {
                        cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                        cmd.Parameters.AddWithValue("@LibroID", libroID);
                        int filasAfectadas = cmd.ExecuteNonQuery();
                        return filasAfectadas > 0; // Retorna verdadero si se actualizó el stock
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al actualizar el stock: " + ex.Message);
                }
            }
        }
    }
}

