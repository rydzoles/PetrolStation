using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PetrolStation
{
   
    public class ProductFromFileViewModel
    {
        ProductViewModel productVIewModel { get; set; }
        public static string[] productDetailsFromTextFile { get; set; }
        public  List<ProductViewModel> finallLIst = new List<ProductViewModel>();
        static string name { get; set; }
        static double price { get; set; }
        public ProductFromFileViewModel()
        {
            
            GetProductInformationFromFile("FuelType.txt");
        }
      public void GetProductInformationFromFile(string path)
        {
           var lines= File.ReadAllLines(path);
            productDetailsFromTextFile = lines;
            ProductAndPriceAssign();
        }
        public void ProductAndPriceAssign()
        {
            string[] uu = productDetailsFromTextFile;
            int counter = 0;
            foreach (var line in uu)
            {
                if (counter == 1)
                {
                    price = Convert.ToDouble(line);
                    var product = new ProductViewModel
                    {
                        ProductName = name,
                        ProductPrice = price
                    };
                    finallLIst.Add(product);
                    counter++;
                }
                if (counter == 0)
                {
                    counter++;
                    name = line;
                }
                if (counter == 2)
                    counter = 0;
            }
        }

    }
}
