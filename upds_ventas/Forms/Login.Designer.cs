namespace upds_ventas.Forms
{
    partial class Login
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
            formLogin = new ReaLTaiizor.Forms.ForeverForm();
            btnClose = new ReaLTaiizor.Controls.ForeverClose();
            tbUsuario = new ReaLTaiizor.Controls.ForeverTextBox();
            lbUsuario = new ReaLTaiizor.Controls.ForeverLabel();
            tbPass = new ReaLTaiizor.Controls.ForeverTextBox();
            lbPass = new ReaLTaiizor.Controls.ForeverLabel();
            btnLogin = new ReaLTaiizor.Controls.ForeverButton();
            formLogin.SuspendLayout();
            SuspendLayout();
            // 
            // formLogin
            // 
            formLogin.BackColor = Color.White;
            formLogin.BaseColor = Color.FromArgb(60, 70, 73);
            formLogin.BorderColor = Color.DodgerBlue;
            formLogin.Controls.Add(btnLogin);
            formLogin.Controls.Add(lbPass);
            formLogin.Controls.Add(lbUsuario);
            formLogin.Controls.Add(tbPass);
            formLogin.Controls.Add(tbUsuario);
            formLogin.Controls.Add(btnClose);
            formLogin.Dock = DockStyle.Fill;
            formLogin.Font = new Font("Segoe UI", 12F);
            formLogin.ForeverColor = Color.FromArgb(35, 168, 109);
            formLogin.HeaderColor = Color.FromArgb(45, 47, 49);
            formLogin.HeaderMaximize = false;
            formLogin.HeaderTextFont = new Font("Segoe UI", 12F);
            formLogin.Image = null;
            formLogin.Location = new Point(0, 0);
            formLogin.MinimumSize = new Size(210, 50);
            formLogin.Name = "formLogin";
            formLogin.Padding = new Padding(1, 51, 1, 1);
            formLogin.Sizable = true;
            formLogin.Size = new Size(324, 361);
            formLogin.TabIndex = 0;
            formLogin.Text = "INICIAR SESIÓN";
            formLogin.TextColor = Color.FromArgb(234, 234, 234);
            formLogin.TextLight = Color.SeaGreen;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.White;
            btnClose.BaseColor = Color.FromArgb(45, 47, 49);
            btnClose.DefaultLocation = true;
            btnClose.DownColor = Color.FromArgb(30, 0, 0, 0);
            btnClose.Font = new Font("Marlett", 10F);
            btnClose.Location = new Point(294, 17);
            btnClose.Name = "btnClose";
            btnClose.OverColor = Color.FromArgb(30, 255, 255, 255);
            btnClose.Size = new Size(18, 18);
            btnClose.TabIndex = 0;
            btnClose.Text = "foreverClose1";
            btnClose.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // tbUsuario
            // 
            tbUsuario.BackColor = Color.Transparent;
            tbUsuario.BaseColor = Color.FromArgb(45, 47, 49);
            tbUsuario.BorderColor = Color.FromArgb(35, 168, 109);
            tbUsuario.FocusOnHover = false;
            tbUsuario.ForeColor = Color.FromArgb(192, 192, 192);
            tbUsuario.Location = new Point(39, 116);
            tbUsuario.MaxLength = 32767;
            tbUsuario.Multiline = false;
            tbUsuario.Name = "tbUsuario";
            tbUsuario.ReadOnly = false;
            tbUsuario.Size = new Size(246, 29);
            tbUsuario.TabIndex = 1;
            tbUsuario.TextAlign = HorizontalAlignment.Left;
            tbUsuario.UseSystemPasswordChar = false;
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.BackColor = Color.Transparent;
            lbUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbUsuario.ForeColor = Color.LightGray;
            lbUsuario.Location = new Point(39, 92);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(73, 21);
            lbUsuario.TabIndex = 2;
            lbUsuario.Text = "Usuario:";
            // 
            // tbPass
            // 
            tbPass.BackColor = Color.Transparent;
            tbPass.BaseColor = Color.FromArgb(45, 47, 49);
            tbPass.BorderColor = Color.FromArgb(35, 168, 109);
            tbPass.FocusOnHover = false;
            tbPass.ForeColor = Color.FromArgb(192, 192, 192);
            tbPass.Location = new Point(39, 192);
            tbPass.MaxLength = 32767;
            tbPass.Multiline = false;
            tbPass.Name = "tbPass";
            tbPass.ReadOnly = false;
            tbPass.Size = new Size(246, 29);
            tbPass.TabIndex = 1;
            tbPass.TextAlign = HorizontalAlignment.Left;
            tbPass.UseSystemPasswordChar = true;
            // 
            // lbPass
            // 
            lbPass.AutoSize = true;
            lbPass.BackColor = Color.Transparent;
            lbPass.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbPass.ForeColor = Color.LightGray;
            lbPass.Location = new Point(39, 168);
            lbPass.Name = "lbPass";
            lbPass.Size = new Size(100, 21);
            lbPass.TabIndex = 2;
            lbPass.Text = "Contraseña:";
            // 
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BaseColor = Color.FromArgb(35, 168, 109);
            btnLogin.Font = new Font("Segoe UI", 12F);
            btnLogin.Location = new Point(39, 295);
            btnLogin.Name = "btnLogin";
            btnLogin.Rounded = false;
            btnLogin.Size = new Size(246, 40);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "INGRESAR";
            btnLogin.TextColor = Color.FromArgb(243, 243, 243);
            btnLogin.Click += btnLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(324, 361);
            Controls.Add(formLogin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Iniciar Sesión";
            TransparencyKey = Color.Fuchsia;
            formLogin.ResumeLayout(false);
            formLogin.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm formLogin;
        private ReaLTaiizor.Controls.ForeverClose btnClose;
        private ReaLTaiizor.Controls.ForeverLabel lbUsuario;
        private ReaLTaiizor.Controls.ForeverTextBox tbUsuario;
        private ReaLTaiizor.Controls.ForeverButton btnLogin;
        private ReaLTaiizor.Controls.ForeverLabel lbPass;
        private ReaLTaiizor.Controls.ForeverTextBox tbPass;
    }
}