using System.Data.SqlClient;
using tickets_cine.Data;
using tickets_cine.Models;

namespace tickets_cine.Repos
{
    public class ProductoRepo
    {
        private readonly DatabaseContext db;

        public ProductoRepo()
        {
            db = new DatabaseContext();
        }

        public List<(int, string)> ObtenerProveedores()
        {
            const string sql = "EXEC dbo.sp_nombres_proveedor";
            var proveedores = new List<(int, string)>();
            try
            {
                db.Connect();
                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    proveedores.Add((
                        reader.GetInt32(reader.GetOrdinal("id_proveedor")),
                        reader.GetString(reader.GetOrdinal("nombre"))
                    ));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar proveedores:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.Close(); }
            return proveedores;
        }

        public bool Set(Producto p, bool isNew)
        {
            string sql;
            if (isNew)
            {
                sql = "EXEC dbo.sp_nuevo_producto @nombre, @stock, @precio_compra, @precio_venta, @estado, @id_proveedor";
            }
            else
            {
                sql = "EXEC dbo.sp_modificar_producto @id_producto, @nombre, @stock, @precio_compra, @precio_venta, @estado, @id_proveedor";
            }
            try
            {
                db.Connect();
                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                if (!isNew) cmd.Parameters.AddWithValue("@id_producto", p.IdProducto);
                cmd.Parameters.AddWithValue("@nombre", p.Nombre);
                cmd.Parameters.AddWithValue("@stock", p.Stock ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@precio_compra", p.PrecioCompra);
                cmd.Parameters.AddWithValue("@precio_venta", p.PrecioVenta ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@estado", p.Estado);
                cmd.Parameters.AddWithValue("@id_proveedor", p.IdProveedor);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al {(isNew ? "crear" : "modificar")} el producto:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { db.Close(); }
        }

        public List<Producto> Listar(bool filtrar)
        {
            const string sql = "EXEC dbo.sp_listar_productos @filter";
            var productos = new List<Producto>();
            try
            {
                db.Connect();
                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                cmd.Parameters.AddWithValue("@filter", filtrar);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        IdProducto = reader.GetInt32(reader.GetOrdinal("id_producto")),
                        IdProveedor = reader.GetInt32(reader.GetOrdinal("id_proveedor")),
                        Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                        Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                        PrecioCompra = reader.GetDecimal(reader.GetOrdinal("precio_compra")),
                        PrecioVenta = reader.GetDecimal(reader.GetOrdinal("precio_venta")),
                        Estado = reader.GetBoolean(reader.GetOrdinal("estado")),
                        Proveedor = new Proveedor
                        {
                            IdProveedor = reader.GetInt32(reader.GetOrdinal("id_proveedor")),
                            Nombre = reader.GetString(reader.GetOrdinal("proveedor")),
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar productos:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.Close(); }

            return productos;
        }

        public bool Eliminar(int IdProducto)
        {
            const string sql = "EXEC dbo.sp_deshabilitar_producto @id_producto";
            try
            {
                db.Connect();

                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                cmd.Parameters.AddWithValue("@id_producto", IdProducto);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar el producto:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            finally { db.Close(); }
        }

        public List<Producto> Reporte()
        {
            const string sql = "EXEC dbo.sp_reporte_producto";
            var productos = new List<Producto>();
            try
            {
                db.Connect();
                using SqlCommand cmd = new SqlCommand(sql, db.Con);
                using SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    productos.Add(new Producto
                    {
                        Nombre = reader.GetString(reader.GetOrdinal("nombre")),
                        Stock = reader.GetInt32(reader.GetOrdinal("stock")),
                        PrecioVenta = reader.GetDecimal(reader.GetOrdinal("precio_venta")),
                        Estado = reader.GetBoolean(reader.GetOrdinal("estado")),
                        Proveedor = new Proveedor
                        {
                            Nombre = reader.GetString(reader.GetOrdinal("proveedor")),
                            Ciudad = reader.GetString(reader.GetOrdinal("ciudad")),
                        }
                    });
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al listar productos:\n{ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally { db.Close(); }

            return productos;
        }
    }
}
