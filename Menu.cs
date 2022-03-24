using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAZE_BANK_APP
{
    public class Menu
    {
        CustomerManager cust = new CustomerManager();
        public void ShowMainMenu()
        {
            bool continueApp = true;

            do
            {
                Console.WriteLine("1. Register");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3 WithDraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5.Change Pin");
                Console.WriteLine("6.Update profile");
                Console.WriteLine("7. Exit");
                Customer customer = new Customer();
                CustomerManager customerManager = new CustomerManager();

               
                int option = int.Parse(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        customerManager.Register();
                      
                        ShowMainMenu();
                        break;
                    case 2:
                       customerManager.Deposit();
                        ShowMainMenu();  
                       break;
                     case 3:
                        customerManager.WithDraw();
                        ShowMainMenu();
                      break;
                    case 4:
                        customerManager.Transfer();
                        ShowMainMenu();
                        break;
                    case 5:
                        customerManager.ChangePin();
                        ShowMainMenu();
                        break;
                    case 6:
                        customerManager.UpdateProfile();
                        ShowMainMenu();
                        break;
                    case 7:
                        customerManager.Exit();
                        ShowMainMenu();
                        break;
                    default:
                        break;




                }
            } while (continueApp);

        }
    }
}
