using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using upds_ventas.Data;
using upds_ventas.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace upds_ventas.Repos
{
    public class UsuarioRepo
    {
        private readonly UpdsVentasContext _dbContext;

        public UsuarioRepo(UpdsVentasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> InsertarUsuarioAsync(Usuario u)
        {
            SqlParameter[] sqlParams = [
                new SqlParameter("@ci", u.Persona.Ci),
                new SqlParameter("@nombre", u.Persona.Nombre),
                new SqlParameter("@ap_paterno", u.Persona.ApPaterno),
                new SqlParameter("@ap_materno", u.Persona.ApMaterno ?? (object)DBNull.Value),
                new SqlParameter("@usuario", u.NombreUsuario),
                new SqlParameter("@pass", u.Pass),
                new SqlParameter("@tipo", u.Tipo),
                new SqlParameter("@estado", u.Estado)

            ];

            var rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC dbo.sp_insertar_usuario @ci, @nombre, @ap_paterno, @ap_materno, @usuario, @pass, @tipo, @estado",
                sqlParams);

            return rowsAffected > 0;
        }

        public async Task<List<Usuario>> ListarUsuariosAsync()
        {
            var usuarios = new List<Usuario>();
            using var connection = _dbContext.Database.GetDbConnection();

            try
            {
                await connection.OpenAsync();

                using var command = connection.CreateCommand();
                command.CommandText = "EXEC dbo.sp_listar_usuarios";
                command.CommandType = System.Data.CommandType.Text;

                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    usuarios.Add(new Usuario
                    {
                        IdUsuario = reader.GetInt32(reader.GetOrdinal("id_persona")),
                        NombreUsuario = reader.GetString(reader.GetOrdinal("nombre_usuario")),
                        Pass = reader.GetString(reader.GetOrdinal("pass")),
                        Tipo = reader.GetString(reader.GetOrdinal("tipo")),
                        Estado = reader.GetBoolean(reader.GetOrdinal("estado")),
                        Persona = new Persona
                        {
                            IdPersona = reader.GetInt32(reader.GetOrdinal("id_persona")),
                            Ci = reader.IsDBNull(reader.GetOrdinal("ci")) ? null : reader.GetString(reader.GetOrdinal("ci")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            ApPaterno = reader.GetString(reader.GetOrdinal("ap_paterno")),
                            ApMaterno = reader.IsDBNull(reader.GetOrdinal("ap_materno")) ? null : reader.GetString(reader.GetOrdinal("ap_materno"))
                        }
                    });
                }
            }
            finally
            {
                await connection.CloseAsync();
            }

            return usuarios;
        }

        public async Task<bool> ModificarUsuarioAsync(Usuario u)
        {
            SqlParameter[] sqlParams = [
                new SqlParameter("@id_usuario", u.IdUsuario),
                new SqlParameter("@ci", u.Persona.Ci),
                new SqlParameter("@nombre", u.Persona.Nombre),
                new SqlParameter("@ap_paterno", u.Persona.ApPaterno),
                new SqlParameter("@ap_materno", u.Persona.ApMaterno ?? (object)DBNull.Value),
                new SqlParameter("@usuario", u.NombreUsuario),
                new SqlParameter("@pass", u.Pass),
                new SqlParameter("@tipo", u.Tipo),
                new SqlParameter("@estado", u.Estado),
            ];
            int rowsAffected = 0;
            try
            {
                rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(
                    "EXEC dbo.sp_modificar_usuario @id_usuario, @ci, @nombre, @ap_paterno, @ap_materno, @usuario, @pass, @tipo, @estado",
                    sqlParams);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }

            return rowsAffected > 0;
        }

        public async Task<bool> EliminarUsuarioAsync(Usuario u)
        {
            SqlParameter[] sqlParams = [
                new SqlParameter("@id_usuario", u.IdUsuario),
                new SqlParameter("@estado", u.Estado),
            ];
            int rowsAffected = 0;
            try
            {
                rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(
                    "EXEC dbo.sp_deshabilitar_usuario @id_usuario, @estado",
                    sqlParams);
            } catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            return rowsAffected > 0;
        }

    }
}
