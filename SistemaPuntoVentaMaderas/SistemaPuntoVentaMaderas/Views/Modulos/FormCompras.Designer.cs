﻿
namespace SistemaPuntoVentaMaderas
{
    partial class FormCompras
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            this.lbrespuesta = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbProvedor = new System.Windows.Forms.TextBox();
            this.btnAlta = new System.Windows.Forms.Button();
            this.dataGridComprasMaderas = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Columnm2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Stock = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCancelarCompra = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComprasMaderas)).BeginInit();
            this.SuspendLayout();
            // 
            // lbrespuesta
            // 
            this.lbrespuesta.AutoSize = true;
            this.lbrespuesta.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbrespuesta.ForeColor = System.Drawing.Color.Black;
            this.lbrespuesta.Location = new System.Drawing.Point(280, 75);
            this.lbrespuesta.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbrespuesta.Name = "lbrespuesta";
            this.lbrespuesta.Size = new System.Drawing.Size(0, 23);
            this.lbrespuesta.TabIndex = 255;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(29, 38);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(250, 23);
            this.label1.TabIndex = 254;
            this.label1.Text = "Buscar, ingrese proveedor";
            // 
            // txbProvedor
            // 
            this.txbProvedor.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbProvedor.Location = new System.Drawing.Point(284, 34);
            this.txbProvedor.Name = "txbProvedor";
            this.txbProvedor.Size = new System.Drawing.Size(300, 31);
            this.txbProvedor.TabIndex = 251;
            this.txbProvedor.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbProvedor_KeyUp);
            // 
            // btnAlta
            // 
            this.btnAlta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(20)))), ((int)(((byte)(27)))));
            this.btnAlta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlta.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.ForeColor = System.Drawing.Color.White;
            this.btnAlta.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAlta.Location = new System.Drawing.Point(1025, 34);
            this.btnAlta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(194, 64);
            this.btnAlta.TabIndex = 252;
            this.btnAlta.Text = "Nueva compra";
            this.btnAlta.UseVisualStyleBackColor = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // dataGridComprasMaderas
            // 
            this.dataGridComprasMaderas.AllowUserToAddRows = false;
            this.dataGridComprasMaderas.AllowUserToDeleteRows = false;
            this.dataGridComprasMaderas.AllowUserToOrderColumns = true;
            this.dataGridComprasMaderas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridComprasMaderas.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(65)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridComprasMaderas.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dataGridComprasMaderas.ColumnHeadersHeight = 60;
            this.dataGridComprasMaderas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column2,
            this.Columnm2,
            this.Stock,
            this.Column1,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7});
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.Color.Aqua;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridComprasMaderas.DefaultCellStyle = dataGridViewCellStyle14;
            this.dataGridComprasMaderas.EnableHeadersVisualStyles = false;
            this.dataGridComprasMaderas.Location = new System.Drawing.Point(21, 129);
            this.dataGridComprasMaderas.Name = "dataGridComprasMaderas";
            this.dataGridComprasMaderas.ReadOnly = true;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Century Gothic", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(217)))), ((int)(((byte)(217)))));
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridComprasMaderas.RowHeadersDefaultCellStyle = dataGridViewCellStyle15;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle16.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(178)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(25)))));
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(213)))), ((int)(((byte)(178)))), ((int)(((byte)(175)))));
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(22)))), ((int)(((byte)(25)))));
            this.dataGridComprasMaderas.RowsDefaultCellStyle = dataGridViewCellStyle16;
            this.dataGridComprasMaderas.RowTemplate.Height = 28;
            this.dataGridComprasMaderas.Size = new System.Drawing.Size(1198, 488);
            this.dataGridComprasMaderas.TabIndex = 253;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Proveedor";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Columnm2
            // 
            this.Columnm2.HeaderText = "Tipo pago";
            this.Columnm2.Name = "Columnm2";
            this.Columnm2.ReadOnly = true;
            this.Columnm2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // Stock
            // 
            this.Stock.HeaderText = "Fecha compra";
            this.Stock.Name = "Stock";
            this.Stock.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Total maderas";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Precio total";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Pago inicial";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Debo";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Entrego";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Recibio";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // buttonCancelarCompra
            // 
            this.buttonCancelarCompra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(20)))), ((int)(((byte)(27)))));
            this.buttonCancelarCompra.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCancelarCompra.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancelarCompra.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancelarCompra.ForeColor = System.Drawing.Color.White;
            this.buttonCancelarCompra.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonCancelarCompra.Location = new System.Drawing.Point(809, 34);
            this.buttonCancelarCompra.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancelarCompra.Name = "buttonCancelarCompra";
            this.buttonCancelarCompra.Size = new System.Drawing.Size(194, 64);
            this.buttonCancelarCompra.TabIndex = 256;
            this.buttonCancelarCompra.Text = "Compra a cancelar";
            this.buttonCancelarCompra.UseVisualStyleBackColor = false;
            this.buttonCancelarCompra.Click += new System.EventHandler(this.buttonCancelarCompra_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(672, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 23);
            this.label2.TabIndex = 257;
            this.label2.Text = "Seleccione la";
            // 
            // FormCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1240, 650);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonCancelarCompra);
            this.Controls.Add(this.lbrespuesta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbProvedor);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.dataGridComprasMaderas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormCompras";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)(this.dataGridComprasMaderas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbrespuesta;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbProvedor;
        public System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.DataGridView dataGridComprasMaderas;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Columnm2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Stock;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        public System.Windows.Forms.Button buttonCancelarCompra;
        private System.Windows.Forms.Label label2;
    }
}