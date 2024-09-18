using System.Data.SqlClient;

namespace upds_ventas.Data
{
    internal class DatabaseContext
    {
        private readonly string ConString;
        public SqlConnection Con { get; set; }
        public DatabaseContext()
        {
            ConString = @"Data Source=localhost;Initial Catalog=upds_ventas;User ID=upds_ventas_admin;Password=admin123";
            Con = new SqlConnection(ConString);
        }
        public void Connect()
        {
            try
            {
                Con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al conectar a la Base de Datos:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void Close()
        {
            try
            {
                Con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cerrar la conexion a la Base de Datos:\n" + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
