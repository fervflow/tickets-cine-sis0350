﻿using System;
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
    public partial class ReporteProductos : Form
    {
        CrearReporteProductos reporte;
        public ReporteProductos()
        {
            InitializeComponent();

            reporte = new CrearReporteProductos();
            reporte.GenerarReporte();
        }
    }
}
