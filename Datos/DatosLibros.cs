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
                orden = "UPDATE Libros SET Autor = @Autor, Genero = @Genero, Stock = @Stock WHERE Titulo = @Titulo;";
            }
            else if (accion == "Baja")
            {
                orden = "DELETE FROM Libros WHERE Titulo = @Titulo;";
            }
            else
            {
                throw new ArgumentException($"Acción '{accion}' no válida. Use 'Alta', 'Modificar' o 'Baja'.");
            }

            if (string.IsNullOrEmpty(orden))
            {
                throw new InvalidOperationException("CommandText no ha sido inicializado correctamente.");
            }

            using (SqlCommand cmd = new SqlCommand(orden, conexion))
            {
                cmd.Parameters.AddWithValue("@Titulo", objLibro.Titulo);
                cmd.Parameters.AddWithValue("@Autor", objLibro.Autor);
                cmd.Parameters.AddWithValue("@Genero", objLibro.Genero);
                cmd.Parameters.AddWithValue("@Stock", objLibro.Stock);

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

        //METODO PARA PODER BUSCAR POR LOS CAMPOS: LibroID, Titulo, Autor y Genero
        public DataSet ListadoLibros(string cual)
        {
            string orden = string.Empty;

            // Si la búsqueda es por ID de libro
            if (int.TryParse(cual, out int libroID))
            {
                // Buscar por LibroID específico
                orden = "SELECT * FROM Libros WHERE LibroID = @LibroID;";
            }
            else if (cual.ToLower() != "todos")
            {
                // Buscar por coincidencias en Titulo, Autor o Genero
                orden = "SELECT * FROM Libros WHERE Titulo LIKE @criterio OR Autor LIKE @criterio OR Genero LIKE @criterio;";
            }
            else
            {
                // Si es "Todos", traer todos los libros
                orden = "SELECT * FROM Libros;";
            }

            using (SqlCommand cmd = new SqlCommand(orden, conexion))
            {
                if (int.TryParse(cual, out libroID))
                {
                    // Si es un ID, se agrega el parámetro LibroID
                    cmd.Parameters.AddWithValue("@LibroID", libroID);
                }
                else if (cual.ToLower() != "todos")
                {
                    // Si no es "Todos", agregar el parámetro de búsqueda
                    cmd.Parameters.AddWithValue("@criterio", "%" + cual + "%");
                }

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

        // Método para obtener los libros por ID (sin necesidad de nueva conexión)
        public DataSet ListadoLibrosPorId(int libroId)
        {
            try
            {
                // Crear una consulta SQL para obtener el libro por ID
                string consulta = "SELECT * FROM Libros WHERE LibroID = @LibroID"; // Asegúrate de que el nombre de la tabla y la columna coincidan

                // Usar la conexión proporcionada por DatosLibros
                SqlCommand cmd = new SqlCommand(consulta, conexion);
                cmd.Parameters.AddWithValue("@LibroID", libroId);

                // Ejecutar la consulta y llenar el DataSet
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                return ds;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar el libro por ID: " + ex.Message);
            }
        }

    }
}

