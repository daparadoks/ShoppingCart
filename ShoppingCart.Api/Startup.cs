using System;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Api.Config;
using ShoppingCart.Api.Contexts;
using ShoppingCart.Api.Data;
using ShoppingCart.Api.Dto.Request.Payment;
using ShoppingCart.Api.Facades;
using ShoppingCart.Api.Repositories;
using ShoppingCart.Api.Repositories.Redis;
using ShoppingCart.Api.Services;
using ShoppingCart.Api.Services.Payment;

namespace ShoppingCart.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            var applicationConfiguration = Configuration.GetSection("Application");
            services.Configure<ApplicationConfig>(applicationConfiguration);
            services.AddLogging();
            services.AddCors();
            AddServices(services, Configuration.GetConnectionString("ShoppingCart"));
            AddAuthentication(services, applicationConfiguration);
            services
                .AddMvc()
                .AddNewtonsoftJson()
                .AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null)
                .SetCompatibilityVersion(CompatibilityVersion.Latest);
        }

        public static void AddServices(IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CartDbContext>(opt =>
            {
                opt.UseSqlServer(connectionString,
                    sqlServerOptionsAction =>
                    {
                        sqlServerOptionsAction.EnableRetryOnFailure(
                            maxRetryCount: 10,
                            maxRetryDelay: TimeSpan.FromSeconds(30),
                            errorNumbersToAdd: null);
                    });
            });
            
            services.AddTransient(typeof(ICartFacade), typeof(CartFacade));
            services.AddTransient(typeof(IPaymentFacade), typeof(PaymentFacade));
            
            services.AddTransient(typeof(ICartService), typeof(CartService));
            services.AddTransient(typeof(ICouponService), typeof(CouponService));
            
            services.AddTransient(typeof(ICartRepository), typeof(CartRepository));
            services.AddTransient(typeof(ICartItemRepository), typeof(CartItemRepository));
            services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepository));
            services.AddTransient(typeof(ICouponRepository), typeof(CouponRepository));
            services.AddTransient(typeof(IRedisClient), typeof(RedisClient));
            
            services.AddTransient<AbankPaymetService>();
            services.AddTransient<BbankPaymetService>();
            services.AddTransient<IyzicoPaymetService>();

            services.AddTransient<PaymentServiceHandler>(serviceProvider => key =>
            {
                switch (key)
                {
                    case BankType.Abank:
                        return serviceProvider.GetService<AbankPaymetService>();
                    case BankType.Bbank:
                        return serviceProvider.GetService<BbankPaymetService>();
                    default:
                        return serviceProvider.GetService<IyzicoPaymetService>();
                }
            });


            services.AddScoped(typeof(ICartContext), typeof(CartContext));
            services.AddScoped(typeof(IUserContext), typeof(UserContext));
        }
        
        private static void AddAuthentication(IServiceCollection services, IConfiguration applicationConfiguration)
        {
            var secretKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(applicationConfiguration.GetSection("JwtConfig")
                    .GetValue<string>("Secret")));
            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters =
                        new TokenValidationParameters
                        {
                            LifetimeValidator = (before, expires, token, param) => expires > DateTime.UtcNow,
                            ValidateAudience = false,
                            ValidateIssuer = false,
                            ValidateActor = false,
                            ValidateLifetime = true,
                            IssuerSigningKey = secretKey
                        };

                    options.Events = new JwtBearerEvents
                    {
                        OnMessageReceived = context =>
                        {
                            var accessToken = context.Request.Query["access_token"];
                            var path = context.HttpContext.Request.Path;
                            if (!string.IsNullOrEmpty(accessToken))
                                context.Token = accessToken;

                            return Task.CompletedTask;
                        }
                    };
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors(builder => builder
                .AllowAnyHeader()
                .WithMethods("GET", "POST", "DELETE", "PUT")
                .AllowCredentials());

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello World!"); });
            });
        }
    }
}