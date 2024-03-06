using Di2P2Eval.Models;

namespace Di2P2Eval.Services.Contracts;

public interface IEventService
{
    public Task<IEnumerable<Event>> GetAllEvent();
    public Task<Event> GetEventId(int eventId);
    public Task AddEvent(Event evt);
    public Task UpdateEvent(Event evt);
    public Task DeleteEvent(Event evt);
}