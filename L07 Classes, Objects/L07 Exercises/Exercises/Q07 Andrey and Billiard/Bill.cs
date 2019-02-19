using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Bill
{
    public Dictionary<string, double> DictOfProducts { get; set; }

    // might need a smallerBill Class 
    //with string ClientName
    // List<Dict<stringProductName, double ProductPrice>> orders 

    public string ClientName { get; set; }

    public string ProductName { get; set; }

    public int NumberOfProducts { get; set; }

    public double CurrentTotalBill => Math.Round(DictOfProducts[ProductName] * NumberOfProducts, 2);

    public void ReturnOrder()
    {
        Console.WriteLine(ClientName);
        Console.WriteLine($"--{ProductName} - {NumberOfProducts}");
        Console.WriteLine($"Bill: {CurrentTotalBill:f2}");
    }

    public double TotalBill { get; set; } 

}
