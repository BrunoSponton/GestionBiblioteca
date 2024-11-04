using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Entidades
{
    public class Libro
    {
        #region Atributos
        private int libroID;
        private string titulo;
        private string autor;
        private string genero;
        private int stock;
        #endregion

        #region Constructor
        public Libro()
        {
            libroID = 0;
            titulo = string.Empty;
            autor = string.Empty;
            genero = string.Empty;
            stock = 0;
        }
        #endregion

        #region Propiedades
        public int LibroID
        {
            get { return libroID; }
            set { libroID = value; }
        }

        public string Titulo
        {
            get { return titulo; }
            set { titulo = value; }
        }

        public string Autor
        {
            get { return autor; }
            set { autor = value; }
        }

        public string Genero
        {
            get { return genero; }
            set { genero = value; }
        }

        public int Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        #endregion
    }
}

