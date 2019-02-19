using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Q07_Part_2
{
    public class PersonalisedBill
    {
      
        // A nested dict
        // <string <dict<string, int>>>
        // outer key = ClientName, outerKey = nested Dict
        // innerey = productName, innerValue = productQuantity
        //public string ClientName { get; set; }

        public Dictionary<string, Dictionary<string, int>> PersonalShoppingBasket { get; set; }
        // key = productName, value = productQuantity

        public double PersonalTotal { get; set; }

        //public void PersonalBillReturn() // tried behaviour didnt work
        //{
        //   return ClientName \n
        //}
    }
}
