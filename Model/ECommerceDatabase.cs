using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class ECommerceDatabase
    {
        public string ConnectionString { get; set; } 

        public string DatabaseName { get; set; }

        public string OrdersCollectionName { get; set; }
    }
}
