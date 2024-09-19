namespace upds_ventas.Forms
{
    partial class ReporteProductos
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
            ReporteFormSkin = new ReaLTaiizor.Forms.ForeverForm();
            SuspendLayout();
            // 
            // ReporteFormSkin
            // 
            ReporteFormSkin.BackColor = Color.White;
            ReporteFormSkin.BaseColor = Color.FromArgb(60, 70, 73);
            ReporteFormSkin.BorderColor = Color.DodgerBlue;
            ReporteFormSkin.Dock = DockStyle.Fill;
            ReporteFormSkin.Font = new Font("Segoe UI", 12F);
            ReporteFormSkin.ForeverColor = Color.FromArgb(35, 168, 109);
            ReporteFormSkin.HeaderColor = Color.FromArgb(45, 47, 49);
            ReporteFormSkin.HeaderMaximize = false;
            ReporteFormSkin.HeaderTextFont = new Font("Segoe UI", 12F);
            ReporteFormSkin.Image = null;
            ReporteFormSkin.Location = new Point(0, 0);
            ReporteFormSkin.MinimumSize = new Size(210, 50);
            ReporteFormSkin.Name = "ReporteFormSkin";
            ReporteFormSkin.Padding = new Padding(1, 51, 1, 1);
            ReporteFormSkin.Sizable = true;
            ReporteFormSkin.Size = new Size(1200, 720);
            ReporteFormSkin.TabIndex = 0;
            ReporteFormSkin.Text = "Reporte de Productos";
            ReporteFormSkin.TextColor = Color.FromArgb(234, 234, 234);
            ReporteFormSkin.TextLight = Color.SeaGreen;
            // 
            // ReporteProductos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1200, 720);
            Controls.Add(ReporteFormSkin);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReporteProductos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ReporteProductos";
            TransparencyKey = Color.Fuchsia;
            ResumeLayout(false);
        }

        #endregion

        private ReaLTaiizor.Forms.ForeverForm ReporteFormSkin;
    }
}