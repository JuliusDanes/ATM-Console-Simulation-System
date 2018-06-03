using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wokeh
{
    class MasterMenuUser
    {
        public static void User(int asd)
        {
            int NoRek = asd;
            int choice;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("============== M E N U  U S E R ==============");
            Console.WriteLine("=========     1. Check Balance      ==========");
            Console.WriteLine("=========     2. Transfer Cash      ==========");
            Console.WriteLine("=========     3. Cash Withdraw      ==========");
            Console.WriteLine("=========     4. Cash Deposit       ==========");
            Console.WriteLine("=========     5. Mutation           ==========");
            Console.WriteLine("=========     6. Change PIN         ==========");
            Console.WriteLine("=========     7. Exit               ==========");
            Console.WriteLine("==============================================\n");
            Console.WriteLine("== Choice Number 1 / 2 / 3 / 4 / 5 / 6 / 7  ==");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    Console.Clear();
                    ProgramUser.CheckBalance(NoRek);
                    Console.Clear();
                    MasterMenuUser.User(NoRek);
                    break;
                case 2:
                    Console.Clear();
                    ProgramUser.Transfer(NoRek);
                    Console.Clear();
                    MasterMenuUser.User(NoRek);
                    break;
                case 3:
                    Console.Clear();
                    ProgramUser.CashWithdraw(NoRek);
                    Console.Clear();
                    MasterMenuUser.User(NoRek);
                    break;
                case 4:
                    Console.Clear();
                    ProgramUser.CashDeposit(NoRek);
                    Console.Clear();
                    MasterMenuUser.User(NoRek);
                    break;
                case 5:
                    Console.Clear();
                    ProgramUser.Mutation(NoRek);
                    Console.Clear();
                    MasterMenuUser.User(NoRek);
                    break;
                case 6:
                    Console.Clear();
                    ProgramUser.ChangePIN(NoRek);
                    MasterMenuUser.User(NoRek);
                    break;
                case 7:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid Choice");
                    Console.ReadKey();
                    Console.Clear();
                    MasterMenuUser.User(NoRek);
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
