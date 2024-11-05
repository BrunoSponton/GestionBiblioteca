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
        }

        private void CargarLibros()
        {
            DataSet dsLibros = negLibros.ListadoLibros("Todos"); // Obtiene todos los libros
            comboBoxLibros.DisplayMember = "Titulo"; // Campo a mostrar
            comboBoxLibros.ValueMember = "LibroID"; // Valor asociado
            comboBoxLibros.DataSource = dsLibros.Tables[0]; // Asignar DataTable al ComboBox
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

            // Obtener el LibroID del ComboBox
            int libroID = (int)comboBoxLibros.SelectedValue;

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

                    MessageBox.Show("Préstamo registrado exitosamente y stock actualizado.");
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

    }
}

