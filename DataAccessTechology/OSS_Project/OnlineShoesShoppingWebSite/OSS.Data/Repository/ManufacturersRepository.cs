using Microsoft.EntityFrameworkCore;
using OSS.Business.Abstraction;
using OSS.Business.Entity;
using OSS.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSS.Data.Repository
{
    public class ManufacturersRepository:IManufacturersRepository
    {
        private readonly OSSContext _context;

        public ManufacturersRepository(OSSContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Manufacturers>> GetManufacturers() => await _context.Manufacturers.ToListAsync();

        public async Task<Manufacturers> GetManufacturersById(int id) => await _context.Manufacturers.FindAsync(id);
        //{
        //    return await _context.Categories.FindAsync(id);
        //}

        public async Task AddManufacturers(Manufacturers manufacturers)
        {
            _context.Manufacturers.Add(manufacturers);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteManufacturers(int id)
        {
            var deleteManufacturers = await _context.Manufacturers.FindAsync(id);
            _context.Manufacturers.Remove(deleteManufacturers);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateManufacturers(int id, Manufacturers manufacturers)
        {
            _context.Entry(manufacturers).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
