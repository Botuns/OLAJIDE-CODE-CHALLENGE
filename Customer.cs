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
        private string firstName;
        private string lastName;
        private int pin;
        private decimal deposit;

        public Customer()
        {

        }

        public Customer(string firstName, string lastName, int pin, decimal deposit, string acctNo)
        {
            _firstName = firstName;
            _lastName = lastName;
            _pin = pin;
            _deposit = deposit;
            _acctNo = acctNo;
        }

        public Customer(string firstName, string lastName, int pin, decimal deposit)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.pin = pin;
            this.deposit = deposit;
        }

        internal object GetAcctNo()
        {
            throw new NotImplementedException();
        }

        public string GetAcctNo(string acctNo)
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
        public void Register()
        {
            return;
        }

    }
}
