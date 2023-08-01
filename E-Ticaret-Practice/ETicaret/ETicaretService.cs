using E_Ticaret_Practice.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ticaret_Practice.ETicaret
{
    public class ETicaretService
    {
        private readonly ETicaretContext _context;

        public ETicaretService()
        {
            _context = new ETicaretContext();
        }

        public void AddCostumer()
        {
            try
            {
                Console.Write("Adınız: ");
                var costumerName = Console.ReadLine();
                Console.Write("Soyadınız: ");
                var costumerSurname = Console.ReadLine();
                Console.Write("Yaşınız: ");
                var costumerAge = int.Parse(Console.ReadLine());

                var newCostumer = new Costumer()
                {
                    Name = costumerName,
                    Surname = costumerSurname,
                    Age = costumerAge
                };

                if(newCostumer != null )
                {
                    _context.costumers.Add(newCostumer);
                    _context.SaveChanges();
                    Console.WriteLine($"{newCostumer.Name} {newCostumer.Surname} - müşteri listesine eklenmiştir.");
                }
                else 
                {
                    Console.WriteLine("İstenilen alanlar boş geçilemez");
                };

                
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }
           
        }

        public void AddProduct()
        {
            Console.Write("Eklemek istediğiniz ürün adı: ");
            var productName = Console.ReadLine();
            Console.Write("Ürün fiyatı: ");
            var unitPrice = decimal.Parse(Console.ReadLine());


        }
    }
}
