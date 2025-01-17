namespace tickets_cine.Forms
{
    partial class SellTicketBase
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
            SellTicketForm = new ReaLTaiizor.Forms.ForeverForm();
            LbTotal = new ReaLTaiizor.Controls.ForeverLabel();
            LbAsiento = new ReaLTaiizor.Controls.ForeverLabel();
            separator16 = new ReaLTaiizor.Controls.Separator();
            separator17 = new ReaLTaiizor.Controls.Separator();
            foreverLabel20 = new ReaLTaiizor.Controls.ForeverLabel();
            foreverLabel21 = new ReaLTaiizor.Controls.ForeverLabel();
            CBxCliente = new ReaLTaiizor.Controls.ForeverComboBox();
            CBxHorario = new ReaLTaiizor.Controls.ForeverComboBox();
            foreverLabel3 = new ReaLTaiizor.Controls.ForeverLabel();
            foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            CBxPelicula = new ReaLTaiizor.Controls.ForeverComboBox();
            foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            BtnVender = new ReaLTaiizor.Controls.ForeverButton();
            SellTicketForm.SuspendLayout();
            SuspendLayout();
            // 
            // SellTicketForm
            // 
            SellTicketForm.BackColor = Color.White;
            SellTicketForm.BaseColor = Color.FromArgb(60, 70, 73);
            SellTicketForm.BorderColor = Color.DodgerBlue;
            SellTicketForm.Controls.Add(BtnVender);
            SellTicketForm.Controls.Add(LbTotal);
            SellTicketForm.Controls.Add(LbAsiento);
            SellTicketForm.Controls.Add(separator16);
            SellTicketForm.Controls.Add(separator17);
            SellTicketForm.Controls.Add(foreverLabel20);
            SellTicketForm.Controls.Add(foreverLabel21);
            SellTicketForm.Controls.Add(CBxCliente);
            SellTicketForm.Controls.Add(CBxHorario);
            SellTicketForm.Controls.Add(foreverLabel3);
            SellTicketForm.Controls.Add(foreverLabel2);
            SellTicketForm.Controls.Add(CBxPelicula);
            SellTicketForm.Controls.Add(foreverLabel1);
            SellTicketForm.Dock = DockStyle.Fill;
            SellTicketForm.Font = new Font("Segoe UI", 12F);
            SellTicketForm.ForeverColor = Color.FromArgb(35, 168, 109);
            SellTicketForm.HeaderColor = Color.FromArgb(45, 47, 49);
            SellTicketForm.HeaderMaximize = false;
            SellTicketForm.HeaderTextFont = new Font("Segoe UI", 12F);
            SellTicketForm.Image = null;
            SellTicketForm.Location = new Point(0, 0);
            SellTicketForm.MinimumSize = new Size(210, 50);
            SellTicketForm.Name = "SellTicketForm";
            SellTicketForm.Padding = new Padding(1, 51, 1, 1);
            SellTicketForm.Sizable = true;
            SellTicketForm.Size = new Size(446, 331);
            SellTicketForm.TabIndex = 0;
            SellTicketForm.Text = "Vender Entrada";
            SellTicketForm.TextColor = Color.FromArgb(234, 234, 234);
            SellTicketForm.TextLight = Color.SeaGreen;
            SellTicketForm.Click += SellTicketForm_Click;
            // 
            // LbTotal
            // 
            LbTotal.AutoSize = true;
            LbTotal.BackColor = Color.Transparent;
            LbTotal.Font = new Font("Lucida Console", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbTotal.ForeColor = Color.LightGray;
            LbTotal.Location = new Point(282, 221);
            LbTotal.Name = "LbTotal";
            LbTotal.Size = new Size(61, 15);
            LbTotal.TabIndex = 12;
            LbTotal.Text = "50 Bs.";
            // 
            // LbAsiento
            // 
            LbAsiento.AutoSize = true;
            LbAsiento.BackColor = Color.Transparent;
            LbAsiento.Font = new Font("Lucida Console", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LbAsiento.ForeColor = Color.LightGray;
            LbAsiento.Location = new Point(87, 223);
            LbAsiento.Name = "LbAsiento";
            LbAsiento.Size = new Size(43, 15);
            LbAsiento.TabIndex = 13;
            LbAsiento.Text = "A-01";
            // 
            // separator16
            // 
            separator16.BackColor = Color.FromArgb(45, 47, 49);
            separator16.LineColor = Color.Gray;
            separator16.Location = new Point(282, 240);
            separator16.Name = "separator16";
            separator16.Size = new Size(128, 4);
            separator16.TabIndex = 10;
            separator16.Text = "separator1";
            // 
            // separator17
            // 
            separator17.BackColor = Color.FromArgb(45, 47, 49);
            separator17.LineColor = Color.Gray;
            separator17.Location = new Point(87, 240);
            separator17.Name = "separator17";
            separator17.Size = new Size(120, 4);
            separator17.TabIndex = 11;
            separator17.Text = "separator1";
            // 
            // foreverLabel20
            // 
            foreverLabel20.AutoSize = true;
            foreverLabel20.BackColor = Color.Transparent;
            foreverLabel20.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            foreverLabel20.ForeColor = Color.LightGray;
            foreverLabel20.Location = new Point(227, 221);
            foreverLabel20.Name = "foreverLabel20";
            foreverLabel20.Size = new Size(52, 21);
            foreverLabel20.TabIndex = 8;
            foreverLabel20.Text = "Total:";
            // 
            // foreverLabel21
            // 
            foreverLabel21.AutoSize = true;
            foreverLabel21.BackColor = Color.Transparent;
            foreverLabel21.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            foreverLabel21.ForeColor = Color.LightGray;
            foreverLabel21.Location = new Point(16, 221);
            foreverLabel21.Name = "foreverLabel21";
            foreverLabel21.Size = new Size(72, 21);
            foreverLabel21.TabIndex = 9;
            foreverLabel21.Text = "Asiento:";
            // 
            // CBxCliente
            // 
            CBxCliente.BaseColor = Color.FromArgb(25, 27, 29);
            CBxCliente.BGColor = Color.FromArgb(45, 47, 49);
            CBxCliente.DrawMode = DrawMode.OwnerDrawFixed;
            CBxCliente.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxCliente.Font = new Font("Segoe UI", 10F);
            CBxCliente.ForeColor = Color.White;
            CBxCliente.FormattingEnabled = true;
            CBxCliente.HoverColor = Color.FromArgb(35, 168, 109);
            CBxCliente.HoverFontColor = Color.White;
            CBxCliente.ItemHeight = 24;
            CBxCliente.Location = new Point(12, 163);
            CBxCliente.Name = "CBxCliente";
            CBxCliente.Size = new Size(417, 30);
            CBxCliente.TabIndex = 6;
            // 
            // CBxHorario
            // 
            CBxHorario.BaseColor = Color.FromArgb(25, 27, 29);
            CBxHorario.BGColor = Color.FromArgb(45, 47, 49);
            CBxHorario.DrawMode = DrawMode.OwnerDrawFixed;
            CBxHorario.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxHorario.Font = new Font("Segoe UI", 10F);
            CBxHorario.ForeColor = Color.White;
            CBxHorario.FormattingEnabled = true;
            CBxHorario.HoverColor = Color.FromArgb(35, 168, 109);
            CBxHorario.HoverFontColor = Color.White;
            CBxHorario.ItemHeight = 24;
            CBxHorario.Location = new Point(284, 89);
            CBxHorario.Name = "CBxHorario";
            CBxHorario.Size = new Size(145, 30);
            CBxHorario.TabIndex = 4;
            // 
            // foreverLabel3
            // 
            foreverLabel3.AutoSize = true;
            foreverLabel3.BackColor = Color.Transparent;
            foreverLabel3.Font = new Font("Segoe UI", 12F);
            foreverLabel3.ForeColor = Color.LightGray;
            foreverLabel3.Location = new Point(284, 65);
            foreverLabel3.Name = "foreverLabel3";
            foreverLabel3.Size = new Size(66, 21);
            foreverLabel3.TabIndex = 3;
            foreverLabel3.Text = "Horario:";
            foreverLabel3.Click += foreverLabel3_Click;
            // 
            // foreverLabel2
            // 
            foreverLabel2.AutoSize = true;
            foreverLabel2.BackColor = Color.Transparent;
            foreverLabel2.Font = new Font("Segoe UI", 12F);
            foreverLabel2.ForeColor = Color.LightGray;
            foreverLabel2.Location = new Point(12, 139);
            foreverLabel2.Name = "foreverLabel2";
            foreverLabel2.Size = new Size(61, 21);
            foreverLabel2.TabIndex = 2;
            foreverLabel2.Text = "Cliente:";
            // 
            // CBxPelicula
            // 
            CBxPelicula.BaseColor = Color.FromArgb(25, 27, 29);
            CBxPelicula.BGColor = Color.FromArgb(45, 47, 49);
            CBxPelicula.DrawMode = DrawMode.OwnerDrawFixed;
            CBxPelicula.DropDownStyle = ComboBoxStyle.DropDownList;
            CBxPelicula.Font = new Font("Segoe UI", 10F);
            CBxPelicula.ForeColor = Color.White;
            CBxPelicula.FormattingEnabled = true;
            CBxPelicula.HoverColor = Color.FromArgb(35, 168, 109);
            CBxPelicula.HoverFontColor = Color.White;
            CBxPelicula.ItemHeight = 24;
            CBxPelicula.Location = new Point(12, 89);
            CBxPelicula.Name = "CBxPelicula";
            CBxPelicula.Size = new Size(256, 30);
            CBxPelicula.TabIndex = 1;
            // 
            // foreverLabel1
            // 
            foreverLabel1.AutoSize = true;
            foreverLabel1.BackColor = Color.Transparent;
            foreverLabel1.Font = new Font("Segoe UI", 12F);
            foreverLabel1.ForeColor = Color.LightGray;
            foreverLabel1.Location = new Point(12, 65);
            foreverLabel1.Name = "foreverLabel1";
            foreverLabel1.Size = new Size(65, 21);
            foreverLabel1.TabIndex = 0;
            foreverLabel1.Text = "Pelicula:";
            // 
            // BtnVender
            // 
            BtnVender.BackColor = Color.Transparent;
            BtnVender.BaseColor = Color.FromArgb(35, 168, 109);
            BtnVender.Font = new Font("Segoe UI", 12F);
            BtnVender.Location = new Point(158, 272);
            BtnVender.Name = "BtnVender";
            BtnVender.Rounded = false;
            BtnVender.Size = new Size(120, 40);
            BtnVender.TabIndex = 14;
            BtnVender.Text = "Vender";
            BtnVender.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // SellTicketBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(446, 331);
            Controls.Add(SellTicketForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SellTicketBase";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SellTicket";
            TransparencyKey = Color.Fuchsia;
            SellTicketForm.ResumeLayout(false);
            SellTicketForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm SellTicketForm;
        private ReaLTaiizor.Controls.ForeverComboBox CBxPelicula;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
        private ReaLTaiizor.Controls.ForeverComboBox CBxHorario;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel3;
        private ReaLTaiizor.Controls.ForeverComboBox CBxCliente;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel4;
        private ReaLTaiizor.Controls.ForeverLabel LbTotal;
        private ReaLTaiizor.Controls.ForeverLabel LbAsiento;
        private ReaLTaiizor.Controls.Separator separator16;
        private ReaLTaiizor.Controls.Separator separator17;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel20;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel21;
        private ReaLTaiizor.Controls.ForeverButton BtnVender;
    }
}