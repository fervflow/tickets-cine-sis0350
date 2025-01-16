using System.Diagnostics;
using tickets_cine.Models;
using tickets_cine.Repos;

namespace tickets_cine.Forms
{
    public partial class SetProducto : Form
    {
        private readonly ProductoRepo repo;
        bool isNew;
        Producto producto;
        List<(int, string)> proveedores;

        public SetProducto()
        {
            repo = new ProductoRepo();
            isNew = true;
            producto = new Producto();
            proveedores = repo.ObtenerProveedores();

            InitializeComponent();

            TbNombre.Text = TbStock.Text = TbPrecioCompra.Text = TbPrecioVenta.Text = "";
            for (int i = 0; i < proveedores.Count; i++)
            {
                CbProveedores.Items.Add(proveedores[i].Item2);
            }
        }

        public void SetForModificar(Producto p)
        {
            isNew = false;

            SetProductoSkin.Text = "Modificar Producto";
            TbNombre.Text = p.Nombre;
            TbStock.Text = p.Stock.ToString();
            TbPrecioCompra.Text = p.PrecioCompra.ToString();
            TbPrecioVenta.Text = p.PrecioVenta.ToString();
            CbProveedores.SelectedItem = proveedores.FirstOrDefault(pv => pv.Item1.Equals(p.IdProveedor)).Item2;
            tglHabilitado.Checked = p.Estado;

            producto.IdProducto = p.IdProducto;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            producto.Nombre = TbNombre.Text;
            producto.Stock = Convert.ToInt32(TbStock.Text);
            producto.PrecioCompra = Convert.ToDecimal(TbPrecioCompra.Text);
            producto.PrecioVenta = Convert.ToDecimal(TbPrecioVenta.Text);
            producto.Estado = tglHabilitado.Checked;
            producto.IdProveedor = proveedores[CbProveedores.SelectedIndex].Item1;
            Debug.WriteLine($"ComboBox Proveedores index: {CbProveedores.SelectedIndex}");

            bool querySuccess = repo.Set(producto, isNew);
            if (querySuccess)
            {
                MessageBox.Show("Datos de producto guardados exitosamente!");
            }
            else
            {
                MessageBox.Show("Error al guardar los datos del producto.");
            }
            this.Close();
        }
    }
}
