using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PostModule.Domain.Services;
using PostModule.Infrastracture.EF.Repositpries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostModule.Infrastracture.EF
{
    public class PostInfrastracture_Bootstrapper
    {
        public static void Confiq(IServiceCollection services, string ConnectionString)
        {
            services.AddTransient<IStateRepository, StateRepository>();
            services.AddTransient<ICityRepository, CityRepository>();
            services.AddTransient<IPostRepository, PostRepositories>();
            services.AddTransient<IPostPriceRepository, PostPriceRepository>();



            services.AddDbContext<Post_Context>(x =>
            {
                x.UseSqlServer(ConnectionString);
            });
        }

    }
}
