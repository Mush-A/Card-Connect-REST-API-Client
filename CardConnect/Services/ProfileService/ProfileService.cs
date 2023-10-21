using CardConnect.Interfaces;
using CardConnect.Models.Profile;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace CardConnect.Services.ProfileService;

public class ProfileService : BaseService, IProfileService
{
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<BaseService> _logger;
    private readonly IConfiguration _configuration;

    public ProfileService(IHttpClientFactory httpClientFactory, ILogger<BaseService> logger, IConfiguration configuration) : base(httpClientFactory, logger, configuration)
    {
        _httpClientFactory = httpClientFactory;
        _logger = logger;
        _configuration = configuration;
    }

    public async Task<CreateProfileResponse> Create(CreateProfileRequest createProfileRequest)
    {
        try
        {
            var response = await _httpClient.PostAsJsonAsync("/cardconnect/rest/profile", createProfileRequest);

            var content = await response.Content.ReadFromJsonAsync<CreateProfileResponse>();

            if (content is null)
                throw new ArgumentNullException(nameof(content), "Response content is null");

            return content;
        }
        catch (Exception ex)
        {
            _logger.LogError("Error {ex}", ex);
            throw;
        }
    }
}