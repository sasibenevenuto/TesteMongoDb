using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ECommerce
{
    public class Product
    {
        [BsonElement("product_id")]
        public string ProductId { get; set; }
        [BsonElement("quantity")]
        public int Quantity { get; set; }
        [BsonElement("price")]
        public decimal Price { get; set; }
    }
}
