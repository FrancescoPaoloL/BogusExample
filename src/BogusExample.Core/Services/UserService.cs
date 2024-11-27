using Bogus;
using BogusExample.Core.Models;

namespace BogusExample.Core.Services
{
    public class UserService
    {
        public List<User> GenerateFakeUsers(int count)
        {
            var userFaker = new Faker<User>()
                .RuleFor(u => u.Id, f => Guid.NewGuid())
                .RuleFor(u => u.Name, f => f.Name.FullName())
                .RuleFor(u => u.Email, f => f.Internet.Email())
                .RuleFor(u => u.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)));

            return userFaker.Generate(count);
        }

        public List<User> GetAdults(List<User> users)
        {
            return users.Where(u => CalculateAge(u.DateOfBirth) >= 18).ToList();
        }

        private int CalculateAge(DateTime birthDate)
        {
            var today = DateTime.Today;
            var age = today.Year - birthDate.Year;

            if (birthDate.Date > today.AddYears(-age))
                age--;

            return age;
        }
    }
}
