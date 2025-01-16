using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using tickets_cine.Models;
using tickets_cine.Repos;

namespace tickets_cine.Reports
{
    internal class CrearReporteProductos
    {
        private ProductoRepo repo;
        private List<Producto> productos;
        private string reportPath;

        public CrearReporteProductos(string reportPath)
        {
            repo = new ProductoRepo();
            productos = repo.Reporte();
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
                    page.Header().Padding(10).Text("Reporte de Productos").FontSize(20).Bold().AlignCenter();

                    page.Content().Table(table =>
                    {
                        // Columns
                        table.ColumnsDefinition(columns =>
                        {
                            columns.RelativeColumn(1);  // Nombre
                            columns.ConstantColumn(40); // Stock
                            columns.RelativeColumn(1);  // PrecioVenta
                            columns.RelativeColumn(1);  // Proveedor
                            columns.ConstantColumn(80); // Ciudad
                            columns.ConstantColumn(60); // Estado
                        });

                        // Header
                        table.Header(header =>
                        {
                            header.Cell().Text("Nombre").Bold().FontSize(10);
                            header.Cell().Text("Stock").Bold().FontSize(10);
                            header.Cell().Text("Precio Venta").Bold().FontSize(10);
                            header.Cell().Text("Proveedor").Bold().FontSize(10);
                            header.Cell().Text("Ciudad").Bold().FontSize(10);
                            header.Cell().Text("Estado").Bold().FontSize(10);
                        });

                        // Rows
                        foreach (var producto in productos)
                        {
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");

                            table.Cell().Padding(4).Text(producto.Nombre).FontSize(10);
                            table.Cell().Padding(4).Text(producto.Stock.ToString()).FontSize(10);
                            table.Cell().Padding(4).Text($"{producto.PrecioVenta} Bs.").FontSize(10);
                            table.Cell().Padding(4).Text(producto.Proveedor!.Nombre).FontSize(10);
                            table.Cell().Padding(4).Text(producto.Proveedor!.Ciudad).FontSize(10);
                            table.Cell().Padding(4).Text(producto.Estado ? "Disponible" : "No disponible").FontSize(10);
                        }
                    });

                    page.Footer().AlignCenter().Text($"Generado en fecha y hora: {DateTime.Now}").FontSize(10);
                });
            });

            document.GeneratePdf(reportPath);
        }
    }
}
