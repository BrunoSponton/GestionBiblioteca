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
    public class DatosPrestamos : DatosConexionBD
    {
        public int AbmPrestamos(string accion, Prestamo objPrestamo)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "INSERT INTO Prestamos (UsuarioID, LibroID, FechaPrestamo, FechaDevolucion) VALUES (@UsuarioID, @LibroID, @FechaPrestamo, @FechaDevolucion);";
            }
            else if (accion == "Modificar")
            {
                orden = "UPDATE Prestamos SET UsuarioID = @UsuarioID, LibroID = @LibroID, FechaPrestamo = @FechaPrestamo, FechaDevolucion = @FechaDevolucion WHERE PrestamoID = @PrestamoID;";
            }
            else if (accion == "Baja")
            {
                orden = "DELETE FROM Prestamos WHERE PrestamoID = @PrestamoID;";
            }

            using (SqlCommand cmd = new SqlCommand(orden, conexion))
            {
                // Agregar parámetros
                cmd.Parameters.AddWithValue("@UsuarioID", objPrestamo.UsuarioID);
                cmd.Parameters.AddWithValue("@LibroID", objPrestamo.LibroID);
                cmd.Parameters.AddWithValue("@FechaPrestamo", objPrestamo.FechaPrestamo);
                cmd.Parameters.AddWithValue("@FechaDevolucion", objPrestamo.FechaDevolucion);
                cmd.Parameters.AddWithValue("@PrestamoID", objPrestamo.PrestamoID);

                try
                {
                    AbrirConexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al tratar de guardar, borrar o modificar préstamos", e);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return resultado;
        }

        public DataSet ListadoPrestamos(string cual)
        {
            string orden = string.Empty;

            if (cual != "Todos")
                orden = "SELECT * FROM Prestamos WHERE PrestamoID = @PrestamoID;";
            else
                orden = "SELECT * FROM Prestamos;";

            using (SqlCommand cmd = new SqlCommand(orden, conexion))
            {
                if (cual != "Todos")
                    cmd.Parameters.AddWithValue("@PrestamoID", int.Parse(cual));

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                try
                {
                    AbrirConexion();
                    da.Fill(ds);
                }
                catch (Exception e)
                {
                    throw new Exception("Error al listar préstamos", e);
                }
                finally
                {
                    CerrarConexion();
                }

                return ds;
            }
        }
    }
}

