using MongoDB.Driver;
using Payment.WebAPI.Data.Repository.Abstractions;
using Payment.WebAPI.Models.Entities;
using Payment.WebAPI.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Payment.WebAPI.Data.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly IMongoDbSettings _settings;
        protected IMongoCollection<T> _dbCollection;

        protected BaseRepository(IMongoDbSettings settings)
        {
            _settings = settings;
            var database = new MongoClient(_settings.ConnectionString).GetDatabase(_settings.DatabaseName);
            _dbCollection = database.GetCollection<T>(typeof(T).Name);
        }

        public Task AddAsync(T document)
        {
           return _dbCollection.InsertOneAsync(document);
        }

        public async Task<T> FindByIdAsync(Guid id)
        {
            return await _dbCollection.Find<T>(m => m.Id == id).FirstOrDefaultAsync();
        }
    
        public IEnumerable<T> GetAsync(Expression<Func<T, bool>> filter)
        {
            return _dbCollection.Find<T>(filter).ToList();
        }

        public Task<T> GetOneAsync(Expression<Func<T, bool>> filter)
        {
            return _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public Task RemoveByIdAsync(Guid id)
        {
            return _dbCollection.DeleteOneAsync(m => m.Id == id);
        }

        public Task Update(T entity)
        {
           return _dbCollection.ReplaceOneAsync(Builders<T>.Filter.Eq("_id", entity.Id), entity);
        }

        private protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute)documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

      
    }
}