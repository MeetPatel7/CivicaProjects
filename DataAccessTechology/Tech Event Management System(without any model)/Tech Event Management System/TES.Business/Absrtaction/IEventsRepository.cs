using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Business.Entity;

namespace TES.Business.Absrtaction
{
    public interface IEventsRepository
    {
        public Task<IEnumerable<Events>> GetEvents();
        public Task<Events> GetEventsById(int id);
        public Task AddEvents(Events events);
        public Task DeleteEvents(int id);
        public Task UpdateEvents(int id, Events events);
        public Task<IEnumerable<Events>> GetEventsByCurrectMonth(int month, int yearNumber);
        public Task<IEnumerable<Events>> GetEventsByCompleted();
    }
}
