using BogusExample.Core.Models;
using BogusExample.Core.Services;
using Xunit;

namespace BogusExample.Tests
{
    public class UserServiceTests
    {
        [Fact]
        public void GenerateFakeUsers_ShouldReturnCorrectCount()
        {
            var userService = new UserService();
            int userCount = 5;
            var users = userService.GenerateFakeUsers(userCount);
            Assert.Equal(userCount, users.Count);
        }

        [Fact]
        public void GetAdults_ShouldReturnOnlyAdults()
        {
            var userService = new UserService();
            var users = new[]
            {
                new User { DateOfBirth = DateTime.Today.AddYears(-20) },
                new User { DateOfBirth = DateTime.Today.AddYears(-15) }
            }.ToList();

            var adults = userService.GetAdults(users);
            Assert.Single(adults);
        }
    }
}
