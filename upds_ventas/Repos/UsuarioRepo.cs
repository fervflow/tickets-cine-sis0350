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

        public async Task<int> InsertarUsuarioAsync(Persona persona, string usuario, string pass, string tipo, bool estado)
        {
            SqlParameter[] sqlParams = [
                new SqlParameter("@ci", persona.Ci),
                new SqlParameter("@nombre", persona.Nombre),
                new SqlParameter("@ap_paterno", persona.ApPaterno),
                new SqlParameter("@ap_materno", persona.ApMaterno ?? (object)DBNull.Value),
                new SqlParameter("@usuario", usuario),
                new SqlParameter("@pass", pass),
                new SqlParameter("@tipo", tipo),
                new SqlParameter("@estado", estado)

            ];

            var rowsAffected = await _dbContext.Database.ExecuteSqlRawAsync(
                "EXEC dbo.sp_insertar_usuario @ci, @nombre, @ap_paterno, @ap_materno, @usuario, @pass, @tipo, @estado",
                sqlParams);

            return rowsAffected;
        }
    }
}
