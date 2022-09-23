using Microsoft.Extensions.FileProviders;
using static System.Net.Mime.MediaTypeNames;

namespace Sid.bookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }

           
            app.UseStaticFiles();
            app.UseStaticFiles(new StaticFileOptions() {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "PrivateImages")),
                RequestPath = "/PrivateImages"
            });
            app.UseRouting();

            app.UseAuthorization();

            app.MapDefaultControllerRoute();
            app.Run();
        }
    }
}