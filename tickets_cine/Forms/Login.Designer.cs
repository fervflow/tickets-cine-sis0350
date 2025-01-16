namespace tickets_cine.Forms
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
            btnLogin = new ReaLTaiizor.Controls.ForeverButton();
            lbPass = new ReaLTaiizor.Controls.ForeverLabel();
            lbUsuario = new ReaLTaiizor.Controls.ForeverLabel();
            TbPass = new ReaLTaiizor.Controls.ForeverTextBox();
            TbUsuario = new ReaLTaiizor.Controls.ForeverTextBox();
            btnClose = new ReaLTaiizor.Controls.ForeverClose();
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
            formLogin.Controls.Add(TbPass);
            formLogin.Controls.Add(TbUsuario);
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
            // btnLogin
            // 
            btnLogin.BackColor = Color.Transparent;
            btnLogin.BaseColor = Color.FromArgb(35, 168, 109);
            btnLogin.Font = new Font("Segoe UI", 12F);
            btnLogin.Location = new Point(39, 295);
            btnLogin.Name = "btnLogin";
            btnLogin.Rounded = false;
            btnLogin.Size = new Size(246, 40);
            btnLogin.TabIndex = 2;
            btnLogin.Text = "INGRESAR";
            btnLogin.TextColor = Color.FromArgb(243, 243, 243);
            btnLogin.Click += btnLogin_Click;
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
            // TbPass
            // 
            TbPass.BackColor = Color.Transparent;
            TbPass.BaseColor = Color.FromArgb(45, 47, 49);
            TbPass.BorderColor = Color.FromArgb(35, 168, 109);
            TbPass.FocusOnHover = false;
            TbPass.ForeColor = Color.FromArgb(192, 192, 192);
            TbPass.Location = new Point(39, 192);
            TbPass.MaxLength = 32767;
            TbPass.Multiline = false;
            TbPass.Name = "TbPass";
            TbPass.ReadOnly = false;
            TbPass.Size = new Size(246, 29);
            TbPass.TabIndex = 1;
            TbPass.TextAlign = HorizontalAlignment.Left;
            TbPass.UseSystemPasswordChar = true;
            // 
            // TbUsuario
            // 
            TbUsuario.BackColor = Color.Transparent;
            TbUsuario.BaseColor = Color.FromArgb(45, 47, 49);
            TbUsuario.BorderColor = Color.FromArgb(35, 168, 109);
            TbUsuario.FocusOnHover = false;
            TbUsuario.ForeColor = Color.FromArgb(192, 192, 192);
            TbUsuario.Location = new Point(39, 116);
            TbUsuario.MaxLength = 32767;
            TbUsuario.Multiline = false;
            TbUsuario.Name = "TbUsuario";
            TbUsuario.ReadOnly = false;
            TbUsuario.Size = new Size(246, 29);
            TbUsuario.TabIndex = 0;
            TbUsuario.TextAlign = HorizontalAlignment.Left;
            TbUsuario.UseSystemPasswordChar = false;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnClose.BackColor = Color.White;
            btnClose.BaseColor = Color.FromArgb(45, 47, 49);
            btnClose.DefaultLocation = true;
            btnClose.DownColor = Color.FromArgb(30, 0, 0, 0);
            btnClose.Font = new Font("Marlett", 10F);
            btnClose.Location = new Point(294, 16);
            btnClose.Name = "btnClose";
            btnClose.OverColor = Color.FromArgb(30, 255, 255, 255);
            btnClose.Size = new Size(18, 18);
            btnClose.TabIndex = 0;
            btnClose.Text = "foreverClose1";
            btnClose.TextColor = Color.FromArgb(243, 243, 243);
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
        private ReaLTaiizor.Controls.ForeverTextBox TbUsuario;
        private ReaLTaiizor.Controls.ForeverButton btnLogin;
        private ReaLTaiizor.Controls.ForeverLabel lbPass;
        private ReaLTaiizor.Controls.ForeverTextBox TbPass;
    }
}