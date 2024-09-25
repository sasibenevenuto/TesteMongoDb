using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.ECommerce
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("order_id")]
        public string OrderId { get; set; }
        [BsonElement("customer")]
        public Customer Customer { get; set; }
        [BsonElement("itens")]
        public List<Product> Itens { get; set; }
        [BsonElement("total_amount")]
        public decimal TotalAmount { get; set; }
        [BsonElement("order_date")]
        public DateTime OrderDate { get; set; }
    }
}
