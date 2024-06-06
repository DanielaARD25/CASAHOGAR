namespace CASAHOGAR
{
    partial class AgregarUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarUsuarios));
            this.txtConttrasenaUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNombreUsuario = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbxEsAdministrador = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.botones1 = new CASAHOGAR.Botones();
            this.btnAgregar = new CASAHOGAR.Botones();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtConttrasenaUsuario
            // 
            this.txtConttrasenaUsuario.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConttrasenaUsuario.Location = new System.Drawing.Point(196, 161);
            this.txtConttrasenaUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtConttrasenaUsuario.MaxLength = 10;
            this.txtConttrasenaUsuario.Name = "txtConttrasenaUsuario";
            this.txtConttrasenaUsuario.Size = new System.Drawing.Size(164, 25);
            this.txtConttrasenaUsuario.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(181, 22);
            this.label2.TabIndex = 32;
            this.label2.Text = "Contraseña del usuario:";
            // 
            // txtNombreUsuario
            // 
            this.txtNombreUsuario.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombreUsuario.Location = new System.Drawing.Point(196, 116);
            this.txtNombreUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreUsuario.MaxLength = 10;
            this.txtNombreUsuario.Name = "txtNombreUsuario";
            this.txtNombreUsuario.Size = new System.Drawing.Size(195, 25);
            this.txtNombreUsuario.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(30, 119);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 22);
            this.label1.TabIndex = 30;
            this.label1.Text = "Nombre del usuario: ";
            // 
            // cbxEsAdministrador
            // 
            this.cbxEsAdministrador.AutoSize = true;
            this.cbxEsAdministrador.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxEsAdministrador.Location = new System.Drawing.Point(196, 211);
            this.cbxEsAdministrador.Name = "cbxEsAdministrador";
            this.cbxEsAdministrador.Size = new System.Drawing.Size(131, 26);
            this.cbxEsAdministrador.TabIndex = 3;
            this.cbxEsAdministrador.Text = "Administrador";
            this.cbxEsAdministrador.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::CASAHOGAR.Properties.Resources.Captura_de_pantalla_2024_05_05_171035;
            this.pictureBox1.Location = new System.Drawing.Point(7, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(52, 53);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 87;
            this.pictureBox1.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Work Sans SemiBold", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(64, 18);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(189, 30);
            this.label5.TabIndex = 86;
            this.label5.Text = "Agregar Usuarios";
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
            this.botones1.Location = new System.Drawing.Point(338, 283);
            this.botones1.Name = "botones1";
            this.botones1.Size = new System.Drawing.Size(76, 43);
            this.botones1.TabIndex = 5;
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
            this.btnAgregar.Location = new System.Drawing.Point(241, 283);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(91, 43);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextColor = System.Drawing.Color.Black;
            this.btnAgregar.UseVisualStyleBackColor = false;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = global::CASAHOGAR.Properties.Resources.Captura_de_pantalla_2024_05_05_173552;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(420, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 363);
            this.panel1.TabIndex = 83;
            // 
            // AgregarUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(249)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(687, 363);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.botones1);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.cbxEsAdministrador);
            this.Controls.Add(this.txtConttrasenaUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombreUsuario);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "AgregarUsuarios";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agregar Usuarios";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtConttrasenaUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombreUsuario;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cbxEsAdministrador;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label5;
        private Botones botones1;
        private Botones btnAgregar;
        private System.Windows.Forms.Panel panel1;
    }
}