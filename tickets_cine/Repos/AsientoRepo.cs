using System.Data.SqlClient;
using tickets_cine.Data;
using tickets_cine.Models;

namespace tickets_cine.Repos
{
    internal class AsientoRepo
    {
        private readonly DatabaseContext dbContext;

        public AsientoRepo()
        {
            dbContext = new DatabaseContext();
        }

        public async Task<List<Asiento>> ListarPorSalaAsync(int salaId)
        {
            const string sql = "EXEC dbo.sp_obtener_asientos @sala_id";
            var asientos = new List<Asiento>();
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@sala_id", salaId);

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    asientos.Add(new Asiento
                    {
                        Id = reader.GetInt32(reader.GetOrdinal("asiento_id")),
                        SalaId = salaId,
                        Codigo = reader.GetString(reader.GetOrdinal("codigo")),
                        Ocupado = reader.GetBoolean(reader.GetOrdinal("ocupado"))
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener los asientos:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { dbContext.Close(); }

            return asientos;
        }
    }
}
