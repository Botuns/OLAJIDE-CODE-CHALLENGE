using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAZE_BANK_APP
{
    class Transaction : ICustomer
    {
        public Transaction ChangePin => throw new NotImplementedException();

        public Customer Deposit()
        {
            throw new NotImplementedException();
        }

        public Customer Exit()
        {
            throw new NotImplementedException();
        }

        public Customer Register()
        {
            throw new NotImplementedException();
        }

        public Customer Transfer()
        {
            throw new NotImplementedException();
        }

        public Customer UpdateProfile()
        {
            throw new NotImplementedException();
        }

        public Customer WithDraw()
        {
            throw new NotImplementedException();
        }

        Customer ICustomer.ChangePin()
        {
            Customer customer = new Customer();
            Console.WriteLine($"Dear {customer.GetFullName()} , below are your transactions");
            Console.WriteLine($"Your current balance is {customer.GetDeposit()} ");
            Console.WriteLine($"Account number: {customer.GetAcctNo()}");
            Console.WriteLine($"Pin ****");
            return customer;
        }
    }
}
