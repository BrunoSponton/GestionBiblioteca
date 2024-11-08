namespace Presentacion
{
    partial class FormPrestamos
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
            btnAceptar = new Button();
            txtDni = new TextBox();
            comboBoxLibros = new ComboBox();
            btnAtras = new Button();
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(462, 141);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(94, 29);
            btnAceptar.TabIndex = 0;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            btnAceptar.Click += btnAceptar_Click_1;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(91, 141);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(159, 27);
            txtDni.TabIndex = 1;
            // 
            // comboBoxLibros
            // 
            comboBoxLibros.FormattingEnabled = true;
            comboBoxLibros.Location = new Point(281, 140);
            comboBoxLibros.Name = "comboBoxLibros";
            comboBoxLibros.Size = new Size(151, 28);
            comboBoxLibros.TabIndex = 2;
            // 
            // btnAtras
            // 
            btnAtras.Location = new Point(694, 12);
            btnAtras.Name = "btnAtras";
            btnAtras.Size = new Size(94, 29);
            btnAtras.TabIndex = 7;
            btnAtras.Text = "Atras";
            btnAtras.UseVisualStyleBackColor = true;
            btnAtras.Click += btnAtras_Click_1;
            // 
            // label5
            // 
            label5.Font = new Font("Verdana", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(91, 56);
            label5.Name = "label5";
            label5.Size = new Size(405, 37);
            label5.TabIndex = 16;
            label5.Text = "REGISTRAR PRESTAMOS";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(281, 118);
            label1.Name = "label1";
            label1.Size = new Size(46, 20);
            label1.TabIndex = 29;
            label1.Text = "Libro:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 118);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 28;
            label2.Text = "DNI:";
            // 
            // FormPrestamos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(label5);
            Controls.Add(btnAtras);
            Controls.Add(comboBoxLibros);
            Controls.Add(txtDni);
            Controls.Add(btnAceptar);
            Name = "FormPrestamos";
            Text = "FormPrestamos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAceptar;
        private TextBox txtDni;
        private ComboBox comboBoxLibros;
        private Button btnAtras;
        private Label label5;
        private Label label1;
        private Label label2;
    }
}