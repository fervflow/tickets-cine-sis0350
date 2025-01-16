//using Microsoft.Data.SqlClient;
using System.Data.SqlClient;
using tickets_cine.Data;
using tickets_cine.Models;

namespace tickets_cine.Repos
{
    internal class UsuarioRepo
    {
        private readonly DatabaseContext dbContext;

        public UsuarioRepo()
        {
            dbContext = new DatabaseContext();
        }

        public async Task<int> Autenticar(string usuario, string pass)
        {
            const string sql = "EXEC dbo.sp_login @usuario, @pass";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@pass", pass);
                var result = await cmd.ExecuteScalarAsync();
                return (int)result!;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return 3;
            }
            finally { dbContext.Close(); }
        }

        public async Task<Usuario> ObtenerUsuarioLogueado(string nombre_usuario)
        {
            Usuario usuario = new Usuario();
            const string sql = "EXEC dbo.sp_obtener_usuario_logueado @usuario";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@usuario", nombre_usuario);

                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    usuario = new Usuario
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
                            //ApPaterno = reader.GetString(reader.GetOrdinal("ap_paterno")),
                            //ApMaterno = reader.IsDBNull(reader.GetOrdinal("ap_materno")) ? null : reader.GetString(reader.GetOrdinal("ap_materno"))
                        }
                    };
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { dbContext.Close(); }
            return usuario;
        }

        public async Task<bool> Insertar(Usuario u)
        {
            const string sql = "EXEC dbo.sp_insertar_usuario @ci, @nombre, @usuario, @pass, @tipo, @estado";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@ci", u.Persona.Ci);
                cmd.Parameters.AddWithValue("@nombre", u.Persona.Nombre);
                //cmd.Parameters.AddWithValue("@ap_paterno", u.Persona.ApPaterno);
                //cmd.Parameters.AddWithValue("@ap_materno", u.Persona.ApMaterno ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@usuario", u.NombreUsuario);
                cmd.Parameters.AddWithValue("@pass", u.Pass);
                cmd.Parameters.AddWithValue("@tipo", u.Tipo);
                cmd.Parameters.AddWithValue("@estado", u.Estado);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al crear el usuario:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }

        public async Task<List<Usuario>> ListarAsync()
        {
            const string sql = "EXEC dbo.sp_listar_usuarios";
            var usuarios = new List<Usuario>();
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                using SqlDataReader reader = await cmd.ExecuteReaderAsync();
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
                            //ApPaterno = reader.GetString(reader.GetOrdinal("ap_paterno")),
                            //ApMaterno = reader.IsDBNull(reader.GetOrdinal("ap_materno")) ? null : reader.GetString(reader.GetOrdinal("ap_materno"))
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar usuarios:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { dbContext.Close(); }

            return usuarios;
        }

        public async Task<bool> ModificarAsync(Usuario u)
        {
            const string sql = "EXEC dbo.sp_modificar_usuario @id_usuario, @ci, @nombre, @usuario, @pass, @tipo, @estado";
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@id_usuario", u.IdUsuario);
                cmd.Parameters.AddWithValue("@ci", u.Persona.Ci);
                cmd.Parameters.AddWithValue("@nombre", u.Persona.Nombre);
                //cmd.Parameters.AddWithValue("@ap_paterno", u.Persona.ApPaterno);
                //cmd.Parameters.AddWithValue("@ap_materno", u.Persona.ApMaterno ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@usuario", u.NombreUsuario);
                cmd.Parameters.AddWithValue("@pass", u.Pass);
                cmd.Parameters.AddWithValue("@tipo", u.Tipo);
                cmd.Parameters.AddWithValue("@estado", u.Estado);
                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el usuario:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }

        public async Task<bool> EliminarAsync(Usuario u)
        {
            const string sql = "EXEC dbo.sp_deshabilitar_usuario @id_usuario, @estado";
            try
            {
                dbContext.Connect();

                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                cmd.Parameters.AddWithValue("@id_usuario", u.IdUsuario);
                cmd.Parameters.AddWithValue("@estado", u.Estado);

                return await cmd.ExecuteNonQueryAsync() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al modificar el usuario:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { dbContext.Close(); }
        }

        public List<Usuario> Reporte()
        {
            const string sql = "EXEC dbo.sp_reporte_usuarios";
            var usuarios = new List<Usuario>();
            try
            {
                dbContext.Connect();
                using SqlCommand cmd = new SqlCommand(sql, dbContext.Con);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        NombreUsuario = reader.GetString(reader.GetOrdinal("nombre_usuario")),
                        Tipo = reader.GetString(reader.GetOrdinal("tipo")),
                        Estado = reader.GetBoolean(reader.GetOrdinal("estado")),
                        Persona = new Persona
                        {
                            Ci = reader.GetString(reader.GetOrdinal("ci")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            //ApPaterno = reader.GetString(reader.GetOrdinal("ap_paterno")),
                            //ApMaterno = reader.IsDBNull(reader.GetOrdinal("ap_materno")) ? "" : reader.GetString(reader.GetOrdinal("ap_materno")),
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar usuarios:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { dbContext.Close(); }

            return usuarios;
        }

    }
}
