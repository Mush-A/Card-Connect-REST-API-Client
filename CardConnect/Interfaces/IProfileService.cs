using CardConnect.Models.Profile;

namespace CardConnect.Interfaces;

public interface IProfileService
{
    Task<CreateProfileResponse> Create(CreateProfileRequest createProfileRequest);
}
