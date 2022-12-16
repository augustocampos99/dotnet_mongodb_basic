using BasicMogodb.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BasicMogodb.Services
{
    public class BookService
    {
        private readonly MongodbService _mongodbService = new MongodbService();

        public async Task<Book> Create(Book book)
        {
            // Get collection
            var collection = _mongodbService.GetCollection<Book>("Books");

            // Insert document
            await collection.InsertOneAsync(book);

            return book;

        }

        public async Task<List<Book>> GetAll(int limit)
        {
            // Get collection
            var collection = _mongodbService.GetCollection<Book>("Books");

            // Get documents
            return await collection.Find(new BsonDocument()).SortBy(e => e.Title).Limit(limit).ToListAsync();

        }

        public async Task<Book> GetOne(string id)
        {
            // Get collection
            var collection = _mongodbService.GetCollection<Book>("Books");

            // Filter
            var constructor = Builders<Book>.Filter;
            var filter = constructor.Eq(e => e.Id, id);

            // Get document
            return await collection.Find(filter).FirstOrDefaultAsync();


        }

        public async Task<Book> Update(Book book, string id)
        {
            // Get collection
            var collection = _mongodbService.GetCollection<Book>("Books");

            // Filter
            var constructor = Builders<Book>.Filter;
            var filter = constructor.Eq(e => e.Id, id);

            // Update document
            book.Id = id;
            await collection.ReplaceOneAsync(filter, book);

            return book;

        }

        public async Task<bool> Remove(string id)
        {
            // Get collection
            var collection = _mongodbService.GetCollection<Book>("Books");

            // Filter
            var constructor = Builders<Book>.Filter;
            var filter = constructor.Eq(e => e.Id, id);

            // Remove document
            await collection.DeleteOneAsync(filter);

            return true;

        }

    }
}
