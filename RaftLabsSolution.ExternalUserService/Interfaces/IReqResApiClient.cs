using RaftLabsSolution.ExternalUserService.Models;

namespace RaftLabsSolution.ExternalUserService.Interfaces
{
    public interface IReqResApiClient
    {
        Task<UserDto?> GetUserByIdAsync(int userId);
        Task<UserListDto> GetUsersByPageAsync(int pageNumber);
    }
}
