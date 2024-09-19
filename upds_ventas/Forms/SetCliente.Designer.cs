namespace upds_ventas.Forms
{
    partial class SetCliente
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
            SetClienteSkin = new ReaLTaiizor.Forms.ForeverForm();
            BtnGuardar = new ReaLTaiizor.Controls.ForeverButtonSticky();
            gbDatosPersonales = new ReaLTaiizor.Controls.ForeverGroupBox();
            TbNombre = new ReaLTaiizor.Controls.TextBoxEdit();
            TbNit = new ReaLTaiizor.Controls.TextBoxEdit();
            TbCi = new ReaLTaiizor.Controls.TextBoxEdit();
            TbApMaterno = new ReaLTaiizor.Controls.TextBoxEdit();
            foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            TbApPaterno = new ReaLTaiizor.Controls.TextBoxEdit();
            lbCi = new ReaLTaiizor.Controls.ForeverLabel();
            lbApMaterno = new ReaLTaiizor.Controls.ForeverLabel();
            lbApPaterno = new ReaLTaiizor.Controls.ForeverLabel();
            lbNombre = new ReaLTaiizor.Controls.ForeverLabel();
            foreverClose1 = new ReaLTaiizor.Controls.ForeverClose();
            SetClienteSkin.SuspendLayout();
            gbDatosPersonales.SuspendLayout();
            SuspendLayout();
            // 
            // SetClienteSkin
            // 
            SetClienteSkin.BackColor = Color.White;
            SetClienteSkin.BaseColor = Color.FromArgb(60, 70, 73);
            SetClienteSkin.BorderColor = Color.DodgerBlue;
            SetClienteSkin.Controls.Add(foreverClose1);
            SetClienteSkin.Controls.Add(BtnGuardar);
            SetClienteSkin.Controls.Add(gbDatosPersonales);
            SetClienteSkin.Dock = DockStyle.Fill;
            SetClienteSkin.Font = new Font("Segoe UI", 12F);
            SetClienteSkin.ForeverColor = Color.FromArgb(35, 168, 109);
            SetClienteSkin.HeaderColor = Color.FromArgb(45, 47, 49);
            SetClienteSkin.HeaderMaximize = false;
            SetClienteSkin.HeaderTextFont = new Font("Segoe UI", 12F);
            SetClienteSkin.Image = null;
            SetClienteSkin.Location = new Point(0, 0);
            SetClienteSkin.MinimumSize = new Size(210, 50);
            SetClienteSkin.Name = "SetClienteSkin";
            SetClienteSkin.Padding = new Padding(1, 51, 1, 1);
            SetClienteSkin.Sizable = true;
            SetClienteSkin.Size = new Size(471, 421);
            SetClienteSkin.TabIndex = 0;
            SetClienteSkin.Text = "foreverForm1";
            SetClienteSkin.TextColor = Color.FromArgb(234, 234, 234);
            SetClienteSkin.TextLight = Color.SeaGreen;
            // 
            // BtnGuardar
            // 
            BtnGuardar.BackColor = Color.Transparent;
            BtnGuardar.BaseColor = Color.FromArgb(35, 168, 109);
            BtnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnGuardar.Location = new Point(156, 367);
            BtnGuardar.Name = "BtnGuardar";
            BtnGuardar.Rounded = false;
            BtnGuardar.Size = new Size(160, 40);
            BtnGuardar.TabIndex = 10;
            BtnGuardar.Text = "GUARDAR";
            BtnGuardar.TextColor = Color.FromArgb(243, 243, 243);
            BtnGuardar.Click += BtnGuardar_Click;
            // 
            // gbDatosPersonales
            // 
            gbDatosPersonales.ArrowColorF = Color.FromArgb(60, 70, 73);
            gbDatosPersonales.ArrowColorH = Color.FromArgb(60, 70, 73);
            gbDatosPersonales.BackColor = Color.FromArgb(45, 47, 49);
            gbDatosPersonales.BaseColor = Color.FromArgb(60, 70, 73);
            gbDatosPersonales.Controls.Add(TbNombre);
            gbDatosPersonales.Controls.Add(TbNit);
            gbDatosPersonales.Controls.Add(TbCi);
            gbDatosPersonales.Controls.Add(TbApMaterno);
            gbDatosPersonales.Controls.Add(foreverLabel1);
            gbDatosPersonales.Controls.Add(TbApPaterno);
            gbDatosPersonales.Controls.Add(lbCi);
            gbDatosPersonales.Controls.Add(lbApMaterno);
            gbDatosPersonales.Controls.Add(lbApPaterno);
            gbDatosPersonales.Controls.Add(lbNombre);
            gbDatosPersonales.Font = new Font("Segoe UI", 10F);
            gbDatosPersonales.Location = new Point(4, 54);
            gbDatosPersonales.Name = "gbDatosPersonales";
            gbDatosPersonales.ShowArrow = false;
            gbDatosPersonales.ShowText = true;
            gbDatosPersonales.Size = new Size(460, 304);
            gbDatosPersonales.TabIndex = 9;
            gbDatosPersonales.Text = "DATOS DE CLIENTE";
            gbDatosPersonales.TextColor = Color.FromArgb(35, 168, 109);
            // 
            // TbNombre
            // 
            TbNombre.BackColor = Color.Transparent;
            TbNombre.Font = new Font("Tahoma", 11F);
            TbNombre.ForeColor = Color.FromArgb(176, 183, 191);
            TbNombre.Image = null;
            TbNombre.Location = new Point(193, 45);
            TbNombre.MaxLength = 30;
            TbNombre.Multiline = false;
            TbNombre.Name = "TbNombre";
            TbNombre.ReadOnly = false;
            TbNombre.Size = new Size(240, 41);
            TbNombre.TabIndex = 0;
            TbNombre.Text = "Juan Gabriel Alejandro Treinta";
            TbNombre.TextAlignment = HorizontalAlignment.Left;
            TbNombre.UseSystemPasswordChar = false;
            // 
            // TbNit
            // 
            TbNit.BackColor = Color.Transparent;
            TbNit.Font = new Font("Lucida Console", 11F);
            TbNit.ForeColor = Color.FromArgb(176, 183, 191);
            TbNit.Image = null;
            TbNit.Location = new Point(193, 243);
            TbNit.MaxLength = 20;
            TbNit.Multiline = false;
            TbNit.Name = "TbNit";
            TbNit.ReadOnly = false;
            TbNit.Size = new Size(240, 38);
            TbNit.TabIndex = 4;
            TbNit.Text = "12345678";
            TbNit.TextAlignment = HorizontalAlignment.Left;
            TbNit.UseSystemPasswordChar = false;
            // 
            // TbCi
            // 
            TbCi.BackColor = Color.Transparent;
            TbCi.Font = new Font("Lucida Console", 11F);
            TbCi.ForeColor = Color.FromArgb(176, 183, 191);
            TbCi.Image = null;
            TbCi.Location = new Point(193, 192);
            TbCi.MaxLength = 20;
            TbCi.Multiline = false;
            TbCi.Name = "TbCi";
            TbCi.ReadOnly = false;
            TbCi.Size = new Size(240, 38);
            TbCi.TabIndex = 3;
            TbCi.Text = "12345678";
            TbCi.TextAlignment = HorizontalAlignment.Left;
            TbCi.UseSystemPasswordChar = false;
            // 
            // TbApMaterno
            // 
            TbApMaterno.BackColor = Color.Transparent;
            TbApMaterno.Font = new Font("Tahoma", 11F);
            TbApMaterno.ForeColor = Color.FromArgb(176, 183, 191);
            TbApMaterno.Image = null;
            TbApMaterno.Location = new Point(193, 143);
            TbApMaterno.MaxLength = 30;
            TbApMaterno.Multiline = false;
            TbApMaterno.Name = "TbApMaterno";
            TbApMaterno.ReadOnly = false;
            TbApMaterno.Size = new Size(240, 41);
            TbApMaterno.TabIndex = 2;
            TbApMaterno.Text = "Juan Gabriel Alejandro Treinta";
            TbApMaterno.TextAlignment = HorizontalAlignment.Left;
            TbApMaterno.UseSystemPasswordChar = false;
            // 
            // foreverLabel1
            // 
            foreverLabel1.AutoSize = true;
            foreverLabel1.BackColor = Color.Transparent;
            foreverLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            foreverLabel1.ForeColor = Color.LightGray;
            foreverLabel1.Location = new Point(28, 253);
            foreverLabel1.Name = "foreverLabel1";
            foreverLabel1.Size = new Size(41, 21);
            foreverLabel1.TabIndex = 4;
            foreverLabel1.Text = "NIT:";
            // 
            // TbApPaterno
            // 
            TbApPaterno.BackColor = Color.Transparent;
            TbApPaterno.Font = new Font("Tahoma", 11F);
            TbApPaterno.ForeColor = Color.FromArgb(176, 183, 191);
            TbApPaterno.Image = null;
            TbApPaterno.Location = new Point(193, 94);
            TbApPaterno.MaxLength = 30;
            TbApPaterno.Multiline = false;
            TbApPaterno.Name = "TbApPaterno";
            TbApPaterno.ReadOnly = false;
            TbApPaterno.Size = new Size(240, 41);
            TbApPaterno.TabIndex = 1;
            TbApPaterno.Text = "Juan Gabriel Alejandro Treinta";
            TbApPaterno.TextAlignment = HorizontalAlignment.Left;
            TbApPaterno.UseSystemPasswordChar = false;
            // 
            // lbCi
            // 
            lbCi.AutoSize = true;
            lbCi.BackColor = Color.Transparent;
            lbCi.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbCi.ForeColor = Color.LightGray;
            lbCi.Location = new Point(28, 202);
            lbCi.Name = "lbCi";
            lbCi.Size = new Size(29, 21);
            lbCi.TabIndex = 4;
            lbCi.Text = "CI:";
            // 
            // lbApMaterno
            // 
            lbApMaterno.AutoSize = true;
            lbApMaterno.BackColor = Color.Transparent;
            lbApMaterno.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbApMaterno.ForeColor = Color.LightGray;
            lbApMaterno.Location = new Point(28, 153);
            lbApMaterno.Name = "lbApMaterno";
            lbApMaterno.Size = new Size(148, 21);
            lbApMaterno.TabIndex = 4;
            lbApMaterno.Text = "Apellido Materno:";
            // 
            // lbApPaterno
            // 
            lbApPaterno.AutoSize = true;
            lbApPaterno.BackColor = Color.Transparent;
            lbApPaterno.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbApPaterno.ForeColor = Color.LightGray;
            lbApPaterno.Location = new Point(28, 104);
            lbApPaterno.Name = "lbApPaterno";
            lbApPaterno.Size = new Size(143, 21);
            lbApPaterno.TabIndex = 4;
            lbApPaterno.Text = "Apellido Paterno:";
            // 
            // lbNombre
            // 
            lbNombre.AutoSize = true;
            lbNombre.BackColor = Color.Transparent;
            lbNombre.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbNombre.ForeColor = Color.LightGray;
            lbNombre.Location = new Point(28, 55);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(77, 21);
            lbNombre.TabIndex = 4;
            lbNombre.Text = "Nombre:";
            // 
            // foreverClose1
            // 
            foreverClose1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            foreverClose1.BackColor = Color.White;
            foreverClose1.BaseColor = Color.FromArgb(45, 47, 49);
            foreverClose1.DefaultLocation = true;
            foreverClose1.DownColor = Color.FromArgb(30, 0, 0, 0);
            foreverClose1.Font = new Font("Marlett", 10F);
            foreverClose1.Location = new Point(441, 17);
            foreverClose1.Name = "foreverClose1";
            foreverClose1.OverColor = Color.FromArgb(30, 255, 255, 255);
            foreverClose1.Size = new Size(18, 18);
            foreverClose1.TabIndex = 11;
            foreverClose1.Text = "foreverClose1";
            foreverClose1.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // SetCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 421);
            Controls.Add(SetClienteSkin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SetCliente";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SetCliente";
            TransparencyKey = Color.Fuchsia;
            SetClienteSkin.ResumeLayout(false);
            gbDatosPersonales.ResumeLayout(false);
            gbDatosPersonales.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm SetClienteSkin;
        private ReaLTaiizor.Controls.ForeverButtonSticky BtnGuardar;
        private ReaLTaiizor.Controls.ForeverGroupBox gbDatosPersonales;
        private ReaLTaiizor.Controls.TextBoxEdit TbNombre;
        private ReaLTaiizor.Controls.TextBoxEdit TbCi;
        private ReaLTaiizor.Controls.TextBoxEdit TbApMaterno;
        private ReaLTaiizor.Controls.TextBoxEdit TbApPaterno;
        private ReaLTaiizor.Controls.ForeverLabel lbCi;
        private ReaLTaiizor.Controls.ForeverLabel lbApMaterno;
        private ReaLTaiizor.Controls.ForeverLabel lbApPaterno;
        private ReaLTaiizor.Controls.ForeverLabel lbNombre;
        private ReaLTaiizor.Controls.TextBoxEdit TbNit;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.ForeverClose foreverClose1;
    }
}