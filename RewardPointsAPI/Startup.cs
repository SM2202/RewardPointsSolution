using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NJsonSchema;
using NJsonSchema.Generation;
using NSwag.Generation.Processors.Security;

namespace RewardPoints
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// 
        /// </summary>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        public void ConfigureServices(IServiceCollection services)
        {
             services.AddOpenApiDocument(document =>
            {
                document.FlattenInheritanceHierarchy = true;
                document.SchemaType = SchemaType.OpenApi3;
                document.DefaultReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;

                document.DefaultResponseReferenceTypeNullHandling = ReferenceTypeNullHandling.NotNull;

                
                document.OperationProcessors.Add(
                    new AspNetCoreOperationSecurityScopeProcessor("Basic"));
                document.Title = $"RewardPoints";
            });

            services.AddControllers()
                .AddNewtonsoftJson(); ;
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseOpenApi();
            app.UseSwaggerUi3();
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
