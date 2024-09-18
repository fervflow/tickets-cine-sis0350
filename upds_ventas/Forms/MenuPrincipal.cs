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
using upds_ventas.Models;
using upds_ventas.Repos;

namespace upds_ventas.Forms
{
    public partial class MenuPrincipal : Form
    {
        private readonly UsuarioRepo _usuarioRepo;
        //private readonly ProveedorRepo _proveedorRepo;

        List<Usuario> usuarios;
        int IdUsuarioSeleccionado;
        Usuario? usuarioSeleccionado;

        List<Proveedor> proveedores;
        int IdProveedorSeleccionado;
        Proveedor? proveedorSeleccionado;

        public MenuPrincipal(UsuarioRepo usuarioRepo)//, ProveedorRepo proveedorRepo)
        {
            _usuarioRepo = usuarioRepo;
            //_proveedorRepo = proveedorRepo;

            usuarios = new List<Usuario>();
            proveedores = new List<Proveedor>();

            InitializeComponent();
            _ = CargarUsuarios();
            //Task loadProveedores = CargarProveedores();
            //DataUsuarios.DataSource = usuarios;

            txtUNombre.Text = txtUApPaterno.Text = txtUApMaterno.Text = txtUCi.Text = txtUTipo.Text = "";
            btnModificarUsuario.BaseColor = Color.DarkOliveGreen;
            btnModificarUsuario.TextColor = Color.DarkGray;
            btnEliminarUsuario.BaseColor = Color.DarkRed;
            btnEliminarUsuario.TextColor = Color.DarkGray;

            txtPvNit.Text = txtPvNombre.Text = txtPvDireccion.Text = txtPvTelefono.Text = txtPvCiudad.Text = "";
            BtnModificarProveedor.BaseColor = Color.DarkOliveGreen;
            BtnModificarProveedor.TextColor = Color.DarkGray;
        }

        private async Task CargarUsuarios()
        {
            usuarios = await _usuarioRepo.ListarUsuariosAsync();
            DataUsuarios.Rows.Clear();

            foreach (var u in usuarios)
            {
                object[] rowData = [
                    u.IdUsuario,
                    u.Persona.Ci!,
                    u.Persona.Nombre,
                    u.Persona.ApPaterno,
                    u.Persona.ApMaterno!,
                    u.Tipo!,
                    u.Estado ? "Habilidato" : "Deshabilitado"
                ];

                DataUsuarios.Rows.Add(rowData);
            }
            MessageBox.Show("CargarUsuarios finalized");
        }

        //private async Task CargarProveedores()
        //{
        //    proveedores = await _proveedorRepo.ListarProveedoresAsync();
        //    DataProveedores.Rows.Clear();

        //    foreach (var p in proveedores)
        //    {
        //        object[] rowData = [
        //            p.IdProveedor,
        //            p.Nit!,
        //            p.Nombre,
        //            p.Direccion,
        //            p.Telefono,
        //            p.Ciudad!,
        //        ];

        //        DataProveedores.Rows.Add(rowData);
        //    }
        //}

        private void DataUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdUsuarioSeleccionado = (int)DataUsuarios.CurrentRow.Cells[0].Value;

            if (!btnModificarUsuario.Enabled)
            {
                btnModificarUsuario.Enabled = true;
                btnModificarUsuario.BaseColor = Color.FromArgb(35, 168, 109);
                btnModificarUsuario.TextColor = Color.WhiteSmoke;
            }
            if (!btnEliminarUsuario.Enabled)
            {
                btnEliminarUsuario.Enabled = true;
                btnEliminarUsuario.BaseColor = Color.IndianRed;
                btnEliminarUsuario.TextColor = Color.WhiteSmoke;
            }

            usuarioSeleccionado = usuarios.FirstOrDefault(u => u.IdUsuario.Equals(IdUsuarioSeleccionado))!;
            txtUNombre.Text = usuarioSeleccionado.Persona.Nombre;
            txtUApPaterno.Text = usuarioSeleccionado.Persona.ApPaterno;
            txtUApMaterno.Text = usuarioSeleccionado.Persona.ApMaterno;
            txtUCi.Text = usuarioSeleccionado.Persona.Ci;
            txtUTipo.Text = usuarioSeleccionado.Tipo;
        }

        private void DataProveedores_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdProveedorSeleccionado = (int)DataProveedores.CurrentRow.Cells[0].Value;

            if (!BtnModificarProveedor.Enabled)
            {
                BtnModificarProveedor.Enabled = true;
                BtnModificarProveedor.BaseColor = Color.FromArgb(35, 168, 109);
                BtnModificarProveedor.TextColor = Color.WhiteSmoke;
            }

            proveedorSeleccionado = proveedores.FirstOrDefault(p => p.IdProveedor.Equals(IdProveedorSeleccionado))!;
            txtPvNit.Text = proveedorSeleccionado.Nit;
            txtPvNombre.Text = proveedorSeleccionado.Nombre;
            txtPvDireccion.Text = proveedorSeleccionado.Direccion;
            txtPvTelefono.Text = proveedorSeleccionado.Telefono;
            txtPvCiudad.Text = proveedorSeleccionado.Ciudad;
        }

        private void btnNuevoUsuario_Click(object sender, EventArgs e)
        {
            var formSetUsuario = Program.ServiceProvider.GetRequiredService<SetUsuario>();
            formSetUsuario.ShowDialog();
            _ = CargarUsuarios();
        }

        private void btnModificarUsuario_Click(object sender, EventArgs e)
        {
            var formSetUsuario = Program.ServiceProvider.GetRequiredService<SetUsuario>();
            formSetUsuario.SetForModificar(usuarioSeleccionado!);
            formSetUsuario.ShowDialog();
            _ = CargarUsuarios();
        }

        private async void btnEliminarUsuario_ClickAsync(object sender, EventArgs e)
        {
            bool querySuccess = await _usuarioRepo.EliminarUsuarioAsync(usuarioSeleccionado!);
            if (querySuccess)
            {
                MessageBox.Show("Usuario deshabilitado exitosamente.");
                _ = CargarUsuarios();
            }
            else
            {
                MessageBox.Show("Error al deshabilitar el usuario.");
            }
        }

        private void BtnNuevoProveedor_Click(object sender, EventArgs e)
        {
            //var formSetProveedor = Program.ServiceProvider.GetRequiredService<SetProveedor>();
            //formSetProveedor.ShowDialog();
            //_ = CargarProveedores();
        }

        private void BtnModificarProveedor_Click(object sender, EventArgs e)
        {
            //var formSetProveedor = Program.ServiceProvider.GetRequiredService<SetProveedor>();
            //formSetProveedor.SetForModificar(proveedorSeleccionado!);
            //formSetProveedor.ShowDialog();
            //_ = CargarUsuarios();
        }

        //private void BtnEliminarProveedor_Click(object sender, EventArgs e)
        //{
        //    bool querySuccess = await _proveedorRepo.EliminarProveedorAsync(proveedorSeleccionado!);
        //    if (querySuccess)
        //    {
        //        MessageBox.Show("Proveedor deshabilitado exitosamente.");
        //        CargarUsuarios();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Error al deshabilitar el proveedor.");
        //    }
        //}
    }
}
