using Entidades;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FormPrestamos : Form
    {
        private NegUsuarios negUsuarios = new NegUsuarios();
        private NegLibros negLibros = new NegLibros();
        private NegPrestamos negPrestamos = new NegPrestamos();

        public FormPrestamos()
        {
            InitializeComponent();
            CargarLibros(); // Método para cargar los libros en el ComboBox
            txtDni.KeyPress += new KeyPressEventHandler(txtDni_KeyPress);
        }

        private void CargarLibros()
        {
            DataSet dsLibros = negLibros.ListadoLibros("Todos"); // Obtiene todos los libros
            comboBoxLibros.DisplayMember = "Titulo"; // Campo a mostrar
            comboBoxLibros.ValueMember = "LibroID"; // Valor asociado
            comboBoxLibros.DataSource = dsLibros.Tables[0]; // Asignar DataTable al ComboBox
        }

        private void txtDni_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Solo permite números y teclas de retroceso
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                if (e.KeyChar == '.')
                {
                    MessageBox.Show("Por favor, ingrese el DNI sin puntos.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    MessageBox.Show("Solo se permiten números en el campo DNI.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                e.Handled = true; // Cancela el ingreso de la tecla actual
            }
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
            // Validar que el DNI no esté vacío
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Por favor, ingrese un DNI.");
                return;
            }

            // Obtener el UsuarioID a partir del DNI
            int usuarioID = ObtenerUsuarioID(txtDni.Text);
            if (usuarioID == -1)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            // Verificar si el usuario tiene un préstamo activo
            Usuario usuario = negUsuarios.ObtenerUsuarioPorID(usuarioID);
            if (usuario.PrestamoActivo)
            {
                MessageBox.Show("El usuario ya tiene un préstamo activo. Debe devolver el libro antes de pedir otro.");
                return;
            }

            // Obtener el nombre del usuario
            string nombreUsuario = negUsuarios.ObtenerNombreDeUsuarioPorDNI(txtDni.Text);

            // Obtener el LibroID y el título del libro del ComboBox
            int libroID = (int)comboBoxLibros.SelectedValue;
            string tituloLibro = comboBoxLibros.Text;

            // Crear un objeto Prestamo
            Prestamo nuevoPrestamo = new Prestamo(usuarioID, libroID)
            {
                FechaPrestamo = DateTime.Now, // Fecha actual
                FechaDevolucion = DateTime.Now.AddDays(14) // Fecha de devolución 2 semanas después
            };

            // Agregar el préstamo
            int resultado = negPrestamos.AbmPrestamos("Alta", nuevoPrestamo);
            if (resultado > 0)
            {
                // Descontar 1 del stock del libro
                if (negLibros.DescontarStock(libroID))
                {
                    // Actualizar PrestamoActivo del usuario a true
                    usuario.PrestamoActivo = true;
                    negUsuarios.AbmUsuarios("Modificar", usuario); // Actualizar en la base de datos

                    MessageBox.Show($"Préstamo registrado a nombre de {nombreUsuario} con el libro '{tituloLibro}'");
                }
                else
                {
                    MessageBox.Show("Préstamo registrado, pero no se pudo actualizar el stock.");
                }
            }
            else
            {
                MessageBox.Show("Error al registrar el préstamo.");
            }
        }




        private int ObtenerUsuarioIDPorDNI(string dni) // Cambiar el nombre para mayor claridad
        {
            // Lógica para buscar el UsuarioID a partir del DNI
            DataSet dsUsuarios = negUsuarios.ListadoUsuarios(dni);
            if (dsUsuarios.Tables[0].Rows.Count > 0)
            {
                // Suponiendo que el primer registro es el correcto
                return Convert.ToInt32(dsUsuarios.Tables[0].Rows[0]["UsuarioID"]);
            }
            return -1; // Usuario no encontrado
        }

        private int ObtenerUsuarioID(string dni)
        {
            // Lógica para buscar el UsuarioID a partir del DNI
            DataSet dsUsuarios = negUsuarios.ListadoUsuarios(dni);
            if (dsUsuarios.Tables[0].Rows.Count > 0)
            {
                // Suponiendo que el primer registro es el correcto
                return Convert.ToInt32(dsUsuarios.Tables[0].Rows[0]["UsuarioID"]);
            }
            return -1; // Usuario no encontrado
        }
        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            FormInicio formInicio = new FormInicio();
            formInicio.Show();
            this.Close();  // Cierra el formulario actual y vuelve a FormInicio
        }

    }
}

