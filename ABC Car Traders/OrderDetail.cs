using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ABC_Car_Traders
{
    internal class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int CarId { get; set; }
        public int PartId { get; set; }
        public int Quantity { get; set; }
    }
}
