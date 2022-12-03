using Microsoft.Extensions.Options;
using MongoDB.Driver;
using delfosti_api.Models;

namespace delfosti_api.Services
{
    public class ProductService
    {
        private readonly IMongoCollection<Producto> _productCollection;

        public ProductService(
            IOptions<DatabaseSettings> dabaseSettings)
        {
            var mongoClient = new MongoClient(dabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(dabaseSettings.Value.DatabaseName);

            _productCollection = mongoDatabase.GetCollection<Producto>("Producto");
        }

        public async Task<List<Producto>> GetAsync() =>
            await _productCollection.Find(_ => true).ToListAsync();

        public async Task<Producto?> GetAsync(string id) =>
            await _productCollection.Find(x => x._id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Producto newProducto) =>
            await _productCollection.InsertOneAsync(newProducto);

        public async Task UpdateAsync(string id, Producto updatedProducto) =>
            await _productCollection.ReplaceOneAsync(x => x._id == id, updatedProducto);

        public async Task RemoveAsync(string id) => await _productCollection.DeleteOneAsync(x => x._id == id);
    }
}
