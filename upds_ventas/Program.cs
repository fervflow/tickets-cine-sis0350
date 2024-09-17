using Microsoft.Extensions.DependencyInjection;
using upds_ventas.Data;
using upds_ventas.Forms;
using upds_ventas.Repos;

namespace upds_ventas
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; } = null!;
        [STAThread]
        static void Main()
        //{
        //    ApplicationConfiguration.Initialize();
        //    Application.Run(new Forms.Login());
        //}
        {
            var services = ConfigureServices();
            ServiceProvider = services.BuildServiceProvider();

            ApplicationConfiguration.Initialize();

            // Create and run the main form with DI
            var mainForm = ServiceProvider.GetRequiredService<Login>();
            Application.Run(mainForm);
        }

        private static IServiceCollection ConfigureServices()
        {
            var services = new ServiceCollection();

            // Register DbContext with the connection string
            services.AddDbContext<UpdsVentasContext>();

            // Register repositories
            services.AddScoped<UsuarioRepo>();
            //services.AddScoped<ProductoRepo>();
            //services.AddScoped<ProveedorRepo>();

            // Register the main form and other forms if needed
            services.AddScoped<Login>();
            services.AddScoped<MenuPrincipal>();
            services.AddScoped<SetUsuario>();
            services.AddScoped<SetProveedor>();

            return services;
        }
    }
}