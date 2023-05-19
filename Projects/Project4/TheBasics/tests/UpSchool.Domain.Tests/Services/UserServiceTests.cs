using FakeItEasy;
using System.Linq.Expressions;
using UpSchool.Domain.Data;
using UpSchool.Domain.Entities;
using UpSchool.Domain.Services;

namespace UpSchool.Domain.Tests.Services
{
    public class UserServiceTests
    {
        [Fact]
        public async Task GetUser_ShouldGetUserWithCorrectId()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            Guid userId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            var cancelletionSource = new CancellationTokenSource();

            var expectedUser = new User()
            {
                Id = userId,
            };

            A.CallTo( () =>  userRepositoryMock.GetByIdAsync(userId,cancelletionSource.Token))
                .Returns(Task.FromResult(expectedUser));

            IUserService userService = new UserManager(userRepositoryMock);

            var user = await userService.GetByIdAsync(userId, cancelletionSource.Token);

            Assert.Equal(expectedUser, user);
        }

        [Fact]
        public async Task AddAsync_ShouldThrowException_WhenEmailIsEmptyOrNull()
        {

            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancelletionSource = new CancellationTokenSource();

            IUserService userService = new UserManager(userRepositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await userService.AddAsync("Ayca", "Akbas", 28, null, cancelletionSource.Token);
            });

            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await userService.AddAsync("Sema", "Topcu", 24, "", cancelletionSource.Token);
            });

        }

        [Fact]
        public async Task AddAsync_ShouldReturn_CorrectUserId()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancelletionSource = new CancellationTokenSource();

            Guid expectedUserId = new Guid("8f319b0a-2428-4e9f-b7c6-ecf78acf00f9");

            A.CallTo(() => userRepositoryMock.AddAsync(A<User>._, cancelletionSource.Token))
                .Invokes((User user, CancellationToken token) =>
                {
                    user.Id = expectedUserId;
                });

            IUserService userService = new UserManager(userRepositoryMock);

            // Act
            Guid userId = await userService.AddAsync("Ayca", "Akbas", 28, "aycrio@gmail.com", cancelletionSource.Token);

            // Assert
            Assert.Equal(expectedUserId, userId);
        }

        [Fact]
        public async Task DeleteAsync_ShouldReturnTrue_WhenUserExists()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancelletionSource = new CancellationTokenSource();

            Guid userId = Guid.NewGuid();

            A.CallTo(() => userRepositoryMock.DeleteAsync(A<Expression<Func<User, bool>>>.Ignored, cancelletionSource.Token))
                .Returns(Task.FromResult(1));

            IUserService userService = new UserManager(userRepositoryMock);

            // Act
            bool result = await userService.DeleteAsync(userId, cancelletionSource.Token);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteAsync_ShouldThrowException_WhenUserDoesntExists()
        {
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationSource = new CancellationTokenSource();

            IUserService userService = new UserManager(userRepositoryMock);

            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await userService.DeleteAsync(Guid.Empty, cancellationSource.Token);
            });
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenUserIdIsEmpty()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancellationToken = new CancellationToken();

            IUserService userService = new UserManager(userRepositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                await userService.UpdateAsync(new User(), cancellationToken);
            });
        }

        [Fact]
        public async Task UpdateAsync_ShouldThrowException_WhenUserEmailEmptyOrNull()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancelletionSource = new CancellationTokenSource();

            IUserService userService = new UserManager(userRepositoryMock);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = null
                };
                await userService.UpdateAsync(user, cancelletionSource.Token);
            });

            await Assert.ThrowsAsync<ArgumentException>(async () =>
            {
                var user = new User
                {
                    Id = Guid.NewGuid(),
                    Email = ""
                };
                await userService.UpdateAsync(user, cancelletionSource.Token);
            });
        }

        [Fact]
        public async Task GetAllAsync_ShouldReturn_UserListWithAtLeastTwoRecords()
        {
            // Arrange
            var userRepositoryMock = A.Fake<IUserRepository>();

            var cancelletionSource = new CancellationTokenSource();

            List<User> userList = new List<User>
            {
                new User { Id = Guid.NewGuid(), FirstName = "Ayca", LastName = "Akbas" },
                new User { Id = Guid.NewGuid(), FirstName = "Sema", LastName = "Topcu" },
                new User { Id = Guid.NewGuid(), FirstName = "Alper", LastName = "Tunga" }
            };

            A.CallTo(() => userRepositoryMock.GetAllAsync(cancelletionSource.Token))
                .Returns(Task.FromResult(userList));

            IUserService userService = new UserManager(userRepositoryMock);

            // Act
            var result = await userService.GetAllAsync(cancelletionSource.Token);

            // Assert
            Assert.NotNull(result);
            Assert.True(result.Count >= 2);
        }
    }
}
