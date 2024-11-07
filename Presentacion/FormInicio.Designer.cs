namespace Presentacion
{
    partial class FormInicio
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnUsuarios = new Button();
            btnLibros = new Button();
            btnPrestamos = new Button();
            btnDevoluciones = new Button();
            SuspendLayout();
            // 
            // btnUsuarios
            // 
            btnUsuarios.Location = new Point(188, 128);
            btnUsuarios.Name = "btnUsuarios";
            btnUsuarios.Size = new Size(112, 42);
            btnUsuarios.TabIndex = 0;
            btnUsuarios.Text = "Usuarios";
            btnUsuarios.UseVisualStyleBackColor = true;
            btnUsuarios.Click += btnUsuarios_Click_1;
            // 
            // btnLibros
            // 
            btnLibros.Location = new Point(486, 128);
            btnLibros.Name = "btnLibros";
            btnLibros.Size = new Size(112, 42);
            btnLibros.TabIndex = 1;
            btnLibros.Text = "Libros";
            btnLibros.UseVisualStyleBackColor = true;
            btnLibros.Click += btnLibros_Click_1;
            // 
            // btnPrestamos
            // 
            btnPrestamos.Location = new Point(188, 277);
            btnPrestamos.Name = "btnPrestamos";
            btnPrestamos.Size = new Size(112, 42);
            btnPrestamos.TabIndex = 2;
            btnPrestamos.Text = "Prestamos";
            btnPrestamos.UseVisualStyleBackColor = true;
            btnPrestamos.Click += btnPrestamos_Click_1;
            // 
            // btnDevoluciones
            // 
            btnDevoluciones.Location = new Point(486, 277);
            btnDevoluciones.Name = "btnDevoluciones";
            btnDevoluciones.Size = new Size(112, 42);
            btnDevoluciones.TabIndex = 3;
            btnDevoluciones.Text = "Devoluciones";
            btnDevoluciones.UseVisualStyleBackColor = true;
            btnDevoluciones.Click += btnDevoluciones_Click_1;
            // 
            // FormInicio
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnDevoluciones);
            Controls.Add(btnPrestamos);
            Controls.Add(btnLibros);
            Controls.Add(btnUsuarios);
            Name = "FormInicio";
            Text = "FormInicio";
            ResumeLayout(false);
        }

        #endregion

        private Button btnUsuarios;
        private Button btnLibros;
        private Button btnPrestamos;
        private Button btnDevoluciones;
    }
}