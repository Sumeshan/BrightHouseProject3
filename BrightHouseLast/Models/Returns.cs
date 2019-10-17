using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BrightHouseLast.Models
{
    public class Returns
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Returned")]
        [Required]
        public string Returned { get; set; }

        [BsonElement("Order ID")]
        [Required]
        public string OrderID { get; set; }

        [BsonElement("Region")]
        [Required]
        public string Region { get; set; }
    }
}
