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
            SuspendLayout();
            // 
            // comboBoxLibros
            // 
            comboBoxLibros.FormattingEnabled = true;
            comboBoxLibros.Location = new Point(355, 189);
            comboBoxLibros.Name = "comboBoxLibros";
            comboBoxLibros.Size = new Size(151, 28);
            comboBoxLibros.TabIndex = 5;
            // 
            // txtDni
            // 
            txtDni.Location = new Point(165, 190);
            txtDni.Name = "txtDni";
            txtDni.Size = new Size(159, 27);
            txtDni.TabIndex = 4;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(536, 190);
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
            // FormDevoluciones
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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
    }
}