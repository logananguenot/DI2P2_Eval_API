
using System.Net;
using System.Text;
using System.Text.Json;
using Di2P2Eval.Models;
using Di2P2Eval.Services.Contracts;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;


namespace Di2P2Eval.Azure.Functions;

public class EventFunctions
{
    private readonly IEventService _eventService;
    private readonly ILogger _logger;

    public EventFunctions(ILoggerFactory loggerFactory, IEventService eventService)
    {
        _logger = loggerFactory.CreateLogger<EventFunctions>();
        _eventService = eventService;
    }

    [Function("AddEvent")]
    public async Task<HttpResponseData> Run([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "Events")] HttpRequestData req)
    {
        string requestBody;
        using (var reader = new StreamReader(req.Body, Encoding.UTF8))
        {
            requestBody = await reader.ReadToEndAsync();
        }
        try
        {
            var response = req.CreateResponse();
            var evt = JsonSerializer.Deserialize<Event>(requestBody, new JsonSerializerOptions());

            response.StatusCode = HttpStatusCode.Created;
            await _eventService.AddEvent(evt);
            return response;
        }
        catch (Exception e)
        {
            var response = req.CreateResponse();
            response.WriteString("An error occurred in AddEvent");
            response.StatusCode = HttpStatusCode.InternalServerError;
            return response;
        }
    }
}