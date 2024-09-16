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
    public partial class SetUsuario : Form
    {
        db_connectionDataContext db_connection;
        string nombre, ap_paterno, ap_materno, ci, usuario, pass, tipo;
        bool estado;
        public SetUsuario()
        {
            InitializeComponent();

            db_connection = new db_connectionDataContext();

            tbNombre.Text = tbApPaterno.Text = tbApMaterno.Text = tbCi.Text = tbUsuario.Text = tbPass.Text = "";
            cbTipo.Items.Clear();
            cbTipo.Items.Add("VENDEDOR");
            cbTipo.Items.Add("ADMINISTRADOR");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            nombre = tbNombre.Text;
            ap_paterno = tbApPaterno.Text;
            ap_materno = tbApMaterno.Text;
            ci = tbCi.Text;
            usuario = tbUsuario.Text;
            pass = tbPass.Text;
            tipo = cbTipo.Text;
            estado = tglHabilitado.Checked;

            db_connection.sp_insertar_usuario(ci, nombre, ap_paterno, ap_materno, usuario, pass, tipo, estado);

        }
    }
}
