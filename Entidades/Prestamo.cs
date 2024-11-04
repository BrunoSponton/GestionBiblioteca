using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace Entidades
{
    public class Prestamo
    {
        #region Atributos
        private int prestamoID;
        private int usuarioID; // Clave foránea hacia Usuarios
        private int libroID;    // Clave foránea hacia Libros
        private DateTime fechaPrestamo;
        private DateTime? fechaDevolucion;
        #endregion

        #region Constructor
        // Constructor que inicializa los valores obligatorios, incluyendo las claves foráneas
        public Prestamo(int usuarioID, int libroID)
        {
            prestamoID = 0; // Será asignado por la base de datos si es IDENTITY
            this.usuarioID = usuarioID; // Se espera que este usuarioID exista en la tabla Usuarios
            this.libroID = libroID;     // Se espera que este libroID exista en la tabla Libros
            fechaPrestamo = DateTime.Now; // Fecha actual como valor por defecto
            fechaDevolucion = null;       // Valor por defecto para indicar que aún no se ha devuelto
        }
        #endregion

        #region Propiedades
        public int PrestamoID
        {
            get { return prestamoID; }
            set { prestamoID = value; }
        }

        public int UsuarioID
        {
            get { return usuarioID; }
            set { usuarioID = value; }
        }

        public int LibroID
        {
            get { return libroID; }
            set { libroID = value; }
        }

        public DateTime FechaPrestamo
        {
            get { return fechaPrestamo; }
            set { fechaPrestamo = value; }
        }

        public DateTime? FechaDevolucion
        {
            get { return fechaDevolucion; }
            set { fechaDevolucion = value; }
        }
        #endregion
    }
}

