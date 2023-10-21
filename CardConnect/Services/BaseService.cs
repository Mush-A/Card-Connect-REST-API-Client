using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Configuration;
using System.Net.Http;

namespace CardConnect.Services;

public class BaseService
{
    private readonly IConfiguration _configuration;

    protected readonly HttpClient _httpClient;
    protected readonly ILogger<BaseService> _logger;

    protected readonly string _merchid;

    public BaseService(IHttpClientFactory httpClientFactory, ILogger<BaseService> logger, IConfiguration configuration)
    {
        _httpClient = httpClientFactory.CreateClient("cardConnect");
        _logger = logger;
        _configuration = configuration;

        var merchIdFromConfig = configuration["cardConnectConfig:Merchid"];

        _merchid = configuration["cardConnectConfig:Merchid"]
                       ?? throw new ConfigurationErrorsException("Missing merchId");
    }
}
