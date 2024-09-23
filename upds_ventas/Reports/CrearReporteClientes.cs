using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using upds_ventas.Models;
using upds_ventas.Repos;

namespace upds_ventas.Reports
{
    internal class CrearReporteClientes
    {
        private ClienteRepo repo;
        private List<Cliente> clientes;

        public CrearReporteClientes()
        {
            repo = new ClienteRepo();
            clientes = repo.Reporte();
        }

        public void GenerarReporte()
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.Letter);
                    page.Margin(2, Unit.Centimetre);
                    page.Header().Padding(10).Text("Reporte de Clientes").FontSize(20).Bold().AlignCenter();

                    page.Content().Table(table =>
                    {
                        // columns
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(80);  // CI
                            columns.ConstantColumn(80);  // NIT
                            columns.RelativeColumn(1);   // Nombre
                            columns.RelativeColumn(1);   // ApPaterno
                            columns.RelativeColumn(1);   // ApMaterno
                        });

                        // headers
                        table.Header(header =>
                        {
                            header.Cell().Text("CI").Bold().FontSize(10);
                            header.Cell().Text("NIT").Bold().FontSize(10);
                            header.Cell().Text("Nombre").Bold().FontSize(10);
                            header.Cell().Text("Ap. Paterno").Bold().FontSize(10);
                            header.Cell().Text("Ap. Materno").Bold().FontSize(10);
                        });

                        // rows
                        foreach (var cliente in clientes)
                        {
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");


                            table.Cell().Padding(4).Text(cliente.Persona.Ci).FontSize(10);
                            table.Cell().Padding(4).Text(cliente.Nit).FontSize(10);
                            table.Cell().Padding(4).Text(cliente.Persona.Nombre).FontSize(10);
                            table.Cell().Padding(4).Text(cliente.Persona.ApPaterno).FontSize(10);
                            table.Cell().Padding(4).Text(cliente.Persona.ApMaterno).FontSize(10);                                                    
                        }
                    });

                    page.Footer().AlignCenter().Text($"Generado en fecha y hora: {DateTime.Now}").FontSize(10);
                });
            });

            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string reportFolder = Path.Combine(documentsPath, "Reportes upds_ventas");

            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }

            string reportPath = Path.Combine(reportFolder, "Reporte Clientes.pdf");

            document.GeneratePdf(reportPath);
        }
    }

}
