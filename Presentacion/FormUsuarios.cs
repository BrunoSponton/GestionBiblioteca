using System;
using System.Data;
using System.Windows.Forms;
using Entidades;
using Negocios;

namespace Presentacion
{
    public partial class FormUsuarios : Form
    {
        private NegUsuarios negUsuarios = new NegUsuarios();

        public FormUsuarios()
        {
            InitializeComponent();
            CargarUsuarios();
        }

        private void CargarUsuarios(string filtroDni = "Todos")
        {
            // Cargar listado de usuarios en el DataGridView
            DataSet dsUsuarios = negUsuarios.ListadoUsuarios(filtroDni);
            dgvUsuarios.DataSource = dsUsuarios.Tables[0];
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string filtro = txtBuscar.Text.Trim();

            if (string.IsNullOrEmpty(filtro))
            {
                // Si no hay filtro, cargamos todos los usuarios.
                CargarUsuarios();
                return;
            }

            // Detectamos si el filtro es un DNI (numérico) o un nombre (texto).
            if (int.TryParse(filtro, out _))
            {
                // Si es un número, asumimos que es un DNI y aplicamos el filtro de DNI.
                CargarUsuarios(filtro);
            }
            else
            {
                // Si es texto, asumimos que es un nombre y aplicamos el filtro de nombre.
                DataTable dtUsuarios = ((DataTable)dgvUsuarios.DataSource);
                DataView dvUsuarios = new DataView(dtUsuarios);
                dvUsuarios.RowFilter = $"Nombre LIKE '%{filtro}%'";
                dgvUsuarios.DataSource = dvUsuarios;
            }
        }


        private void btnAlta_Click_1(object sender, EventArgs e)
        {
            Usuario nuevoUsuario = new Usuario
            {
                Nombre = txtNombre.Text.Trim(),
                Dni = txtDni.Text.Trim(),
                Email = txtEmail.Text.Trim(),
                Direccion = txtDireccion.Text.Trim()
            };

            int resultado = negUsuarios.AbmUsuarios("Alta", nuevoUsuario);

            if (resultado > 0)
            {
                MessageBox.Show("Usuario agregado correctamente.");
                LimpiarCampos();
                CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Error al agregar el usuario.");
            }
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int usuarioID = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["UsuarioID"].Value);
                Usuario usuarioModificado = new Usuario
                {
                    UsuarioID = usuarioID,
                    Nombre = txtNombre.Text.Trim(),
                    Dni = txtDni.Text.Trim(),
                    Email = txtEmail.Text.Trim(),
                    Direccion = txtDireccion.Text.Trim()
                };

                int resultado = negUsuarios.AbmUsuarios("Modificar", usuarioModificado);

                if (resultado > 0)
                {
                    MessageBox.Show("Usuario modificado correctamente.");
                    LimpiarCampos();
                    CargarUsuarios();
                }
                else
                {
                    MessageBox.Show("Error al modificar el usuario.");
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para modificar.");
            }
        }

        private void btnBaja_Click_1(object sender, EventArgs e)
        {
            if (dgvUsuarios.SelectedRows.Count > 0)
            {
                int usuarioID = Convert.ToInt32(dgvUsuarios.SelectedRows[0].Cells["UsuarioID"].Value);

                DialogResult confirmacion = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?", "Confirmación", MessageBoxButtons.YesNo);

                if (confirmacion == DialogResult.Yes)
                {
                    Usuario usuarioEliminar = new Usuario { UsuarioID = usuarioID };
                    int resultado = negUsuarios.AbmUsuarios("Baja", usuarioEliminar);

                    if (resultado > 0)
                    {
                        MessageBox.Show("Usuario eliminado correctamente.");
                        CargarUsuarios();
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el usuario.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione un usuario para eliminar.");
            }
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Llenar los campos con los datos del usuario seleccionado
                DataGridViewRow row = dgvUsuarios.Rows[e.RowIndex];
                txtNombre.Text = row.Cells["Nombre"].Value.ToString();
                txtDni.Text = row.Cells["Dni"].Value.ToString();
                txtEmail.Text = row.Cells["Email"].Value.ToString();
                txtDireccion.Text = row.Cells["Direccion"].Value.ToString();
            }
        }

        private void LimpiarCampos()
        {
            txtNombre.Clear();
            txtDni.Clear();
            txtEmail.Clear();
            txtDireccion.Clear();
        }

        private void btnAtras_Click_1(object sender, EventArgs e)
        {
            FormInicio formInicio = new FormInicio();
            formInicio.Show();
            this.Close();  // Cierra el formulario actual y vuelve a FormInicio
        }

    }
}


