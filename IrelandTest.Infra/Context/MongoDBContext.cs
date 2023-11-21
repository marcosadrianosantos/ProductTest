using IrelandTest.Domain.Models.Response;
using MongoDB.Driver;

namespace IrelandTest.Infra.Context
{
    public class MongoDBContext
    {
        public MongoDBContext(IMongoDatabase database) => Database = database;
        public IMongoDatabase Database { get; }
        public IMongoCollection<Product> Products => Database.GetCollection<Product>("Products");
        public IMongoCollection<Category> Categories => Database.GetCollection<Category>("Categories");
    }
}
