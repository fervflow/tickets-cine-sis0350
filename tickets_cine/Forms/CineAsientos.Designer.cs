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
            button1 = new Button();
            panelAsientos = new ReaLTaiizor.Controls.Panel();
            foreverClose1 = new ReaLTaiizor.Controls.ForeverClose();
            CineAsientosForeverForm.SuspendLayout();
            SuspendLayout();
            // 
            // CineAsientosForeverForm
            // 
            CineAsientosForeverForm.BackColor = Color.White;
            CineAsientosForeverForm.BaseColor = Color.FromArgb(60, 70, 73);
            CineAsientosForeverForm.BorderColor = Color.DodgerBlue;
            CineAsientosForeverForm.Controls.Add(button1);
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
            // button1
            // 
            button1.BackColor = Color.DarkOliveGreen;
            button1.FlatAppearance.BorderColor = Color.FromArgb(64, 64, 64);
            button1.FlatAppearance.BorderSize = 2;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Location = new Point(114, 581);
            button1.Name = "button1";
            button1.Size = new Size(75, 41);
            button1.TabIndex = 2;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = false;
            // 
            // panelAsientos
            // 
            panelAsientos.AutoScroll = true;
            panelAsientos.BackColor = Color.FromArgb(39, 51, 63);
            panelAsientos.EdgeColor = Color.FromArgb(32, 41, 50);
            panelAsientos.Location = new Point(12, 54);
            panelAsientos.Name = "panelAsientos";
            panelAsientos.Padding = new Padding(15);
            panelAsientos.Size = new Size(976, 521);
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
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm CineAsientosForeverForm;
        private ReaLTaiizor.Controls.ForeverClose foreverClose1;
        private ReaLTaiizor.Controls.Panel panelAsientos;
        private Button button1;
    }
}