using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace BrightHouseLast.Models
{
    public class Orders
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("Row ID")]
        [Required]
        public string RowID { get; set; }

        [BsonElement("Order ID")]
        [Required]
        public string OrderID { get; set; }

        [BsonElement("Order Date")]
        [Required]
        public string OrderDate { get; set; }

        [BsonElement("Ship Date")]
        [Required]
        public string ShipDate { get; set; }

        [BsonElement("Ship Mode")]
        [Required]
        public string ShipMode { get; set; }

        [BsonElement("Customer ID")]
        [Required]
        public string CustomerID { get; set; }

        [BsonElement("Segment")]
        [Required]
        public string Segment { get; set; }

        [BsonElement("Postal Code")]
        public string PostalCode { get; set; }

        [BsonElement("City")]
        [Required]
        public string City { get; set; }

        [BsonElement("State")]
        [Required]
        public string State { get; set; }

        [BsonElement("Country")]
        [Required]
        public string Country { get; set; }

        [BsonElement("Region")]
        [Required]
        public string Region { get; set; }

        [BsonElement("Market")]
        [Required]
        public string Market { get; set; }

        [BsonElement("Product ID")]
        [Required]
        public string ProductID { get; set; }

        [BsonElement("Category")]
        [Required]
        public string Category { get; set; }

        [BsonElement("Sub-Category")]
        [Required]
        public string SubCategory { get; set; }

        [BsonElement("Product Name")]
        [Required]
        public string ProductName { get; set; }

        [BsonElement("Sales")]
        [Display(Name = "Sales($)")]
        [Required]
        public string Sales { get; set; }

        [BsonElement("Quantity")]
        [Required]
        public string Quantity { get; set; }

        [BsonElement("Discount")]
        [Display(Name = "Discount(% x 100)")]
        [Required]
        public string Discount { get; set; }

        [BsonElement("Profit")]
        [Display(Name = "Profit($)")]
        [Required]
        public string Profit { get; set; }

        [BsonElement("Shipping Cost")]
        [Display(Name = "Shipping Cost($)")]
        [Required]
        public string ShippingCost { get; set; }

        [BsonElement("Order Priority")]
        [Required]
        public string OrderPriority { get; set; }

    }
}

