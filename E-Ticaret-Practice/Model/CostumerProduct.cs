using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_Practice.Model
{
    public class CostumerProduct
    {
        public int CostumerID { get; set; }
        public Costumer Costumers { get; set; }
        public int ProductID { get; set; }
        public Product Products { get; set; }
    }
}
