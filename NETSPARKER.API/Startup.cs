using AutoMapper;
using NETSPARKER.Infrastructure.Interfaces;
using NETSPARKER.Infrastructure.Interfaces.Base;
using NETSPARKER.Infrastructure.Repositories;
using NETSPARKER.Infrastructure.Repositories.Base;
using NETSPARKER.Infrastructure.Services;
using NETSPARKER.Infrastructure.Services.Base;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NETSPARKER.Data;


namespace NETSPARKER.API
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
            services.AddAutoMapper(typeof(Startup));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_3_0);


            services.AddDbContext<NetsparkerDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("NETSPARKERDbConnection")));
            services.AddScoped<DbContext, NetsparkerDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWorkRepository>();



            #region |       ADD REPOSITORIES        |

            //     services.AddTransient<IUrun, UrunRepository>();
            services.AddTransient<IUser, UserRepository>();
            services.AddTransient<IProduct, ProductRepository>();
            services.AddTransient<IProductNotification, ProductNotificationRepository>();
            #endregion

            #region |       ADD SERVICES        |

            //    services.AddTransient<IUrun, UrunService>();
            services.AddTransient<UserService>();
            services.AddTransient<ProductService>();
            services.AddTransient<ProductNotificationService>();
            #endregion

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
