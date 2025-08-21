using DB_First.Models;

namespace DB_First
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (EntityFrameWorkCoreContext context = new EntityFrameWorkCoreContext())
            {
                //GET ALL
                Console.WriteLine("------------------- GET ALL --------------------");
                var customer = context.Customers.Select(a => a);
                foreach (var c in customer)
                {
                    Console.WriteLine(c.CustomerName);
                }
                Console.WriteLine();

                //GET BY ID
                Console.WriteLine("------------------ GET BY ID ------------------");
                var customerByID = context.Customers.Find(100);
                Console.WriteLine(customerByID.CustomerName);
                Console.WriteLine();
            }
        }
    }
}




