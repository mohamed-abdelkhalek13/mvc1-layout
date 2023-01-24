using System.ComponentModel.Design;

namespace mvc1
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
            app.Use(async (context, next) =>
            {
                if (context.Request.Cookies.ContainsKey("visits"))
                {
                    var oldVisits = int.Parse(context.Request.Cookies["visits"]);
                    int visits = ++oldVisits;
                    if (visits >= 10 && visits < 20)
                    {
                        context.Response.Cookies.Append("Rating", "1 star");
                    }
                    else if (visits >= 20 && visits < 30)
                    {
                        context.Response.Cookies.Append("Rating", "2 stars");
                    }
                    else if (visits >= 30 && visits < 40)
                    {
                        context.Response.Cookies.Append("Rating", "3 stars");
                    }
                    else if (visits >= 40 && visits < 50)
                    {
                        context.Response.Cookies.Append("Rating", "4 stars");
                    }
                    else if (visits > 50)
                    {
                        context.Response.Cookies.Append("Rating", "5 stars");
                    }

                    context.Response.Cookies.Append("visits", visits.ToString());

                } else
                {
                    context.Response.Cookies.Append("visits", "1");
                }
                await next();
            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}