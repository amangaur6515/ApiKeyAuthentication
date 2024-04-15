using ApiKeyAuthentication.CustomFilter;
using ApiKeyAuthentication.CustomMiddleware;
using ApiKeyAuthentication.Services;

namespace ApiKeyAuthentication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            

            builder.Services.AddTransient<IApiKeyValidation, ApiKeyValidation>();

            builder.Services.AddScoped<ApiKeyAuthFilter>();
            builder.Services.AddHttpContextAccessor();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //custom middleware to enable api key authentication
            //app.UseMiddleware<ApiKeyMiddleware>();
            
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
