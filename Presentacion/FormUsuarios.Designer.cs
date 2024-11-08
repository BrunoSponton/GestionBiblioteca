namespace Presentacion
{
    partial class FormUsuarios
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
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            txtDireccion = new TextBox();
            txtEmail = new TextBox();
            txtDni = new TextBox();
            txtNombre = new TextBox();
            txtBuscar = new TextBox();
            dgvUsuarios = new DataGridView();
            btnAlta = new Button();
            btnModificar = new Button();
            btnBaja = new Button();
            btnBuscar = new Button();
            btnAtras = new Button();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).BeginInit();
            SuspendLayout();
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(746, 329);
            label4.Name = "label4";
            label4.Size = new Size(75, 20);
            label4.TabIndex = 27;
            label4.Text = "Dirección:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(746, 259);
            label3.Name = "label3";
            label3.Size = new Size(49, 20);
            label3.TabIndex = 26;
            label3.Text = "Email:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(746, 194);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 25;
            label2.Text = "DNI:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(747, 125);
            label1.Name = "label1";
            label1.Size = new Size(67, 20);
            label1.TabIndex = 24;
            label1.Text = "Nombre:";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(746, 352);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(212, 27);
            txtDireccion.TabIndex = 23;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(746, 282);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(212, 27);
            txtEmail.TabIndex = 22;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(746, 217);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(212, 27);
            txtDni.TabIndex = 21;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(746, 149);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(212, 27);
            txtNombre.TabIndex = 20;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(106, 106);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(435, 27);
            txtBuscar.TabIndex = 19;
            // 
            // dgvUsuarios
            // 
            dgvUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvUsuarios.Location = new Point(97, 149);
            dgvUsuarios.Name = "dgvUsuarios";
            dgvUsuarios.RowHeadersWidth = 51;
            dgvUsuarios.Size = new Size(618, 230);
            dgvUsuarios.TabIndex = 18;
            // 
            // btnAlta
            // 
            btnAlta.Location = new Point(866, 400);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(94, 29);
            btnAlta.TabIndex = 17;
            btnAlta.Text = "Alta";
            btnAlta.UseVisualStyleBackColor = true;
            btnAlta.Click += btnAlta_Click_1;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(746, 400);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 16;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click_1;
            // 
            // btnBaja
            // 
            btnBaja.Location = new Point(621, 400);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(94, 29);
            btnBaja.TabIndex = 15;
            btnBaja.Text = "Baja";
            btnBaja.UseVisualStyleBackColor = true;
            btnBaja.Click += btnBaja_Click_1;
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(560, 107);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 14;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(944, 12);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(94, 29);
            btnAtras.TabIndex = 28;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click_1;
            // 
            // label5
            // 
            label5.Font = new Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(106, 43);
            label5.Name = "label5";
            label5.Size = new Size(391, 37);
            label5.TabIndex = 29;
            label5.Text = "GESTIÓN DE USUARIOS";
            // 
            // FormUsuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 450);
            Controls.Add(label5);
            Controls.Add(btnAtras);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDireccion);
            Controls.Add(txtEmail);
            Controls.Add(txtDni);
            Controls.Add(txtNombre);
            Controls.Add(txtBuscar);
            Controls.Add(dgvUsuarios);
            Controls.Add(btnAlta);
            Controls.Add(btnModificar);
            Controls.Add(btnBaja);
            Controls.Add(btnBuscar);
            Name = "FormUsuarios";
            Text = "FormUsuarios";
            ((System.ComponentModel.ISupportInitialize)dgvUsuarios).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox txtDireccion;
        private TextBox txtEmail;
        private TextBox txtDni;
        private TextBox txtNombre;
        private TextBox txtBuscar;
        private DataGridView dgvUsuarios;
        private Button btnAlta;
        private Button btnModificar;
        private Button btnBaja;
        private Button btnBuscar;
        private Button btnAtras;
        private Label label5;
    }
}