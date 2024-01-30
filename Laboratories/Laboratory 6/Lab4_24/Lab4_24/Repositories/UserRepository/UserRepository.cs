using Lab4_24.Data;
using Lab4_24.Helpers.Extensions;
using Lab4_24.Models;
using Lab4_24.Repositories.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace Lab4_24.Repositories.UserRepository;

public class UserRepository:GenericRepository<User>, IUserRepository
{
    public UserRepository(Lab4Context lab4Context) : base(lab4Context)
    {
    }

    public async Task<User> FindByUsername(string username)
    {
        return (await _table.FirstOrDefaultAsync(u => u.Username.Equals(username)))!;
    }

    public async Task<List<User>> FindAll()
    {
        return await _table.GetActiveUser().ToListAsync();
    }

    public async Task<List<User>> FindAllActive()
    {
        return await _table.ToListAsync();
    }
}