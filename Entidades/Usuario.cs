using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Usuario
    {
        #region Atributos
        private int usuarioID;
        private string nombre;
        private string dni;
        private string email;
        private string direccion;
        private bool prestamoActivo;
        #endregion

        #region Constructor
        public Usuario()
        {
            usuarioID = 0;
            nombre = string.Empty;
            dni = string.Empty;
            email = string.Empty;
            direccion = string.Empty;
            prestamoActivo = false;
        }
        #endregion

        #region Propiedades
        public int UsuarioID
        {
            get { return usuarioID; }
            set { usuarioID = value; }
        }

        public string Nombre
        {
            get { return nombre; }
            set { nombre = value; }
        }

        public string Dni
        {
            get { return dni; }
            set { dni = value; }
        }

        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        public string Direccion
        {
            get { return direccion; }
            set { direccion = value; }
        }

        public bool PrestamoActivo
        {
            get { return prestamoActivo; }
            set { prestamoActivo = value; }
        }
        #endregion
    }
}
