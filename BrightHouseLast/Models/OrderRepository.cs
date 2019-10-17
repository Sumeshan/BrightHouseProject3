using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrightHouseLast.Data;
using MongoDB.Driver;

namespace BrightHouseLast.Models
{
    public class OrderRepository : IOrderRepository
    {
        Context db = new Context();



        public async Task Add(Orders order) 
        {
            try
            {
                await db.Orders.InsertOneAsync(order); 
            }
            catch
            {
                throw;
            }
        }
        public async Task<Orders> GetOrders(string id)
        {
            try
            {
                FilterDefinition<Orders> filter = Builders<Orders>.Filter.Eq("Id", id);
                return await db.Orders.Find(filter).FirstOrDefaultAsync(); 
            }
            catch
            {
                throw;
            }
        }
        public async Task<IEnumerable<Orders>> GetOrders() 
        {
            try
            {
                return await db.Orders.Find(_ => true).ToListAsync(); 
            }
            catch
            {
                throw;
            }
        }
        public async Task Update(Orders order) 
        {
            try
            {
                await db.Orders.ReplaceOneAsync(filter: g => g.Id == order.Id, replacement: order); 
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
                FilterDefinition<Orders> data = Builders<Orders>.Filter.Eq("Id", id);
                await db.Orders.DeleteOneAsync(data); 
            }
            catch
            {
                throw;
            }
        }
    }

}

