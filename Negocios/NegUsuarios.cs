using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Datos;
using Entidades;

namespace Negocios
{
    public class NegUsuarios
    {
        private DatosUsuarios objDatosUsuarios = new DatosUsuarios();

        public int AbmUsuarios(string accion, Usuario objUsuario)
        {
            return objDatosUsuarios.AbmUsuarios(accion, objUsuario);
        }

        public DataSet ListadoUsuarios(string cual)
        {
            return objDatosUsuarios.ListadoUsuarios(cual);
        }

        public int ObtenerUsuarioIDPorDNI(string dni)
        {
            DataSet ds = ListadoUsuarios(dni);
            if (ds.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(ds.Tables[0].Rows[0]["UsuarioID"]);
            }
            return -1; // Usuario no encontrado
        }
        public Usuario ObtenerUsuarioPorID(int usuarioID)
        {
            return objDatosUsuarios.ObtenerUsuarioPorID(usuarioID);
        }

        // Nuevo método para actualizar el estado de préstamo activo de un usuario
        public int ActualizarPrestamoActivo(int usuarioID, bool prestamoActivo)
        {
            return objDatosUsuarios.ActualizarPrestamoActivo(usuarioID, prestamoActivo);
        }

        public DataSet ObtenerUsuarioConPrestamoActivo(int usuarioID)
        {
            return objDatosUsuarios.ObtenerUsuarioConPrestamoActivo(usuarioID);
        }

        public string ObtenerNombreDeUsuarioPorDNI(string dni)
        {
            return objDatosUsuarios.ObtenerNombreDeUsuarioPorDNI(dni);
        }

    }
}

