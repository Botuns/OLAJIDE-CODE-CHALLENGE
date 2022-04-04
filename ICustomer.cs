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
        public bool Deposit();
        public bool WithDraw();
        public bool Transfer();
        public void UpdateProfile();
    }
}
