namespace upds_ventas.Forms
{
    partial class SetProveedor
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
            FormTitle = new ReaLTaiizor.Forms.ForeverForm();
            foreverClose1 = new ReaLTaiizor.Controls.ForeverClose();
            btnGuardar = new ReaLTaiizor.Controls.ForeverButtonSticky();
            gbDatosUsuario = new ReaLTaiizor.Controls.ForeverGroupBox();
            CbCiudad = new ReaLTaiizor.Controls.ForeverComboBox();
            TbTelefono = new ReaLTaiizor.Controls.TextBoxEdit();
            TbNit = new ReaLTaiizor.Controls.TextBoxEdit();
            TbDireccion = new ReaLTaiizor.Controls.TextBoxEdit();
            TbNombre = new ReaLTaiizor.Controls.TextBoxEdit();
            foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            lbTipo = new ReaLTaiizor.Controls.ForeverLabel();
            foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            lbPass = new ReaLTaiizor.Controls.ForeverLabel();
            lbUsuario = new ReaLTaiizor.Controls.ForeverLabel();
            FormTitle.SuspendLayout();
            gbDatosUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // FormTitle
            // 
            FormTitle.BackColor = Color.White;
            FormTitle.BaseColor = Color.FromArgb(60, 70, 73);
            FormTitle.BorderColor = Color.DodgerBlue;
            FormTitle.Controls.Add(foreverClose1);
            FormTitle.Controls.Add(btnGuardar);
            FormTitle.Controls.Add(gbDatosUsuario);
            FormTitle.Dock = DockStyle.Fill;
            FormTitle.Font = new Font("Segoe UI", 12F);
            FormTitle.ForeverColor = Color.FromArgb(35, 168, 109);
            FormTitle.HeaderColor = Color.FromArgb(45, 47, 49);
            FormTitle.HeaderMaximize = false;
            FormTitle.HeaderTextFont = new Font("Segoe UI", 12F);
            FormTitle.Image = null;
            FormTitle.Location = new Point(0, 0);
            FormTitle.MinimumSize = new Size(210, 50);
            FormTitle.Name = "FormTitle";
            FormTitle.Padding = new Padding(1, 51, 1, 1);
            FormTitle.Sizable = true;
            FormTitle.Size = new Size(471, 404);
            FormTitle.TabIndex = 0;
            FormTitle.Text = "foreverForm1";
            FormTitle.TextColor = Color.FromArgb(234, 234, 234);
            FormTitle.TextLight = Color.SeaGreen;
            // 
            // foreverClose1
            // 
            foreverClose1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            foreverClose1.BackColor = Color.White;
            foreverClose1.BaseColor = Color.FromArgb(45, 47, 49);
            foreverClose1.DefaultLocation = true;
            foreverClose1.DownColor = Color.FromArgb(30, 0, 0, 0);
            foreverClose1.Font = new Font("Marlett", 10F);
            foreverClose1.Location = new Point(441, 16);
            foreverClose1.Name = "foreverClose1";
            foreverClose1.OverColor = Color.FromArgb(30, 255, 255, 255);
            foreverClose1.Size = new Size(18, 18);
            foreverClose1.TabIndex = 6;
            foreverClose1.Text = "foreverClose1";
            foreverClose1.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom;
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.BaseColor = Color.FromArgb(35, 168, 109);
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGuardar.Location = new Point(155, 353);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Rounded = false;
            btnGuardar.Size = new Size(160, 40);
            btnGuardar.TabIndex = 5;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.TextColor = Color.FromArgb(243, 243, 243);
            btnGuardar.Click += btnGuardar_Click;
            // 
            // gbDatosUsuario
            // 
            gbDatosUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbDatosUsuario.ArrowColorF = Color.FromArgb(60, 70, 73);
            gbDatosUsuario.ArrowColorH = Color.FromArgb(60, 70, 73);
            gbDatosUsuario.BackColor = Color.FromArgb(45, 47, 49);
            gbDatosUsuario.BaseColor = Color.FromArgb(60, 70, 73);
            gbDatosUsuario.Controls.Add(CbCiudad);
            gbDatosUsuario.Controls.Add(TbTelefono);
            gbDatosUsuario.Controls.Add(TbNit);
            gbDatosUsuario.Controls.Add(TbDireccion);
            gbDatosUsuario.Controls.Add(TbNombre);
            gbDatosUsuario.Controls.Add(foreverLabel1);
            gbDatosUsuario.Controls.Add(lbTipo);
            gbDatosUsuario.Controls.Add(foreverLabel2);
            gbDatosUsuario.Controls.Add(lbPass);
            gbDatosUsuario.Controls.Add(lbUsuario);
            gbDatosUsuario.Font = new Font("Segoe UI", 10F);
            gbDatosUsuario.Location = new Point(5, 54);
            gbDatosUsuario.Name = "gbDatosUsuario";
            gbDatosUsuario.ShowArrow = false;
            gbDatosUsuario.ShowText = true;
            gbDatosUsuario.Size = new Size(460, 293);
            gbDatosUsuario.TabIndex = 4;
            gbDatosUsuario.Text = "DATOS DE PROVEEDOR";
            gbDatosUsuario.TextColor = Color.FromArgb(35, 168, 109);
            // 
            // CbCiudad
            // 
            CbCiudad.BaseColor = Color.FromArgb(25, 27, 29);
            CbCiudad.BGColor = Color.FromArgb(45, 47, 49);
            CbCiudad.DrawMode = DrawMode.OwnerDrawFixed;
            CbCiudad.DropDownStyle = ComboBoxStyle.DropDownList;
            CbCiudad.Font = new Font("Tahoma", 9F);
            CbCiudad.ForeColor = Color.White;
            CbCiudad.FormattingEnabled = true;
            CbCiudad.HoverColor = Color.FromArgb(35, 168, 109);
            CbCiudad.HoverFontColor = Color.White;
            CbCiudad.ItemHeight = 24;
            CbCiudad.Location = new Point(193, 242);
            CbCiudad.Name = "CbCiudad";
            CbCiudad.Size = new Size(240, 30);
            CbCiudad.TabIndex = 15;
            // 
            // TbTelefono
            // 
            TbTelefono.BackColor = Color.Transparent;
            TbTelefono.Font = new Font("Lucida Console", 11F);
            TbTelefono.ForeColor = Color.FromArgb(176, 183, 191);
            TbTelefono.Image = null;
            TbTelefono.Location = new Point(193, 191);
            TbTelefono.MaxLength = 32767;
            TbTelefono.Multiline = false;
            TbTelefono.Name = "TbTelefono";
            TbTelefono.ReadOnly = false;
            TbTelefono.Size = new Size(240, 38);
            TbTelefono.TabIndex = 12;
            TbTelefono.Text = "60607070";
            TbTelefono.TextAlignment = HorizontalAlignment.Left;
            TbTelefono.UseSystemPasswordChar = false;
            // 
            // TbNit
            // 
            TbNit.BackColor = Color.Transparent;
            TbNit.Font = new Font("Lucida Console", 11F);
            TbNit.ForeColor = Color.FromArgb(176, 183, 191);
            TbNit.Image = null;
            TbNit.Location = new Point(193, 42);
            TbNit.MaxLength = 32767;
            TbNit.Multiline = false;
            TbNit.Name = "TbNit";
            TbNit.ReadOnly = false;
            TbNit.Size = new Size(240, 38);
            TbNit.TabIndex = 12;
            TbNit.Text = "123456789017";
            TbNit.TextAlignment = HorizontalAlignment.Left;
            TbNit.UseSystemPasswordChar = false;
            // 
            // TbDireccion
            // 
            TbDireccion.BackColor = Color.Transparent;
            TbDireccion.Font = new Font("Tahoma", 11F);
            TbDireccion.ForeColor = Color.FromArgb(176, 183, 191);
            TbDireccion.Image = null;
            TbDireccion.Location = new Point(193, 141);
            TbDireccion.MaxLength = 32767;
            TbDireccion.Multiline = false;
            TbDireccion.Name = "TbDireccion";
            TbDireccion.ReadOnly = false;
            TbDireccion.Size = new Size(240, 41);
            TbDireccion.TabIndex = 14;
            TbDireccion.Text = "Av Panamericana S/N";
            TbDireccion.TextAlignment = HorizontalAlignment.Left;
            TbDireccion.UseSystemPasswordChar = false;
            // 
            // TbNombre
            // 
            TbNombre.BackColor = Color.Transparent;
            TbNombre.Font = new Font("Tahoma", 11F);
            TbNombre.ForeColor = Color.FromArgb(176, 183, 191);
            TbNombre.Image = null;
            TbNombre.Location = new Point(193, 91);
            TbNombre.MaxLength = 32767;
            TbNombre.Multiline = false;
            TbNombre.Name = "TbNombre";
            TbNombre.ReadOnly = false;
            TbNombre.Size = new Size(240, 41);
            TbNombre.TabIndex = 14;
            TbNombre.Text = "Monsters INC.";
            TbNombre.TextAlignment = HorizontalAlignment.Left;
            TbNombre.UseSystemPasswordChar = false;
            // 
            // foreverLabel1
            // 
            foreverLabel1.AutoSize = true;
            foreverLabel1.BackColor = Color.Transparent;
            foreverLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            foreverLabel1.ForeColor = Color.LightGray;
            foreverLabel1.Location = new Point(28, 151);
            foreverLabel1.Name = "foreverLabel1";
            foreverLabel1.Size = new Size(87, 21);
            foreverLabel1.TabIndex = 10;
            foreverLabel1.Text = "Dirección:";
            // 
            // lbTipo
            // 
            lbTipo.AutoSize = true;
            lbTipo.BackColor = Color.Transparent;
            lbTipo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbTipo.ForeColor = Color.LightGray;
            lbTipo.Location = new Point(28, 247);
            lbTipo.Name = "lbTipo";
            lbTipo.Size = new Size(68, 21);
            lbTipo.TabIndex = 9;
            lbTipo.Text = "Ciudad:";
            // 
            // foreverLabel2
            // 
            foreverLabel2.AutoSize = true;
            foreverLabel2.BackColor = Color.Transparent;
            foreverLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            foreverLabel2.ForeColor = Color.LightGray;
            foreverLabel2.Location = new Point(28, 201);
            foreverLabel2.Name = "foreverLabel2";
            foreverLabel2.Size = new Size(81, 21);
            foreverLabel2.TabIndex = 11;
            foreverLabel2.Text = "Teléfono:";
            // 
            // lbPass
            // 
            lbPass.AutoSize = true;
            lbPass.BackColor = Color.Transparent;
            lbPass.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbPass.ForeColor = Color.LightGray;
            lbPass.Location = new Point(28, 101);
            lbPass.Name = "lbPass";
            lbPass.Size = new Size(77, 21);
            lbPass.TabIndex = 10;
            lbPass.Text = "Nombre:";
            // 
            // lbUsuario
            // 
            lbUsuario.AutoSize = true;
            lbUsuario.BackColor = Color.Transparent;
            lbUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbUsuario.ForeColor = Color.LightGray;
            lbUsuario.Location = new Point(28, 52);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(41, 21);
            lbUsuario.TabIndex = 11;
            lbUsuario.Text = "NIT:";
            // 
            // SetProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 404);
            Controls.Add(FormTitle);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SetProveedor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SetProveedor";
            TransparencyKey = Color.Fuchsia;
            FormTitle.ResumeLayout(false);
            gbDatosUsuario.ResumeLayout(false);
            gbDatosUsuario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm FormTitle;
        private ReaLTaiizor.Controls.ForeverButtonSticky btnGuardar;
        private ReaLTaiizor.Controls.ForeverGroupBox gbDatosUsuario;
        private ReaLTaiizor.Controls.ForeverComboBox CbCiudad;
        private ReaLTaiizor.Controls.TextBoxEdit TbNit;
        private ReaLTaiizor.Controls.TextBoxEdit TbNombre;
        private ReaLTaiizor.Controls.ForeverLabel lbTipo;
        private ReaLTaiizor.Controls.ForeverLabel lbPass;
        private ReaLTaiizor.Controls.ForeverLabel lbUsuario;
        private ReaLTaiizor.Controls.ForeverClose foreverClose1;
        private ReaLTaiizor.Controls.TextBoxEdit TbDireccion;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.TextBoxEdit TbTelefono;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
    }
}