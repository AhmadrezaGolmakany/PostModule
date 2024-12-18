using Microsoft.Extensions.DependencyInjection;
using PosModule.Application.Services;
using PostModule.Application.Contract.StateQuery;
using PostModule.Infrastracture.EF;
using PostModule.Query.Services;


namespace PostModule.Query
{
    public class Post_Bootstrapper
    {
        public static void Confiq(IServiceCollection services , string ConnectionString)
        {
            PostInfrastracture_Bootstrapper.Confiq(services,ConnectionString);
            PostApplication_Bootstrapper.Confiq(services);

            services.AddTransient<IStateQuery, StateQuery>();
        }
    }
}
