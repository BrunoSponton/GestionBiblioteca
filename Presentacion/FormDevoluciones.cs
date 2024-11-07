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
            txtDni.KeyPress += new KeyPressEventHandler(txtDni_KeyPress);
        }

        private void CargarLibros()
        {
            DataSet dsLibros = negLibros.ListadoLibros("Todos");
            comboBoxLibros.DisplayMember = "Titulo";
            comboBoxLibros.ValueMember = "LibroID";
            comboBoxLibros.DataSource = dsLibros.Tables[0];
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
            if (string.IsNullOrWhiteSpace(txtDni.Text))
            {
                MessageBox.Show("Por favor, ingrese un DNI.");
                return;
            }

            int usuarioID = ObtenerUsuarioID(txtDni.Text);
            if (usuarioID == -1)
            {
                MessageBox.Show("Usuario no encontrado.");
                return;
            }

            int libroID = (int)comboBoxLibros.SelectedValue;

            Prestamo prestamoActivo = ObtenerPrestamoActivo(usuarioID, libroID);
            if (prestamoActivo == null)
            {
                MessageBox.Show("No se encontró un préstamo activo para este usuario y libro.");
                return;
            }

            if (!negLibros.IncrementarStock(libroID))
            {
                MessageBox.Show("Error al incrementar el stock del libro.");
                return;
            }

            Usuario usuario = new Usuario { UsuarioID = usuarioID, PrestamoActivo = false };
            if (negUsuarios.ActualizarPrestamoActivo(usuario.UsuarioID, false) > 0)
            {
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
            DataSet dsUsuario = negUsuarios.ObtenerUsuarioConPrestamoActivo(usuarioID);
            DataTable tablaUsuario = dsUsuario.Tables[0];

            if (tablaUsuario.Rows.Count == 0 || !(bool)tablaUsuario.Rows[0]["PrestamoActivo"])
            {
                MessageBox.Show("No se encontró usuario con préstamo activo.");
                return null;
            }

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
            this.Close();
        }

        private void btnVerificarUsuario_Click_1(object sender, EventArgs e)
        {
            string dni = txtDni.Text.Trim();
            if (string.IsNullOrEmpty(dni))
            {
                MessageBox.Show("Por favor, ingrese un DNI.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string nombreUsuario = negUsuarios.ObtenerNombreDeUsuarioPorDNI(dni);
            if (string.IsNullOrEmpty(nombreUsuario))
            {
                MessageBox.Show("Usuario no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show($"Usuario encontrado: {nombreUsuario}", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            int usuarioID = ObtenerUsuarioID(dni);
            int libroID = (int)comboBoxLibros.SelectedValue;
            Prestamo prestamoActivo = ObtenerPrestamoActivo(usuarioID, libroID);

            if (prestamoActivo != null)
            {
                for (int i = 0; i < comboBoxLibros.Items.Count; i++)
                {
                    if (((DataRowView)comboBoxLibros.Items[i])["LibroID"].ToString() == libroID.ToString())
                    {
                        comboBoxLibros.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
    }
}


