using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace WinFormsApp
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options => options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Contact = new OpenApiContact() { Email = "e@mail.com", Name = "Name", Url = new Uri("http://localhost") }
            }));

            builder.Services.AddSingleton<Form1>();

            var app = builder.Build();
            
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

            }

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.RunAsync();

            Form1 frm = app.Services.GetRequiredService<Form1>();
            Application.Run(frm);

            app.StopAsync();
        }
    }
}