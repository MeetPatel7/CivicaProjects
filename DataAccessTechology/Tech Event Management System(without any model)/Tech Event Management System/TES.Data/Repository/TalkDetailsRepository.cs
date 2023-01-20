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
    public class TalkDetailsRepository : ITalkDetailsRepository
    {
        private readonly TESContext _context;
        public TalkDetailsRepository(TESContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<TalkDetails>> GetTalkDetails()
        {
            return await _context.TalkDetails.ToListAsync();          
        }

        public async Task<TalkDetails> GetTalkDetailsById(int id)
        {         
                return await _context.TalkDetails.FirstAsync(x => x.Id == id);                 
        }

        public async Task AddTalkDetails(TalkDetails talkDetails)
        {
            _context.TalkDetails.Add(talkDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteTalkDetails(int id)
        {
            var talkDetails = await _context.TalkDetails.FindAsync(id);
            _context.TalkDetails.Remove(talkDetails);
            _context.SaveChanges(); 
        }

        public async Task UpdateTalkDetails(int id, TalkDetails talkDetails)
        {
            _context.Entry(talkDetails).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
