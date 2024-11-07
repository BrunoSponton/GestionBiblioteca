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
    public partial class FormLibros : Form
    {
        public Libro objEntLibro = new Libro();
        public NegLibros objNegLibro = new NegLibros();

        public FormLibros()
        {
            InitializeComponent();
            dgvLibros.ColumnCount = 4;
            dgvLibros.Columns[0].HeaderText = "Título";
            dgvLibros.Columns[1].HeaderText = "Autor";
            dgvLibros.Columns[2].HeaderText = "Género";
            dgvLibros.Columns[3].HeaderText = "Stock";
            dgvLibros.Columns[0].Width = 150;
            dgvLibros.Columns[1].Width = 150;
            dgvLibros.Columns[2].Width = 100;
            dgvLibros.Columns[3].Width = 60;
            LlenarDGV();
        }

        private void LlenarDGV()
        {
            // Obtener el listado de libros
            DataSet ds = objNegLibro.ListadoLibros("Todos"); // O el parámetro que estés usando

            // Limpiar las columnas del DataGridView antes de agregar nuevas
            dgvLibros.Columns.Clear();

            // Asignar el DataSource para llenar el DataGridView
            dgvLibros.DataSource = ds.Tables[0]; // Asumimos que el DataTable está en la primera tabla del DataSet

            // Verificar si la columna 'LibroID' ya existe en el DataGridView
            if (dgvLibros.Columns.Contains("LibroID"))
            {
                // Hacer invisible la columna 'LibroID' después de la asignación
                dgvLibros.Columns["LibroID"].Visible = false;
            }
        }
       
        //METODO DE VALIDACION:
        private bool ValidarCampos()
        {
            // Verificar que Título, Autor y Género no estén vacíos
            if (string.IsNullOrWhiteSpace(txtTitulo.Text))
            {
                MessageBox.Show("El campo 'Título' no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTitulo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtAutor.Text))
            {
                MessageBox.Show("El campo 'Autor' no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtAutor.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtGenero.Text))
            {
                MessageBox.Show("El campo 'Género' no puede estar vacío.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtGenero.Focus();
                return false;
            }

            // Verificar que Stock sea un número positivo
            if (!int.TryParse(txtStock.Text, out int stock) || stock < 0)
            {
                MessageBox.Show("El campo 'Stock' debe ser un número entero positivo.", "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtStock.Focus();
                return false;
            }

            // Si todas las validaciones pasaron, retornar true
            return true;
        }


        private void TxtBox_a_Obj()
        {
            objEntLibro.Titulo = txtTitulo.Text;
            objEntLibro.Autor = txtAutor.Text;
            objEntLibro.Genero = txtGenero.Text;
            objEntLibro.Stock = int.Parse(txtStock.Text);
        }

        private void btnAlta_Click_1(object sender, EventArgs e)
        {
            // Validar los campos antes de continuar
            if (!ValidarCampos()) return;

            int nGrabados = -1;
            TxtBox_a_Obj();
            nGrabados = objNegLibro.AbmLibros("Alta", objEntLibro);
            if (nGrabados == -1)
            {
                MessageBox.Show("No se pudo grabar el libro en el sistema", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("El libro se grabó con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LlenarDGV();
                Limpiar();
            }
        }

        private void Limpiar()
        {
            txtTitulo.Text = string.Empty;
            txtAutor.Text = string.Empty;
            txtGenero.Text = string.Empty;
            txtStock.Text = string.Empty;
            txtBuscar.Text = string.Empty;
            txtTitulo.Enabled = true;
        }

        private void dgvLibros_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataSet ds = new DataSet();
            objEntLibro.Titulo = dgvLibros.CurrentRow.Cells[0].Value.ToString();
            ds = objNegLibro.ListadoLibros(objEntLibro.Titulo);
            if (ds.Tables[0].Rows.Count > 0)
            {
                Ds_a_TxtBox(ds);
                btnAlta.Visible = false;
            }
        }

        private void Ds_a_TxtBox(DataSet ds)
        {
            txtTitulo.Text = ds.Tables[0].Rows[0]["Titulo"].ToString();
            txtAutor.Text = ds.Tables[0].Rows[0]["Autor"].ToString();
            txtGenero.Text = ds.Tables[0].Rows[0]["Genero"].ToString();
            txtStock.Text = ds.Tables[0].Rows[0]["Stock"].ToString();
            txtTitulo.Enabled = false;
        }

        private void btnModificar_Click_1(object sender, EventArgs e)
        {
            // Validar los campos antes de continuar
            if (!ValidarCampos()) return;

            int nResultado = -1;
            TxtBox_a_Obj();
            nResultado = objNegLibro.AbmLibros("Modificar", objEntLibro);
            if (nResultado != -1)
            {
                MessageBox.Show("El libro fue modificado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar();
                LlenarDGV();
                txtTitulo.Enabled = true;
            }
            else
            {
                MessageBox.Show("Error al intentar modificar el libro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBaja_Click_1(object sender, EventArgs e)
        {
            if (dgvLibros.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un libro para eliminar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Si no hay fila seleccionada, salir del método
            }

            // Obtener el ID del libro seleccionado de la columna oculta 'LibroID'
            int libroIdSeleccionado = Convert.ToInt32(dgvLibros.CurrentRow.Cells["LibroID"].Value); // Accediendo a la columna 'LibroID'

            // Ahora puedes usar este libroIdSeleccionado para buscar el libro o hacer otras operaciones
            DataSet ds = objNegLibro.ListadoLibrosPorId(libroIdSeleccionado);
            if (ds.Tables[0].Rows.Count > 0)
            {
                // Cargar los datos del libro en los controles de texto
                txtTitulo.Text = ds.Tables[0].Rows[0]["Titulo"].ToString();
                txtAutor.Text = ds.Tables[0].Rows[0]["Autor"].ToString();
                txtGenero.Text = ds.Tables[0].Rows[0]["Genero"].ToString();
                txtStock.Text = ds.Tables[0].Rows[0]["Stock"].ToString();

                // Establecer el libro en el objeto entidad
                objEntLibro.Titulo = ds.Tables[0].Rows[0]["Titulo"].ToString();
                objEntLibro.Autor = ds.Tables[0].Rows[0]["Autor"].ToString();
                objEntLibro.Genero = ds.Tables[0].Rows[0]["Genero"].ToString();
                objEntLibro.Stock = Convert.ToInt32(ds.Tables[0].Rows[0]["Stock"]);

                // Llamar al método para eliminar el libro
                int nResultado = objNegLibro.AbmLibros("Baja", objEntLibro);
                if (nResultado != -1)
                {
                    MessageBox.Show("El libro fue eliminado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Limpiar();
                    LlenarDGV();
                }
                else
                {
                    MessageBox.Show("Error al intentar eliminar el libro", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("No se encontró el libro seleccionado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnBuscar_Click_1(object sender, EventArgs e)
        {
            string buscarTexto = txtBuscar.Text.Trim();

            // Verificar si el texto de búsqueda no está vacío
            if (!string.IsNullOrEmpty(buscarTexto))
            {
                // Llamar al método de búsqueda pasando el texto ingresado
                DataSet ds = objNegLibro.ListadoLibros(buscarTexto);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    // Si tienes un BindingSource, puedes hacer esto:
                    dgvLibros.DataSource = ds.Tables[0]; // Establecer el DataSource con la nueva tabla
                }
                else
                {
                    MessageBox.Show("No se encontraron libros con ese criterio de búsqueda", "Sin resultados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Limpiar el DataGridView si no se encontraron resultados
                    dgvLibros.DataSource = null; // Remover el DataSource
                }
            }
            else
            {
                MessageBox.Show("Por favor ingrese un criterio de búsqueda.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

