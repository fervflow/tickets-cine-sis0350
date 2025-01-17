using System.Data;
using System.Data.SqlClient;
using tickets_cine.Models;

namespace tickets_cine.Repositories
{
    public class TicketRepository
    {
        private readonly string _connectionString;

        public TicketRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InsertTicket(Ticket ticket)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_insertar_ticket", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@cliente_id", ticket.ClienteId);
                    command.Parameters.AddWithValue("@usuario_id", ticket.UsuarioId);
                    command.Parameters.AddWithValue("@horario_id", ticket.HorarioId);
                    command.Parameters.AddWithValue("@asiento_id", ticket.AsientoId);
                    command.Parameters.AddWithValue("@precio_total", ticket.PrecioTotal);

                    connection.Open();
                    return Convert.ToInt32(command.ExecuteScalar());
                }
            }
        }

        public Ticket? GetTicketById(int ticketId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand("sp_obtener_ticket", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@ticket_id", ticketId);

                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var ticket = new Ticket
                            {
                                TicketId = reader.GetInt32(reader.GetOrdinal("ticket_id")),
                                FechaCompra = reader.GetDateTime(reader.GetOrdinal("fecha_compra")),
                                PrecioTotal = reader.GetDecimal(reader.GetOrdinal("precio_total")),
                                ClienteId = reader.GetInt32(reader.GetOrdinal("cliente_id")),
                                UsuarioId = reader.GetInt32(reader.GetOrdinal("usuario_id")),
                                HorarioId = reader.GetInt32(reader.GetOrdinal("horario_id")),
                                AsientoId = reader.GetInt32(reader.GetOrdinal("asiento_id")),
                                Cliente = new Cliente
                                {
                                    IdCliente = reader.GetInt32(reader.GetOrdinal("cliente_id")),
                                    Persona = new Persona
                                    {
                                        Ci = reader.GetString(reader.GetOrdinal("cliente_ci")),
                                        Nombre = reader.GetString(reader.GetOrdinal("cliente_nombre"))
                                    }
                                },
                                Usuario = new Usuario
                                {
                                    IdUsuario = reader.GetInt32(reader.GetOrdinal("usuario_id")),
                                    NombreUsuario = reader.GetString(reader.GetOrdinal("usuario_nombre_usuario"))
                                },
                                Horario = new Horario
                                {
                                    Id = reader.GetInt32(reader.GetOrdinal("horario_id")),
                                    SalaId = reader.GetInt32(reader.GetOrdinal("sala_id")),
                                    Fecha = reader.GetDateTime(reader.GetOrdinal("horario_fecha")),
                                    HoraInicio = reader.GetTimeSpan(reader.GetOrdinal("horario_hora_inicio")),
                                    Precio = reader.GetDecimal(reader.GetOrdinal("horario_precio")),
                                    Pelicula = new Pelicula
                                    {
                                        Id = reader.GetInt32(reader.GetOrdinal("pelicula_id")),
                                        Titulo = reader.GetString(reader.GetOrdinal("pelicula_titulo")),
                                        Duracion = reader.GetInt32(reader.GetOrdinal("pelicula_duracion")),
                                        Genero = reader.GetString(reader.GetOrdinal("pelicula_genero")),
                                        Clasificacion = reader.GetString(reader.GetOrdinal("pelicula_clasificacion"))
                                    }
                                }
                            };

                            return ticket;
                        }
                    }
                }
            }

            return null;
        }
    }
}
