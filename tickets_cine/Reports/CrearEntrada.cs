using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using tickets_cine.Models;

namespace tickets_cine.Reports
{
    internal class CrearEntrada
    {
        private Ticket ticket;
        private string reportPath;

        public CrearEntrada(Ticket ticket, string reportPath)
        {
            this.ticket = ticket;
            this.reportPath = reportPath;
        }

        public void GenerarTicket()
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(200, 300, Unit.Millimetre);
                    page.Margin(5, Unit.Millimetre);
                    page.Content().Column(column =>
                    {
                        // Ticket Header
                        column.Item().AlignCenter().Text("Entrada de Cine").FontSize(16).Bold();
                        column.Item().PaddingBottom(5).AlignCenter().Text("¡Gracias por tu compra!").FontSize(10);

                        // Cliente Information
                        column.Item().Text($"Cliente: {ticket.Cliente?.Persona?.Nombre}")
                            .FontSize(10).Bold();

                        // Movie Details
                        column.Item().Text($"Película: {ticket.Horario?.Pelicula?.Titulo}")
                            .FontSize(10);
                        column.Item().Text($"Fecha: {ticket.Horario?.Fecha:dd/MM/yyyy}")
                            .FontSize(10);
                        column.Item().Text($"Hora: {ticket.Horario?.HoraInicio:hh:mm tt}")
                            .FontSize(10);

                        // Sala and Asiento
                        column.Item().PaddingTop(5).Text($"Sala: {ticket.Asiento?.SalaId}")
                            .FontSize(10).Bold();
                        column.Item().Text($"Asiento: {ticket.Asiento?.Codigo}")
                            .FontSize(10).Bold();

                        // Usuario Details
                        column.Item().PaddingTop(5).Text($"Vendido por: {ticket.Usuario?.Persona?.Nombre}")
                            .FontSize(10);

                        // Fecha y Hora de Venta
                        column.Item().PaddingTop(5).AlignRight()
                            .Text($"Fecha y hora de venta: {ticket.FechaCompra:dd/MM/yyyy hh:mm tt}")
                            .FontSize(8).Italic();

                        // Footer Message
                        column.Item().PaddingTop(10).AlignCenter()
                            .Text("Disfruta tu función. ¡Hasta pronto!")
                            .FontSize(10).Bold();
                    });
                });
            });

            document.GeneratePdf(reportPath);
        }
    }
}
