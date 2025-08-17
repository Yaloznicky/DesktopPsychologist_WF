using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
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

            //Application.Run(new Form1());
            Application.Run(serviceProvider.GetRequiredService<Form1>());
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            // Регистрация AppDbContext
            //services.AddTransient<AppDbContext>();

            // Регистрация сервисов
            //services.AddTransient<IDbService, DbService>();
            services.AddTransient<IHttpClient, ApiHttpClient>();

            // Регистрация форм
            services.AddTransient<Form1>();
        }
    }
}
