using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrightHouseLast.Data;
using MongoDB.Driver;

namespace BrightHouseLast.Models
{
    public class PeopleRepository :IPeopleRepository
    {
        Context db = new Context();

        public async Task Add(People people) 
        {
            try
            {
                await db.People.InsertOneAsync(people); 
            }
            catch
            {
                throw;
            }
        }
        public async Task<People> GetMember(string id)
        {
            try
            {
                FilterDefinition<People> filter = Builders<People>.Filter.Eq("Id", id);
                return await db.People.Find(filter).FirstOrDefaultAsync(); 
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<People>> GetMembers() 
        {
            try
            {
                return await db.People.Find(_ => true).ToListAsync(); 
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(People people) 
        {
            try
            {
                await db.People.ReplaceOneAsync(filter: g => g.Id == people.Id, replacement: people); 
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
                FilterDefinition<People> data = Builders<People>.Filter.Eq("Id", id);
                await db.People.DeleteOneAsync(data); 
            }
            catch
            {
                throw;
            }
        }
    }

}

