using LolaFlora.Common.Interfaces;
using LolaFlora.Web.AppSettings;
using LolaFlora.Web.DBContext;
using LolaFlora.Web.Middlewares;
using LolaFlora.Web.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace LolaFlora.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = Configuration["JwtOption:Issuer"],
                        ValidAudience = Configuration["JwtOption:Issuer"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtOption:Key"]))
                    };
                });

            //for multi languages
            services
            .AddLocalization(o => o.ResourcesPath = "Resources")
            //after 3.x ...
            //services.AddMvcCore() -> 2.x
            //.AddDataAnnotations() // for model validation by using attribute
            //.AddApiExplorer() // for swagger and similar tools
            .AddControllers()
            //Annotation Language
            .AddDataAnnotationsLocalization(options =>
            {
                options.DataAnnotationLocalizerProvider = (type, factory) => factory.Create(typeof(SharedResource));
            });

            services.Configure<JwtOption>(Configuration.GetSection("JwtOption"));

            // configure DI for application services
            services.AddScoped<IUserService, UserService>();

            //already added AddApiExplorer in AddControllers
            services
                .AddSwaggerGen();

            services.AddPgsqlDbContext(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseJsonExceptionHandler(loggerFactory);

            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
