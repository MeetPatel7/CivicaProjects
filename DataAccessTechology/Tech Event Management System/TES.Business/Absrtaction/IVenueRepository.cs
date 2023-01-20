using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Business.Entity;

namespace TES.Business.Absrtaction
{
    public interface IVenueRepository
    {
        public Task<IEnumerable<Venue>> GetVenue();
        public Task<Venue> GetVenueById(int id);
        public Task AddVenue(Venue venue);
        public Task DeleteVenue(int id);
        public Task UpdateVenue(int id, Venue venue);
        public Task<IEnumerable<Venue>> GetVenueByEventsId(int id);
        public Task<IEnumerable<Venue>> GetVenueByEvenetsIdAndVenueId(int eventsId, int venueId);
     }
}
