using IrelandTest.Domain.Interfaces.Repositories;
using IrelandTest.Domain.Models.Response;
using IrelandTest.Infra.Context;
using MongoDB.Driver;

namespace IrelandTest.Infra.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly MongoDBContext _context;

        public CategoryRepository(MongoDBContext context)
        {
            _context = context;
        }

        public async Task Add(Category category) => await _context.Categories.InsertOneAsync(category);
        public async Task<List<Category>> GetAll() => await _context.Categories.AsQueryable().ToListAsync();
        public async Task<Category> GetById(string id) => await _context.Categories.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task UpdateAsync(string id, Category category) => await _context.Categories.ReplaceOneAsync(x => x.Id == id, category);
        public async Task DeleteAsync(string id) => await _context.Categories.DeleteOneAsync(x => x.Id == id);
    }
}
