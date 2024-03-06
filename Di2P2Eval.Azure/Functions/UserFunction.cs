using Di2P2Eval.Services.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;

namespace Di2P2Eval.Azure.Functions;

public class UserFunction
{
    private readonly ILogger<UserFunction> _logger;
    private readonly IUserService _userService;

    public UserFunction(ILogger<UserFunction> logger, IUserService userService)
    {
        _logger = logger;
        _userService = userService;
    }

    [Function("GetAllUser")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "users")] HttpRequestData req)
    {
        try
        {
            var response = req.CreateResponse();
            var users = await _userService.GetAllUser();

            if (users is null)
            {
                _logger.LogWarning("Users not found");
                response.WriteString("Users not found");
                response.StatusCode = HttpStatusCode.NotFound;
                return response;
            }


            response.WriteAsJsonAsync(users);
            response.StatusCode = HttpStatusCode.OK;
            return response;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error getting all users");
            var response = req.CreateResponse();
            response.WriteString("Error getting all users");
            response.StatusCode = HttpStatusCode.InternalServerError;
            return response;
        }
    }

}
