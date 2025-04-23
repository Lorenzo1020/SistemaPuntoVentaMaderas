
namespace SistemaPuntoVentaMaderas
{
    partial class FormInventarioMaderas
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
            this.Piezas = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.richTxbDescripcion = new System.Windows.Forms.RichTextBox();
            this.texBoxNombreMadera = new System.Windows.Forms.TextBox();
            this.texBoxStock = new System.Windows.Forms.TextBox();
            this.txbQuitar = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.texBoxAgregar = new System.Windows.Forms.TextBox();
            this.buttonBuscarNombre = new System.Windows.Forms.Button();
            this.comboBoxAgregarQuitar = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Piezas
            // 
            this.Piezas.AutoSize = true;
            this.Piezas.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Piezas.ForeColor = System.Drawing.Color.Black;
            this.Piezas.Location = new System.Drawing.Point(529, 272);
            this.Piezas.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Piezas.Name = "Piezas";
            this.Piezas.Size = new System.Drawing.Size(70, 23);
            this.Piezas.TabIndex = 268;
            this.Piezas.Text = "piezas";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(20)))), ((int)(((byte)(27)))));
            this.btnGuardar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGuardar.Enabled = false;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGuardar.Location = new System.Drawing.Point(533, 459);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(162, 81);
            this.btnGuardar.TabIndex = 259;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // richTxbDescripcion
            // 
            this.richTxbDescripcion.Enabled = false;
            this.richTxbDescripcion.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.richTxbDescripcion.Location = new System.Drawing.Point(308, 175);
            this.richTxbDescripcion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.richTxbDescripcion.Name = "richTxbDescripcion";
            this.richTxbDescripcion.Size = new System.Drawing.Size(387, 74);
            this.richTxbDescripcion.TabIndex = 267;
            this.richTxbDescripcion.Text = "";
            // 
            // texBoxNombreMadera
            // 
            this.texBoxNombreMadera.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texBoxNombreMadera.Location = new System.Drawing.Point(308, 39);
            this.texBoxNombreMadera.Name = "texBoxNombreMadera";
            this.texBoxNombreMadera.Size = new System.Drawing.Size(387, 31);
            this.texBoxNombreMadera.TabIndex = 257;
            this.texBoxNombreMadera.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.texBoxNombreMadera.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texBoxNombreMadera_KeyPress_1);
            // 
            // texBoxStock
            // 
            this.texBoxStock.Enabled = false;
            this.texBoxStock.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texBoxStock.Location = new System.Drawing.Point(308, 268);
            this.texBoxStock.Name = "texBoxStock";
            this.texBoxStock.Size = new System.Drawing.Size(197, 31);
            this.texBoxStock.TabIndex = 266;
            this.texBoxStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txbQuitar
            // 
            this.txbQuitar.Enabled = false;
            this.txbQuitar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txbQuitar.Location = new System.Drawing.Point(308, 509);
            this.txbQuitar.Name = "txbQuitar";
            this.txbQuitar.Size = new System.Drawing.Size(197, 31);
            this.txbQuitar.TabIndex = 258;
            this.txbQuitar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txbQuitar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbQuitar_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(236, 513);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 23);
            this.label5.TabIndex = 265;
            this.label5.Text = "Quitar";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(216, 463);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 23);
            this.label4.TabIndex = 264;
            this.label4.Text = "Agregar";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(139, 272);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(164, 23);
            this.label3.TabIndex = 263;
            this.label3.Text = "Cantidad actual";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(51, 201);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 23);
            this.label2.TabIndex = 262;
            this.label2.Text = "Descripción de la madera";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(69, 43);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(234, 23);
            this.label1.TabIndex = 261;
            this.label1.Text = "Ingrese nombre madera";
            // 
            // texBoxAgregar
            // 
            this.texBoxAgregar.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.texBoxAgregar.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.texBoxAgregar.Enabled = false;
            this.texBoxAgregar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.texBoxAgregar.Location = new System.Drawing.Point(308, 459);
            this.texBoxAgregar.Name = "texBoxAgregar";
            this.texBoxAgregar.Size = new System.Drawing.Size(197, 31);
            this.texBoxAgregar.TabIndex = 260;
            this.texBoxAgregar.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.texBoxAgregar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.texBoxAgregar_KeyPress);
            // 
            // buttonBuscarNombre
            // 
            this.buttonBuscarNombre.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(143)))), ((int)(((byte)(20)))), ((int)(((byte)(27)))));
            this.buttonBuscarNombre.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonBuscarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBuscarNombre.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBuscarNombre.ForeColor = System.Drawing.Color.White;
            this.buttonBuscarNombre.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBuscarNombre.Location = new System.Drawing.Point(308, 88);
            this.buttonBuscarNombre.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonBuscarNombre.Name = "buttonBuscarNombre";
            this.buttonBuscarNombre.Size = new System.Drawing.Size(197, 43);
            this.buttonBuscarNombre.TabIndex = 269;
            this.buttonBuscarNombre.Text = "Buscar";
            this.buttonBuscarNombre.UseVisualStyleBackColor = false;
            this.buttonBuscarNombre.Click += new System.EventHandler(this.buttonBuscarNombre_Click);
            // 
            // comboBoxAgregarQuitar
            // 
            this.comboBoxAgregarQuitar.BackColor = System.Drawing.Color.White;
            this.comboBoxAgregarQuitar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAgregarQuitar.Enabled = false;
            this.comboBoxAgregarQuitar.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxAgregarQuitar.FormattingEnabled = true;
            this.comboBoxAgregarQuitar.Items.AddRange(new object[] {
            "Agregar madera",
            "Quitar madera"});
            this.comboBoxAgregarQuitar.Location = new System.Drawing.Point(308, 353);
            this.comboBoxAgregarQuitar.Name = "comboBoxAgregarQuitar";
            this.comboBoxAgregarQuitar.Size = new System.Drawing.Size(387, 31);
            this.comboBoxAgregarQuitar.TabIndex = 271;
            this.comboBoxAgregarQuitar.SelectedIndexChanged += new System.EventHandler(this.comboBoxAgregarQuitar_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(80, 357);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(223, 23);
            this.label6.TabIndex = 270;
            this.label6.Text = "Seleccione una opción";
            // 
            // FormInventarioMaderas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(769, 599);
            this.Controls.Add(this.comboBoxAgregarQuitar);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.buttonBuscarNombre);
            this.Controls.Add(this.Piezas);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.richTxbDescripcion);
            this.Controls.Add(this.texBoxNombreMadera);
            this.Controls.Add(this.texBoxStock);
            this.Controls.Add(this.txbQuitar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.texBoxAgregar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormInventarioMaderas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Piezas;
        public System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.RichTextBox richTxbDescripcion;
        private System.Windows.Forms.TextBox texBoxNombreMadera;
        private System.Windows.Forms.TextBox texBoxStock;
        private System.Windows.Forms.TextBox txbQuitar;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox texBoxAgregar;
        public System.Windows.Forms.Button buttonBuscarNombre;
        private System.Windows.Forms.ComboBox comboBoxAgregarQuitar;
        private System.Windows.Forms.Label label6;
    }
}