using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Final_Assessment.Data; // Replace with your actual namespace for the DbContext
using Final_Assessment.Models; // Replace with your actual namespace for the models

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        // Configure MySQL database context
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                Configuration.GetConnectionString("DefaultConnection"),
                new MySqlServerVersion(new Version(8, 0, 21)) // Replace with your MySQL version
            ));

        // Add Swagger for API documentation
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "CollegeRegistration", // Provide a descriptive title for your API
                Version = "v1",
                Description = "Description of your API's functionality and purpose.",
                //Contact = new OpenApiContact
                //{
                   // Name = "Your Name",
                   // Email = "your.email@example.com",
                    //Url = new Uri("https://yourwebsite.com") // Replace with your contact URL
                //},
                //License = new OpenApiLicense
                //{
                   // Name = "Use under LICX",
                   // Url = new Uri("https://example.com/license") // Replace with your license URL
               // }
            });

            // Optional: Include XML comments if you want to provide more detailed API documentation.
            //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            //c.IncludeXmlComments(xmlPath);
        });

        // Add MVC services to the container (with controllers)
        services.AddControllers();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        // Enable Swagger middleware
        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "CollegeRegistration V1");
            c.RoutePrefix = string.Empty; // Set Swagger UI at the root
        });

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}

