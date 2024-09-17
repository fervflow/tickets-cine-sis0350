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
    public partial class Login : Form
    {
        private readonly UsuarioRepo _usuarioRepo;
        public Login(UsuarioRepo usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //using (var scope = Program.ServiceProvider.CreateScope())
            //{
                //var formMenuPrincipal = new MenuPrincipal();
            var formMenuPrincipal = Program.ServiceProvider.GetRequiredService<MenuPrincipal>();
            formMenuPrincipal.FormClosed += (s, args) => this.Close();
            this.Hide();
            formMenuPrincipal.Show();

            //}
        }
    }
}
