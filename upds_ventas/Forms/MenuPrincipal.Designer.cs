namespace upds_ventas.Forms
{
    partial class MenuPrincipal
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
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            MenuPrincipalFor = new ReaLTaiizor.Forms.ForeverForm();
            foreverClose1 = new ReaLTaiizor.Controls.ForeverClose();
            tabPageMain = new ReaLTaiizor.Controls.ForeverTabPage();
            tabPageClientes = new TabPage();
            tabPageUsuarios = new TabPage();
            foreverGroupBox2 = new ReaLTaiizor.Controls.ForeverGroupBox();
            poisonDataGridView1 = new ReaLTaiizor.Controls.PoisonDataGridView();
            id = new DataGridViewTextBoxColumn();
            nombre = new DataGridViewTextBoxColumn();
            foreverGroupBox1 = new ReaLTaiizor.Controls.ForeverGroupBox();
            btnEliminarUsuario = new ReaLTaiizor.Controls.ForeverButton();
            btnModificarUsuario = new ReaLTaiizor.Controls.ForeverButton();
            btnNuevoUsuario = new ReaLTaiizor.Controls.ForeverButton();
            gbDatosUsuario = new ReaLTaiizor.Controls.ForeverGroupBox();
            parrotPictureBox1 = new ReaLTaiizor.Controls.ParrotPictureBox();
            txtTipo = new ReaLTaiizor.Controls.ForeverLabel();
            txtCi = new ReaLTaiizor.Controls.ForeverLabel();
            txtApMaterno = new ReaLTaiizor.Controls.ForeverLabel();
            txtApPaterno = new ReaLTaiizor.Controls.ForeverLabel();
            separator5 = new ReaLTaiizor.Controls.Separator();
            txtNombre = new ReaLTaiizor.Controls.ForeverLabel();
            separator4 = new ReaLTaiizor.Controls.Separator();
            separator3 = new ReaLTaiizor.Controls.Separator();
            separator2 = new ReaLTaiizor.Controls.Separator();
            foreverLabel6 = new ReaLTaiizor.Controls.ForeverLabel();
            separator1 = new ReaLTaiizor.Controls.Separator();
            foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            lbApMaterno = new ReaLTaiizor.Controls.ForeverLabel();
            lbApPaterno = new ReaLTaiizor.Controls.ForeverLabel();
            lbNombre = new ReaLTaiizor.Controls.ForeverLabel();
            tabPageProveedores = new TabPage();
            tabPageProductos = new TabPage();
            MenuPrincipalFor.SuspendLayout();
            tabPageMain.SuspendLayout();
            tabPageUsuarios.SuspendLayout();
            foreverGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)poisonDataGridView1).BeginInit();
            foreverGroupBox1.SuspendLayout();
            gbDatosUsuario.SuspendLayout();
            SuspendLayout();
            // 
            // MenuPrincipalFor
            // 
            MenuPrincipalFor.BackColor = Color.White;
            MenuPrincipalFor.BaseColor = Color.FromArgb(60, 70, 73);
            MenuPrincipalFor.BorderColor = Color.DodgerBlue;
            MenuPrincipalFor.Controls.Add(foreverClose1);
            MenuPrincipalFor.Controls.Add(tabPageMain);
            MenuPrincipalFor.Dock = DockStyle.Fill;
            MenuPrincipalFor.Font = new Font("Segoe UI", 12F);
            MenuPrincipalFor.ForeverColor = Color.FromArgb(35, 168, 109);
            MenuPrincipalFor.HeaderColor = Color.FromArgb(45, 47, 49);
            MenuPrincipalFor.HeaderMaximize = false;
            MenuPrincipalFor.HeaderTextFont = new Font("Segoe UI", 12F);
            MenuPrincipalFor.Image = null;
            MenuPrincipalFor.Location = new Point(0, 0);
            MenuPrincipalFor.MaximumSize = new Size(1400, 900);
            MenuPrincipalFor.MinimumSize = new Size(700, 400);
            MenuPrincipalFor.Name = "MenuPrincipalFor";
            MenuPrincipalFor.Padding = new Padding(1, 51, 1, 1);
            MenuPrincipalFor.Sizable = true;
            MenuPrincipalFor.Size = new Size(800, 720);
            MenuPrincipalFor.TabIndex = 0;
            MenuPrincipalFor.Text = "Menú Principal";
            MenuPrincipalFor.TextColor = Color.FromArgb(234, 234, 234);
            MenuPrincipalFor.TextLight = Color.SeaGreen;
            // 
            // foreverClose1
            // 
            foreverClose1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            foreverClose1.BackColor = Color.White;
            foreverClose1.BaseColor = Color.FromArgb(45, 47, 49);
            foreverClose1.DefaultLocation = true;
            foreverClose1.DownColor = Color.FromArgb(30, 0, 0, 0);
            foreverClose1.Font = new Font("Marlett", 10F);
            foreverClose1.Location = new Point(770, 16);
            foreverClose1.Name = "foreverClose1";
            foreverClose1.OverColor = Color.FromArgb(30, 255, 255, 255);
            foreverClose1.Size = new Size(18, 18);
            foreverClose1.TabIndex = 1;
            foreverClose1.Text = "foreverClose1";
            foreverClose1.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // tabPageMain
            // 
            tabPageMain.ActiveColor = Color.FromArgb(35, 168, 109);
            tabPageMain.ActiveFontColor = Color.White;
            tabPageMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabPageMain.BaseColor = Color.FromArgb(45, 47, 49);
            tabPageMain.BGColor = Color.FromArgb(60, 70, 73);
            tabPageMain.Controls.Add(tabPageClientes);
            tabPageMain.Controls.Add(tabPageUsuarios);
            tabPageMain.Controls.Add(tabPageProveedores);
            tabPageMain.Controls.Add(tabPageProductos);
            tabPageMain.DeactiveFontColor = Color.White;
            tabPageMain.Font = new Font("Segoe UI", 10F);
            tabPageMain.ItemSize = new Size(120, 40);
            tabPageMain.Location = new Point(12, 54);
            tabPageMain.Name = "tabPageMain";
            tabPageMain.SelectedIndex = 0;
            tabPageMain.Size = new Size(776, 654);
            tabPageMain.SizeMode = TabSizeMode.Fixed;
            tabPageMain.TabIndex = 0;
            // 
            // tabPageClientes
            // 
            tabPageClientes.BackColor = Color.FromArgb(60, 70, 73);
            tabPageClientes.Location = new Point(4, 44);
            tabPageClientes.Name = "tabPageClientes";
            tabPageClientes.Padding = new Padding(3);
            tabPageClientes.Size = new Size(768, 606);
            tabPageClientes.TabIndex = 0;
            tabPageClientes.Text = "Clientes";
            // 
            // tabPageUsuarios
            // 
            tabPageUsuarios.BackColor = Color.FromArgb(60, 70, 73);
            tabPageUsuarios.Controls.Add(foreverGroupBox2);
            tabPageUsuarios.Controls.Add(foreverGroupBox1);
            tabPageUsuarios.Controls.Add(gbDatosUsuario);
            tabPageUsuarios.Location = new Point(4, 44);
            tabPageUsuarios.Name = "tabPageUsuarios";
            tabPageUsuarios.Padding = new Padding(3);
            tabPageUsuarios.Size = new Size(768, 606);
            tabPageUsuarios.TabIndex = 1;
            tabPageUsuarios.Text = "Usuarios";
            // 
            // foreverGroupBox2
            // 
            foreverGroupBox2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            foreverGroupBox2.ArrowColorF = Color.FromArgb(60, 70, 73);
            foreverGroupBox2.ArrowColorH = Color.FromArgb(60, 70, 73);
            foreverGroupBox2.BackColor = Color.FromArgb(45, 47, 49);
            foreverGroupBox2.BaseColor = Color.FromArgb(60, 70, 73);
            foreverGroupBox2.Controls.Add(poisonDataGridView1);
            foreverGroupBox2.Font = new Font("Segoe UI", 10F);
            foreverGroupBox2.Location = new Point(0, 204);
            foreverGroupBox2.Name = "foreverGroupBox2";
            foreverGroupBox2.ShowArrow = false;
            foreverGroupBox2.ShowText = true;
            foreverGroupBox2.Size = new Size(768, 402);
            foreverGroupBox2.TabIndex = 2;
            foreverGroupBox2.Text = "foreverGroupBox2";
            foreverGroupBox2.TextColor = Color.FromArgb(35, 168, 109);
            // 
            // poisonDataGridView1
            // 
            poisonDataGridView1.AllowUserToAddRows = false;
            poisonDataGridView1.AllowUserToOrderColumns = true;
            poisonDataGridView1.AllowUserToResizeRows = false;
            poisonDataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            poisonDataGridView1.BackgroundColor = Color.FromArgb(45, 47, 49);
            poisonDataGridView1.BorderStyle = BorderStyle.None;
            poisonDataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;
            poisonDataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle4.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            poisonDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            poisonDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            poisonDataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, nombre });
            dataGridViewCellStyle5.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle5.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle5.ForeColor = Color.FromArgb(136, 136, 136);
            dataGridViewCellStyle5.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle5.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle5.WrapMode = DataGridViewTriState.False;
            poisonDataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            poisonDataGridView1.EnableHeadersVisualStyles = false;
            poisonDataGridView1.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            poisonDataGridView1.GridColor = Color.FromArgb(255, 255, 255);
            poisonDataGridView1.Location = new Point(16, 46);
            poisonDataGridView1.Name = "poisonDataGridView1";
            poisonDataGridView1.ReadOnly = true;
            poisonDataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(0, 174, 219);
            dataGridViewCellStyle6.Font = new Font("Segoe UI", 11F, FontStyle.Regular, GraphicsUnit.Pixel);
            dataGridViewCellStyle6.ForeColor = Color.FromArgb(255, 255, 255);
            dataGridViewCellStyle6.SelectionBackColor = Color.FromArgb(0, 198, 247);
            dataGridViewCellStyle6.SelectionForeColor = Color.FromArgb(17, 17, 17);
            dataGridViewCellStyle6.WrapMode = DataGridViewTriState.True;
            poisonDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            poisonDataGridView1.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            poisonDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            poisonDataGridView1.Size = new Size(733, 338);
            poisonDataGridView1.TabIndex = 0;
            // 
            // id
            // 
            id.HeaderText = "identifier";
            id.Name = "id";
            id.ReadOnly = true;
            // 
            // nombre
            // 
            nombre.HeaderText = "Nombre";
            nombre.Name = "nombre";
            nombre.ReadOnly = true;
            // 
            // foreverGroupBox1
            // 
            foreverGroupBox1.ArrowColorF = Color.FromArgb(60, 70, 73);
            foreverGroupBox1.ArrowColorH = Color.FromArgb(60, 70, 73);
            foreverGroupBox1.BackColor = Color.FromArgb(45, 47, 49);
            foreverGroupBox1.BaseColor = Color.FromArgb(60, 70, 73);
            foreverGroupBox1.Controls.Add(btnEliminarUsuario);
            foreverGroupBox1.Controls.Add(btnModificarUsuario);
            foreverGroupBox1.Controls.Add(btnNuevoUsuario);
            foreverGroupBox1.Font = new Font("Segoe UI", 10F);
            foreverGroupBox1.Location = new Point(602, 0);
            foreverGroupBox1.Name = "foreverGroupBox1";
            foreverGroupBox1.ShowArrow = false;
            foreverGroupBox1.ShowText = true;
            foreverGroupBox1.Size = new Size(167, 204);
            foreverGroupBox1.TabIndex = 1;
            foreverGroupBox1.Text = "ACCIONES";
            foreverGroupBox1.TextColor = Color.FromArgb(35, 168, 109);
            // 
            // btnEliminarUsuario
            // 
            btnEliminarUsuario.BackColor = Color.Transparent;
            btnEliminarUsuario.BaseColor = Color.IndianRed;
            btnEliminarUsuario.Enabled = false;
            btnEliminarUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnEliminarUsuario.Location = new Point(19, 149);
            btnEliminarUsuario.Name = "btnEliminarUsuario";
            btnEliminarUsuario.Rounded = false;
            btnEliminarUsuario.Size = new Size(128, 32);
            btnEliminarUsuario.TabIndex = 0;
            btnEliminarUsuario.Text = "Eliminar";
            btnEliminarUsuario.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // btnModificarUsuario
            // 
            btnModificarUsuario.BackColor = Color.Transparent;
            btnModificarUsuario.BaseColor = Color.FromArgb(35, 168, 109);
            btnModificarUsuario.Enabled = false;
            btnModificarUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnModificarUsuario.Location = new Point(19, 99);
            btnModificarUsuario.Name = "btnModificarUsuario";
            btnModificarUsuario.Rounded = false;
            btnModificarUsuario.Size = new Size(128, 32);
            btnModificarUsuario.TabIndex = 0;
            btnModificarUsuario.Text = "Modificar";
            btnModificarUsuario.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // btnNuevoUsuario
            // 
            btnNuevoUsuario.BackColor = Color.Transparent;
            btnNuevoUsuario.BaseColor = Color.FromArgb(35, 168, 109);
            btnNuevoUsuario.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnNuevoUsuario.Location = new Point(19, 49);
            btnNuevoUsuario.Name = "btnNuevoUsuario";
            btnNuevoUsuario.Rounded = false;
            btnNuevoUsuario.Size = new Size(128, 32);
            btnNuevoUsuario.TabIndex = 0;
            btnNuevoUsuario.Text = "Nuevo Usuario";
            btnNuevoUsuario.TextColor = Color.FromArgb(243, 243, 243);
            btnNuevoUsuario.Click += btnNuevoUsuario_Click;
            // 
            // gbDatosUsuario
            // 
            gbDatosUsuario.ArrowColorF = Color.FromArgb(60, 70, 73);
            gbDatosUsuario.ArrowColorH = Color.FromArgb(60, 70, 73);
            gbDatosUsuario.BackColor = Color.FromArgb(45, 47, 49);
            gbDatosUsuario.BaseColor = Color.FromArgb(60, 70, 73);
            gbDatosUsuario.Controls.Add(parrotPictureBox1);
            gbDatosUsuario.Controls.Add(txtTipo);
            gbDatosUsuario.Controls.Add(txtCi);
            gbDatosUsuario.Controls.Add(txtApMaterno);
            gbDatosUsuario.Controls.Add(txtApPaterno);
            gbDatosUsuario.Controls.Add(separator5);
            gbDatosUsuario.Controls.Add(txtNombre);
            gbDatosUsuario.Controls.Add(separator4);
            gbDatosUsuario.Controls.Add(separator3);
            gbDatosUsuario.Controls.Add(separator2);
            gbDatosUsuario.Controls.Add(foreverLabel6);
            gbDatosUsuario.Controls.Add(separator1);
            gbDatosUsuario.Controls.Add(foreverLabel2);
            gbDatosUsuario.Controls.Add(lbApMaterno);
            gbDatosUsuario.Controls.Add(lbApPaterno);
            gbDatosUsuario.Controls.Add(lbNombre);
            gbDatosUsuario.Font = new Font("Segoe UI", 10F);
            gbDatosUsuario.Location = new Point(0, 0);
            gbDatosUsuario.Name = "gbDatosUsuario";
            gbDatosUsuario.ShowArrow = false;
            gbDatosUsuario.ShowText = true;
            gbDatosUsuario.Size = new Size(605, 204);
            gbDatosUsuario.TabIndex = 0;
            gbDatosUsuario.Text = "DATOS DE USUARIO";
            gbDatosUsuario.TextColor = Color.FromArgb(35, 168, 109);
            // 
            // parrotPictureBox1
            // 
            parrotPictureBox1.ColorLeft = Color.DodgerBlue;
            parrotPictureBox1.ColorRight = Color.DodgerBlue;
            parrotPictureBox1.CompositingQualityType = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            parrotPictureBox1.FilterAlpha = 200;
            parrotPictureBox1.FilterEnabled = true;
            parrotPictureBox1.Image = null;
            parrotPictureBox1.InterpolationType = System.Drawing.Drawing2D.InterpolationMode.HighQualityBilinear;
            parrotPictureBox1.IsElipse = false;
            parrotPictureBox1.IsParallax = false;
            parrotPictureBox1.Location = new Point(449, 46);
            parrotPictureBox1.Name = "parrotPictureBox1";
            parrotPictureBox1.PixelOffsetType = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            parrotPictureBox1.Size = new Size(119, 112);
            parrotPictureBox1.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            parrotPictureBox1.TabIndex = 9;
            parrotPictureBox1.Text = "parrotPictureBox1";
            parrotPictureBox1.TextRenderingType = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            // 
            // txtTipo
            // 
            txtTipo.AutoSize = true;
            txtTipo.BackColor = Color.Transparent;
            txtTipo.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtTipo.ForeColor = Color.LightGray;
            txtTipo.Location = new Point(294, 161);
            txtTipo.Name = "txtTipo";
            txtTipo.Size = new Size(127, 18);
            txtTipo.TabIndex = 7;
            txtTipo.Text = "ADMINISTRADOR";
            // 
            // txtCi
            // 
            txtCi.AutoSize = true;
            txtCi.BackColor = Color.Transparent;
            txtCi.Font = new Font("Lucida Console", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtCi.ForeColor = Color.LightGray;
            txtCi.Location = new Point(63, 163);
            txtCi.Name = "txtCi";
            txtCi.Size = new Size(106, 15);
            txtCi.TabIndex = 7;
            txtCi.Text = "12345678 PO";
            // 
            // txtApMaterno
            // 
            txtApMaterno.AutoSize = true;
            txtApMaterno.BackColor = Color.Transparent;
            txtApMaterno.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApMaterno.ForeColor = Color.LightGray;
            txtApMaterno.Location = new Point(181, 123);
            txtApMaterno.Name = "txtApMaterno";
            txtApMaterno.Size = new Size(44, 18);
            txtApMaterno.TabIndex = 7;
            txtApMaterno.Text = "Perez";
            // 
            // txtApPaterno
            // 
            txtApPaterno.AutoSize = true;
            txtApPaterno.BackColor = Color.Transparent;
            txtApPaterno.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtApPaterno.ForeColor = Color.LightGray;
            txtApPaterno.Location = new Point(181, 85);
            txtApPaterno.Name = "txtApPaterno";
            txtApPaterno.Size = new Size(44, 18);
            txtApPaterno.TabIndex = 7;
            txtApPaterno.Text = "Perez";
            // 
            // separator5
            // 
            separator5.LineColor = Color.Gray;
            separator5.Location = new Point(294, 180);
            separator5.Name = "separator5";
            separator5.Size = new Size(128, 4);
            separator5.TabIndex = 6;
            separator5.Text = "separator1";
            // 
            // txtNombre
            // 
            txtNombre.AutoSize = true;
            txtNombre.BackColor = Color.Transparent;
            txtNombre.Font = new Font("Tahoma", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombre.ForeColor = Color.LightGray;
            txtNombre.Location = new Point(181, 48);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(202, 18);
            txtNombre.TabIndex = 7;
            txtNombre.Text = "Juan Gabriel Alejandro Treinta";
            // 
            // separator4
            // 
            separator4.LineColor = Color.Gray;
            separator4.Location = new Point(63, 180);
            separator4.Name = "separator4";
            separator4.Size = new Size(120, 4);
            separator4.TabIndex = 6;
            separator4.Text = "separator1";
            // 
            // separator3
            // 
            separator3.LineColor = Color.Gray;
            separator3.Location = new Point(181, 142);
            separator3.Name = "separator3";
            separator3.Size = new Size(240, 4);
            separator3.TabIndex = 6;
            separator3.Text = "separator1";
            // 
            // separator2
            // 
            separator2.LineColor = Color.Gray;
            separator2.Location = new Point(181, 104);
            separator2.Name = "separator2";
            separator2.Size = new Size(240, 4);
            separator2.TabIndex = 6;
            separator2.Text = "separator1";
            // 
            // foreverLabel6
            // 
            foreverLabel6.AutoSize = true;
            foreverLabel6.BackColor = Color.Transparent;
            foreverLabel6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            foreverLabel6.ForeColor = Color.LightGray;
            foreverLabel6.Location = new Point(227, 161);
            foreverLabel6.Name = "foreverLabel6";
            foreverLabel6.Size = new Size(48, 21);
            foreverLabel6.TabIndex = 4;
            foreverLabel6.Text = "Tipo:";
            // 
            // separator1
            // 
            separator1.LineColor = Color.Gray;
            separator1.Location = new Point(181, 67);
            separator1.Name = "separator1";
            separator1.Size = new Size(240, 4);
            separator1.TabIndex = 6;
            separator1.Text = "separator1";
            // 
            // foreverLabel2
            // 
            foreverLabel2.AutoSize = true;
            foreverLabel2.BackColor = Color.Transparent;
            foreverLabel2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            foreverLabel2.ForeColor = Color.LightGray;
            foreverLabel2.Location = new Point(16, 161);
            foreverLabel2.Name = "foreverLabel2";
            foreverLabel2.Size = new Size(29, 21);
            foreverLabel2.TabIndex = 4;
            foreverLabel2.Text = "CI:";
            // 
            // lbApMaterno
            // 
            lbApMaterno.AutoSize = true;
            lbApMaterno.BackColor = Color.Transparent;
            lbApMaterno.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lbApMaterno.ForeColor = Color.LightGray;
            lbApMaterno.Location = new Point(16, 123);
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
            lbApPaterno.Location = new Point(16, 85);
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
            lbNombre.Location = new Point(16, 48);
            lbNombre.Name = "lbNombre";
            lbNombre.Size = new Size(77, 21);
            lbNombre.TabIndex = 4;
            lbNombre.Text = "Nombre:";
            // 
            // tabPageProveedores
            // 
            tabPageProveedores.BackColor = Color.FromArgb(60, 70, 73);
            tabPageProveedores.Location = new Point(4, 44);
            tabPageProveedores.Name = "tabPageProveedores";
            tabPageProveedores.Padding = new Padding(3);
            tabPageProveedores.Size = new Size(768, 606);
            tabPageProveedores.TabIndex = 2;
            tabPageProveedores.Text = "Proveedores";
            // 
            // tabPageProductos
            // 
            tabPageProductos.BackColor = Color.FromArgb(60, 70, 73);
            tabPageProductos.Location = new Point(4, 44);
            tabPageProductos.Name = "tabPageProductos";
            tabPageProductos.Padding = new Padding(3);
            tabPageProductos.Size = new Size(768, 606);
            tabPageProductos.TabIndex = 3;
            tabPageProductos.Text = "Productos";
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 720);
            Controls.Add(MenuPrincipalFor);
            FormBorderStyle = FormBorderStyle.None;
            MaximumSize = new Size(1400, 900);
            MinimumSize = new Size(700, 400);
            Name = "MenuPrincipal";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MenuPrincipal";
            TransparencyKey = Color.Fuchsia;
            MenuPrincipalFor.ResumeLayout(false);
            tabPageMain.ResumeLayout(false);
            tabPageUsuarios.ResumeLayout(false);
            foreverGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)poisonDataGridView1).EndInit();
            foreverGroupBox1.ResumeLayout(false);
            gbDatosUsuario.ResumeLayout(false);
            gbDatosUsuario.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm MenuPrincipalFor;
        private ReaLTaiizor.Controls.ForeverTabPage tabPageMain;
        private TabPage tabPageClientes;
        private TabPage tabPageUsuarios;
        private TabPage tabPageProveedores;
        private TabPage tabPageProductos;
        private ReaLTaiizor.Controls.ForeverGroupBox gbDatosUsuario;
        private ReaLTaiizor.Controls.ForeverLabel lbNombre;
        private ReaLTaiizor.Controls.Separator separator1;
        private ReaLTaiizor.Controls.ForeverLabel txtNombre;
        private ReaLTaiizor.Controls.ForeverLabel txtApPaterno;
        private ReaLTaiizor.Controls.Separator separator2;
        private ReaLTaiizor.Controls.ForeverLabel lbApPaterno;
        private ReaLTaiizor.Controls.ForeverLabel txtApMaterno;
        private ReaLTaiizor.Controls.Separator separator3;
        private ReaLTaiizor.Controls.ForeverLabel lbApMaterno;
        private ReaLTaiizor.Controls.ForeverLabel txtCi;
        private ReaLTaiizor.Controls.Separator separator4;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
        private ReaLTaiizor.Controls.ForeverLabel txtTipo;
        private ReaLTaiizor.Controls.Separator separator5;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel6;
        private ReaLTaiizor.Controls.ParrotPictureBox parrotPictureBox1;
        private ReaLTaiizor.Controls.ForeverGroupBox foreverGroupBox1;
        private ReaLTaiizor.Controls.ForeverButton btnNuevoUsuario;
        private ReaLTaiizor.Controls.ForeverButton btnEliminarUsuario;
        private ReaLTaiizor.Controls.ForeverButton btnModificarUsuario;
        private ReaLTaiizor.Controls.ForeverGroupBox foreverGroupBox2;
        private ReaLTaiizor.Controls.PoisonDataGridView poisonDataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn nombre;
        private ReaLTaiizor.Controls.ForeverClose foreverClose1;
    }
}