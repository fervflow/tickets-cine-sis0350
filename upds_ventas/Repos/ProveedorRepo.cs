using System.Data.SqlClient;
using upds_ventas.Data;
using upds_ventas.Models;

namespace upds_ventas.Repos
{
    public class ProveedorRepo
    {
        private readonly DatabaseContext dbContext;

        public ProveedorRepo()
        {
            dbContext = new DatabaseContext();
        }

        public async Task<bool> InsertarProveedorAsync(Proveedor p)
        {
            const string sql = "EXEC dbo.sp_insertar_proveedor @nit, @nombre, @direccion, @telefono, @ciudad";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@nit", p.Nit);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@direccion", p.Direccion);
                cmd.Parameters.AddWithValue("@telefono", p.Telefono);
                cmd.Parameters.AddWithValue("@ciudad", p.Ciudad);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al insertar el proveedor:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }

        public async Task<List<Proveedor>> ListarProveedoresAsync()
        {
            const string sql = "EXEC dbo.sp_listar_proveedores";
            var proveedores = new List<Proveedor>();
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    proveedores.Add(new Proveedor
                    {
                        IdProveedor = reader.GetInt32(reader.GetOrdinal("id_proveedor")),
                        Nit = reader.IsDBNull(reader.GetOrdinal("nit")) ? null : reader.GetString(reader.GetOrdinal("nit")),
                        Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                        Direccion = reader.GetString(reader.GetOrdinal("direccion")),
                        Telefono = reader.GetString(reader.GetOrdinal("telefono")),
                        Ciudad = reader.IsDBNull(reader.GetOrdinal("ciudad")) ? null : reader.GetString(reader.GetOrdinal("ciudad")),
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar proveedores:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { dbContext.Close(); }
            return proveedores;
        }

        public async Task<bool> ModificarProveedorAsync(Proveedor p)
        {
            const string sql = "EXEC dbo.sp_modificar_proveedor @id_proveedor, @nit, @nombre, @direccion, @telefono, @ciudad";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@id_proveedor", p.IdProveedor);
                cmd.Parameters.AddWithValue("@nit", p.Nit ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@direccion", p.Direccion);
                cmd.Parameters.AddWithValue("@telefono", p.Telefono);
                cmd.Parameters.AddWithValue("@ciudad", p.Ciudad ?? (object)DBNull.Value);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el proveedor:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }

        public List<Proveedor> BuscarProveedor(string nombre)
        {
            const string sql = "EXEC dbo.sp_buscar_proveedor @nombre";
            var proveedores = new List<Proveedor>();
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@nombre", nombre);

                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    proveedores.Add(new Proveedor
                    {
                        IdProveedor = reader.GetInt32(reader.GetOrdinal("id_proveedor")),
                        Nit = reader.IsDBNull(reader.GetOrdinal("nit")) ? null : reader.GetString(reader.GetOrdinal("nit")),
                        Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                        Direccion = reader.GetString(reader.GetOrdinal("direccion")),
                        Telefono = reader.GetString(reader.GetOrdinal("telefono")),
                        Ciudad = reader.IsDBNull(reader.GetOrdinal("ciudad")) ? null : reader.GetString(reader.GetOrdinal("ciudad")),
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar el proveedor:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { dbContext.Close(); }
            return proveedores;
        }

    }
}
