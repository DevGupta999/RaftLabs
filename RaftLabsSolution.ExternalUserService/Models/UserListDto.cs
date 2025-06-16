namespace RaftLabsSolution.ExternalUserService.Models
{
    public class UserListDto
    {
        public int Page { get; set; }
        public int Total_Pages { get; set; }
        public List<UserDto> Data { get; set; } = new List<UserDto>();

    }
}
