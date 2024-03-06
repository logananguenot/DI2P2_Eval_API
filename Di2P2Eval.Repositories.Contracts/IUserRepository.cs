using Di2P2Eval.Models;

namespace Di2P2Eval.Repositories.Contracts;

public interface IUserRepository
{
    public Task<IEnumerable<User>> GetAllUser();
    public Task<User> GetUserId(int userId);
    public Task AddUser(User user);
    public Task UpdateUser(User user);
    public Task DeleteUser(User user);
}
