using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Business.Absrtaction;
using TES.Business.Entity;
using TES.Data.Entity;

namespace TES.Data.Repository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly TESContext _context;

        public EventsRepository(TESContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Events>> GetEvents()
        {     
                var eventsList = await _context.Events.ToListAsync();
                return eventsList;
        }
        public async Task<Events> GetEventsById(int id)
        {
                var eventsById = await _context.Events.FindAsync(id);
                return eventsById;
        }
        public async Task AddEvents(Events events)
        {
                 _context.Events.Add(events);
                 await _context.SaveChangesAsync();   
        }
        public Task DeleteEvents(int id)
        {
                var events = _context.Events.Find(id);
                _context.Events.Remove(events);
                return _context.SaveChangesAsync();
        }
        public async Task UpdateEvents(int id, Events events)
        {
                _context.Entry(events).State = EntityState.Modified;
                await _context.SaveChangesAsync();
           
        }
        public async Task<IEnumerable<Events>> GetEventsByCurrectMonth(int month, int yearNumber)
        {
           
                var eventsByCurrectMonth = await _context.Events.Where(x => x.StartDate.Month == month && x.StartDate.Year == yearNumber).ToListAsync();
                return eventsByCurrectMonth;
           
        }
        public async Task<IEnumerable<Events>> GetEventsByCompleted()
        {
                var eventsByCompleted = await _context.Events.Where(x => x.IsCompleted == true).ToListAsync();
                return eventsByCompleted;
        }
    }
}
