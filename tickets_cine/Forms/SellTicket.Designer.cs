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
            foreverLabel2 = new ReaLTaiizor.Controls.ForeverLabel();
            foreverComboBox1 = new ReaLTaiizor.Controls.ForeverComboBox();
            foreverLabel1 = new ReaLTaiizor.Controls.ForeverLabel();
            foreverTextBox1 = new ReaLTaiizor.Controls.ForeverTextBox();
            SellTicketForm.SuspendLayout();
            SuspendLayout();
            // 
            // SellTicketForm
            // 
            SellTicketForm.BackColor = Color.White;
            SellTicketForm.BaseColor = Color.FromArgb(60, 70, 73);
            SellTicketForm.BorderColor = Color.DodgerBlue;
            SellTicketForm.Controls.Add(foreverTextBox1);
            SellTicketForm.Controls.Add(foreverLabel2);
            SellTicketForm.Controls.Add(foreverComboBox1);
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
            SellTicketForm.Size = new Size(441, 534);
            SellTicketForm.TabIndex = 0;
            SellTicketForm.Text = "Vender Entrada";
            SellTicketForm.TextColor = Color.FromArgb(234, 234, 234);
            SellTicketForm.TextLight = Color.SeaGreen;
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
            // foreverComboBox1
            // 
            foreverComboBox1.BaseColor = Color.FromArgb(25, 27, 29);
            foreverComboBox1.BGColor = Color.FromArgb(45, 47, 49);
            foreverComboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            foreverComboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            foreverComboBox1.Font = new Font("Segoe UI", 8F);
            foreverComboBox1.ForeColor = Color.White;
            foreverComboBox1.FormattingEnabled = true;
            foreverComboBox1.HoverColor = Color.FromArgb(35, 168, 109);
            foreverComboBox1.HoverFontColor = Color.White;
            foreverComboBox1.ItemHeight = 18;
            foreverComboBox1.Location = new Point(12, 98);
            foreverComboBox1.Name = "foreverComboBox1";
            foreverComboBox1.Size = new Size(417, 24);
            foreverComboBox1.TabIndex = 1;
            // 
            // foreverLabel1
            // 
            foreverLabel1.AutoSize = true;
            foreverLabel1.BackColor = Color.Transparent;
            foreverLabel1.Font = new Font("Segoe UI", 12F);
            foreverLabel1.ForeColor = Color.LightGray;
            foreverLabel1.Location = new Point(12, 65);
            foreverLabel1.Name = "foreverLabel1";
            foreverLabel1.Size = new Size(135, 21);
            foreverLabel1.TabIndex = 0;
            foreverLabel1.Text = "Pelicula Y Horario:";
            // 
            // foreverTextBox1
            // 
            foreverTextBox1.BackColor = Color.Transparent;
            foreverTextBox1.BaseColor = Color.FromArgb(45, 47, 49);
            foreverTextBox1.BorderColor = Color.FromArgb(35, 168, 109);
            foreverTextBox1.FocusOnHover = false;
            foreverTextBox1.ForeColor = Color.FromArgb(192, 192, 192);
            foreverTextBox1.Location = new Point(12, 172);
            foreverTextBox1.MaxLength = 32767;
            foreverTextBox1.Multiline = false;
            foreverTextBox1.Name = "foreverTextBox1";
            foreverTextBox1.ReadOnly = false;
            foreverTextBox1.Size = new Size(417, 29);
            foreverTextBox1.TabIndex = 4;
            foreverTextBox1.Text = "foreverTextBox1";
            foreverTextBox1.TextAlign = HorizontalAlignment.Left;
            foreverTextBox1.UseSystemPasswordChar = false;
            foreverTextBox1.TextChanged += foreverTextBox1_TextChanged;
            // 
            // SellTicketBase
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(441, 534);
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
        private ReaLTaiizor.Controls.ForeverComboBox foreverComboBox1;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel1;
        private ReaLTaiizor.Controls.ForeverLabel foreverLabel2;
        private ReaLTaiizor.Controls.ForeverTextBox foreverTextBox1;
    }
}