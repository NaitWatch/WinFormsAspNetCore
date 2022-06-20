using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.EventLog;
using Microsoft.OpenApi.Models;

namespace WinFormsAspNetCore
{
    public class Program
    {
        public static Form1 MainForm { get; private set; }

        [STAThread]
        public static void Main(string[] args)
        {
            ApplicationConfiguration.Initialize();

            var builder = WebApplication.CreateBuilder(args);

            builder.Logging.ClearProviders();
            builder.Logging.AddConsole();

            builder.Services.AddMvc().AddXmlDataContractSerializerFormatters();

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

            //app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.RunAsync();

            MainForm = app.Services.GetRequiredService<Form1>();

            Application.Run(MainForm);

            app.StopAsync();
        }
    }
}