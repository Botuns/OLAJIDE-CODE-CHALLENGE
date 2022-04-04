using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLAZE_BANK_APP
{
    public class Menu
    {
        public void ShowMainMenu()
        {
            bool continueApp = true;

            do
            {
                Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");
                Console.WriteLine("_-_-_-_-WELCOME TO BLAZE BANK_-_-_-_-_-_-_-_");
                Console.WriteLine("_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_-_");


                Console.WriteLine("1. Register");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3 WithDraw");
                Console.WriteLine("4. Transfer");
                Console.WriteLine("5.Update profile");
                Console.WriteLine("6. Exit");
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
                        customerManager.UpdateProfile();
                        ShowMainMenu();
                        break;
                    case 6:
                        return;
                    default:
                        break;
                }
            } while (continueApp);
        }
    }
}
