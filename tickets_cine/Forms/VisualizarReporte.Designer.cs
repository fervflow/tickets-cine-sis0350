namespace tickets_cine.Forms
{
    partial class VisualizarReporte
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
            Reporte = new ReaLTaiizor.Forms.ForeverForm();
            webView21 = new Microsoft.Web.WebView2.WinForms.WebView2();
            foreverClose1 = new ReaLTaiizor.Controls.ForeverClose();
            foreverMaximize1 = new ReaLTaiizor.Controls.ForeverMaximize();
            Reporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)webView21).BeginInit();
            SuspendLayout();
            // 
            // Reporte
            // 
            Reporte.BackColor = Color.White;
            Reporte.BaseColor = Color.FromArgb(60, 70, 73);
            Reporte.BorderColor = Color.DodgerBlue;
            Reporte.Controls.Add(foreverMaximize1);
            Reporte.Controls.Add(webView21);
            Reporte.Controls.Add(foreverClose1);
            Reporte.Dock = DockStyle.Fill;
            Reporte.Font = new Font("Segoe UI", 12F);
            Reporte.ForeverColor = Color.FromArgb(35, 168, 109);
            Reporte.HeaderColor = Color.FromArgb(45, 47, 49);
            Reporte.HeaderMaximize = false;
            Reporte.HeaderTextFont = new Font("Segoe UI", 12F);
            Reporte.Image = null;
            Reporte.Location = new Point(0, 0);
            Reporte.MinimumSize = new Size(210, 50);
            Reporte.Name = "Reporte";
            Reporte.Padding = new Padding(1, 51, 1, 1);
            Reporte.Sizable = true;
            Reporte.Size = new Size(1200, 720);
            Reporte.TabIndex = 0;
            Reporte.Text = "Reporte";
            Reporte.TextColor = Color.FromArgb(234, 234, 234);
            Reporte.TextLight = Color.SeaGreen;
            // 
            // webView21
            // 
            webView21.BackColor = Color.DimGray;
            webView21.CreationProperties = null;
            webView21.DefaultBackgroundColor = Color.PapayaWhip;
            webView21.Location = new Point(12, 54);
            webView21.Name = "webView21";
            webView21.Size = new Size(1176, 654);
            webView21.TabIndex = 1;
            webView21.ZoomFactor = 1D;
            // 
            // foreverClose1
            // 
            foreverClose1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            foreverClose1.BackColor = Color.White;
            foreverClose1.BaseColor = Color.FromArgb(45, 47, 49);
            foreverClose1.DefaultLocation = true;
            foreverClose1.DownColor = Color.FromArgb(30, 0, 0, 0);
            foreverClose1.Font = new Font("Marlett", 10F);
            foreverClose1.Location = new Point(1170, 16);
            foreverClose1.Name = "foreverClose1";
            foreverClose1.OverColor = Color.FromArgb(30, 255, 255, 255);
            foreverClose1.Size = new Size(18, 18);
            foreverClose1.TabIndex = 0;
            foreverClose1.Text = "foreverClose1";
            foreverClose1.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // foreverMaximize1
            // 
            foreverMaximize1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            foreverMaximize1.BackColor = Color.White;
            foreverMaximize1.BaseColor = Color.FromArgb(45, 47, 49);
            foreverMaximize1.DefaultLocation = true;
            foreverMaximize1.DownColor = Color.FromArgb(30, 0, 0, 0);
            foreverMaximize1.Font = new Font("Marlett", 12F);
            foreverMaximize1.Location = new Point(1146, 16);
            foreverMaximize1.Name = "foreverMaximize1";
            foreverMaximize1.OverColor = Color.FromArgb(30, 255, 255, 255);
            foreverMaximize1.Size = new Size(18, 18);
            foreverMaximize1.TabIndex = 2;
            foreverMaximize1.Text = "foreverMaximize1";
            foreverMaximize1.TextColor = Color.FromArgb(243, 243, 243);
            // 
            // VisualizarReporte
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 720);
            Controls.Add(Reporte);
            FormBorderStyle = FormBorderStyle.None;
            Name = "VisualizarReporte";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "VisualizarReporte";
            TransparencyKey = Color.Fuchsia;
            Reporte.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)webView21).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm Reporte;
        private ReaLTaiizor.Controls.ForeverClose foreverClose1;
        private Microsoft.Web.WebView2.WinForms.WebView2 webView21;
        private ReaLTaiizor.Controls.ForeverMaximize foreverMaximize1;
    }
}