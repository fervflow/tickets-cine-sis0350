using upds_ventas.Models;
using upds_ventas.Repos;

namespace upds_ventas.Forms
{
    public partial class SetCliente : Form
    {
        private readonly ClienteRepo repo;
        bool isNew;
        Cliente cliente;
        public SetCliente()
        {
            repo = new ClienteRepo();
            isNew = true;
            cliente = new Cliente();

            InitializeComponent();

            TbCi.Text = TbNombre.Text = TbApPaterno.Text = TbApMaterno.Text = TbNit.Text = "";
        }

        public void SetForModificar(Cliente c)
        {
            isNew = false;

            SetClienteSkin.Text = "Modificar Cliente";

            TbCi.Text = c.Persona.Ci;
            TbNombre.Text = c.Persona.Nombre;
            //TbApPaterno.Text = c.Persona.ApPaterno;
            //TbApMaterno.Text = c.Persona.ApMaterno;
            //TbNit.Text = c.Nit ?? "";

            cliente.IdCliente = c.IdCliente;
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            cliente.Persona = new Persona
            {
                IdPersona = cliente.IdCliente,
                Ci = TbCi.Text,
                Nombre = TbNombre.Text,
                //ApPaterno = TbApPaterno.Text,
                //ApMaterno = TbApMaterno.Text
            };
            //cliente.Nit = string.IsNullOrWhiteSpace(TbNit.Text) ? null : TbNit.Text;

            bool querySuccess = repo.Set(cliente, isNew);

            if (querySuccess)
            {
                MessageBox.Show("Datos del cliente guardados exitosamente!");
            }
            else
            {
                MessageBox.Show("Error al guardar los datos del cliente.");
            }
            this.Close();
        }
    }
}
