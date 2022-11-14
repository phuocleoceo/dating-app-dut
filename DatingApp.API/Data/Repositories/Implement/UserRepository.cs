using Microsoft.EntityFrameworkCore;
using DatingApp.API.Data.Entities;

namespace DatingApp.API.Data.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;
    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<List<User>> GetUsers()
    {
        return await _context.AppUsers.ToListAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _context.AppUsers.FindAsync(id);
    }

    public async Task<User> GetUserByUsername(string username)
    {
        User userDB = await _context.AppUsers.FirstOrDefaultAsync(c => c.Username == username);
        if (userDB == null) return null;
        _context.Entry(userDB).State = EntityState.Detached;
        return userDB;
    }

    public async Task<User> InsertNewUser(User user)
    {
        await _context.AppUsers.AddAsync(user);
        await IsSaveChanged();
        return await GetUserByUsername(user.Username);
    }

    public async Task<bool> UpdateNewUser(User user)
    {
        _context.AppUsers.Update(user);
        return await IsSaveChanged();
    }

    public async Task<bool> DeleteNewUser(User user)
    {
        _context.AppUsers.Remove(user);
        return await IsSaveChanged();
    }

    public async Task<bool> IsSaveChanged()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}