using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

using SeidoDemoDb;
using SeidoDemoModels;

namespace SeidoApplication
{
    class Program
    {
        private static DbContextOptionsBuilder<SeidoDemoDbContext> _optionsBuilder;
        static void Main(string[] args)
        {
            BuildOptions();

            #region Uncomment to seed and query the Database
            /*
            SeedDataBase();
            QueryDatabaseAsync().Wait();
            QueryDatabaseWithLinq();
            */
            #endregion

            Console.WriteLine($"\nApplication finished");
        }

        private static void BuildOptions()
        {
            _optionsBuilder = new DbContextOptionsBuilder<SeidoDemoDbContext>();

            #region Ensuring appsettings.json is in the right location
            Console.WriteLine($"DbConnections Directory: {DBConnection.DbConnectionsDirectory}");

            var connectionString = DBConnection.ConfigurationRoot.GetConnectionString(DBConnection.ThisConnection);
            if (!string.IsNullOrEmpty(connectionString))
                Console.WriteLine($"Connection string to Database: {connectionString}");
            else
            {
                Console.WriteLine($"Please copy the 'DbConnections.json' to this location");
                return;
            }
            #endregion

            _optionsBuilder.UseSqlite(connectionString);

        }

        #region Uncomment to seed and query the Database
        /*
        private static void SeedDataBase()
        {
            using (var db = new SeidoDemoDbContext(_optionsBuilder.Options))
            {
                //Create some customers
                var CustomerList = new List<Customer>();
                for (int i = 0; i < 10; i++)
                {
                    CustomerList.Add(new Customer());
                }
                //Create some orders randomly linked to customers
                var rnd = new Random();
                var OrderList = new List<Order>();
                for (int i = 0; i < 20; i++)
                {
                    OrderList.Add(new Order(CustomerList[rnd.Next(0, CustomerList.Count)].CustomerID));
                }

                //Add it to the Database
                CustomerList.ForEach(cust => db.Customers.Add(cust));
                OrderList.ForEach(order => db.Orders.Add(order));

                db.SaveChanges();
            }
        }
        private static async Task QueryDatabaseAsync()
        {
            using (var db = new SeidoDemoDbContext(_optionsBuilder.Options))
            {
                var customers = await db.Customers.CountAsync();
                var orders = await db.Orders.CountAsync();

                Console.WriteLine($"Nr of Customers: {customers}");
                Console.WriteLine($"Nr of Orders: {orders}");
            }
        }
        private static void QueryDatabaseWithLinq()
        {
            using (var db = new SeidoDemoDbContext(_optionsBuilder.Options))
            {
                var customers = db.Customers;
                var orders = db.Orders;

                Console.WriteLine("\n\nQuery Database with Linq");
                Console.WriteLine("------------------------");
                Console.WriteLine($"Nr of customers: {customers.Count()}");
                Console.WriteLine($"Nr of orders: {orders.Count()}");

                var list = customers.Join(orders, cust => cust.CustomerID, order => order.CustomerID, (cust, order) => new { cust, order });
                Console.WriteLine($"\nInnerJoin Customer - Order via Join, Count: {list.Count()}");
            }
        }
        */
        #endregion
    }
}
