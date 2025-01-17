using System.Data.SqlClient;
using tickets_cine.Data;
using tickets_cine.Models;

namespace tickets_cine.Repos
{
    internal class SalaRepo
    {
        private readonly DatabaseContext dbContext;

        public SalaRepo()
        {
            dbContext = new DatabaseContext();
        }

        public async Task<bool> InsertarAsync(Sala sala)
        {
            const string sql = "INSERT INTO Salas (filas, columnas, bloques) VALUES (@filas, @columnas, @bloques)";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@filas", sala.Filas);
                cmd.Parameters.AddWithValue("@columnas", sala.Columnas);
                cmd.Parameters.AddWithValue("@bloques", sala.Bloques);

                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar la sala:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }

        public async Task<bool> ModificarAsync(Sala sala)
        {
            const string sql = "UPDATE Salas SET filas = @filas, columnas = @columnas, bloques = @bloques WHERE sala_id = @id";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@id", sala.Id);
                cmd.Parameters.AddWithValue("@filas", sala.Filas);
                cmd.Parameters.AddWithValue("@columnas", sala.Columnas);
                cmd.Parameters.AddWithValue("@bloques", sala.Bloques);

                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar la sala:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }

        public async Task<List<Sala>> ListarAsync()
        {
            const string sql = "EXEC dbo.sp_listar_salas";
            var salas = new List<Sala>();
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    salas.Add(new Sala
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("sala_id")),
                        Filas = reader.GetInt32(reader.GetOrdinal("filas")),
                        Columnas = reader.GetInt32(reader.GetOrdinal("columnas")),
                        Bloques = reader.GetInt32(reader.GetOrdinal("bloques"))
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar las salas:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { dbContext.Close(); }

            return salas;
        }

        public async Task<bool> EliminarAsync(int salaId)
        {
            const string sql = "DELETE FROM Salas WHERE sala_id = @id";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@id", salaId);

                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar la sala:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }
    }
}
