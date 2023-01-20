using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Business.Entity;

namespace TES.Business.Absrtaction
{
    public interface ISpeakersRepository
    {
        public Task<IEnumerable<Speakers>> GetSpeakers();
        public Task<Speakers> GetSpeakersById(int id);
        public Task AddSpeakers(Speakers speakers);
        public Task DeleteSpeakers(int id);
        public Task UpdateSpeakers(int id, Speakers speakers);
        public Task<IEnumerable<TalkDetails>> GetTalkDetailsByEventIDAndSpeakerID(int EventId, int SpeakerId);
        public Task<IEnumerable<Speakers>> GetSpeakersByEventID(int id);
        public Task<IEnumerable<Speakers>> GetSpeakerByEventIdAndSpeakerId(int eventId, int speakerId);
    }
}
