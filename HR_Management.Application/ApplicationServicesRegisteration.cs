using HR_Management.Application.Profiles;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HR_Management.Application
{
    public static class ApplicationServicesRegisteration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            //services.AddAutoMapper(typeof(MappingProfile));

            services.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
