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
    public class SpeakersRepository : ISpeakersRepository
    {
        private readonly TESContext _context;
        public SpeakersRepository(TESContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Speakers>> GetSpeakers()
        {
            return await _context.Speakers.ToListAsync();
        }

        public async Task<Speakers> GetSpeakersById(int id)
        {
            return await _context.Speakers.FirstAsync(x => x.Id == id);
        }

        public async Task AddSpeakers(Speakers speakers)
        {
            _context.Speakers.Add(speakers);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteSpeakers(int id)
        {
            var speakers = await _context.Speakers.FindAsync(id);
            _context.Speakers.Remove(speakers);
            _context.SaveChanges();
        }

        public async Task UpdateSpeakers(int id, Speakers speakers)
        {
            _context.Entry(speakers).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task<IEnumerable<Speakers>> GetSpeakersByEventID(int id)
        {

            return await (from e in _context.Events
                          where e.Id == id
                          join t in _context.TalkDetails on e.Id equals t.EventId
                          join s in _context.Speakers on t.SpeakerId equals s.Id
                          select new Speakers()
                          {
                              Id = s.Id,
                              Name = s.Name,
                              Profile = s.Profile,
                              LinkedInUrl = s.LinkedInUrl,
                              Twitter = s.Twitter,
                              Pic = s.Pic
                          }).ToListAsync();
        }

        public async Task<IEnumerable<TalkDetails>> GetTalkDetailsByEventIDAndSpeakerID(int EventId, int SpeakerId)
        {

            return await (from t in _context.TalkDetails
                          where t.EventId == EventId && t.SpeakerId == SpeakerId
                          join e in _context.Events on t.EventId equals e.Id
                          join s in _context.Speakers on t.SpeakerId equals s.Id
                          select new TalkDetails()
                          {
                              Id = t.Id,
                              Title = t.Title,
                              Room = t.Room,
                              Description = t.Description,
                              Tags = t.Tags,
                              StartTime = t.StartTime,
                              EndTime = t.EndTime,
                              SpeakerId = t.SpeakerId,
                              EventId = t.EventId,

                          }).ToListAsync();
        }

        public async Task<IEnumerable<Speakers>> GetSpeakerByEventIdAndSpeakerId(int eventId, int speakerId)
        {
            return await (from t in _context.TalkDetails
                          where t.EventId == eventId && t.SpeakerId == speakerId
                          join e in _context.Events on t.EventId equals e.Id
                          join s in _context.Speakers on t.SpeakerId equals s.Id
                          select new Speakers()
                          {
                              Id = s.Id,
                              Name = s.Name,
                              Profile = s.Profile,
                              LinkedInUrl = s.LinkedInUrl,
                              Twitter = s.Twitter,
                              Pic = s.Pic
                          }).ToListAsync();
        }
    }
}
