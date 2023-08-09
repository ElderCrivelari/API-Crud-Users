
using CRUDUsersAPI.Data;
using CRUDUsersAPI.Repository;

namespace CRUDUsersAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDbContext<DatabaseContext>();
            // Add services to the container.
            builder.Services.AddControllers();


            //Scoped Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();

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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllerRoute(
                name:   "default",
                pattern:"{controller=Home}/{action=Index}/{id?}"
                );

            app.Run();
        }
    }
}