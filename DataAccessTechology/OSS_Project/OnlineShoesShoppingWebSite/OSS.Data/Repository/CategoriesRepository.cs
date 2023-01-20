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
    public class CategoriesRepository : ICategoriesRepository
    {
        private readonly OSSContext _context;

        public CategoriesRepository(OSSContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<Categories>> GetCategories() => await _context.Categories.ToListAsync();

        public async Task<Categories> GetCategoriesById(int id) => await _context.Categories.FindAsync(id);
        //{
        //    return await _context.Categories.FindAsync(id);
        //}

        public async Task AddCategories(Categories categories)
        {
            _context.Categories.Add(categories);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCategories(int id)
        {
            var deleteCategories = await _context.Categories.FindAsync(id);
            _context.Categories.Remove(deleteCategories);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCategories(int id,Categories categories)
        {
            _context.Entry(categories).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

    }
}
