using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormInicio : Form
    {
        public FormInicio()
        {
            InitializeComponent();
        }

        private void btnUsuarios_Click_1(object sender, EventArgs e)
        {
            FormUsuarios formUsuarios = new FormUsuarios();
            formUsuarios.Show();
            this.Hide();  // Oculta FormInicio cuando se abre FormUsuarios
        }

        private void btnLibros_Click_1(object sender, EventArgs e)
        {
            FormLibros formLibros = new FormLibros();
            formLibros.Show();
            this.Hide();  // Oculta FormInicio cuando se abre FormLibros
        }

        private void btnPrestamos_Click_1(object sender, EventArgs e)
        {
            FormPrestamos formPrestamos = new FormPrestamos();
            formPrestamos.Show();
            this.Hide();
        }

        private void btnDevoluciones_Click_1(object sender, EventArgs e)
        {
            FormDevoluciones formDevoluciones = new FormDevoluciones();
            formDevoluciones.Show();
            this.Hide();
        }
    }
}

