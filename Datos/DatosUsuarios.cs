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
    public class DatosUsuarios : DatosConexionBD
    {
        public int AbmUsuarios(string accion, Usuario objUsuario)
        {
            int resultado = -1;
            string orden = string.Empty;

            if (accion == "Alta")
            {
                orden = "INSERT INTO Usuarios (Nombre, Dni, Email, Direccion, PrestamoActivo) VALUES (@Nombre, @Dni, @Email, @Direccion, @PrestamoActivo);";
            }
            else if (accion == "Modificar")
            {
                orden = "UPDATE Usuarios SET Nombre = @Nombre, Dni = @Dni, Email = @Email, Direccion = @Direccion, PrestamoActivo = @PrestamoActivo WHERE UsuarioID = @UsuarioID;";
            }
            else if (accion == "Baja")
            {
                orden = "DELETE FROM Usuarios WHERE UsuarioID = @UsuarioID;";
            }

            using (SqlCommand cmd = new SqlCommand(orden, conexion))
            {
                // Agregar parámetros
                cmd.Parameters.AddWithValue("@Nombre", objUsuario.Nombre);
                cmd.Parameters.AddWithValue("@Dni", objUsuario.Dni);
                cmd.Parameters.AddWithValue("@Email", objUsuario.Email);
                cmd.Parameters.AddWithValue("@Direccion", objUsuario.Direccion);
                cmd.Parameters.AddWithValue("@PrestamoActivo", objUsuario.PrestamoActivo);
                cmd.Parameters.AddWithValue("@UsuarioID", objUsuario.UsuarioID);

                try
                {
                    AbrirConexion();
                    resultado = cmd.ExecuteNonQuery();
                }
                catch (Exception e)
                {
                    throw new Exception("Error al tratar de guardar, borrar o modificar usuarios", e);
                }
                finally
                {
                    CerrarConexion();
                }
            }
            return resultado;
        }

        public DataSet ListadoUsuarios(string dni)
        {
            string orden = "SELECT * FROM Usuarios WHERE DNI = @dni"; // Reemplaza 'Usuarios' y 'DNI' con los nombres correctos
            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@dni", dni); // Usar parámetros para evitar inyecciones SQL
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            try
            {
                AbrirConexion();
                da.Fill(ds);
            }
            catch (Exception e)
            {
                throw new Exception("Error al listar usuarios", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }
            return ds;
        }

        public Usuario ObtenerUsuarioPorID(int usuarioID)
        {
            string orden = "SELECT * FROM Usuarios WHERE UsuarioID = @UsuarioID;";
            SqlCommand cmd = new SqlCommand(orden, conexion);
            cmd.Parameters.AddWithValue("@UsuarioID", usuarioID);

            Usuario usuario = null;

            try
            {
                AbrirConexion();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        usuario = new Usuario
                        {
                            UsuarioID = Convert.ToInt32(reader["UsuarioID"]),
                            Nombre = reader["Nombre"].ToString(),
                            Dni = reader["Dni"].ToString(),
                            Email = reader["Email"].ToString(),
                            Direccion = reader["Direccion"].ToString(),
                            PrestamoActivo = Convert.ToBoolean(reader["PrestamoActivo"])
                        };
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception("Error al obtener el usuario por ID", e);
            }
            finally
            {
                CerrarConexion();
                cmd.Dispose();
            }

            return usuario;
        }

    }
}
