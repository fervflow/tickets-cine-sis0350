using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using upds_ventas.Models;
using upds_ventas.Repos;

namespace upds_ventas.Reports
{
    internal class CrearReporteProveedores
    {
        private ProveedorRepo repo;
        private List<Proveedor> proveedores;
        private string reportPath;

        public CrearReporteProveedores(string reportPath)
        {
            repo = new ProveedorRepo();
            proveedores = repo.Reporte();
            this.reportPath = reportPath;
        }

        public void GenerarReporte()
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.Letter);
                    page.Margin(2, Unit.Centimetre);
                    page.Header().Padding(10).Text("Reporte de Proveedores").FontSize(20).Bold().AlignCenter();

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(100);  // NIT
                            columns.RelativeColumn(2);    // Nombre
                            columns.RelativeColumn(2);    // Direccion
                            columns.ConstantColumn(80);   // Telefono
                            columns.ConstantColumn(80);   // Ciudad
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("NIT").Bold().FontSize(10);
                            header.Cell().Text("Nombre").Bold().FontSize(10);
                            header.Cell().Text("Dirección").Bold().FontSize(10);
                            header.Cell().Text("Teléfono").Bold().FontSize(10);
                            header.Cell().Text("Ciudad").Bold().FontSize(10);
                        });

                        foreach (var proveedor in proveedores)
                        {
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");


                            table.Cell().Padding(4).Text(proveedor.Nit).FontSize(10);
                            table.Cell().Padding(4).Text(proveedor.Nombre).FontSize(10);
                            table.Cell().Padding(4).Text(proveedor.Direccion).FontSize(10);
                            table.Cell().Padding(4).Text(proveedor.Telefono).FontSize(10);
                            table.Cell().Padding(4).Text(proveedor.Ciudad).FontSize(10);
                        }
                    });

                    page.Footer().AlignCenter().Text($"Generado en fecha y hora: {DateTime.Now}").FontSize(10);
                });
            });

            document.GeneratePdf(reportPath);
        }
    }

}
