using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using upds_ventas.Repos;

namespace upds_ventas.Forms
{
    public partial class MenuPrincipal : Form
    {
        private readonly UsuarioRepo _usuarioRepo;
        public MenuPrincipal(UsuarioRepo usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
            InitializeComponent();
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            var formSetUsuario = Program.ServiceProvider.GetRequiredService<SetUsuario>();
            formSetUsuario.ShowDialog();
            
        }
    }
}
