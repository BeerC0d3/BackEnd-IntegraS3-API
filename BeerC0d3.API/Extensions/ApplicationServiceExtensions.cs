using BeerC0d3.API.Helpers;
using BeerC0d3.API.Helpers.Errors;
using BeerC0d3.API.Services.chatGPT;
using BeerC0d3.API.Services.Seguridad;
using BeerC0d3.API.Services.Sistema;
using BeerC0d3.Core.Entities.Seguridad;
using BeerC0d3.Core.Interfaces;
using BeerC0d3.Infrastructure.UnitOfWork;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Configuration;
using System.Text;

namespace BeerC0d3.API.Extensions
{
    public static class ApplicationServiceExtensions
    {


        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            //options.AddPolicy("CorsPolicy", builder =>
            //     //builder.AllowAnyOrigin()   //WithOrigins("https://dominio.com")
            //     builder.WithOrigins("http://localhost:9000", "http://192.168.100.11:9000")
            //    .AllowAnyMethod()          //WithMethods("GET","POST")
            //    .AllowAnyHeader());        //WithHeaders("accept","content-type")

            options.AddPolicy("CorsPolicy", builder =>

                // Allow multiple methods
                builder.WithMethods("GET", "POST", "PUT", "PATCH", "DELETE", "OPTIONS")
                .WithHeaders(
                    HeaderNames.Accept,
                    HeaderNames.ContentType,
                    HeaderNames.Authorization, "x-header-sucID")
                .WithOrigins(
                    "http://localhost:9000"
                    //"http://192.168.100.11:9000",
                    //"https://clinica-rosario.netlify.app"
                    )
                .AllowCredentials()
                .SetIsOriginAllowed(host => true)
                //.SetIsOriginAllowed(origin =>
                //{
                //    //var variables = unitWork.Variables.Find(item => item.Clave == "PushNotification_ServerKeys").FirstOrDefault();
                //    if (string.IsNullOrWhiteSpace(origin)) return false;
                //    // Only add this to allow testing with localhost, remove this line in production!
                //    if (origin.ToLower().StartsWith("http://localhost")) return true;
                //    if (origin.ToLower().StartsWith("https://localhost")) return true;

                //    // Insert your production domain here.
                //    if (origin.ToLower().StartsWith("https://clinica-rosario.netlify.app")) return true;
                //    return false;
                //})

                );


        });


        public static void AddAplicacionServices(this IServiceCollection services)
        {

            services.AddScoped<IPasswordHasher<Usuario>, PasswordHasher<Usuario>>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {
            //Configuration from AppSettings
            services.Configure<JWT>(configuration.GetSection("JWT"));
            services.Configure<chatSetting>(configuration.GetSection("chatSetting"));

            //Adding Athentication - JWT
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero,
                        ValidIssuer = configuration["JWT:Issuer"],
                        ValidAudience = configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]))
                    };
                });
        }
        public static void AddValidationErrors(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actionContext =>
                {

                    var errors = actionContext.ModelState.Where(u => u.Value.Errors.Count > 0)
                                                    .SelectMany(u => u.Value.Errors)
                                                    .Select(u => u.ErrorMessage).ToArray();

                    var errorResponse = new ApiValidation()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorResponse);
                };
            });
        }

    }
}
