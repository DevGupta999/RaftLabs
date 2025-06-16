using Moq;
using RaftLabsSolution.ExternalUserService.Interfaces;
using RaftLabsSolution.ExternalUserService.Models;
namespace RaftLabsSolution.ExternalUserService.Test
{
    public class ExternalUserServiceTests
    {
        [Fact]
        public async Task GetUserByIdAsync_ReturnsUser()
        {
            var mockClient = new Mock<IReqResApiClient>();
            mockClient.Setup(c => c.GetUserByIdAsync(1))
                      .ReturnsAsync(new UserDto { Id = 1, First_Name = "John", Last_Name = "Doe" });

            var service = new RaftLabsSolution.ExternalUserService.Services.ExternalUserService(mockClient.Object);
            var user = await service.GetUserByIdAsync(1);

            Assert.NotNull(user);
            Assert.Equal(1, user.Id);
            Assert.Equal("John", user.First_Name);
        }

        [Fact]
        public async Task GetAllUsersAsync_ReturnsUsersFromAllPages()
        {
            var mockClient = new Mock<IReqResApiClient>();
            mockClient.Setup(c => c.GetUsersByPageAsync(1))
                      .ReturnsAsync(new UserListDto { Page = 1, Total_Pages = 2, Data = [new UserDto { Id = 1 }] });
            mockClient.Setup(c => c.GetUsersByPageAsync(2))
                      .ReturnsAsync(new UserListDto { Page = 2, Total_Pages = 2, Data = [new UserDto { Id = 2 }] });

            var service = new RaftLabsSolution.ExternalUserService.Services.ExternalUserService(mockClient.Object);
            var users = await service.GetAllUsersAsync();

            Assert.Equal(2, users.Count());
            Assert.Contains(users, u => u.Id == 1);
            Assert.Contains(users, u => u.Id == 2);
        }
    }
}