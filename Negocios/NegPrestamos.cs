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
    public class NegPrestamos
    {
        private DatosPrestamos objDatosPrestamos = new DatosPrestamos();

        public int AbmPrestamos(string accion, Prestamo objPrestamo)
        {
            return objDatosPrestamos.AbmPrestamos(accion, objPrestamo);
        }

        public DataSet ListadoPrestamos(string cual)
        {
            return objDatosPrestamos.ListadoPrestamos(cual);
        }
    }
}

