using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BaiTapLon_WinFormApp.Models;
using BaiTapLon_WinFormApp.Views.Teacher;
using BaiTapLon_WinFormApp.Repositories.Interfaces;
using BaiTapLon_WinFormApp.Repositories.Implementations;
using BaiTapLon_WinFormApp.Services.Interfaces;
using BaiTapLon_WinFormApp.Services.Implementations;
using EnglishCenterManagement.UI.Views;

namespace BaiTapLon_WinFormApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // 1. Đọc file appsettings.json
            var config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // 2. Tạo ServiceCollection để đăng ký các service (DI)
            var services = new ServiceCollection();

            

            // 3. Đăng ký DbContext EF Core
            services.AddDbContext<EnglishCenterDbContext>(options =>
                options.UseSqlServer(config.GetConnectionString("EnglishCenterDb")));

            //Đăng ký các service cho Repository ở đây
            services.AddScoped<IStudentRepository, StudentRepository>();

            //Đăng ký các service cho Service ở đây
            services.AddScoped<IStudentService, StudentService>();


            // 4. Đăng ký Form cần dùng DI
            services.AddTransient<Form1>();
            services.AddTransient<TeacherMainForm>();
            services.AddTransient<StudentFrom>();
            // 5. Build provider
            var provider = services.BuildServiceProvider();

            // 6. Chạy WinForms
            ApplicationConfiguration.Initialize();
            Application.Run(provider.GetRequiredService<StudentFrom>());
        }
    }
}
