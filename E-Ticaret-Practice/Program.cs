using E_Ticaret_Practice.ETicaret;

namespace E_Ticaret_Practice
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ETicaret = new ETicaretService();

            ETicaret.AddCostumer();

            Console.WriteLine("Hello, World!");
        }
    }
}