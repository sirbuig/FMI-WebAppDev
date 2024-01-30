using Lab4_24.Data;
using Lab4_24.Models;

namespace Lab4_24.Helpers.Seeders;

public class UsersSeeders
{
    private readonly Lab4Context _lab4Context;

    public UsersSeeders(Lab4Context lab4Context)
    {
        _lab4Context = lab4Context;
    }

    public void SeedInitialUsers()
    {
        if (!_lab4Context.Users.Any())
        {
            var user1 = new User
            {
                FirstName = "First name User 1",
                LastName = "Last name User 1",
                Email = "user1@mail.com",
                Username = "user1"
            };
            
            var user2 = new User
            {
                FirstName = "First name User 2",
                LastName = "Last name User 2",
                Email = "user2@mail.com",
                Username = "user2"
            };

            _lab4Context.Users.Add(user1);
            _lab4Context.Users.Add(user2);

            _lab4Context.SaveChanges();
        }
    }
}