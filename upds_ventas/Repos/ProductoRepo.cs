using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using upds_ventas.Data;

namespace upds_ventas.Repos
{
    public class ProductoRepo
    {
        private readonly UpdsVentasContext _dbContext;
        
        public ProductoRepo(UpdsVentasContext dbContext)
        {
            _dbContext = dbContext;
        }


    }
}
