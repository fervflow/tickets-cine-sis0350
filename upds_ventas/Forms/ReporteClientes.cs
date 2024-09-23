using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using upds_ventas.Reports;

namespace upds_ventas.Forms
{
    public partial class ReporteClientes : Form
    {
        CrearReporteClientes reporteClientes;
        public ReporteClientes()
        {
            InitializeComponent();

            reporteClientes = new CrearReporteClientes();
            reporteClientes.GenerarReporte();
        }
    }
}
