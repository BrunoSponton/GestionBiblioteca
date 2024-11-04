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
    public class NegLibros
    {
        private DatosLibros objDatosLibros = new DatosLibros();

        public int AbmLibros(string accion, Libro objLibro)
        {
            return objDatosLibros.AbmLibros(accion, objLibro);
        }

        public DataSet ListadoLibros(string cual)
        {
            return objDatosLibros.ListadoLibros(cual);
        }

        public bool DescontarStock(int libroID)
        {
            DatosLibros datosLibros = new DatosLibros();
            return datosLibros.ActualizarStock(libroID, -1); // Restar 1 del stock
        }
    }
}

