﻿using System.Data.SqlClient;
using tickets_cine.Data;
using tickets_cine.Models;

namespace tickets_cine.Repos
{
    public class ClienteRepo
    {
        private readonly DatabaseContext db;

        public ClienteRepo()
        {
            db = new DatabaseContext();
        }

        public bool Set(Cliente c, bool isNew)
        {
            string sql;
            if (isNew)
            {
                sql = "EXEC dbo.sp_insertar_cliente @ci, @nombre";
            }
            else
            {
                sql = "EXEC dbo.sp_modificar_cliente @id_cliente, @ci, @nombre";
            }
            try
            {
                db.Connect();
                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                if (!isNew) cmd.Parameters.AddWithValue("@id_cliente", c.IdCliente);
                cmd.Parameters.AddWithValue("@ci", c.Persona.Ci);
                cmd.Parameters.AddWithValue("@nombre", c.Persona.Nombre);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al {(isNew ? "crear" : "modificar")} el cliente:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { db.Close(); }
        }

        public List<Cliente> Listar()
        {
            const string sql = "EXEC dbo.sp_listar_clientes";
            var clientes = new List<Cliente>();
            try
            {
                db.Connect();
                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        IdCliente = reader.GetInt32(reader.GetOrdinal("id_cliente")),
                        Persona = new Persona
                        {
                            IdPersona = reader.GetInt32(reader.GetOrdinal("id_cliente")),
                            Ci = reader.GetString(reader.GetOrdinal("ci")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar clientes:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.Close(); }

            return clientes;
        }

        public Cliente BuscarCliente(string nit)
        {
            const string sql = "EXEC dbo.sp_buscar_cliente @nit";
            var cliente = new Cliente();
            try
            {
                db.Connect();
                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                cmd.Parameters.AddWithValue("nit", nit);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cliente = new Cliente
                    {
                        IdCliente = reader.GetInt32(reader.GetOrdinal("id_cliente")),
                        //Nit = reader.IsDBNull(reader.GetOrdinal("nit")) ? null : reader.GetString(reader.GetOrdinal("nit")),
                        Persona = new Persona
                        {
                            IdPersona = reader.GetInt32(reader.GetOrdinal("id_cliente")),
                            Ci = reader.GetString(reader.GetOrdinal("ci")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                            //ApPaterno = reader.GetString(reader.GetOrdinal("ap_paterno")),
                            //ApMaterno = reader.IsDBNull(reader.GetOrdinal("ap_materno")) ? null : reader.GetString(reader.GetOrdinal("ap_materno"))
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al buscar cliente:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.Close(); }

            return cliente;
        }

        public List<Cliente> Reporte()
        {
            const string sql = "EXEC dbo.sp_reporte_clientes";
            var clientes = new List<Cliente>();
            try
            {
                db.Connect();
                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    clientes.Add(new Cliente
                    {
                        //Nit = reader.GetString(reader.GetOrdinal("nit")),
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
                MessageBox.Show($"Error al listar clientes:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.Close(); }

            return clientes;
        }

    }
}
