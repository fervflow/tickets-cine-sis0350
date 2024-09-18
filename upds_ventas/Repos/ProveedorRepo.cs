using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upds_ventas.Data;
using upds_ventas.Models;

namespace upds_ventas.Repos
{
    public class ProveedorRepo
    {
        private readonly UpdsVentasContext _dbContext;

        public ProveedorRepo(UpdsVentasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> InsertarProveedorAsync(Proveedor p)
        {
            SqlParameter[] sqlParams = [
                new SqlParameter("@nit", p.Nit),
                new SqlParameter("@nombre", p.Nombre),
                new SqlParameter("@direccion", p.Direccion),
                new SqlParameter("@telefono", p.Telefono),
                new SqlParameter("@ciudad", p.Ciudad),
            ];

            var rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC dbo.sp_insertar_proveedor @nit, @nombre, @direccion, @telefono, @ciudad",
                sqlParams);

            return rowsAffected > 0;
        }

        public async Task<List<Proveedor>> ListarProveedoresAsync()
        {
            var proveedores = new List<Proveedor>();
            using var connection = _dbContext.Database.GetDbConnection();

            try
            {
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "EXEC dbo.sp_listar_proveedores";
                command.CommandType = System.Data.CommandType.Text;

                using var reader = await command.ExecuteReaderAsync();
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
            finally
            {
                await connection.CloseAsync();
            }

            return proveedores;
        }

        public async Task<bool> ModificarProveedorAsync(Proveedor p)
        {
            SqlParameter[] sqlParams = [
                new SqlParameter("@id_proveedor", p.IdProveedor),
                new SqlParameter("@nit", p.Nit ?? (object)DBNull.Value),
                new SqlParameter("@nombre", p.Nombre),
                new SqlParameter("@direccion", p.Direccion),
                new SqlParameter("@telefono", p.Telefono),
                new SqlParameter("@ciudad", p.Ciudad ?? (object)DBNull.Value),
            ];
            int rowsAffected = 0;
            try
            {
                rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(
                    "EXEC dbo.sp_modificar_proveedor @id_proveedor, @nit, @nombre, @direccion, @telefono, @ciudad",
                    sqlParams);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return rowsAffected > 0;
        }

    }
}
