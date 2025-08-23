using System;
using System.Windows.Forms;
using DesktopPsychologist_WF.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DesktopPsychologist_WF
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            var serviceProvider = serviceCollection.BuildServiceProvider();

            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {

            // Регистрация сервисов
            services.AddTransient<IHttpClient, ApiHttpClient>();

            // Регистрация форм
            services.AddTransient<Form1>();
        }
    }
}
