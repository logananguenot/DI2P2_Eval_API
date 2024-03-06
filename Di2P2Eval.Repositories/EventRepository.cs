using Di2P2Eval.DbContext;
using Di2P2Eval.Models;
using Di2P2Eval.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Di2P2Eval.Repositories;

public class EventRepository : IEventRepository
{

    private readonly AppDbContext _context;
    
    public async Task<IEnumerable<Event>> GetAllEvent()
    {
        return await _context.Events.ToListAsync();
    }

    public Task<Event> GetEventId(int eventId)
    {
        return _context.Events.FirstOrDefaultAsync(e => e.Id == eventId);
    }

    public async Task AddEvent(Event evt)
    {
        _context.Events.Add(evt);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateEvent(Event evt)
    {
        _context.Events.Update(evt);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEvent(Event evt)
    {
        _context.Events.Remove(evt);
        await _context.SaveChangesAsync();
    }
}