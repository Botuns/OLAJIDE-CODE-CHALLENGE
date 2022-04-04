using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BLAZE_BANK_APP
{
    class CustomerManager : ICustomer
    {
        public static IList<Customer> CustomerList = new List<Customer>();
        string file = "C:\\Users\\TOSHIBA\\source\\repos\\BLAZE BANK APP\\Files\\Customer.txt";
       public CustomerManager()
        {
            ReadCustomerFromFile();
        }
        private void ReadCustomerFromFile()
        {
            try
            {
                if (File.Exists(file))
                {
                    var allCustomers = File.ReadAllLines(file);
                    foreach (var customer in allCustomers)
                    {
                        CustomerList.Add(Customer.ToCustomer(customer));
                    }
                }
                else
                {
                    string path = "C:\\Users\\TOSHIBA\\source\\repos\\BLAZE BANK APP\\Files";
                    Directory.CreateDirectory(path);
                    string fileName = "Customer.txt";
                    string fullPath = Path.Combine(path, fileName);
                    using (File.Create(fullPath)) { }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        public void RefreshFile()
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(file))
                {
                    foreach (var customer in CustomerList)
                    {
                        sr.WriteLine(customer.ToString());
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private void AddToFile(Customer customer)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(file, true))
                {
                    sr.WriteLine(customer.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public bool Deposit()
        {
            bool isSuccessful = false;
            Console.WriteLine("Pls input your account number");
            string acctno = Console.ReadLine();
            Console.WriteLine("Pls input your pin");
            int pin = int.Parse(Console.ReadLine());
            foreach (var item in CustomerList)
            {
                if(item._acctNo ==  acctno && item.GetPin() == pin)
                {
                    Console.WriteLine("Enter the amount you want to deposit");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    var theCustomer = CustomerList.Where(cust => cust._acctNo == acctno).FirstOrDefault();
                    var transaction = theCustomer._deposit += amount;
                    Console.WriteLine($"Dear {theCustomer.GetFullName()} you have sucessfully deposited {amount} naira");
                    Console.WriteLine("Your new Balance is {0}", theCustomer._deposit);
                    RefreshFile();
                    isSuccessful = true;
                }
                else
                {
                    Console.WriteLine("Invalid Credentials");
                    isSuccessful = false;
                }
            }
            return isSuccessful;
        }

        public bool Transfer()
        {
            bool isSuccessful = false;
            Console.WriteLine("Pls input your account number");
            string acctno = Console.ReadLine();
            Console.WriteLine("Pls input your pin");
            int pin = int.Parse(Console.ReadLine());
            Console.WriteLine("Pls enter the Destination Account Number");
            string destinationAcct = Console.ReadLine();
            foreach (var item in CustomerList)
            {
                if (item._acctNo == acctno && item.GetPin() == pin)
                {
                    Console.WriteLine("Enter the amount you want to Transfer");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    var theCustomer = CustomerList.Where(cust => cust._acctNo == acctno).FirstOrDefault();

                    if (amount > theCustomer.GetDeposit())
                    {
                        Console.WriteLine("You cant transfer, insuficient balance ");
                        isSuccessful = false;
                    }
                    else if (amount < theCustomer.GetDeposit())
                    {
                        var transaction = theCustomer._deposit -= amount;
                        Console.WriteLine($" Dear {theCustomer.GetFullName()}  Transfer sucessful!,  Your new Balance is{theCustomer.GetDeposit()}");
                        RefreshFile();
                        isSuccessful = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Credentials");
                    isSuccessful = false;
                }
            }
            return isSuccessful;
        }

        public void UpdateProfile()
        {
            Console.WriteLine("Pls input your account number");
            string acctno = Console.ReadLine();
            Console.WriteLine("Pls input your pin");
            int pin = int.Parse(Console.ReadLine());
            foreach (var item in CustomerList)
            {
                if (item._acctNo == acctno && item.GetPin() == pin)
                {
                    var theCustomer = CustomerList.Where(cust => cust._acctNo == acctno).FirstOrDefault();

                    Console.WriteLine("Enter new firstName");
                    string nmae = Console.ReadLine();
                    Console.WriteLine("Enter new lastName");
                    string last = Console.ReadLine();
                    Console.WriteLine("Enter new Pin");
                    int newPin = int.Parse(Console.ReadLine());
                    theCustomer.SetFirstName(nmae);
                    theCustomer.SetLastName(last);
                    theCustomer.Setpin(newPin);
                    RefreshFile();
                    Console.WriteLine("Details Successfully Updated");
                }
                else
                {
                    Console.WriteLine("Invalid Credentials");
                }
                RefreshFile();
            }
        }

        public bool WithDraw()
        {
            bool isSuccessful = false;
            Console.WriteLine("Pls input your account number");
            string acctno = Console.ReadLine();
            Console.WriteLine("Pls input your pin");
            int pin = int.Parse(Console.ReadLine());
            foreach (var item in CustomerList)
            {
                if (item._acctNo == acctno && item.GetPin() == pin)
                {

                    Console.WriteLine("Enter the amount you want to withdraw");
                    decimal amount = decimal.Parse(Console.ReadLine());
                    var theCustomer = CustomerList.Where(cust => cust._acctNo == acctno).FirstOrDefault();

                    if (amount > theCustomer.GetDeposit())
                    {
                        Console.WriteLine("You cant withdraw, insuficient balance ");
                        isSuccessful = false;
                    }
                    else if (amount < theCustomer.GetDeposit())
                    {
                        var transaction = theCustomer._deposit -= amount;
                        Console.WriteLine($" Dear {theCustomer.GetFullName()}  Withdraw sucessful!,  Your new Balance is {theCustomer.GetDeposit()}");
                        isSuccessful = true;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid Credentials");
                    isSuccessful = false;
                }
            }
            return isSuccessful;
        } 

        public  Customer Register()
        {
            Console.WriteLine("Enter firstName");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your lastName");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Pin");
            int pin = int.Parse(Console.ReadLine());

            Customer customer = new Customer(firstName, lastName, pin);
            AddToFile(customer);
            CustomerList.Add(customer);
            Console.WriteLine($"Dear {customer.GetFullName()},you have sucessfully registered and your acctNo is {customer.GetAcctNo()}");
            
            return customer;
        }
    }
}
