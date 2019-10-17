using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrightHouseLast.Data;
using MongoDB.Driver;

namespace BrightHouseLast.Models
{
    public class ReturnRepository
    {
        Context db = new Context();

        public async Task Add(Returns returns) 
        {
            try
            {
                await db.Returns.InsertOneAsync(returns);
            }
            catch
            {
                throw;
            }
        }
        public async Task<Returns> GetReturnItem(string id) 
        {
            try
            {
                FilterDefinition<Returns> filter = Builders<Returns>.Filter.Eq("Id", id);
                return await db.Returns.Find(filter).FirstOrDefaultAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Returns>> GetReturnItems() 
        {
            try
            {
                return await db.Returns.Find(_ => true).ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Returns returns) 
        {
            try
            {
                await db.Returns.ReplaceOneAsync(filter: g => g.Id == returns.Id, replacement: returns);
            }
            catch
            {
                throw;
            }
        }
        public async Task Delete(string id) 
        {
            try
            {
                FilterDefinition<Returns> data = Builders<Returns>.Filter.Eq("Id", id);
                await db.Returns.DeleteOneAsync(data);
            }
            catch
            {
                throw;
            }
        }
    }

}

