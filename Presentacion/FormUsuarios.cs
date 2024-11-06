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
    public partial class FormUsuarios : Form
    {
        public Usuario objEntUsuario = new Usuario();
        public NegUsuarios objNegUsuario = new NegUsuarios();

        public FormUsuarios()
        {
            InitializeComponent();
            dgvUsuarios.ColumnCount = 4;
            dgvUsuarios.Columns[0].HeaderText = "Nombre";
            dgvUsuarios.Columns[1].HeaderText = "DNI";
            dgvUsuarios.Columns[2].HeaderText = "Email";
            dgvUsuarios.Columns[3].HeaderText = "Dirección";
            dgvUsuarios.Columns[0].Width = 150;
            dgvUsuarios.Columns[1].Width = 100;
            dgvUsuarios.Columns[2].Width = 150;
            dgvUsuarios.Columns[3].Width = 150;
            LlenarDGV();
        }

        private void LlenarDGV()
        {
            dgvUsuarios.Rows.Clear();
            DataSet ds = objNegUsuario.ListadoUsuarios("Todos");
            if (ds.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvUsuarios.Rows.Add(dr["Nombre"].ToString(), dr["Dni"].ToString(), dr["Email"].ToString(), dr["Direccion"].ToString());
                }
            }
            else
            {
                MessageBox.Show("No hay usuarios cargados en el sistema", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TxtBox_a_Obj()
        {
            objEntUsuario.Nombre = txtNombre.Text;
            objEntUsuario.Dni = txtDni.Text;
            objEntUsuario.Email = txtEmail.Text;
            objEntUsuario.Direccion = txtDireccion.Text;
        }

        private void btnAlta_Click_1(object sender, EventArgs e)
        {
            int nGrabados = -1;
            TxtBox_a_Obj();
            nGrabados = objNegUsuario.AbmUsuarios("Agregar", objEntUsuario);
            if (nGrabados == -1)
            {
                MessageBox.Show("No se pudo grabar el usuario en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("El usuario se grabó con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarDGV();
                Limpiar();
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtBuscar.Text = string.Empty;
            txtNombre.Enabled = true;
        }

        private void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds = new DataSet();
            objEntUsuario.Nombre = dgvUsuarios.CurrentRow.Cells[0].Value.ToString();
            ds = objNegUsuario.ListadoUsuarios(objEntUsuario.Nombre);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Ds_a_TxtBox(ds);
                btnAlta.Visible = false;
            }
        }

        private void Ds_a_TxtBox(DataSet ds)
        {
            txtNombre.Text = ds.Tables[0].Rows[0]["Nombre"].ToString();
            txtDni.Text = ds.Tables[0].Rows[0]["Dni"].ToString();
            txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
            txtDireccion.Text = ds.Tables[0].Rows[0]["Direccion"].ToString();
            txtNombre.Enabled = false;
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            int nResultado = -1;
            TxtBox_a_Obj();
            nResultado = objNegUsuario.AbmUsuarios("Modificar", objEntUsuario);
            if (nResultado != -1)
            {
                MessageBox.Show("El usuario fue modificado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                LlenarDGV();
                txtNombre.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al intentar modificar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaja_Click_1(object sender, EventArgs e)
        {
            int nResultado = -1;
            TxtBox_a_Obj();
            nResultado = objNegUsuario.AbmUsuarios("Eliminar", objEntUsuario);
            if (nResultado != -1)
            {
                MessageBox.Show("El usuario fue eliminado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                LlenarDGV();
            }
            else
            {
                MessageBox.Show("Error al intentar eliminar el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            DataSet ds = objNegUsuario.ListadoUsuarios(txtBuscar.Text);
            if (ds.Tables[0].Rows.Count > 0)
            {
                dgvUsuarios.Rows.Clear();
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    dgvUsuarios.Rows.Add(dr["Nombre"].ToString(), dr["Dni"].ToString(), dr["Email"].ToString(), dr["Direccion"].ToString());
                }
                MessageBox.Show($"Resultados para '{txtBuscar.Text}'", "Búsqueda", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("No se encontraron usuarios con ese criterio de búsqueda", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvUsuarios.Rows.Clear();
            }
        }

     
    }
}

