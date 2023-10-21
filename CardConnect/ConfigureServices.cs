using System.Net.Http.Headers;
using System.Text;
using CardConnect.Interfaces;
using CardConnect.Services.ProfileService;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CardConnect
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCardConnect(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddHttpClient("cardConnect", c =>
            {
                c.BaseAddress = new System.Uri("https://fts-uat.cardconnect.com");

                string base64Credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes("testing:testing123"));
                c.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", base64Credentials);
            });

            services.AddScoped<IProfileService, ProfileService>();

            return services;
        }
    }
   
}