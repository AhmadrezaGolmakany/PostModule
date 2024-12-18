using Microsoft.Extensions.DependencyInjection;
using PostModule.Application.Contract.CityApplication;
using PostModule.Application.Contract.StateApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosModule.Application.Services
{
    public class PostApplication_Bootstrapper
    {
        public static void Confiq(IServiceCollection service)
        {
            service.AddTransient<IStateApplication, StateApplication>();
            service.AddTransient<ICityApplication, CityApplication>();
        }
    }
}
