using HR_Management.Application.Contract.Infrastructure;
using HR_Management.Application.Models;
using HR_Management.Infrastructure.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR_Management.Infrastructure
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection InfrastructureServicesServices(this IServiceCollection services
            , IConfiguration configuration)
        {

            services.Configure<EmailSetting>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();

            return services;
        }
    }
}
