using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BrightHouseLast.Models;
using MongoDB.Driver;

namespace BrightHouseLast.Data
{
    
    public class Context
    {
        private readonly IMongoDatabase db;
        public Context()
        {

           var mongoClient = new MongoClient("mongodb+srv://Sushi:<Meshan@29>@brighthouse-dsmtl.azure.mongodb.net/test?retryWrites=true&w=majority");
            db = mongoClient.GetDatabase("project3");
        }

        public IMongoCollection<People> People
        {
            get
            {
                return db.GetCollection<People>("people");
            }
        }
        public IMongoCollection<Orders> Orders
        {
            get
            {
                return db.GetCollection<Orders>("Orders");
            }
        }
        public IMongoCollection<Returns> Returns
        {
            get
            {
                return db.GetCollection<Returns>("Returns");
            }
        }
    }

}

