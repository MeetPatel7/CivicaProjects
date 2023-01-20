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
    public class FootwearDetailsRepository : IFootwearDetailsRepository
    {
        private readonly OSSContext _context;

        public FootwearDetailsRepository(OSSContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<FootwearDetails>> GetFootwearDetails() => await _context.FootwearDetails.ToListAsync();

        public async Task<FootwearDetails> GetFootwearDetailsById(int id) => await _context.FootwearDetails.FindAsync(id);
        //{
        //    return await _context.Categories.FindAsync(id);
        //}

        public async Task AddFootwearDetails(FootwearDetails footwearDetails)
        {
            _context.FootwearDetails.Add(footwearDetails);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteFootwearDetails(int id)
        {
            var deleteFootwearDetails = await _context.FootwearDetails.FindAsync(id);
            _context.FootwearDetails.Remove(deleteFootwearDetails);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateFootwearDetails(int id, FootwearDetails footwearDetails)
        {
            _context.Entry(footwearDetails).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FootwearDetails>> GetFootwearDetailsByCategoryId(int categoryId)
        {
            return await (from f in _context.FootwearDetails
                          where f.CategoryId == categoryId && f.InStock == true
                          join c in _context.Categories on f.CategoryId equals c.Id
                          select new FootwearDetails()
                          {
                              Id = f.Id,
                              CategoryId = f.CategoryId,
                              ManufacturerId = f.ManufacturerId,
                              Name = f.Name,
                              Pic = f.Pic,
                              Price = f.Price,
                              Color = f.Color,
                              Material = f.Material,    
                              ManufacturingDate = f.ManufacturingDate,
                              InStock = f.InStock
                          }).ToListAsync();
        }

        public async Task<IEnumerable<FootwearDetails>> GetFootwearDetailsByCategoryIdAndFootwearDetailsId(int categoryId,int id)
        {
            return await (from f in _context.FootwearDetails
                          where f.CategoryId == categoryId && f.Id == id
                          join c in _context.Categories on f.CategoryId equals c.Id
                          join m in _context.Manufacturers on f.ManufacturerId equals m.Id
                          select new FootwearDetails()
                          {
                              Id = f.Id,
                              CategoryId = f.CategoryId,
                              ManufacturerId = f.ManufacturerId,
                              Name = f.Name,
                              Pic = f.Pic,
                              Price = f.Price,
                              Color = f.Color,
                              Material = f.Material,
                              ManufacturingDate = f.ManufacturingDate,
                              InStock = f.InStock
                          }).ToListAsync();

        }
    }
}
