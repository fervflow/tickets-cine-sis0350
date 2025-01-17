namespace tickets_cine.Forms
{
    partial class CineAsientosForm
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
            CineAsientosForeverForm = new ReaLTaiizor.Forms.ForeverForm();
            CBxSalas = new ReaLTaiizor.Controls.ForeverComboBox();
            foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            panelAsientos = new ReaLTaiizor.Controls.Panel();
            foreverClose1 = new ReaLTaiizor.Controls.ForeverClose();
            BtnAdmin = new ReaLTaiizor.Controls.ForeverButton();
            CineAsientosForeverForm.SuspendLayout();
            SuspendLayout();
            // 
            // CineAsientosForeverForm
            // 
            CineAsientosForeverForm.BackColor = Color.White;
            CineAsientosForeverForm.BaseColor = Color.FromArgb(60, 70, 73);
            CineAsientosForeverForm.BorderColor = Color.DodgerBlue;
            CineAsientosForeverForm.Controls.Add(BtnAdmin);
            CineAsientosForeverForm.Controls.Add(CBxSalas);
            CineAsientosForeverForm.Controls.Add(foreverLabel1);
            CineAsientosForeverForm.Controls.Add(panelAsientos);
            CineAsientosForeverForm.Controls.Add(foreverClose1);
            CineAsientosForeverForm.Dock = DockStyle.Fill;
            CineAsientosForeverForm.Font = new Font("Segoe UI", 12F);
            CineAsientosForeverForm.ForeverColor = Color.FromArgb(35, 168, 109);
            CineAsientosForeverForm.HeaderColor = Color.FromArgb(45, 47, 49);
            CineAsientosForeverForm.HeaderMaximize = false;
            CineAsientosForeverForm.HeaderTextFont = new Font("Segoe UI", 12F);
            CineAsientosForeverForm.Image = null;
            CineAsientosForeverForm.Location = new Point(0, 0);
            CineAsientosForeverForm.MinimumSize = new Size(210, 50);
            CineAsientosForeverForm.Name = "CineAsientosForeverForm";
            CineAsientosForeverForm.Padding = new Padding(1, 51, 1, 1);
            CineAsientosForeverForm.Sizable = true;
            CineAsientosForeverForm.Size = new Size(1000, 650);
            CineAsientosForeverForm.TabIndex = 0;
            CineAsientosForeverForm.Text = "Asientos de la Sala";
            CineAsientosForeverForm.TextColor = Color.FromArgb(234, 234, 234);
            CineAsientosForeverForm.TextLight = Color.SeaGreen;
            // 
            // CBxSalas
            // 
            CBxSalas.BaseColor = Color.FromArgb(25, 27, 29);
            CBxSalas.BGColor = Color.FromArgb(45, 47, 49);
            CBxSalas.DrawMode = DrawMode.OwnerDrawFixed;
            CBxSalas.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxSalas.Font = new Font("Segoe UI", 11F);
            CBxSalas.ForeColor = Color.White;
            CBxSalas.FormattingEnabled = true;
            CBxSalas.HoverColor = Color.FromArgb(35, 168, 109);
            CBxSalas.HoverFontColor = Color.White;
            CBxSalas.ItemHeight = 24;
            CBxSalas.Location = new Point(767, 86);
            CBxSalas.Name = "CBxSalas";
            CBxSalas.Size = new Size(221, 30);
            CBxSalas.TabIndex = 4;
            CBxSalas.SelectedIndexChanged += CBxSalas_SelectedIndexChanged;
            // 
            // foreverLabel1
            // 
            foreverLabel1.AutoSize = true;
            foreverLabel1.BackColor = Color.Transparent;
            foreverLabel1.Font = new Font("Segoe UI", 11F);
            foreverLabel1.ForeColor = Color.LightGray;
            foreverLabel1.Location = new Point(767, 63);
            foreverLabel1.Name = "foreverLabel1";
            foreverLabel1.Size = new Size(40, 20);
            foreverLabel1.TabIndex = 2;
            foreverLabel1.Text = "Sala:";
            // 
            // panelAsientos
            // 
            panelAsientos.AutoScroll = true;
            panelAsientos.BackColor = Color.FromArgb(39, 51, 63);
            panelAsientos.EdgeColor = Color.FromArgb(32, 41, 50);
            panelAsientos.Location = new Point(12, 63);
            panelAsientos.Name = "panelAsientos";
            panelAsientos.Padding = new Padding(15);
            panelAsientos.Size = new Size(749, 575);
            panelAsientos.SmoothingType = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            panelAsientos.TabIndex = 1;
            panelAsientos.Text = "Panel Asientos";
            // 
            // foreverClose1
            // 
            foreverClose1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            foreverClose1.BackColor = Color.White;
            foreverClose1.BaseColor = Color.FromArgb(45, 47, 49);
            foreverClose1.DefaultLocation = true;
            foreverClose1.DownColor = Color.FromArgb(30, 0, 0, 0);
            foreverClose1.Font = new Font("Marlett", 10F);
            foreverClose1.Location = new Point(970, 16);
            foreverClose1.Name = "foreverClose1";
            foreverClose1.OverColor = Color.FromArgb(30, 255, 255, 255);
            foreverClose1.Size = new Size(18, 18);
            foreverClose1.TabIndex = 0;
            foreverClose1.Text = "foreverClose1";
            foreverClose1.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // BtnAdmin
            // 
            BtnAdmin.BackColor = Color.Transparent;
            BtnAdmin.BaseColor = Color.FromArgb(35, 168, 109);
            BtnAdmin.Font = new Font("Segoe UI", 12F);
            BtnAdmin.Location = new Point(767, 598);
            BtnAdmin.Name = "BtnAdmin";
            BtnAdmin.Rounded = false;
            BtnAdmin.Size = new Size(221, 40);
            BtnAdmin.TabIndex = 0;
            BtnAdmin.Text = "Ir a Administración";
            BtnAdmin.TextColor = Color.FromArgb(243, 243, 243);
            BtnAdmin.Click += BtnAdmin_Click;
            // 
            // CineAsientosForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 650);
            Controls.Add(CineAsientosForeverForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "CineAsientosForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CineAsientos";
            TransparencyKey = Color.Fuchsia;
            CineAsientosForeverForm.ResumeLayout(false);
            CineAsientosForeverForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm CineAsientosForeverForm;
        private ReaLTaiizor.Controls.ForeverClose foreverClose1;
        private ReaLTaiizor.Controls.Panel panelAsientos;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.ForeverComboBox CBxSalas;
        private ReaLTaiizor.Controls.ForeverButton BtnAdmin;
    }
}