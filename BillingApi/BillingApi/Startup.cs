using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using BillingApi.Database;
using Microsoft.EntityFrameworkCore;
using BillingApi.Services.Validators;
using BillingApi.Services;
using BillingApi.Core.Services;
using BillingApi.Service.Services.GatewayHandlers;

namespace BillingApi
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

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BillingApi", Version = "v1" });
            });

            services.AddDbContext<BillingApiDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("billing-api"));
            });

            services.AddTransient<IBillingApiDbContext, BillingApiDbContext>();
            services.AddTransient<IValidator, OrderValidator>();
            services.AddTransient<IValidator, PaymentGatewayValidator>();
            services.AddTransient<IBillingService, BillingService>();
            services.AddTransient<IPaymentGateway, AmazonPaymentGatewayHandler>();
            services.AddTransient<IPaymentGateway, PayPalGatewayHandler>();
            services.AddTransient<IPaymentGateway, StripeGatewayHandler>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BillingApi v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
