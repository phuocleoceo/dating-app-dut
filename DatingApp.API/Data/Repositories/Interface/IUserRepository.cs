using DatingApp.API.Data.Entities;

namespace DatingApp.API.Data.Repositories;

public interface IUserRepository
{
    Task<List<User>> GetUsers();

    Task<User> GetUserById(int id);

    Task<User> GetUserByUsername(string username);

    Task<User> InsertNewUser(User user);

    Task<bool> UpdateNewUser(User user);

    Task<bool> DeleteNewUser(User user);

    Task<bool> IsSaveChanged();
}