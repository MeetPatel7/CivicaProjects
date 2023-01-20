using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TES.Business.Entity;

namespace TES.Business.Absrtaction
{
    public interface ITalkDetailsRepository
    {
        public Task<IEnumerable<TalkDetails>> GetTalkDetails();
        public Task<TalkDetails> GetTalkDetailsById(int id);
        public Task AddTalkDetails(TalkDetails talkDetails);
        public Task DeleteTalkDetails(int id);
        public Task UpdateTalkDetails(int id, TalkDetails talkDetails);
    }
}
