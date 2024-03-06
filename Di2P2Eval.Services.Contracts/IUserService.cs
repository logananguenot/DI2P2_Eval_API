using Di2P2Eval.Models;

namespace Di2P2Eval.Services.Contracts;

public interface IUserService
{ 
    public Task<IEnumerable<User>> GetAllUser();
    public Task GetUserId(int userId);
    public Task AddUser(User user);
    public Task UpdateUser(User user);
    public Task DeleteUser(User user);
}
