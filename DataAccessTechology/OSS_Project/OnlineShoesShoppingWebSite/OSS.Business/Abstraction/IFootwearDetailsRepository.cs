using OSS.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSS.Business.Abstraction
{
    public interface IFootwearDetailsRepository
    {
        public Task<IEnumerable<FootwearDetails>> GetFootwearDetails();
        public Task<FootwearDetails> GetFootwearDetailsById(int id);
        public Task AddFootwearDetails(FootwearDetails footwearDetails);
        public Task DeleteFootwearDetails(int id);
        public Task UpdateFootwearDetails(int id, FootwearDetails footwearDetails);
        public Task<IEnumerable<FootwearDetails>> GetFootwearDetailsByCategoryId(int categoryId);
        public Task<IEnumerable<FootwearDetails>> GetFootwearDetailsByCategoryIdAndFootwearDetailsId(int categoryId,int id);
    }
}
