using MongoDB.Bson;
using MongoDB.Driver;
using System.Runtime.CompilerServices;

namespace BasicMogodb.Services

{
    public class MongodbService
    {
        private readonly string host = "mongodb://localhost:27017";

        public IMongoCollection<T> GetCollection<T> (string collectionName)
        {
            // Create connectionj
            IMongoClient mongoClient = new MongoClient(this.host);

            // Get database
            IMongoDatabase database = mongoClient.GetDatabase("Library");

            // Get collection
            IMongoCollection<T> collectionResult = database.GetCollection<T>(collectionName);

            return collectionResult;
        }

    }
}
