using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using upds_ventas.Data;
using upds_ventas.Models;
using upds_ventas.Repos;

namespace upds_ventas.Forms
{
    public partial class SetUsuario : Form
    {
        private readonly UsuarioRepo _usuarioRepo;
        private bool isNewUser;
        private Usuario usuario;

        public SetUsuario(UsuarioRepo usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
            isNewUser = true;
            usuario = new Usuario
            {
                Persona = new Persona()
            };

            InitializeComponent();

            SetUsuarioForm.Text = "Registrar Nuevo Usuario";
            tbNombre.Text = tbApPaterno.Text = tbApMaterno.Text = tbCi.Text = tbUsuario.Text = tbPass.Text = "";
            //cbTipo.Items.Clear();
            cbTipo.Items.Add("VENDEDOR");
            cbTipo.Items.Add("ADMINISTRADOR");
        }

        public void SetForModificar(Usuario u) {
            isNewUser = false;

            SetUsuarioForm.Text = "Modificar Usuario";
            tbNombre.Text = u.Persona.Nombre;
            tbApPaterno.Text = u.Persona.ApPaterno;
            tbApMaterno.Text = u.Persona.ApMaterno;
            tbCi.Text = u.Persona.Ci;
            tbUsuario.Text = u.NombreUsuario;
            tbPass.Text = u.Pass;
            cbTipo.SelectedItem = u.Tipo;

            usuario.IdUsuario = u.IdUsuario;
        }

        private void SetUsuario_Load(object sender, EventArgs e)
        {
            //cbTipo.Items.Clear();
            //cbTipo.Items.Add("VENDEDOR");
            //cbTipo.Items.Add("ADMINISTRADOR");

            //if (isNewUser)
            //{
            //    cbTipo.SelectedItem = usuario!.Tipo;
            //}
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            usuario.Persona.Ci = tbCi.Text;
            usuario.Persona.Nombre = tbNombre.Text;
            usuario.Persona.ApPaterno = tbApPaterno.Text;
            usuario.Persona.ApMaterno = tbApMaterno.Text;
            usuario.NombreUsuario = tbUsuario.Text;
            usuario.Pass = tbPass.Text;
            usuario.Tipo = cbTipo.Text;
            usuario.Estado = tglHabilitado.Checked;


            bool querySuccess;
            if (isNewUser)
            {
                querySuccess = await _usuarioRepo.InsertarUsuarioAsync(usuario);
            }
            else
            {
                querySuccess = await _usuarioRepo.ModificarUsuarioAsync(usuario);
                //MessageBox.Show("SP modificar executed with rowsAffected: " + rowsAffected);
            }

            if (querySuccess)
            {
                MessageBox.Show("Datos de usuario guardados exitosamente!");
            }
            else
            {
                MessageBox.Show("Error al guardar los datos del usuario.");
            }

            this.Close();

        }
    }
}
