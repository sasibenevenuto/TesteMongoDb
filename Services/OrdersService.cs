using Microsoft.Extensions.Options;
using Model;
using Model.ECommerce;
using MongoDB.Driver;

namespace Services
{
    public class OrdersService
    {
        private readonly IMongoCollection<Order> _booksCollection;

        public OrdersService(
            IOptions<ECommerceDatabase> bookStoreDatabaseSettings)
        {
            var mongoClient = new MongoClient(
                bookStoreDatabaseSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(
                bookStoreDatabaseSettings.Value.DatabaseName);

            _booksCollection = mongoDatabase.GetCollection<Order>(
                bookStoreDatabaseSettings.Value.OrdersCollectionName);
        }

        public async Task<List<Order>> GetAsync() =>
            await _booksCollection.Find(x => x.Itens.Where(i => i.Price == 0).Any()).ToListAsync();

        public async Task<Order?> GetAsync(string id) =>
            await _booksCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

        public async Task CreateAsync(Order newBook) =>
            await _booksCollection.InsertOneAsync(newBook);

        public async Task UpdateAsync(string id, Order updatedBook) =>
            await _booksCollection.ReplaceOneAsync(x => x.Id == id, updatedBook);

        public async Task RemoveAsync(string id) =>
            await _booksCollection.DeleteOneAsync(x => x.Id == id);
    }
}
