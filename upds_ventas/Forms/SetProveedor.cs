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
    public partial class SetProveedor : Form
    {
        private readonly ProveedorRepo repo;
        private bool isNew;
        private Proveedor proveedor;

        public SetProveedor()
        {
            repo = new ProveedorRepo();
            isNew = true;
            proveedor = new Proveedor();

            InitializeComponent();

            FormTitle.Text = "Registrar Nuevo Proveedor";
            TbNit.Text = TbNombre.Text = TbDireccion.Text = TbTelefono.Text = "";
            CbCiudad.Items.Add("POTOSI");
            CbCiudad.Items.Add("COCHABAMBA");
            CbCiudad.Items.Add("CHUQUISACA");
            CbCiudad.Items.Add("TARIJA");
            CbCiudad.Items.Add("LA PAZ");
            CbCiudad.Items.Add("SANTA CRUZ");
            CbCiudad.Items.Add("ORURO");
            CbCiudad.Items.Add("BENI");
            CbCiudad.Items.Add("PANDO");
        }

        public void SetForModificar(Proveedor p)
        {
            isNew = false;

            FormTitle.Text = "Editar Proveedor";
            TbNit.Text = p.Nit;
            TbNombre.Text = p.Nombre;
            TbDireccion.Text = p.Direccion;
            TbTelefono.Text = p.Telefono;
            CbCiudad.SelectedItem = p.Ciudad;

            proveedor.IdProveedor = p.IdProveedor;
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            proveedor.Nit = TbNit.Text;
            proveedor.Nombre = TbNombre.Text;
            proveedor.Direccion = TbDireccion.Text;
            proveedor.Telefono = TbTelefono.Text;
            proveedor.Ciudad = CbCiudad.Text;

            bool querySuccess;
            if (isNew)
            {
                querySuccess = await repo.InsertarAsync(proveedor);
            }
            else
            {
                querySuccess = await repo.ModificarAsync(proveedor);
            }
            if (querySuccess)
            {
                MessageBox.Show("Datos de proveedor guardados exitosamente!");
            }
            else
            {
                MessageBox.Show("Error al guardar los datos del proveedor.");
            }

            this.Close();
        }
    }
}
