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
        private Venta venta;

        public CrearReporteVenta(int idVenta)
        {
            repo = new VentaRepo();
            venta = repo.Reporte(idVenta);
        }

        public void GenerarReporte()
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.Letter);
                    page.Margin(2, Unit.Centimetre);
                    page.Header().Padding(10).Text($"Reporte de Venta: {venta.IdVenta}").FontSize(20).Bold().AlignCenter();

                    page.Content().PaddingBottom(10).Text($"Usuario: {venta.Usuario.NombreUsuario} ({venta.Usuario.Persona.Ci}) - " +
                        $"{venta.Usuario.Persona.Nombre} {venta.Usuario.Persona.ApPaterno} {venta.Usuario.Persona.ApMaterno}")
                        .FontSize(12);

                    page.Content().PaddingBottom(10).Text($"Cliente: {venta.Cliente.Nit} ({venta.Cliente.Persona.Ci}) - " +
                        $"{venta.Cliente.Persona.Nombre} {venta.Cliente.Persona.ApPaterno} {venta.Cliente.Persona.ApMaterno}")
                        .FontSize(12);

                    page.Content().Table(table =>
                    {
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(80);   // IdDetalleVenta
                            columns.ConstantColumn(80);   // IdProducto
                            columns.RelativeColumn(1);    // Cantidad
                            columns.RelativeColumn(2);    // Subtotal
                        });

                        table.Header(header =>
                        {
                            header.Cell().Text("IdDetalleVenta").Bold().FontSize(10);
                            header.Cell().Text("IdProducto").Bold().FontSize(10);
                            header.Cell().Text("Cantidad").Bold().FontSize(10);
                            header.Cell().Text("SubTotal").Bold().FontSize(10);
                        });

                        foreach (var detalle in venta.DetalleVenta)
                        {
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");

                            table.Cell().Padding(4).Text(detalle.IdDetalleVenta.ToString()).FontSize(10);
                            table.Cell().Padding(4).Text(detalle.IdProducto.ToString()).FontSize(10);
                            table.Cell().Padding(4).Text(detalle.Cantidad.ToString()).FontSize(10);
                            table.Cell().Padding(4).Text(detalle.SubTotal.ToString() + "Bs.").FontSize(10);

                        }
                    });

                    page.Footer().AlignCenter().Text($"Generado en fecha y hora: {DateTime.Now}").FontSize(10);
                });
            });

            // Save to the user's Documents folder
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            string reportFolder = Path.Combine(documentsPath, "Reportes_upds_ventas");

            if (!Directory.Exists(reportFolder))
            {
                Directory.CreateDirectory(reportFolder);
            }

            string reportPath = Path.Combine(reportFolder, $"Reporte_Venta_{venta.IdVenta}.pdf");

            // Generate the PDF report
            document.GeneratePdf(reportPath);
        }
    }

}
