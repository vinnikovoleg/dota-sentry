using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotaSentry.Business.Models;
using MongoDB.Driver;

namespace DotaSentry.Business.MongoClient
{
    public class MongoHeroesRepository
    {
        private readonly IMongoCollection<HeroData> _heroes;

        public MongoHeroesRepository(DotaSentryDatabaseSettings settings)
        {
            var client = new MongoDB.Driver.MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _heroes = database.GetCollection<HeroData>(settings.HeroesCollectionName);
        }

        public List<HeroData> Get() => _heroes.Find(book => true).ToList();

        public HeroData Get(long id) => _heroes.Find(book => book.Id == id).FirstOrDefault();

        public HeroData Create(HeroData book)
        {
            _heroes.InsertOne(book);
            return book;
        }

        public void Update(long id, HeroData bookIn) => _heroes.ReplaceOne(book => book.Id == id, bookIn);

        public void Remove(HeroData bookIn) => _heroes.DeleteOne(book => book.Id == bookIn.Id);

        public void Remove(long id) => _heroes.DeleteOne(book => book.Id == id);
    }
}
