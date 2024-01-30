using Lab4_24.Models;
using Lab4_24.Repositories.GenericRepository;

namespace Lab4_24.Repositories.UserRepository;

public interface IUserRepository: IGenericRepository<User>
{
     Task<User> FindByUsername(string username);
     Task<List<User>> FindAll();
     Task<List<User>> FindAllActive();
}