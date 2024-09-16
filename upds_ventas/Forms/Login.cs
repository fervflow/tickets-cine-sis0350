using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace upds_ventas.Forms
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MenuPrincipal form = new MenuPrincipal();
            form.FormClosed += (s, args) => this.Close();
            this.Hide();
            form.Show();
        }
    }
}
