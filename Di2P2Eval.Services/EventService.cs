using Di2P2Eval.Models;
using Di2P2Eval.Repositories.Contracts;
using Di2P2Eval.Services.Contracts;

namespace Di2P2Eval.Services;

public class EventService : IEventService
{
    private readonly IEventRepository _eventRepository;

    public EventService(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }
    
    public Task<IEnumerable<Event>> GetAllEvent()
    {
        return _eventRepository.GetAllEvent();
    }

    public Task<Event> GetEventId(int eventId)
    {
        return _eventRepository.GetEventId(eventId);
    }

    public Task AddEvent(Event evt)
    {
        return _eventRepository.AddEvent(evt);
    }

    public Task UpdateEvent(Event evt)
    {
        return _eventRepository.UpdateEvent(evt);
    }

    public Task DeleteEvent(Event evt)
    {
        return _eventRepository.DeleteEvent(evt);
    }
}