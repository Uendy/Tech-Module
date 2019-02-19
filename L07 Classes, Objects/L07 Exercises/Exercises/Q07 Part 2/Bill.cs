using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Part_2
{
    public class Bill
    {

        public List<PersonalisedBill> ListOfPersonalisedBills { get; set; }

        public List<string> ListOfClients { get; set; }

        public Dictionary<string, double> DictOfProductAndPrice { get; set; }
        // key = productName, value = ProductPrice


        public double BigBillTotal { get; set; }

        //public string ReturnBillInfo()
        //{
        //    return 
        //}
    }
}
