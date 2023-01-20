using OSS.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSS.Business.Abstraction
{
    public interface ICategoriesRepository
    {
        public Task<IEnumerable<Categories>> GetCategories();
        public Task<Categories> GetCategoriesById(int id);
        public Task AddCategories(Categories category);
        public Task DeleteCategories(int id);
        public Task UpdateCategories(int id,Categories category);
    }
}
