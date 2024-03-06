using Di2P2Eval.DbContext;
using Di2P2Eval.Models;
using Di2P2Eval.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Di2P2Eval.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public async Task<IEnumerable<User>> GetAllUser()
    {
        return await _context.Users.ToListAsync();
    }

    public Task<User> GetUserId(int userId)
    {
        return _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
    }

    public async Task AddUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        _context.Users.Update(user);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUser(User user)
    {
        _context.Users.Remove(user);
        await _context.SaveChangesAsync();
    }
}
