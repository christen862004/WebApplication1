using WebApplication1.Hubs;

namespace WebApplication1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSignalR();
            builder.Services.AddCors(options =>
            {
                options.AddDefaultPolicy(build =>
                {
                    build.AllowAnyMethod()//Get|Post
                    .AllowAnyHeader()//
                    .AllowCredentials()
                    .SetIsOriginAllowed(alow => true);//allow domain
                });

            });
           
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseCors();
           
            app.UseAuthorization();
            //Chat
            app.MapHub<ChatHub>("/ChatH");
            app.MapHub<ProductHub>("/ProductH");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
