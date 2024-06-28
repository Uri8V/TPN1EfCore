using Microsoft.Extensions.DependencyInjection;
using TPN1EfCore.IOC;

namespace TPN1EfCore.Windows
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var serviceProvider = DI.ConfiguracionServicios(); 
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmPrincipal(serviceProvider));//Hago esto para después poder injectar el service en cualquier form futuro
                                                        //y poder usar los servicios que deseo
        }
    }
}