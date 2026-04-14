using Microsoft.EntityFrameworkCore;
using MusicGearTracker.Data;

namespace MusicGearTracker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /*
             * Default Code:
             * 1) Creates a WebApplicationBuilder which is responsible for:
             * > configuring services 
             * > building the ASP.NET Core application
             * 
             * This prepares the services and middleware pipeline.
             */
            var builder = WebApplication.CreateBuilder(args);

            /*
             * Default Code:
             * 2) Register services with Dependency Injection (DI):
             * - Add services to the "Dependency Injection" container
             * - AddControllersWithViews() enables support for MVC controllers and Razor views
             * - This is required when building applications using the MVC pattern.
             * 
             * This adds MVC services (Controllers + Views).
             */

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            /*
             * 2-a) Register our "MusicGearTrackerDbContext"
             * *********************************************
             *
             * After creating our DbContext class, 
             * we must register it with the ASP.NET Core Dependency Injection (DI) container.
             *
             * This allows ASP.NET Core to automatically create and provide
             * an instance of our DbContext wherever it is needed
             * (for example inside Controllers).
             *
             * In our case we register the DbContext using the
             * EF Core "InMemory" database provider.
             *
             * IMPORTANT NOTE TO REMEMBER:
             * ***************************
             * The InMemory database provider is mainly used for:
             *  - Learning
             *  - Demonstrations
             *  - Unit testing
             *
             * The database exists only in RAM (memory) 
             * and will be cleared whenever the application stops.
             *
             * Link: https://learn.microsoft.com/en-us/ef/core/providers/in-memory/
             *
             * 
             * Logical Steps Detailed:
             * ***********************
             *
             * 1) Use the builder.Services object:
             *    This object allows us to register services 
             *    with the ASP.NET Core Dependency Injection container.
             *
             * 2) Use the AddDbContext<TContext>() method:
             *    This method registers our DbContext class with the DI system.
             *
             * 3) Specify our DbContext class:
             *      > MusicGearTrackerDbContext
             *
             * 4) Provide configuration options:
             *      > using a lambda expression
             *
             * 5) Call UseInMemoryDatabase():
             *    This tells EF Core to use the InMemory database provider.
             *
             * 6) Provide a name for the in-memory database:
             *      > MusicGearTrackerDb
             *
             * NOTE:
             * The database name is only an identifier for this temporary
             * in-memory database. Since it is not persisted to disk,
             * we can choose any descriptive name.
             *
             * Microsoft Documentation Example:
             * ********************************
             *
             * services.AddDbContext<BlogContext>
             *      (options => options.UseInMemoryDatabase("BasicExample"));
             *
             * In our application we use the "builder" object instead of "services":
             *
             * builder.Services.AddDbContext<BlogContext>
             *      (options => options.UseInMemoryDatabase("BasicExample"));
             *
             * Where:
             *  - BlogContext => DbContext class
             *  - BasicExample => Database name
             *
             * In our application:
             *  - BlogContext => MusicGearTrackerDbContext
             *  - BasicExample => MusicGearTrackerDb
             *
             * Link: https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/
             * Link: https://learn.microsoft.com/en-us/ef/core/dbcontext-configuration/#dbcontext-in-dependency-injection-for-aspnet-core
             */

            builder.Services.AddDbContext<MusicGearTrackerDbContext>(options =>
                options.UseInMemoryDatabase("MusicGearTrackerDb"));

            /*
             * Default Code:
             * *************
             * 3) Builds the "app", the WebApplication instance:
             */
            var app = builder.Build();



            /*
             * 4) Configure the HTTP request pipeline:
             * - The pipeline defines how HTTP requests are processed by the application.
             */
            if (!app.Environment.IsDevelopment())
            {
                // In production environments, we use a global exception handler.
                app.UseExceptionHandler("/Home/Error"); // Production-friendly error page (Default Code)

                // Adds HTTP Strict Transport Security (HSTS).
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts(); // HTTP Strict Transport Security (Default Code)
            }

            // Calling the required app methods (also default code):

            // Redirects HTTP requests to HTTPS:
            app.UseHttpsRedirection();

            // Enables serving static files such as CSS, JavaScript, and images
            // NOTE: static files are located inside the "wwwroot" folder.
            app.UseStaticFiles(); // Serve wwwroot static files (CSS, JS, images)

            // Enables endpoint routing:
            app.UseRouting();

            // Adds authorization middleware to the request pipeline.
            app.UseAuthorization(); // Enable Authorization (we're not adding auth yet)

            /*
            * 5) Configure default route:
            * Below is the routing configuration for MVC controllers.
            * This defines the default URL pattern used by the application.
            * 
            * Template/Pattern: "{controller=ControllerName}/{action=Index}/{id?}"
            * 
            * - controller=ControllerName => default controller if none is specified in URL
            * - action=Index => default action if none is specified
            * - id? => optional id parameter for details/edit/delete
            * 
            * We changed the default controller from "Home" to our custom
            * controller "Instruments".
            * 
            * This makes the app start at /Instruments/Index by default:
            */
            app.MapControllerRoute(
                name: "default",

                // Default Code - ASP.NET MVC template route:
                // pattern: "{controller=Home}/{action=Index}/{id?}";

                // Our Code - Our customized route:
                pattern: "{controller=Instruments}/{action=Index}/{id?}");
            /*
             * controller=Instruments => corresponds to InstrumentsController.cs
             * action=Index => corresponds to the Index() method inside the controller
             *
             * When the application starts and the root URL ("/") is requested,
             * ASP.NET Core will automatically route the request to:
             *
             *      InstrumentsController => Index()
             *
             * NOTE:
             * In many real-world applications the default controller remains "Home".
             * Here we intentionally change it to "Instruments" so that our tutorial
             * application immediately loads the main feature of the app
             * (the Music Gear Tracker).
             */

            // 6) Starts the web application and begins listening for HTTP requests.
            app.Run(); // un the app (Default Code)
        }
    }
}
