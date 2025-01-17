using System.Data.SqlClient;
using tickets_cine.Data;
using tickets_cine.Models;

namespace tickets_cine.Repos
{
    internal class HorariosRepo
    {
        private readonly DatabaseContext dbContext;

        public HorariosRepo()
        {
            dbContext = new DatabaseContext();
        }

        public async Task<bool> Insertar(Horario h)
        {
            const string sql = "EXEC dbo.sp_insertar_horario @sala_id, @pelicula_id, @fecha, @hora_inicio, @precio";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@sala_id", h.SalaId);
                cmd.Parameters.AddWithValue("@pelicula_id", h.PeliculaId);
                cmd.Parameters.AddWithValue("@fecha", h.Fecha);
                cmd.Parameters.AddWithValue("@hora_inicio", h.HoraInicio);
                cmd.Parameters.AddWithValue("@precio", h.Precio);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el horario:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }

        public async Task<bool> ModificarAsync(Horario h)
        {
            const string sql = "EXEC dbo.sp_modificar_horario @horario_id, @sala_id, @pelicula_id, @fecha, @hora_inicio, @precio";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@horario_id", h.Id);
                cmd.Parameters.AddWithValue("@sala_id", h.SalaId);
                cmd.Parameters.AddWithValue("@pelicula_id", h.PeliculaId);
                cmd.Parameters.AddWithValue("@fecha", h.Fecha);
                cmd.Parameters.AddWithValue("@hora_inicio", h.HoraInicio);
                cmd.Parameters.AddWithValue("@precio", h.Precio);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el horario:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }

        public async Task<List<Horario>> ListarAsync()
        {
            const string sql = "EXEC dbo.sp_listar_horarios";
            var horarios = new List<Horario>();
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    horarios.Add(new Horario
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("horario_id")),
                        SalaId = reader.GetInt32(reader.GetOrdinal("sala_id")),
                        PeliculaId = reader.GetInt32(reader.GetOrdinal("pelicula_id")),
                        Fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                        HoraInicio = reader.GetTimeSpan(reader.GetOrdinal("hora_inicio")),
                        Precio = reader.GetDecimal(reader.GetOrdinal("precio")),
                        Sala = new Sala
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("sala_id")),
                        },
                        Pelicula = new Pelicula
                        {
                            Titulo = reader.GetString(reader.GetOrdinal("pelicula_titulo")),
                            Duracion = reader.GetInt32(reader.GetOrdinal("pelicula_duracion")),
                            Genero = reader.GetString(reader.GetOrdinal("pelicula_genero")),
                            Clasificacion = reader.GetString(reader.GetOrdinal("pelicula_clasificacion")),
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar horarios:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { dbContext.Close(); }

            return horarios;
        }

        public async Task<bool> EliminarAsync(int horarioId)
        {
            const string sql = "EXEC dbo.sp_eliminar_horario @horario_id";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@horario_id", horarioId);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el horario:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }
    }
}
