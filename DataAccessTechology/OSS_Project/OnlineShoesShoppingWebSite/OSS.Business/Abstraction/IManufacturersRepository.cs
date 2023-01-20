using OSS.Business.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSS.Business.Abstraction
{
    public interface IManufacturersRepository
    {
        public Task<IEnumerable<Manufacturers>> GetManufacturers();
        public Task<Manufacturers> GetManufacturersById(int id);
        public Task AddManufacturers(Manufacturers manufacturers);
        public Task DeleteManufacturers(int id);
        public Task UpdateManufacturers(int id, Manufacturers manufacturers);
    }
}
