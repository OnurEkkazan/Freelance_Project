using Freelance_Project.DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Freelance_Project
{
    public class TransferObject
    {
        StringBuilder mainDirectory = new StringBuilder(AppDomain.CurrentDomain.BaseDirectory);
        public void CompareSqlToText()
        {
            var state = CheckTextFileDirectory();

            if (state)
            {
                var customerListText = new List<Customer>();
                using (StreamReader reader = new StreamReader(mainDirectory.ToString()))
                {
                    string customerJson;
                    while ((customerJson = reader.ReadLine()) != null)
                    {
                        if (customerJson == "")
                        {
                            continue;
                        }
                        try
                        {
                            var customer = JsonConvert.DeserializeObject<Customer>(customerJson);
                            customerListText.Add(customer);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine("Customer Convert Exception: " + ex.Message);
                        }
                    }
                }

                using (var context = new Context())
                {
                    var customerListDB = context.Customers.ToArray();
                    var missingCustomer = customerListDB.Where(x => !customerListText.Any(y => y.Mail == x.Mail)).ToArray();
                    foreach (var customer in missingCustomer)
                    {
                        var jsonToCustomer = JsonConvert.SerializeObject(customer);
                        Console.WriteLine("Eksik Müşteri: " + jsonToCustomer);
                        File.AppendAllText(mainDirectory.ToString(), jsonToCustomer + "\n");
                    }
                }
            }
            else
            {
                using (var context = new Context())
                {
                    var customerList = context.Customers.ToArray();

                    foreach (var customer in customerList)
                    {
                        var jsonToCustomer = JsonConvert.SerializeObject(customer);
                        File.AppendAllText(mainDirectory.ToString(), jsonToCustomer + "\n");
                    }




                }
            }

        }





        private bool CheckTextFileDirectory()
        {
            mainDirectory.Append(@"\Text");

            if (!Directory.Exists(mainDirectory.ToString()))
            {
                Directory.CreateDirectory(mainDirectory.ToString());
            }

            mainDirectory.Append(@"\Customer.txt");

            if (File.Exists(mainDirectory.ToString()))
            {
                return true;
            }
            return false;
        }
    }


}
