namespace tickets_cine.Utils
{
    internal class Utils
    {
        public static string ReportPath(string nombreReporte)
        {
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string reportFolder = Path.Combine(documentsPath, "Reportes_tickets-cine");

            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }

            string reportPath = Path.Combine(reportFolder, $"{nombreReporte}.pdf");
            return reportPath;
        }
    }
}
