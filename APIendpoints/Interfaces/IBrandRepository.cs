using APIendpoints.Entities;

namespace APIendpoints.Interfaces
{
    public interface IBrandRepository
    {
        public Task<IEnumerable<Brand>> GetAsync();
        public Task<bool> CreateAsync(Brand brand);
        public Task<Brand> FindByIdAsync(byte id);
        public Task<bool> UpdateAsync(Brand brand);
        public Task<bool> DeleteAsync(Brand brand);
    }
}
