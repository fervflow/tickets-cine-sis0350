using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    }
}
