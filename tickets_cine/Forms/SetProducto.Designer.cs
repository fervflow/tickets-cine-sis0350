namespace upds_ventas.Forms
{
    partial class SetProducto
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
            SetProductoSkin = new ReaLTaiizor.Forms.ForeverForm();
            btnGuardar = new ReaLTaiizor.Controls.ForeverButtonSticky();
            gbDatosUsuario = new ReaLTaiizor.Controls.ForeverGroupBox();
            tglHabilitado = new ReaLTaiizor.Controls.ForeverToggle();
            CbProveedores = new ReaLTaiizor.Controls.ForeverComboBox();
            TbPrecioVenta = new ReaLTaiizor.Controls.TextBoxEdit();
            TbStock = new ReaLTaiizor.Controls.TextBoxEdit();
            TbPrecioCompra = new ReaLTaiizor.Controls.TextBoxEdit();
            TbNombre = new ReaLTaiizor.Controls.TextBoxEdit();
            foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            foreverLabel3 = new ReaLTaiizor.Controls.ForeverLabel();
            lbTipo = new ReaLTaiizor.Controls.ForeverLabel();
            foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            lbPass = new ReaLTaiizor.Controls.ForeverLabel();
            lbUsuario = new ReaLTaiizor.Controls.ForeverLabel();
            foreverClose1 = new ReaLTaiizor.Controls.ForeverClose();
            SetProductoSkin.SuspendLayout();
            gbDatosUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // SetProductoSkin
            // 
            SetProductoSkin.BackColor = Color.White;
            SetProductoSkin.BaseColor = Color.FromArgb(60, 70, 73);
            SetProductoSkin.BorderColor = Color.DodgerBlue;
            SetProductoSkin.Controls.Add(foreverClose1);
            SetProductoSkin.Controls.Add(btnGuardar);
            SetProductoSkin.Controls.Add(gbDatosUsuario);
            SetProductoSkin.Dock = DockStyle.Fill;
            SetProductoSkin.Font = new Font("Segoe UI", 12F);
            SetProductoSkin.ForeverColor = Color.FromArgb(35, 168, 109);
            SetProductoSkin.HeaderColor = Color.FromArgb(45, 47, 49);
            SetProductoSkin.HeaderMaximize = false;
            SetProductoSkin.HeaderTextFont = new Font("Segoe UI", 12F);
            SetProductoSkin.Image = null;
            SetProductoSkin.Location = new Point(0, 0);
            SetProductoSkin.MinimumSize = new Size(210, 50);
            SetProductoSkin.Name = "SetProductoSkin";
            SetProductoSkin.Padding = new Padding(1, 51, 1, 1);
            SetProductoSkin.Sizable = true;
            SetProductoSkin.Size = new Size(471, 463);
            SetProductoSkin.TabIndex = 0;
            SetProductoSkin.Text = "foreverForm1";
            SetProductoSkin.TextColor = Color.FromArgb(234, 234, 234);
            SetProductoSkin.TextLight = Color.SeaGreen;
            // 
            // btnGuardar
            // 
            btnGuardar.Anchor = AnchorStyles.Bottom;
            btnGuardar.BackColor = Color.Transparent;
            btnGuardar.BaseColor = Color.FromArgb(35, 168, 109);
            btnGuardar.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnGuardar.Location = new Point(155, 411);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Rounded = false;
            btnGuardar.Size = new Size(160, 40);
            btnGuardar.TabIndex = 7;
            btnGuardar.Text = "GUARDAR";
            btnGuardar.TextColor = Color.FromArgb(243, 243, 243);
            btnGuardar.Click += btnGuardar_Click;
            // 
            // gbDatosUsuario
            // 
            gbDatosUsuario.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbDatosUsuario.ArrowColorF = Color.FromArgb(60, 70, 73);
            gbDatosUsuario.ArrowColorH = Color.FromArgb(60, 70, 73);
            gbDatosUsuario.BackColor = Color.FromArgb(45, 47, 49);
            gbDatosUsuario.BaseColor = Color.FromArgb(60, 70, 73);
            gbDatosUsuario.Controls.Add(tglHabilitado);
            gbDatosUsuario.Controls.Add(CbProveedores);
            gbDatosUsuario.Controls.Add(TbPrecioVenta);
            gbDatosUsuario.Controls.Add(TbStock);
            gbDatosUsuario.Controls.Add(TbPrecioCompra);
            gbDatosUsuario.Controls.Add(TbNombre);
            gbDatosUsuario.Controls.Add(foreverLabel1);
            gbDatosUsuario.Controls.Add(foreverLabel3);
            gbDatosUsuario.Controls.Add(lbTipo);
            gbDatosUsuario.Controls.Add(foreverLabel2);
            gbDatosUsuario.Controls.Add(lbPass);
            gbDatosUsuario.Controls.Add(lbUsuario);
            gbDatosUsuario.Font = new Font("Segoe UI", 10F);
            gbDatosUsuario.Location = new Point(5, 54);
            gbDatosUsuario.Name = "gbDatosUsuario";
            gbDatosUsuario.ShowArrow = false;
            gbDatosUsuario.ShowText = true;
            gbDatosUsuario.Size = new Size(460, 350);
            gbDatosUsuario.TabIndex = 6;
            gbDatosUsuario.Text = "DATOS DE PRODUCTO";
            gbDatosUsuario.TextColor = Color.FromArgb(35, 168, 109);
            // 
            // tglHabilitado
            // 
            tglHabilitado.BackColor = Color.Transparent;
            tglHabilitado.BaseColor = Color.FromArgb(35, 168, 109);
            tglHabilitado.BaseColorRed = Color.FromArgb(220, 85, 96);
            tglHabilitado.BGColor = Color.FromArgb(84, 85, 86);
            tglHabilitado.Checked = true;
            tglHabilitado.Font = new Font("Segoe UI", 10F);
            tglHabilitado.Location = new Point(193, 294);
            tglHabilitado.Name = "tglHabilitado";
            tglHabilitado.Options = ReaLTaiizor.Controls.ForeverToggle._Options.Style2;
            tglHabilitado.Size = new Size(76, 33);
            tglHabilitado.TabIndex = 5;
            tglHabilitado.Text = "tglHabilitado";
            tglHabilitado.TextColor = Color.FromArgb(243, 243, 243);
            tglHabilitado.ToggleColor = Color.FromArgb(45, 47, 49);
            // 
            // CbProveedores
            // 
            CbProveedores.BaseColor = Color.FromArgb(25, 27, 29);
            CbProveedores.BGColor = Color.FromArgb(45, 47, 49);
            CbProveedores.DrawMode = DrawMode.OwnerDrawFixed;
            CbProveedores.DropDownStyle = ComboBoxStyle.DropDownList;
            CbProveedores.Font = new Font("Tahoma", 9F);
            CbProveedores.ForeColor = Color.White;
            CbProveedores.FormattingEnabled = true;
            CbProveedores.HoverColor = Color.FromArgb(35, 168, 109);
            CbProveedores.HoverFontColor = Color.White;
            CbProveedores.ItemHeight = 24;
            CbProveedores.Location = new Point(193, 246);
            CbProveedores.Name = "CbProveedores";
            CbProveedores.Size = new Size(240, 30);
            CbProveedores.TabIndex = 4;
            // 
            // TbPrecioVenta
            // 
            TbPrecioVenta.BackColor = Color.Transparent;
            TbPrecioVenta.Font = new Font("Lucida Console", 11.25F);
            TbPrecioVenta.ForeColor = Color.FromArgb(176, 183, 191);
            TbPrecioVenta.Image = null;
            TbPrecioVenta.Location = new Point(193, 191);
            TbPrecioVenta.MaxLength = 15;
            TbPrecioVenta.Multiline = false;
            TbPrecioVenta.Name = "TbPrecioVenta";
            TbPrecioVenta.ReadOnly = false;
            TbPrecioVenta.Size = new Size(240, 38);
            TbPrecioVenta.TabIndex = 3;
            TbPrecioVenta.Text = "40.00";
            TbPrecioVenta.TextAlignment = HorizontalAlignment.Left;
            TbPrecioVenta.UseSystemPasswordChar = false;
            // 
            // TbStock
            // 
            TbStock.BackColor = Color.Transparent;
            TbStock.Font = new Font("Lucida Console", 11F);
            TbStock.ForeColor = Color.FromArgb(176, 183, 191);
            TbStock.Image = null;
            TbStock.Location = new Point(193, 92);
            TbStock.MaxLength = 15;
            TbStock.Multiline = false;
            TbStock.Name = "TbStock";
            TbStock.ReadOnly = false;
            TbStock.Size = new Size(240, 38);
            TbStock.TabIndex = 1;
            TbStock.Text = "123456789017";
            TbStock.TextAlignment = HorizontalAlignment.Left;
            TbStock.UseSystemPasswordChar = false;
            // 
            // TbPrecioCompra
            // 
            TbPrecioCompra.BackColor = Color.Transparent;
            TbPrecioCompra.Font = new Font("Lucida Console", 11.25F);
            TbPrecioCompra.ForeColor = Color.FromArgb(176, 183, 191);
            TbPrecioCompra.Image = null;
            TbPrecioCompra.Location = new Point(193, 141);
            TbPrecioCompra.MaxLength = 15;
            TbPrecioCompra.Multiline = false;
            TbPrecioCompra.Name = "TbPrecioCompra";
            TbPrecioCompra.ReadOnly = false;
            TbPrecioCompra.Size = new Size(240, 38);
            TbPrecioCompra.TabIndex = 2;
            TbPrecioCompra.Text = "35.00";
            TbPrecioCompra.TextAlignment = HorizontalAlignment.Left;
            TbPrecioCompra.UseSystemPasswordChar = false;
            // 
            // TbNombre
            // 
            TbNombre.BackColor = Color.Transparent;
            TbNombre.Font = new Font("Tahoma", 11F);
            TbNombre.ForeColor = Color.FromArgb(176, 183, 191);
            TbNombre.Image = null;
            TbNombre.Location = new Point(193, 40);
            TbNombre.MaxLength = 30;
            TbNombre.Multiline = false;
            TbNombre.Name = "TbNombre";
            TbNombre.ReadOnly = false;
            TbNombre.Size = new Size(240, 41);
            TbNombre.TabIndex = 0;
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
            foreverLabel1.Size = new Size(149, 21);
            foreverLabel1.TabIndex = 10;
            foreverLabel1.Text = "Precio de Compra:";
            // 
            // foreverLabel3
            // 
            foreverLabel3.AutoSize = true;
            foreverLabel3.BackColor = Color.Transparent;
            foreverLabel3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            foreverLabel3.ForeColor = Color.LightGray;
            foreverLabel3.Location = new Point(28, 300);
            foreverLabel3.Name = "foreverLabel3";
            foreverLabel3.Size = new Size(97, 21);
            foreverLabel3.TabIndex = 11;
            foreverLabel3.Text = "Disponible:";
            // 
            // lbTipo
            // 
            lbTipo.AutoSize = true;
            lbTipo.BackColor = Color.Transparent;
            lbTipo.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbTipo.ForeColor = Color.LightGray;
            lbTipo.Location = new Point(28, 251);
            lbTipo.Name = "lbTipo";
            lbTipo.Size = new Size(94, 21);
            lbTipo.TabIndex = 9;
            lbTipo.Text = "Proveedor:";
            // 
            // foreverLabel2
            // 
            foreverLabel2.AutoSize = true;
            foreverLabel2.BackColor = Color.Transparent;
            foreverLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            foreverLabel2.ForeColor = Color.LightGray;
            foreverLabel2.Location = new Point(28, 201);
            foreverLabel2.Name = "foreverLabel2";
            foreverLabel2.Size = new Size(133, 21);
            foreverLabel2.TabIndex = 11;
            foreverLabel2.Text = "Precio de Venta:";
            // 
            // lbPass
            // 
            lbPass.AutoSize = true;
            lbPass.BackColor = Color.Transparent;
            lbPass.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbPass.ForeColor = Color.LightGray;
            lbPass.Location = new Point(28, 50);
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
            lbUsuario.Location = new Point(28, 102);
            lbUsuario.Name = "lbUsuario";
            lbUsuario.Size = new Size(57, 21);
            lbUsuario.TabIndex = 11;
            lbUsuario.Text = "Stock:";
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
            foreverClose1.TabIndex = 8;
            foreverClose1.Text = "foreverClose1";
            foreverClose1.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // SetProducto
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(471, 463);
            Controls.Add(SetProductoSkin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SetProducto";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SetProducto";
            TransparencyKey = Color.Fuchsia;
            SetProductoSkin.ResumeLayout(false);
            gbDatosUsuario.ResumeLayout(false);
            gbDatosUsuario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm SetProductoSkin;
        private ReaLTaiizor.Controls.ForeverButtonSticky btnGuardar;
        private ReaLTaiizor.Controls.ForeverGroupBox gbDatosUsuario;
        private ReaLTaiizor.Controls.ForeverComboBox CbProveedores;
        private ReaLTaiizor.Controls.TextBoxEdit TbPrecioVenta;
        private ReaLTaiizor.Controls.TextBoxEdit TbStock;
        private ReaLTaiizor.Controls.TextBoxEdit TbPrecioCompra;
        private ReaLTaiizor.Controls.TextBoxEdit TbNombre;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.ForeverLabel lbTipo;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
        private ReaLTaiizor.Controls.ForeverLabel lbPass;
        private ReaLTaiizor.Controls.ForeverLabel lbUsuario;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel3;
        private ReaLTaiizor.Controls.ForeverToggle tglHabilitado;
        private ReaLTaiizor.Controls.ForeverClose foreverClose1;
    }
}