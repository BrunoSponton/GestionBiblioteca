﻿namespace Presentacion
{
    partial class FormLibros
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
            btnBuscar = new Button();
            btnBaja = new Button();
            btnModificar = new Button();
            btnAlta = new Button();
            dgvLibros = new DataGridView();
            txtBuscar = new TextBox();
            txtTitulo = new TextBox();
            txtAutor = new TextBox();
            txtGenero = new TextBox();
            txtStock = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvLibros).BeginInit();
            SuspendLayout();
            // 
            // btnBuscar
            // 
            btnBuscar.Location = new Point(536, 54);
            btnBuscar.Name = "btnBuscar";
            btnBuscar.Size = new Size(94, 29);
            btnBuscar.TabIndex = 0;
            btnBuscar.Text = "Buscar";
            btnBuscar.UseVisualStyleBackColor = true;
            btnBuscar.Click += btnBuscar_Click_1;
            // 
            // btnBaja
            // 
            btnBaja.Location = new Point(597, 347);
            btnBaja.Name = "btnBaja";
            btnBaja.Size = new Size(94, 29);
            btnBaja.TabIndex = 1;
            btnBaja.Text = "Baja";
            btnBaja.UseVisualStyleBackColor = true;
            btnBaja.Click += btnBaja_Click_1;
            // 
            // btnModificar
            // 
            btnModificar.Location = new Point(722, 347);
            btnModificar.Name = "btnModificar";
            btnModificar.Size = new Size(94, 29);
            btnModificar.TabIndex = 2;
            btnModificar.Text = "Modificar";
            btnModificar.UseVisualStyleBackColor = true;
            btnModificar.Click += btnModificar_Click_1;
            // 
            // btnAlta
            // 
            btnAlta.Location = new Point(842, 347);
            btnAlta.Name = "btnAlta";
            btnAlta.Size = new Size(94, 29);
            btnAlta.TabIndex = 3;
            btnAlta.Text = "Alta";
            btnAlta.UseVisualStyleBackColor = true;
            btnAlta.Click += btnAlta_Click_1;
            // 
            // dgvLibros
            // 
            dgvLibros.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLibros.Location = new Point(73, 96);
            dgvLibros.Name = "dgvLibros";
            dgvLibros.RowHeadersWidth = 51;
            dgvLibros.Size = new Size(618, 230);
            dgvLibros.TabIndex = 4;
            // 
            // txtBuscar
            // 
            txtBuscar.Location = new Point(82, 53);
            txtBuscar.Name = "txtBuscar";
            txtBuscar.Size = new Size(435, 27);
            txtBuscar.TabIndex = 5;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(722, 96);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(212, 27);
            txtTitulo.TabIndex = 6;
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(722, 164);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(212, 27);
            txtAutor.TabIndex = 7;
            // 
            // txtGenero
            // 
            txtGenero.Location = new Point(722, 229);
            txtGenero.Name = "txtGenero";
            txtGenero.Size = new Size(212, 27);
            txtGenero.TabIndex = 8;
            // 
            // txtStock
            // 
            txtStock.Location = new Point(722, 299);
            txtStock.Name = "txtStock";
            txtStock.Size = new Size(212, 27);
            txtStock.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(723, 72);
            label1.Name = "label1";
            label1.Size = new Size(50, 20);
            label1.TabIndex = 10;
            label1.Text = "Título:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(722, 141);
            label2.Name = "label2";
            label2.Size = new Size(49, 20);
            label2.TabIndex = 11;
            label2.Text = "Autor:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(722, 206);
            label3.Name = "label3";
            label3.Size = new Size(60, 20);
            label3.TabIndex = 12;
            label3.Text = "Género:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(722, 276);
            label4.Name = "label4";
            label4.Size = new Size(48, 20);
            label4.TabIndex = 13;
            label4.Text = "Stock:";
            // 
            // FormLibros
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1006, 450);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtStock);
            Controls.Add(txtGenero);
            Controls.Add(txtAutor);
            Controls.Add(txtTitulo);
            Controls.Add(txtBuscar);
            Controls.Add(dgvLibros);
            Controls.Add(btnAlta);
            Controls.Add(btnModificar);
            Controls.Add(btnBaja);
            Controls.Add(btnBuscar);
            Name = "FormLibros";
            Text = "FormLibros";
            ((System.ComponentModel.ISupportInitialize)dgvLibros).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnBuscar;
        private Button btnBaja;
        private Button btnModificar;
        private Button btnAlta;
        private DataGridView dgvLibros;
        private TextBox txtBuscar;
        private TextBox txtTitulo;
        private TextBox txtAutor;
        private TextBox txtGenero;
        private TextBox txtStock;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
    }
}