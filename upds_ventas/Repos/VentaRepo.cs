using System.Data.SqlClient;
using upds_ventas.Data;
using upds_ventas.Models;

namespace upds_ventas.Repos
{
    public class VentaRepo
    {
        private readonly DatabaseContext db;
        public VentaRepo()
        {
            db = new DatabaseContext();
        }

        public bool Insertar(Venta v)
        {
            const string sql = "EXEC dbo.sp_registrar_venta @id_usuario, @id_cliente, @total";
            int IdVenta;
            bool success = true;
            try
            {
                db.Connect();
                using (SqlCommand cmd = new SqlCommand(sql, db.Con))
                {
                    cmd.Parameters.AddWithValue("@id_usuario", v.IdUsuario);
                    cmd.Parameters.AddWithValue("@id_cliente", v.IdCliente);
                    cmd.Parameters.AddWithValue("@total", v.Total);
                    IdVenta = Convert.ToInt32(cmd.ExecuteScalar());
                }

                foreach (DetalleVenta d in v.DetalleVenta)
                {
                    const string sqlDetalle = "EXEC dbo.sp_registrar_detalle @id_venta, @id_producto, @cantidad, @sub_total";
                    using SqlCommand cmdDetalle = new SqlCommand(sqlDetalle, db.Con);
                    cmdDetalle.Parameters.AddWithValue("@id_venta", IdVenta);
                    cmdDetalle.Parameters.AddWithValue("@id_producto", d.IdProducto);
                    cmdDetalle.Parameters.AddWithValue("@cantidad", d.Cantidad);
                    cmdDetalle.Parameters.AddWithValue("@sub_total", d.SubTotal);
                    bool detailSuccess = cmdDetalle.ExecuteNonQuery() > 0;
                    if (!detailSuccess)
                    {
                        MessageBox.Show($"Error al registrar detalle de la venta:", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                return success;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al registrar la venta:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { db.Close(); }
        }

        //public Venta Reporte(int idVenta)
        //{
        //    const string sql = "EXEC dbo.sp_reporte_venta @id_venta";
        //    Venta? venta = null;
        //    try
        //    {
        //        db.Connect();
        //        using SqlCommand cmd = new SqlCommand(sql, db.Con);
        //        cmd.Parameters.AddWithValue("@id_venta", idVenta);
        //        using SqlDataReader reader = cmd.ExecuteReader();

        //        if (reader.Read())
        //        {
        //            venta = new Venta
        //            {
        //                IdVenta = reader.GetInt32(reader.GetOrdinal("id_venta")),
        //                Fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
        //                Total = reader.GetDecimal(reader.GetOrdinal("total")),
        //                Cliente = new Cliente
        //                {
        //                    Nit = reader.GetString(reader.GetOrdinal("cliente_nit")),
        //                    Persona = new Persona
        //                    {
        //                        Ci = reader.GetString(reader.GetOrdinal("cliente_ci")),
        //                        Nombre = reader.GetString(reader.GetOrdinal("cliente_nombre")),
        //                        ApPaterno = reader.GetString(reader.GetOrdinal("cliente_ap_paterno")),
        //                        ApMaterno = reader.GetString(reader.GetOrdinal("cliente_ap_materno"))
        //                    }
        //                },
        //                Usuario = new Usuario
        //                {
        //                    NombreUsuario = reader.GetString(reader.GetOrdinal("usuario_nombre")),
        //                    Persona = new Persona
        //                    {
        //                        Ci = reader.GetString(reader.GetOrdinal("usuario_ci")),
        //                        Nombre = reader.GetString(reader.GetOrdinal("usuario_nombre_real")),
        //                        ApPaterno = reader.GetString(reader.GetOrdinal("usuario_ap_paterno")),
        //                        ApMaterno = reader.GetString(reader.GetOrdinal("usuario_ap_materno"))
        //                    }
        //                },
        //                DetalleVenta = new List<DetalleVenta>()
        //            };
        //        }

        //        if (venta != null && reader.NextResult())
        //        {
        //            while (reader.Read())
        //            {
        //                venta.DetalleVenta.Add(new DetalleVenta
        //                {
        //                    IdDetalleVenta = reader.GetInt32(reader.GetOrdinal("id_detalle_venta")),
        //                    IdProducto = reader.GetInt32(reader.GetOrdinal("id_producto")),
        //                    Cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")),
        //                    SubTotal = reader.GetDecimal(reader.GetOrdinal("sub_total"))
        //                });
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error al obtener reporte de la venta:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //    finally
        //    {
        //        db.Close();
        //    }

        //    return venta;
        //}

        public List<Venta> ObtenerVentas()
        {
            const string sql = "EXEC dbo.sp_reporte_ventas";
            List<Venta> ventas = new List<Venta>();

            try
            {
                db.Connect();
                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    ventas.Add(new Venta
                    {
                        IdVenta = reader.GetInt32(reader.GetOrdinal("id_venta")),
                        Fecha = reader.GetDateTime(reader.GetOrdinal("fecha")),
                        Total = reader.GetDecimal(reader.GetOrdinal("total")),

                        Usuario = new Usuario
                        {
                            Tipo = reader.GetString(reader.GetOrdinal("usuario_tipo")),
                            Persona = new Persona
                            {
                                Ci = reader.GetString(reader.GetOrdinal("usuario_ci")),
                                Nombre = reader.GetString(reader.GetOrdinal("usuario_nombre")),
                                ApPaterno = reader.GetString(reader.GetOrdinal("usuario_ap_paterno")),
                                ApMaterno = reader.IsDBNull(reader.GetOrdinal("usuario_ap_materno")) ? "" : reader.GetString(reader.GetOrdinal("usuario_ap_materno"))
                            }
                        },

                        Cliente = new Cliente
                        {
                            Nit = reader.GetString(reader.GetOrdinal("cliente_nit")),
                            Persona = new Persona
                            {
                                Nombre = reader.GetString(reader.GetOrdinal("cliente_nombre")),
                                ApPaterno = reader.GetString(reader.GetOrdinal("cliente_ap_paterno")),
                                ApMaterno = reader.IsDBNull(reader.GetOrdinal("cliente_ap_materno")) ? "" : reader.GetString(reader.GetOrdinal("cliente_ap_materno"))
                            }
                        },

                        DetalleVenta = new List<DetalleVenta>()
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener ventas:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.Close(); }

            return ventas;
        }

        public List<DetalleVenta> ObtenerDetalleVenta(int idVenta)
        {
            const string sql = "EXEC dbo.sp_reporte_detalle_venta @id_venta";
            List<DetalleVenta> detalles = new List<DetalleVenta>();

            try
            {
                db.Connect();
                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                cmd.Parameters.AddWithValue("@id_venta", idVenta);
                using SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    detalles.Add(new DetalleVenta
                    {
                        IdDetalleVenta = reader.GetInt32(reader.GetOrdinal("id_detalle_venta")),
                        IdVenta = idVenta,
                        IdProducto = reader.GetInt32(reader.GetOrdinal("id_producto")),
                        Cantidad = reader.GetInt32(reader.GetOrdinal("cantidad")),
                        SubTotal = reader.GetDecimal(reader.GetOrdinal("sub_total")),
                        Producto = new Producto()
                        {
                            IdProducto = reader.GetInt32(reader.GetOrdinal("id_producto")),
                            Nombre = reader.GetString(reader.GetOrdinal("nombre_producto")),
                            PrecioVenta = reader.GetDecimal(reader.GetOrdinal("precio_venta")),
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al obtener detalles de venta:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.Close(); }

            return detalles;
        }

        public List<Venta> Reporte()
        {
            var ventas = ObtenerVentas();

            foreach (var venta in ventas)
            {
                venta.DetalleVenta = ObtenerDetalleVenta(venta.IdVenta);
            }

            return ventas;
        }

    }
}
