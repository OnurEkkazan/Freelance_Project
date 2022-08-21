using Freelance_Project.DataModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Freelance_Project
{
    class Program
    {
        static void Main(string[] args)
        {

            InitialDataMigration();
            var transferObject = new TransferObject();
            transferObject.CompareSqlToText();
            Console.ReadLine();
        }

        private static void InitialDataMigration()
        {
            try
            {
                using (var context = new Context())
                {
                    var oldCustomer = context.Customers.ToArray();
                    context.Customers.RemoveRange(oldCustomer);

                    var customerList = new List<Customer>()
                {
                   new Customer
                   {
                       Name = "Onur",
                       Surname = "Ekkazan",
                       Address = "Tekirdağ",
                       Mail = "onurekkazan@gmail.com"
                   },
                   new Customer
                   {
                        Name = "Serhat",
                        Surname = "Kanbaş",
                        Address = "Ankara",
                        Mail = "sekanbas@gmail.com"
                   },
                   new Customer
                   {
                       Name = "Ramazan",
                       Surname = "Uysal",
                       Address = "Ankara",
                       Mail = "ramazanuysal@gmail.com"
                   },
                   new Customer
                   {
                       Name = "Tunahan",
                       Surname = "Yollar",
                       Address = "Konya",
                       Mail = "tunahanyollar@gmail.com"
                   }
                };
                    context.AddRange(customerList);
                    context.SaveChanges();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error has occurred. Error Message: " + ex.Message);
            }
        }
    }
}
