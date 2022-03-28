using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAZE_BANK_APP
{
    interface ICustomer
    {
        public Customer Register();
        public Transaction ChangePin { get; }

        public Customer Deposit();
        public Customer WithDraw();
        public Customer Transfer();
        public Customer ChangePin();
        public Customer UpdateProfile();
        public Customer Exit();
    }
}
