using Di2P2Eval.Models;
using Di2P2Eval.Repositories.Contracts;
using Di2P2Eval.Services.Contracts;

namespace Di2P2Eval.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    
    public Task<IEnumerable<User>> GetAllUser()
    {
        return _userRepository.GetAllUser();
    }

    public Task GetUserId(int userId)
    {
        return _userRepository.GetUserId(userId);
    }

    public Task AddUser(User user)
    {
        return _userRepository.AddUser(user);
    }

    public Task UpdateUser(User user)
    {
        return _userRepository.UpdateUser(user);
    }

    public Task DeleteUser(User user)
    {
        return _userRepository.DeleteUser(user);
    }
}
