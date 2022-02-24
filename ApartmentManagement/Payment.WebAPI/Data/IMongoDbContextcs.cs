using MongoDB.Driver;


namespace Payment.WebAPI.Data
{
    public interface IMongoDBContext
    {
        IMongoDatabase _db { get; }
        MongoClient _mongoClient { get; }
        IMongoCollection<T> GetCollection<T>(string name);
    }
}
