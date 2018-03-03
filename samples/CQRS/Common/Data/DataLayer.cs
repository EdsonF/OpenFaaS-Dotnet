﻿using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Driver;

namespace Data
{
    public class DataLayer
    {
        private IMongoClient _mongoClient;

        public IEnumerable<string> SaveEventData<T>(IEnumerable<T> eventData) where T : class
        {
            var client = Client();
            var db = client.GetDatabase("EventDataStore");
            var collection = db.GetCollection<EventStoreItem>("Events");
            var storeItems = eventData.Select(x => new EventStoreItem
            {
                Event = x,
                Timestamp = DateTime.UtcNow
            }).ToList();
            collection.InsertMany(storeItems);

            foreach (var item in storeItems)
            {
                yield return item.Id.ToString();
            }
        }

        private IMongoClient Client()
        {
            return _mongoClient ?? (_mongoClient = new MongoClient("mongodb://localhost"));
        }
    }
}
