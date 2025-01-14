using System.Diagnostics;
//using upds_ventas.Utils;
using upds_ventas.Models;
using upds_ventas.Reports;
using upds_ventas.Repos;

namespace upds_ventas.Forms
{
    public partial class MenuPrincipal : Form
    {
        private readonly UsuarioRepo _usuarioRepo;
        private readonly ClienteRepo _clienteRepo;

        private readonly Usuario usuarioActual;

        List<Usuario> usuarios;
        int IdUsuarioSeleccionado;
        Usuario? usuarioSeleccionado;

        List<Cliente> clientes;
        int IdClienteSeleccionado;
        Cliente? clienteSeleccionado;
        Cliente? clienteVenta;

        public MenuPrincipal(Usuario u)
        {
            _usuarioRepo = new UsuarioRepo();
            _clienteRepo = new ClienteRepo();

            usuarioActual = u;

            usuarios = new List<Usuario>();
            clientes = new List<Cliente>();

            InitializeComponent();
            _ = CargarUsuarios();
            CargarClientes();

            LbUsuarioActual.Text = usuarioActual.Persona.Nombre + " (" + usuarioActual.Tipo + ')';

            txtUNombre.Text = txtUApPaterno.Text = txtUApMaterno.Text = txtUCi.Text = txtUTipo.Text = "";
            btnModificarUsuario.BaseColor = Color.DarkOliveGreen;
            btnModificarUsuario.TextColor = Color.DarkGray;
            btnEliminarUsuario.BaseColor = Color.DarkRed;
            btnEliminarUsuario.TextColor = Color.DarkGray;

            LbCCi.Text = LbCNombre.Text = LbCApPaterno.Text = LbCApMaterno.Text = LbCNit.Text = "";
            BtnModificarCliente.BaseColor = Color.DarkOliveGreen;
            BtnModificarCliente.TextColor = Color.DarkGray;
            BtnModificarCliente.Enabled = false;

        }

        private async Task CargarUsuarios()
        {
            usuarios = await _usuarioRepo.ListarAsync();
            DataUsuarios.Rows.Clear();

            foreach (var u in usuarios)
            {
                object[] rowData = [
                    u.IdUsuario,
                    u.Persona.Ci!,
                    u.Persona.Nombre,
                    //u.Persona.ApPaterno,
                    //u.Persona.ApMaterno!,
                    u.Tipo!,
                    u.Estado ? "Habilidato" : "Deshabilitado"
                ];

                DataUsuarios.Rows.Add(rowData);
            }
            //MessageBox.Show("CargarUsuarios finalized");
        }

        private void CargarClientes()
        {
            clientes = _clienteRepo.Listar();
            DataClientes.Rows.Clear();
            foreach (var c in clientes)
            {
                object[] rowData = {
                    c.IdCliente,
                    c.Persona.Ci!,
                    c.Persona.Nombre,
                    //c.Persona.ApPaterno,
                    //c.Persona.ApMaterno!,
                    //c.Nit!
                };

                DataClientes.Rows.Add(rowData);
            }
        }

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
            //txtUApPaterno.Text = usuarioSeleccionado.Persona.ApPaterno;
            //txtUApMaterno.Text = usuarioSeleccionado.Persona.ApMaterno;
            txtUCi.Text = usuarioSeleccionado.Persona.Ci;
            txtUTipo.Text = usuarioSeleccionado.Tipo;
        }

        private void DataClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            IdClienteSeleccionado = (int)DataClientes.CurrentRow.Cells[0].Value;

            if (!BtnModificarCliente.Enabled)
            {
                BtnModificarCliente.Enabled = true;
                BtnModificarCliente.BaseColor = Color.FromArgb(35, 168, 109);
                BtnModificarCliente.TextColor = Color.WhiteSmoke;
            }

            clienteSeleccionado = clientes.FirstOrDefault(c => c.IdCliente.Equals(IdClienteSeleccionado))!;

            LbCCi.Text = clienteSeleccionado.Persona.Ci;
            LbCNombre.Text = clienteSeleccionado.Persona.Nombre;
            //LbCApPaterno.Text = clienteSeleccionado.Persona.ApPaterno;
            //LbCApMaterno.Text = clienteSeleccionado.Persona.ApMaterno;
            //LbCNit.Text = clienteSeleccionado.Nit;
        }

        private void BtnNuevoUsuario_Click(object sender, EventArgs e)
        {
            var formSetUsuario = new SetUsuario();
            formSetUsuario.ShowDialog();
            _ = CargarUsuarios();
        }

        private void BtnModificarUsuario_Click(object sender, EventArgs e)
        {
            var formSetUsuario = new SetUsuario();
            formSetUsuario.SetForModificar(usuarioSeleccionado!);
            formSetUsuario.ShowDialog();
            _ = CargarUsuarios();
        }

        private async void BtnEliminarUsuario_ClickAsync(object sender, EventArgs e)
        {
            bool querySuccess = await _usuarioRepo.EliminarAsync(usuarioSeleccionado!);
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

        private void BtnGenerarReporte_Click(object sender, EventArgs e)
        {

        }

        private void BtnNuevoCliente_Click(object sender, EventArgs e)
        {
            var formSetCliente = new SetCliente();
            formSetCliente.ShowDialog();
            CargarClientes();
        }

        private void BtnModificarCliente_Click(object sender, EventArgs e)
        {
            var formSetCliente = new SetCliente();
            formSetCliente.SetForModificar(clienteSeleccionado!);
            formSetCliente.ShowDialog();
            CargarClientes();
        }

        private void BtnCrearReporteClientes_Click(object sender, EventArgs e)
        {
            string reportPath = Utils.Utils.ReportPath("Reporte Clientes");
            CrearReporteClientes reporteClientes = new CrearReporteClientes(reportPath);
            reporteClientes.GenerarReporte();
            var formVisualizarReporte = new VisualizarReporte(reportPath);
            formVisualizarReporte.ShowDialog();
        }

        private void BtnCrearReporteUsuarios_Click(object sender, EventArgs e)
        {
            string reportPath = Utils.Utils.ReportPath("Reporte Usuarios");
            CrearReporteUsuarios reporteUsuarios = new CrearReporteUsuarios(reportPath);
            reporteUsuarios.GenerarReporte();
            var formVisualizarReporte = new VisualizarReporte(reportPath);
            formVisualizarReporte.ShowDialog();
        }

    }
}
