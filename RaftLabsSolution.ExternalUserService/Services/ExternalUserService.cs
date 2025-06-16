using RaftLabsSolution.ExternalUserService.Interfaces;
using RaftLabsSolution.ExternalUserService.Models;

namespace RaftLabsSolution.ExternalUserService.Services
{
    public class ExternalUserService : IExternalUserService
    {
        private readonly IReqResApiClient _client;

        public ExternalUserService(IReqResApiClient client)
        {
            _client = client;
        }

        public Task<UserDto?> GetUserByIdAsync(int userId)
        {
            return _client.GetUserByIdAsync(userId);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var allUsers = new List<UserDto>();

            var firstPage = await _client.GetUsersByPageAsync(1);
            if (firstPage?.Data != null)
                allUsers.AddRange(firstPage.Data);

            for (int page = 2; page <= firstPage.Total_Pages; page++)
            {
                var result = await _client.GetUsersByPageAsync(page);
                if (result?.Data != null)
                    allUsers.AddRange(result.Data);
            }

            return allUsers;
        }

    }
}
