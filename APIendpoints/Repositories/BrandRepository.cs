using APIendpoints.Data;
using APIendpoints.Entities;
using APIendpoints.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace APIendpoints.Repositories
{
    public class BrandRepository : IBrandRepository
    {
        private readonly DataContext _ctx;

        public BrandRepository(DataContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<IEnumerable<Brand>> GetAsync()
        {
            var brands = await _ctx.Brand.ToListAsync();
            return brands;
        }

        public async Task<bool> UpdateAsync(Brand brand)
        {
            _ctx.Brand.Update(brand);
            var result = await _ctx.SaveChangesAsync();

            return result > 0;
        }

        public async Task<Brand> FindByIdAsync(byte id)
        {
            var brand = await _ctx.Brand.FindAsync(id);

            if (brand == null)
            {
                return new Brand();
            }

            return brand;
        }

        public async Task<bool> DeleteAsync(Brand brand)
        {
            _ctx.Brand.Remove(brand);
            var result = await _ctx.SaveChangesAsync();

            return result > 0;
        }

        public async Task<bool> CreateAsync(Brand brand)
        {
            _ctx.Brand.Add(brand);
            var result = await _ctx.SaveChangesAsync();

            return result > 0;
        }
    }
}
