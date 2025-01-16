using tickets_cine.Models;
using tickets_cine.Repos;

namespace tickets_cine.Forms
{
    public partial class Login : Form
    {
        UsuarioRepo repo;
        public Login()
        {
            repo = new UsuarioRepo();
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            int result = await repo.Autenticar(TbUsuario.Text, TbPass.Text);

            switch (result)
            {
                case 0:
                    Usuario usuarioActual = await repo.ObtenerUsuarioLogueado(TbUsuario.Text);
                    var formMenuPrincipal = new MenuPrincipal(usuarioActual);
                    formMenuPrincipal.FormClosed += (s, args) => this.Close();
                    this.Hide();
                    formMenuPrincipal.Show();
                    break;
                case 1:
                    MessageBox.Show($"Usuario '{TbUsuario.Text}' no encontrado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 2:
                    MessageBox.Show($"El usuario '{TbUsuario.Text}' está deshabilitado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case 3:
                    MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
    }
}
