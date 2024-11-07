using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Negocios;

namespace Presentacion
{
    public partial class FormDevoluciones : Form
    {
        private NegUsuarios negUsuarios = new NegUsuarios();
        private NegLibros negLibros = new NegLibros();
        private NegPrestamos negPrestamos = new NegPrestamos();

        public FormDevoluciones()
        {
            InitializeComponent();
            CargarLibros();
        }

        private void CargarLibros()
        {
            DataSet dsLibros = negLibros.ListadoLibros("Todos");
            comboBoxLibros.DisplayMember = "Titulo";
            comboBoxLibros.ValueMember = "LibroID";
            comboBoxLibros.DataSource = dsLibros.Tables[0];
        }

        private void btnAceptar_Click_1(object sender, EventArgs e)
        {
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

            int libroID = (int)comboBoxLibros.SelectedValue;

            // Verificar si el usuario tiene un préstamo activo y si corresponde al libro seleccionado
            Prestamo prestamoActivo = ObtenerPrestamoActivo(usuarioID, libroID);
            if (prestamoActivo == null)
            {
                MessageBox.Show("No se encontró un préstamo activo para este usuario y libro.");
                return;
            }

            // Incrementar el stock del libro
            if (!negLibros.IncrementarStock(libroID))
            {
                MessageBox.Show("Error al incrementar el stock del libro.");
                return;
            }

            // Cambiar el estado de PrestamoActivo a false en el usuario
            Usuario usuario = new Usuario { UsuarioID = usuarioID, PrestamoActivo = false };
            if (negUsuarios.ActualizarPrestamoActivo(usuario.UsuarioID, false) > 0)
            {
                // Comparar fechas para determinar si la devolución fue en tiempo o fuera de término
                DateTime fechaActual = DateTime.Now;
                string mensaje = (fechaActual <= prestamoActivo.FechaDevolucion)
                    ? "Devolución realizada a tiempo."
                    : "Devolución fuera de término.";

                MessageBox.Show(mensaje);
            }
            else
            {
                MessageBox.Show("Error al actualizar el estado de préstamo del usuario.");
            }
        }

        private int ObtenerUsuarioID(string dni)
        {
            DataSet dsUsuarios = negUsuarios.ListadoUsuarios(dni);
            if (dsUsuarios.Tables[0].Rows.Count > 0)
            {
                return Convert.ToInt32(dsUsuarios.Tables[0].Rows[0]["UsuarioID"]);
            }
            return -1;
        }

        private Prestamo ObtenerPrestamoActivo(int usuarioID, int libroID)
        {
            // Obtener el usuario específico y verificar si tiene préstamo activo
            DataSet dsUsuario = negUsuarios.ObtenerUsuarioConPrestamoActivo(usuarioID);
            DataTable tablaUsuario = dsUsuario.Tables[0];

            if (tablaUsuario.Rows.Count == 0 || !(bool)tablaUsuario.Rows[0]["PrestamoActivo"])
            {
                MessageBox.Show("No se encontró usuario con préstamo activo.");
                return null;
            }

            // Encontrar el préstamo en la tabla de préstamos
            DataSet dsPrestamos = negPrestamos.ListadoPrestamos("Todos");
            DataTable tablaPrestamos = dsPrestamos.Tables[0];

            DataRow prestamoRow = tablaPrestamos.AsEnumerable()
                .FirstOrDefault(row => (int)row["UsuarioID"] == usuarioID && (int)row["LibroID"] == libroID);

            if (prestamoRow != null)
            {
                return new Prestamo(usuarioID, libroID)
                {
                    PrestamoID = (int)prestamoRow["PrestamoID"],
                    FechaPrestamo = (DateTime)prestamoRow["FechaPrestamo"],
                    FechaDevolucion = (DateTime)prestamoRow["FechaDevolucion"]
                };
            }
            else
            {
                MessageBox.Show("No se encontró un préstamo activo para el libro seleccionado.");
                return null;
            }
        }

        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            FormInicio formInicio = new FormInicio();
            formInicio.Show();
            this.Close();  // Cierra el formulario actual y vuelve a FormInicio
        }
    }
}

