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

        public SetUsuario(UsuarioRepo usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
            InitializeComponent();

            //db_connection = new UpdsVentasContext();

            tbNombre.Text = tbApPaterno.Text = tbApMaterno.Text = tbCi.Text = tbUsuario.Text = tbPass.Text = "";
            cbTipo.Items.Clear();
            cbTipo.Items.Add("VENDEDOR");
            cbTipo.Items.Add("ADMINISTRADOR");
        }

        private async void btnGuardar_Click(object sender, EventArgs e)
        {
            var persona = new Persona
            {
                Ci = tbCi.Text,
                Nombre = tbNombre.Text,
                ApPaterno = tbApPaterno.Text,
                ApMaterno = tbApMaterno.Text
            };

            string usuario = tbUsuario.Text;
            string pass = tbPass.Text;
            string tipo = cbTipo.Text;
            bool estado = tglHabilitado.Checked;

            MessageBox.Show("Nombre: " + persona.Nombre + "\nAp_paterno: " + persona.ApPaterno + "\nAp_materno: " + persona.ApMaterno +
                "\nCI: " + persona.Ci + "\nUsuario: " + usuario + "\nPass: " + pass + "\nTipo: " + tipo + "\nestado: " + estado);

            int rowsAffected = await _usuarioRepo.InsertarUsuarioAsync(persona, usuario, pass, tipo, estado);

            if (rowsAffected > 0)
            {
                MessageBox.Show("Usuario registrado exitosamente!");
            }
            else
            {
                MessageBox.Show("Error al registrar el usuario.");
            }

        }
    }
}
