using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAZE_BANK_APP
{
    class CustomerManager : ICustomer
    {
        Customer customer = new Customer();
        public static Customer[] _customers = new Customer[100];
   
        public static decimal _deposit = 0;
        public static Customer[] GetCustomers = new Customer[100];

        public CustomerManager()
        {
        }

        public Customer ChangePin()
        {
            Console.WriteLine("Enter your old pin");
            int old = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new pin");
            int neww = int.Parse(Console.ReadLine());
            Customer customer = new Customer();
            neww += customer.GetPin();
            Console.WriteLine("New pin sucessfully updated");
            return customer;
        }

        public Customer Deposit()
        {
            Console.WriteLine("Pls input your account number");
            string acctno = Console.ReadLine();
            if (acctno == GenerateAccountNo())
            {
                Console.WriteLine("Pls input your pin");
                int pin = int.Parse(Console.ReadLine());
                Customer customer = new Customer();





                if (customer.GetPin() == pin)
                {
                    Console.WriteLine("Enter the amount you want to deposit");
                    decimal amount = decimal.Parse(Console.ReadLine());

                    amount = customer.GetDeposit();
                    Console.WriteLine($"Dear {customer.GetFullName()} you have sucessfully deposited {customer.GetDeposit()} naira");

                }
            }
          //  else
          //  {
                Console.WriteLine("WRONG PIN!!!!");
           // }
            return customer;



        }

        public Customer Exit()
        {
            return customer;
        }

       

        
        public  string GenerateAccountNo()
        {
            String startWith = "10";
            Random generator = new Random();
            String r = generator.Next(0, 100000000).ToString("D6");
            String aAccounNumber = startWith + r;
            return aAccounNumber;




        }

        public Customer Transfer()
        {
            Console.WriteLine("input your pin");
            int pin = int.Parse(Console.ReadLine());
            Customer customer = new Customer();



           
            if (customer.GetPin() == pin)
            {
                Console.WriteLine("Enter the account you want to tranfer");
                decimal trans = decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter the amount");
                decimal amount = decimal.Parse (Console.ReadLine());
                if (amount > customer.GetDeposit())
                {
                    Console.WriteLine("insufficient fund");
                    if (amount < customer.GetDeposit())
                    {
                        Console.WriteLine("You will transfer with a deduction of 2%");

                        
                        Console.WriteLine($" Sucesssful transfer by {customer.GetFullName()}");
                        Console.WriteLine($"your current balance is {(customer.GetDeposit()- amount)} naira ");
                    }
                }
              else  if (customer.GetPin() != pin)
                {
                    Console.WriteLine("invalid pin");
                }

            }
            return customer;

        }

        public Customer UpdateProfile()
        {
            Console.WriteLine("1.Upate First name");
            Console.WriteLine("2. update Last Name");
            Console.WriteLine(" choose an option to update");
            int option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter new firstName");
                    string nmae = Console.ReadLine();
                    Customer customer = new Customer();
                    nmae = customer.GetFirstName();
                    Console.WriteLine("Sucessfully Updated");
                    break;
                case 2:
                    Console.WriteLine("Enter new lastName");
                    string last = Console.ReadLine();
                    customer = new Customer();
                    last = customer.GetLastName();
                    Console.WriteLine("Sucessfully Updated");
                    break;
                    default:
                    break;
            }
            return customer;
        }

        public Customer WithDraw()
        {
            Console.WriteLine("Pls enter your pin");
                int pin = int.Parse(Console.ReadLine());
            Customer customer = new Customer();
            if(customer.GetPin() != pin)
            {
                Console.WriteLine("WRONG PIN!!!!");
            }
            else
            {
                Console.WriteLine("Enter the amount you want to deposit");
                decimal amount = decimal.Parse(Console.ReadLine());
                if(amount > customer.GetDeposit())
                {
                    Console.WriteLine("You cant withdraw, insuficient balance ");

                }
                else if(amount < customer.GetDeposit())
                {
                    Console.WriteLine($" Dear {customer.GetFullName()}  Withdraw sucessful!,  acctBalance is{customer.GetDeposit()-amount} ");

                }
            }
            return customer;
        } 

        public  Customer Register()
        {
            Console.WriteLine("Enter firstName");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your lastName");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Pin");
            int pin = int.Parse(Console.ReadLine());


            Customer customer = new Customer(firstName, lastName, pin, _deposit);
            GetCustomers[(int)_deposit] = customer;
            _deposit++;
            Console.WriteLine($"Dear {customer.GetFullName()},you have sucessfully registered and your acctNo is {GenerateAccountNo()}");
            
            return customer;
        }


        Transaction ICustomer.ChangePin
        {
            get
            {
                Customer customer = new Customer();
                Console.WriteLine($"Dear {customer.GetFullName()} , below are your transactions");
                Console.WriteLine($"Your current balance is {customer.GetDeposit()} ");
                Console.WriteLine($"Account number: {customer.GetAcctNo()}");
                Console.WriteLine($"Pin ****");
                Customer customer1 = new Customer();
                return Customer(customer1);
            }
        }

        private Transaction Customer(Customer customer1)
        {
            throw new NotImplementedException();
        }
    }
}
