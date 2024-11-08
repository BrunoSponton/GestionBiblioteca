namespace Presentacion
{
    partial class FormDevoluciones
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
            comboBoxLibros = new ComboBox();
            txtDni = new TextBox();
            btnAceptar = new Button();
            btnAtras = new Button();
            btnVerificarUsuario = new Button();
            label5 = new Label();
            label2 = new Label();
            label1 = new Label();
            SuspendLayout();
            // 
            // comboBoxLibros
            // 
            comboBoxLibros.FormattingEnabled = true;
            comboBoxLibros.Location = new Point(274, 184);
            comboBoxLibros.Name = "comboBoxLibros";
            comboBoxLibros.Size = new Size(151, 28);
            comboBoxLibros.TabIndex = 5;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(84, 185);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(159, 27);
            txtDni.TabIndex = 4;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(559, 185);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 3;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click_1;
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(694, 12);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(94, 29);
            btnAtras.TabIndex = 6;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click_1;
            // 
            // btnVerificarUsuario
            // 
            btnVerificarUsuario.Location = new Point(447, 185);
            btnVerificarUsuario.Name = "btnVerificarUsuario";
            btnVerificarUsuario.Size = new Size(94, 29);
            btnVerificarUsuario.TabIndex = 7;
            btnVerificarUsuario.Text = "Verificar";
            btnVerificarUsuario.UseVisualStyleBackColor = true;
            btnVerificarUsuario.Click += btnVerificarUsuario_Click_1;
            // 
            // label5
            // 
            label5.Font = new Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(84, 80);
            label5.Name = "label5";
            label5.Size = new Size(462, 37);
            label5.TabIndex = 17;
            label5.Text = "REGISTRAR DEVOLUCIONES";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(84, 162);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 26;
            label2.Text = "DNI:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(274, 162);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 27;
            label1.Text = "Libro:";
            // 
            // FormDevoluciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(btnVerificarUsuario);
            Controls.Add(btnAtras);
            Controls.Add(comboBoxLibros);
            Controls.Add(txtDni);
            Controls.Add(btnAceptar);
            Name = "FormDevoluciones";
            Text = "FormDevoluciones";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBoxLibros;
        private TextBox txtDni;
        private Button btnAceptar;
        private Button btnAtras;
        private Button btnVerificarUsuario;
        private Label label5;
        private Label label2;
        private Label label1;
    }
}