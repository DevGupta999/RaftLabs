using RaftLabsSolution.ExternalUserService.Models;

namespace RaftLabsSolution.ExternalUserService.Interfaces
{
    public interface IExternalUserService
    {
        Task<UserDto?> GetUserByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
    }
}
