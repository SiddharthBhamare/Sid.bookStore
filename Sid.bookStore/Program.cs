using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using Sid.bookStore.Data;
using Sid.bookStore.Repository;
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
            builder.Services.AddDbContext<BookStoreContext>(options => options.UseSqlServer("Server=AISHU\\SQLEXPRESS;Database=BookStore;Integrated Security=True; TrustServerCertificate=True;Encrypt=True"));
            builder.Services.AddScoped<BookRepository, BookRepository>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

           
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