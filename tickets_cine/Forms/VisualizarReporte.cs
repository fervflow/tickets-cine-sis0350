namespace upds_ventas.Forms
{
    public partial class VisualizarReporte : Form
    {
        string reportPath;
        public VisualizarReporte(string reportPath)
        {
            this.reportPath = reportPath;

            InitializeComponent();

            LoadPdf();
        }

        private async void LoadPdf()
        {
            await webView21.EnsureCoreWebView2Async(null);
            webView21.Source = new Uri(@$"file:///{reportPath}");
        }
    }
}
