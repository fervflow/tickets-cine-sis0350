using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using upds_ventas.Models;
using upds_ventas.Repos;

namespace upds_ventas.Reports
{
    internal class CrearReporteVenta
    {
        private VentaRepo repo;
        private List<Venta> ventas;
        private string reportPath;

        public CrearReporteVenta(string reportPath)
        {
            repo = new VentaRepo();
            ventas = repo.Reporte();
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
                    page.Header().Padding(10).Text($"Reporte de Ventas").FontSize(15).Bold().AlignCenter();

                    page.Content().PaddingVertical(10).Column(stack =>
                    {
                        foreach (Venta v in ventas)
                        {
                            stack.Item().Padding(4).Text($"VENDEDOR: ({v.Usuario!.Persona.Ci}) - " +
                                $"{v.Usuario.Persona.Nombre} {v.Usuario.Persona.ApPaterno} {v.Usuario.Persona.ApMaterno} " +
                                $"- {v.Usuario.Tipo}")
                                .FontSize(11);

                            stack.Item().Padding(4).Text($"CLIENTE: {v.Cliente!.Nit} - " +
                                $"{v.Cliente.Persona.Nombre} {v.Cliente.Persona.ApPaterno} {v.Cliente.Persona.ApMaterno}")
                                .FontSize(11);
                            stack.Item().Padding(4).Text($"FECHA DE VENTA: {v.Fecha}").FontSize(11);
                            stack.Item().Padding(4).Text($"MONTO TOTAL: {v.Total} Bs.").FontSize(11);

                            stack.Item().Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.ConstantColumn(50); // IdProducto
                                    columns.RelativeColumn(1);  // Nombre Producto
                                    columns.RelativeColumn(1);  // Precio Venta
                                    columns.RelativeColumn(1);  // Cantidad
                                    columns.RelativeColumn(2);  // Subtotal
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Text("Id Producto").Bold().FontSize(10);
                                    header.Cell().Text("Nombre").Bold().FontSize(10);
                                    header.Cell().Text("Precio").Bold().FontSize(10);
                                    header.Cell().Text("Cantidad").Bold().FontSize(10);
                                    header.Cell().Text("SubTotal").Bold().FontSize(10);
                                });

                                table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                                table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                                table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                                table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                                table.Cell().BorderBottom(1).BorderColor("#D3D3D3");

                                foreach (var detalle in v.DetalleVenta)
                                {

                                    table.Cell().Padding(4).Text(detalle.IdProducto.ToString()).FontSize(10);
                                    table.Cell().Padding(4).Text(detalle.Producto!.Nombre).FontSize(10);
                                    table.Cell().Padding(4).Text(detalle.Producto!.PrecioVenta.ToString()).FontSize(10);
                                    table.Cell().Padding(4).Text(detalle.Cantidad.ToString()).FontSize(10);
                                    table.Cell().Padding(4).Text($"{detalle.SubTotal:F2} Bs.").FontSize(10);

                                    table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                                    table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                                    table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                                    table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                                    table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                                }
                            });
                            stack.Item().PaddingTop(15);
                        }

                    });

                    page.Footer().AlignCenter().Text($"Generado en fecha y hora: {DateTime.Now}").FontSize(10);
                });
            });

            document.GeneratePdf(reportPath);
        }
    }
}
