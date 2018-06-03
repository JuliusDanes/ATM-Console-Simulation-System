using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Wokeh
{
    class MasterMenuAdmin
    {
        public static void Admin()
        {
            int choice;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("============== MASTER MENU ADMINISTRATOR ==============");
            Console.WriteLine("=====            1. Create User                   =====");
            Console.WriteLine("=======          2. Display All User            =======");
            Console.WriteLine("=====            3. Search User                   =====");
            Console.WriteLine("=========        4. Update User              ==========");
            Console.WriteLine("=========        5. Delete User              ==========");
            Console.WriteLine("=========        6. Exit                     ==========");
            Console.WriteLine("=======================================================\n");
            Console.WriteLine("======    Choice Number 1 / 2 / 3 / 4 / 5 / 6   =======");
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    ProgramAdmin.CreateUserData();
                    Console.Clear();
                    MasterMenuAdmin.Admin();
                    break;
                case 2:
                    ProgramAdmin.DisplayUserData();
                    Console.Clear();
                    MasterMenuAdmin.Admin();
                    break;
                case 3:
                    ProgramAdmin.SearchUserData();
                    Console.Clear();
                    MasterMenuAdmin.Admin();
                    break;
                case 4:
                    ProgramAdmin.UpdateUserData();
                    Console.Clear();
                    MasterMenuAdmin.Admin();
                    break;
                case 5:
                    ProgramAdmin.SearchDataUserForDelete();
                    Console.Clear();
                    MasterMenuAdmin.Admin();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nInvalid Choice!!");
                    Console.ReadKey();
                    Console.Clear();
                    MasterMenuAdmin.Admin();
                    break;
            }
            Console.ReadKey();
            Console.Clear();
        }
    }
}
