using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using tickets_cine.Models;
using tickets_cine.Repos;

namespace tickets_cine.Reports
{
    internal class CrearReporteUsuarios
    {
        private UsuarioRepo repo;
        private List<Usuario> usuarios;
        private string reportPath;

        public CrearReporteUsuarios(string reportPath)
        {
            repo = new UsuarioRepo();
            usuarios = repo.Reporte();
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
                    page.Header().Padding(10).Text("Reporte de Usuarios").FontSize(20).Bold().AlignCenter();

                    page.Content().Table(table =>
                    {
                        // columns
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(80);  // CI
                            columns.RelativeColumn(1);   // Nombre
                            //columns.RelativeColumn(1);   // ApPaterno
                            //columns.RelativeColumn(1);   // ApMaterno
                            columns.RelativeColumn(1);   // NombreUsuario
                            columns.ConstantColumn(100);  // Tipo
                            columns.ConstantColumn(55);  // Estado
                        });

                        // headers
                        table.Header(header =>
                        {
                            header.Cell().Text("CI").Bold().FontSize(10);
                            header.Cell().Text("Nombre").Bold().FontSize(10);
                            //header.Cell().Text("Ap. Paterno").Bold().FontSize(10);
                            //header.Cell().Text("Ap. Materno").Bold().FontSize(10);
                            header.Cell().Text("Usuario").Bold().FontSize(10);
                            header.Cell().Text("Tipo").Bold().FontSize(10);
                            header.Cell().Text("Estado").Bold().FontSize(10);
                        });

                        // rows
                        foreach (var usuario in usuarios)
                        {
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            //table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            //table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");
                            table.Cell().BorderBottom(1).BorderColor("#D3D3D3");


                            table.Cell().Padding(4).Text(usuario.Persona.Ci).FontSize(10);
                            table.Cell().Padding(4).Text(usuario.Persona.Nombre).FontSize(10);
                            //table.Cell().Padding(4).Text(usuario.Persona.ApPaterno).FontSize(10);
                            //table.Cell().Padding(4).Text(usuario.Persona.ApMaterno).FontSize(10);
                            table.Cell().Padding(4).Text(usuario.NombreUsuario).FontSize(10);
                            table.Cell().Padding(4).Text(usuario.Tipo).FontSize(10);
                            table.Cell().Padding(4).Text(usuario.Estado ? "Activo" : "Inactivo").FontSize(10);
                        }
                    });

                    page.Footer().AlignCenter().Text($"Generado en fecha y hora: {DateTime.Now}").FontSize(10);
                });
            });

            //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //string reportFolder = Path.Combine(documentsPath, "Reportes upds_ventas");

            //if (!Directory.Exists(reportFolder))
            //{
            //    Directory.CreateDirectory(reportFolder);
            //}

            //string reportPath = Path.Combine(reportFolder, "Reporte Usuarios.pdf");

            document.GeneratePdf(reportPath);
        }
    }

}
