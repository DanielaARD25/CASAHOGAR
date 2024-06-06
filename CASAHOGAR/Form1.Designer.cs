namespace CASAHOGAR
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.lblTitulo = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.txtContrasena = new System.Windows.Forms.TextBox();
            this.lblContrtaseña = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnIngresar = new CASAHOGAR.Botones();
            this.botones2 = new CASAHOGAR.Botones();
            this.btnIngresar2 = new CASAHOGAR.Botones();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Work Sans SemiBold", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(445, 78);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(181, 39);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "¡Bienvenido!";
            this.lblTitulo.Click += new System.EventHandler(this.lblTitulo_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuario.Font = new System.Drawing.Font("Work Sans", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuario.Location = new System.Drawing.Point(428, 177);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(222, 22);
            this.txtUsuario.TabIndex = 4;
            // 
            // txtContrasena
            // 
            this.txtContrasena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtContrasena.Font = new System.Drawing.Font("Work Sans", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtContrasena.Location = new System.Drawing.Point(428, 241);
            this.txtContrasena.Margin = new System.Windows.Forms.Padding(2);
            this.txtContrasena.Name = "txtContrasena";
            this.txtContrasena.PasswordChar = '*';
            this.txtContrasena.Size = new System.Drawing.Size(222, 22);
            this.txtContrasena.TabIndex = 5;
            // 
            // lblContrtaseña
            // 
            this.lblContrtaseña.AutoSize = true;
            this.lblContrtaseña.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContrtaseña.Location = new System.Drawing.Point(424, 217);
            this.lblContrtaseña.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblContrtaseña.Name = "lblContrtaseña";
            this.lblContrtaseña.Size = new System.Drawing.Size(94, 22);
            this.lblContrtaseña.TabIndex = 3;
            this.lblContrtaseña.Text = "Contraseña";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Work Sans", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuario.Location = new System.Drawing.Point(424, 153);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(150, 22);
            this.lblUsuario.TabIndex = 2;
            this.lblUsuario.Text = "Nombre de usuario";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(183)))), ((int)(((byte)(48)))));
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(355, 441);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(225)))), ((int)(((byte)(175)))));
            this.btnIngresar.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(225)))), ((int)(((byte)(175)))));
            this.btnIngresar.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnIngresar.BorderRadius = 20;
            this.btnIngresar.BorderSize = 0;
            this.btnIngresar.FlatAppearance.BorderSize = 0;
            this.btnIngresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar.Font = new System.Drawing.Font("Work Sans", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.ForeColor = System.Drawing.Color.Black;
            this.btnIngresar.Location = new System.Drawing.Point(466, 283);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(150, 36);
            this.btnIngresar.TabIndex = 6;
            this.btnIngresar.Text = "Iniciar sesión";
            this.btnIngresar.TextColor = System.Drawing.Color.Black;
            this.btnIngresar.UseVisualStyleBackColor = false;
            // 
            // botones2
            // 
            this.botones2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(225)))), ((int)(((byte)(175)))));
            this.botones2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(225)))), ((int)(((byte)(175)))));
            this.botones2.BackgroundImage = global::CASAHOGAR.Properties.Resources.cerrar_sesion1;
            this.botones2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.botones2.BorderColor = System.Drawing.Color.Transparent;
            this.botones2.BorderRadius = 20;
            this.botones2.BorderSize = 0;
            this.botones2.FlatAppearance.BorderSize = 0;
            this.botones2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.botones2.ForeColor = System.Drawing.Color.White;
            this.botones2.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.botones2.Location = new System.Drawing.Point(628, 394);
            this.botones2.Name = "botones2";
            this.botones2.Size = new System.Drawing.Size(84, 35);
            this.botones2.TabIndex = 9;
            this.botones2.TextColor = System.Drawing.Color.White;
            this.botones2.UseVisualStyleBackColor = false;
            // 
            // btnIngresar2
            // 
            this.btnIngresar2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(225)))), ((int)(((byte)(175)))));
            this.btnIngresar2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(199)))), ((int)(((byte)(225)))), ((int)(((byte)(175)))));
            this.btnIngresar2.BorderColor = System.Drawing.Color.PaleVioletRed;
            this.btnIngresar2.BorderRadius = 20;
            this.btnIngresar2.BorderSize = 0;
            this.btnIngresar2.FlatAppearance.BorderSize = 0;
            this.btnIngresar2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIngresar2.Font = new System.Drawing.Font("Work Sans", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar2.ForeColor = System.Drawing.Color.Black;
            this.btnIngresar2.Location = new System.Drawing.Point(462, 277);
            this.btnIngresar2.Name = "btnIngresar2";
            this.btnIngresar2.Size = new System.Drawing.Size(150, 40);
            this.btnIngresar2.TabIndex = 9;
            this.btnIngresar2.Text = "Iniciar sesión";
            this.btnIngresar2.TextColor = System.Drawing.Color.Black;
            this.btnIngresar2.UseVisualStyleBackColor = false;
            this.btnIngresar2.Click += new System.EventHandler(this.btnIngresar2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(724, 441);
            this.Controls.Add(this.btnIngresar2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtContrasena);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblContrtaseña);
            this.Controls.Add(this.lblUsuario);
            this.Controls.Add(this.lblTitulo);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesión";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtContrasena;
        private Botones btnIngresar;
        private System.Windows.Forms.Label lblContrtaseña;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Panel panel1;
        private Botones botones2;
        private Botones btnIngresar2;
    }
}

