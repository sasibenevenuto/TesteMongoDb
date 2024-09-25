using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ECommerce
{
    public class Customer
    {
        [BsonElement("customer_id")]
        public string CustomerId { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("email")]
        public string Email { get; set; }
    }
}
