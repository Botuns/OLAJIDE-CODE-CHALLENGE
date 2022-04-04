using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAZE_BANK_APP
{
    public class Customer
    {
        private string _firstName;
        private string _lastName;
        private int _pin;
        public decimal _deposit;
        public string _acctNo;

        public Customer()
        {

        }

        public  Customer(string firstName, string lastName, int pin)
        {
            _firstName = firstName;
            _lastName = lastName;
            _pin = pin;
            _deposit = 0;
            _acctNo = GenerateAccountNo();
        }
        public  Customer(string firstName, string lastName, int pin, decimal deposit, string acctNo)
        {
            _firstName = firstName;
            _lastName = lastName;
            _pin = pin;
            _deposit = deposit;
            _acctNo = acctNo;
        }
        public static string GenerateAccountNo()
        {
            String startWith = "10";
            Random generator = new Random();
            String r = generator.Next(0, 100000000).ToString("D6");
            String aAccounNumber = startWith + r;
            return aAccounNumber;
        }
        public override string ToString()
        {
            return $"\t{_firstName}\t{_lastName}\t{_pin}\t{_deposit}\t{_acctNo}";
        }
        public static Customer ToCustomer (string str)
        {
            var customerStr = str.Split("\t");
            string firstName = customerStr[0];
            string lastName = customerStr[1];
            int pin = Convert.ToInt32(customerStr[2]);
            decimal deposit = Convert.ToDecimal(customerStr[3]);
            string acctNo = customerStr[4];
            Customer customer = new Customer(firstName, lastName, pin,deposit,acctNo);
            return customer;
        }
        public string GetAcctNo()
        {
            return _acctNo;
        }
        public string GetFirstName()
        {
            return _firstName;
        }
        public decimal GetDeposit()
        {
            return _deposit;
        }
        public string GetLastName()
        {
            return _lastName;
        }
        public void SetFirstName(string firstName)
        {
            _firstName = firstName;
        }
        public void SetLastName(string lastName)
        {
            _lastName = lastName;
            
        }
        public string GetFullName()
        {
            return _firstName + " " + _lastName;
        }
        public void Setpin(int pin)
        {
            _pin = pin;
        }
        public int GetPin()
        {
            return _pin;
        }
    }
}
