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
    public class VenueRepository : IVenueRepository
    {
        private readonly TESContext _context;
        public VenueRepository(TESContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Venue>> GetVenue()
        {
            return await _context.Venue.ToListAsync();
        }

        public async Task<Venue> GetVenueById(int id)
        {
            return await _context.Venue.FirstAsync(x => x.Id == id);
        }

        public async Task AddVenue(Venue venue)
        {
            _context.Venue.Add(venue);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteVenue(int id)
        {
            var venue = await _context.Venue.FindAsync(id);
            _context.Venue.Remove(venue);
            _context.SaveChanges();
        }

        public async Task UpdateVenue(int id, Venue venue)
        {
            _context.Entry(venue).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Venue>> GetVenueByEventsId(int id)
        {
            return await (from e in _context.Events
                          where e.Id == id
                          join v in _context.Venue on e.VenueId equals v.Id
                          select new Venue()
                          {
                              Id = v.Id,
                              Name = v.Name,
                              Address = v.Address,
                              City = v.City,
                              State = v.State,
                              Pincode = v.Pincode,
                              MapUrl = v.MapUrl,
                              MobileNo = v.MobileNo,
                              Picture = v.Picture
                          }).ToListAsync();
        }

        public async Task<IEnumerable<Venue>> GetVenueByEvenetsIdAndVenueId(int eventsId, int venueId)
        {
            return await (from e in _context.Events
                          where e.Id == eventsId
                          && e.VenueId == venueId
                          join v in _context.Venue on e.VenueId equals v.Id
                          select new Venue()
                          {
                              Id = v.Id,
                              Name = v.Name,
                              Address = v.Address,
                              City = v.City,
                              State = v.State,
                              Pincode = v.Pincode,
                              MapUrl = v.MapUrl,
                              MobileNo = v.MobileNo,
                              Picture = v.Picture
                          }).ToListAsync();
        }
    }
}
