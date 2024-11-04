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
            // FormPrestamos
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}