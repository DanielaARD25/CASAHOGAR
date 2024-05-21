namespace CASAHOGAR
{
    partial class AgregarDonacion
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
            this.label3 = new System.Windows.Forms.Label();
            this.txtCantidadDonada = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProductoDonado = new System.Windows.Forms.TextBox();
            this.dtpFechaDonacion = new System.Windows.Forms.DateTimePicker();
            this.Donante = new System.Windows.Forms.Label();
            this.cbxNombreDonante = new System.Windows.Forms.ComboBox();
            this.cbxIdDonante = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.botones1 = new CASAHOGAR.Botones();
            this.btnAgregar = new CASAHOGAR.Botones();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(40, 147);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(126, 22);
            this.label3.TabIndex = 12;
            this.label3.Text = "Fecha donación:";
            // 
            // txtCantidadDonada
            // 
            this.txtCantidadDonada.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCantidadDonada.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantidadDonada.Location = new System.Drawing.Point(170, 110);
            this.txtCantidadDonada.Margin = new System.Windows.Forms.Padding(2);
            this.txtCantidadDonada.Name = "txtCantidadDonada";
            this.txtCantidadDonada.Size = new System.Drawing.Size(168, 25);
            this.txtCantidadDonada.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 112);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 22);
            this.label2.TabIndex = 10;
            this.label2.Text = "Cantidad donada:";
            // 
            // txtProductoDonado
            // 
            this.txtProductoDonado.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProductoDonado.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtProductoDonado.Location = new System.Drawing.Point(170, 73);
            this.txtProductoDonado.Margin = new System.Windows.Forms.Padding(2);
            this.txtProductoDonado.Name = "txtProductoDonado";
            this.txtProductoDonado.Size = new System.Drawing.Size(168, 25);
            this.txtProductoDonado.TabIndex = 9;
            // 
            // dtpFechaDonacion
            // 
            this.dtpFechaDonacion.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFechaDonacion.Location = new System.Drawing.Point(170, 146);
            this.dtpFechaDonacion.Margin = new System.Windows.Forms.Padding(2);
            this.dtpFechaDonacion.Name = "dtpFechaDonacion";
            this.dtpFechaDonacion.Size = new System.Drawing.Size(208, 25);
            this.dtpFechaDonacion.TabIndex = 13;
            // 
            // Donante
            // 
            this.Donante.AutoSize = true;
            this.Donante.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Donante.Location = new System.Drawing.Point(91, 226);
            this.Donante.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.Donante.Name = "Donante";
            this.Donante.Size = new System.Drawing.Size(75, 22);
            this.Donante.TabIndex = 60;
            this.Donante.Text = "Donante:";
            // 
            // cbxNombreDonante
            // 
            this.cbxNombreDonante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxNombreDonante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxNombreDonante.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxNombreDonante.FormattingEnabled = true;
            this.cbxNombreDonante.Location = new System.Drawing.Point(170, 218);
            this.cbxNombreDonante.Name = "cbxNombreDonante";
            this.cbxNombreDonante.Size = new System.Drawing.Size(121, 30);
            this.cbxNombreDonante.TabIndex = 61;
            this.cbxNombreDonante.SelectedIndexChanged += new System.EventHandler(this.cbxNombreDonante_SelectedIndexChanged);
            // 
            // cbxIdDonante
            // 
            this.cbxIdDonante.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxIdDonante.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxIdDonante.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxIdDonante.FormattingEnabled = true;
            this.cbxIdDonante.Location = new System.Drawing.Point(170, 182);
            this.cbxIdDonante.Name = "cbxIdDonante";
            this.cbxIdDonante.Size = new System.Drawing.Size(56, 30);
            this.cbxIdDonante.TabIndex = 62;
            this.cbxIdDonante.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CASAHOGAR.Properties.Resources.Captura_de_pantalla_2024_05_05_162742;
            this.pictureBox1.Location = new System.Drawing.Point(6, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(51, 50);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 77;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Work Sans SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(62, 21);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(219, 30);
            this.label5.TabIndex = 76;
            this.label5.Text = "Agregar Donaciones";
            // 
            // botones1
            // 
            this.botones1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.botones1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.botones1.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.botones1.BorderRadius = 20;
            this.botones1.BorderSize = 0;
            this.botones1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.botones1.FlatAppearance.BorderSize = 0;
            this.botones1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(225)))), ((int)(((byte)(175)))));
            this.botones1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(225)))), ((int)(((byte)(175)))));
            this.botones1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botones1.Font = new System.Drawing.Font("Work Sans Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.botones1.ForeColor = System.Drawing.Color.Black;
            this.botones1.Location = new System.Drawing.Point(330, 254);
            this.botones1.Name = "botones1";
            this.botones1.Size = new System.Drawing.Size(76, 43);
            this.botones1.TabIndex = 75;
            this.botones1.Text = "Salir";
            this.botones1.TextColor = System.Drawing.Color.Black;
            this.botones1.UseVisualStyleBackColor = false;
            this.botones1.Click += new System.EventHandler(this.botones1_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.btnAgregar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(236)))), ((int)(((byte)(231)))), ((int)(((byte)(231)))));
            this.btnAgregar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnAgregar.BorderRadius = 20;
            this.btnAgregar.BorderSize = 0;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(225)))), ((int)(((byte)(175)))));
            this.btnAgregar.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(225)))), ((int)(((byte)(175)))));
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Font = new System.Drawing.Font("Work Sans Medium", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregar.ForeColor = System.Drawing.Color.Black;
            this.btnAgregar.Location = new System.Drawing.Point(220, 254);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(91, 43);
            this.btnAgregar.TabIndex = 74;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextColor = System.Drawing.Color.Black;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::CASAHOGAR.Properties.Resources.Captura_de_pantalla_2024_05_05_163057;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(412, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(182, 309);
            this.panel1.TabIndex = 73;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(29, 76);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(137, 22);
            this.label4.TabIndex = 78;
            this.label4.Text = "Producto donado:";
            // 
            // AgregarDonacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(594, 309);
            this.ControlBox = false;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.botones1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbxIdDonante);
            this.Controls.Add(this.cbxNombreDonante);
            this.Controls.Add(this.Donante);
            this.Controls.Add(this.dtpFechaDonacion);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtCantidadDonada);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtProductoDonado);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AgregarDonacion";
            this.ShowIcon = false;
            this.Text = "Agregar Donacion";
            this.Load += new System.EventHandler(this.AgregarDonacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCantidadDonada;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtProductoDonado;
        private System.Windows.Forms.DateTimePicker dtpFechaDonacion;
        private System.Windows.Forms.Label Donante;
        private System.Windows.Forms.ComboBox cbxNombreDonante;
        private System.Windows.Forms.ComboBox cbxIdDonante;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private Botones botones1;
        private Botones btnAgregar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
    }
}