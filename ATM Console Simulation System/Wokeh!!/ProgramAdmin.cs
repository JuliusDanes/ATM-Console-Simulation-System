using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;

namespace Wokeh
{
    class ProgramAdmin
    {
        public static void CreateUserData()
        {
            string KTP = "", Name = "", Address = "", PlaceOfBirth = "", UserName = "", Password = "", Email = "", HandphoneN = "", Employment = "", Gender = "", AccountType = "";
            string NoKartu = "";
            Random rnd = new Random();
            Regex rgxstr = new Regex("^[a-zA-Z ]+$");
            Regex rgxint = new Regex("^[0-9]+$");
            Regex rgxmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");
            Regex rgxpass = new Regex("^[A-Za-z0-9]+$");
            int AccountN = 0;
            long Balance = 50000, PIN = 123456, FBalance = 50000;
            string choice = "n";
            while (choice == "n" || choice == "N")
            {
                Console.Clear();
                var dbUser = File.ReadAllLines("UserData.txt");

                bool i = true;
                while (i)
                {
                    AccountN = rnd.Next(10000000, 99999999);
                    foreach (string data in dbUser)
                    {

                        data.Split('#');
                        if (AccountN.Equals(data[12]))
                        {
                            i = true;
                            break;
                        }
                        else
                        {
                            i = false;
                            continue;
                        }
                    }
                }

                bool v = true;
                while (v)
                {
                    Console.Clear();
                    Console.WriteLine("Waiting for card swipe...");
                    NoKartu = Console.ReadLine();
                    foreach (string data in dbUser)
                    {
                        string[] ary = data.Split('#');
                        if (NoKartu.Equals(ary[16]))
                        {
                            v = true;
                            Console.WriteLine("Duplicate card detected");
                            Console.ReadKey();
                            break;

                        }
                        else if (!NoKartu.Equals(ary[16]))
                        {
                            v = false;
                        }
                    }
                }

                bool x = true;
                while (x)
                {
                    Console.Clear();
                    Console.WriteLine("Enter your Number of KTP :");
                    KTP = Console.ReadLine();
                    foreach (string data in dbUser)
                    {
                        string[] ary = data.Split('#');
                        if (KTP.Length == 0)
                        {
                            x = true;
                            Console.WriteLine("Your Number Of KTP is null, Please Enter Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (KTP.Length < 10)
                        {
                            x = true;
                            Console.WriteLine("Number of KTP Must 10 Digit, please Enter Again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                        }
                        else if (ary[0].Equals(KTP))
                        {
                            x = true;
                            Console.WriteLine("Nomor KTP already used, Please Enter Again");
                            Console.ReadKey();
                            break;
                        }
                        else if (rgxint.IsMatch(KTP))
                        {
                            x = false;
                        }
                        else
                        {
                            x = true;
                        }
                    }
                }

                bool k = true;
                while (k)
                {
                    Console.Write("Enter Your Name :\n");
                    Name = Console.ReadLine();
                    if (Name.Length == 0)
                    {
                        k = true;
                        Console.WriteLine("Your Name is Null, Please Enter Your Name Again ");
                    }
                    else if (rgxstr.IsMatch(Name))
                    {
                        k = false;
                    }
                    else
                    {
                        k = true;
                    }
                }

                bool b = true;
                while (b)
                {
                    Console.WriteLine("Enter Your Gender (M / F):");
                    Gender = Console.ReadLine();
                    switch (Gender)
                    {
                        case "M":
                            b = false;
                            break;
                        case "F":
                            b = false;
                            break;
                        default:
                            Console.WriteLine("Your Input not Valid, Please Enter Again :");
                            break;
                    }
                }

                bool m = true;
                while (m)
                {
                    Console.WriteLine("Enter Your Address :");
                    Address = Console.ReadLine();
                    if (Address.Length == 0)
                    {
                        m = true;
                        Console.WriteLine("Your Address is Null, Please Enter Your Address Again");
                    }
                    else
                    {
                        m = false;
                    }
                }

                bool n = true;
                while (n)
                {
                    Console.WriteLine("Enter Place of Birth :");
                    PlaceOfBirth = Console.ReadLine();
                    if (PlaceOfBirth.Length == 0)
                    {
                        n = true;
                        Console.WriteLine("Your Place of Birth is Null, Please Enter Again");
                    }
                    else if (rgxstr.IsMatch(PlaceOfBirth))
                    {
                        n = false;
                    }
                    else
                    {
                        n = true;
                    }
                }

                bool y = true;
                while (y)
                {
                    Console.WriteLine("Enter E-Mail :");
                    Email = Console.ReadLine();
                    foreach (string data in dbUser)
                    {
                        string[] ary = data.Split('#');
                        if (Email.Length == 0)
                        {
                            y = true;
                            Console.WriteLine("Your e-Mail is Null, Please Enter Again");
                            break;
                        }
                        else if (ary[5].Equals(Email))
                        {
                            y = true;
                            Console.WriteLine("E-Mail already used, Please Enter Again");
                            break;
                        }
                        else if (rgxmail.IsMatch(Email))
                        {
                            y = false;
                        }
                        else
                        {
                            y = true;
                        }
                    }
                }

                bool p = true;
                while (p)
                {
                    Console.WriteLine("Enter your Number of Phone :");
                    HandphoneN = Console.ReadLine();
                    foreach (string data in dbUser)
                    {
                        string[] ary = data.Split('#');
                        if (HandphoneN.Length == 0)
                        {
                            p = true;
                            Console.WriteLine("Your Number of Phone is Null, Please Enter Again");
                            break;
                        }
                        else if (ary[6].Equals(HandphoneN))
                        {
                            p = true;
                            Console.WriteLine("Number Phone already used, Please Enter Again");
                            break;
                        }
                        else if (rgxint.IsMatch(HandphoneN))
                        {
                            p = false;
                        }
                        else
                        {
                            p = true;
                        }
                    }
                }

                bool t = true;
                while (t)
                {
                    Console.WriteLine("Enter your Employment :");
                    Employment = Console.ReadLine();
                    if (Employment.Length == 0)
                    {
                        t = true;
                        Console.WriteLine("Your Employment is null, Please Enter Again :");
                    }
                    else if (rgxstr.IsMatch(Employment))
                    {
                        t = false;
                    }
                    else
                    {
                        t = true;
                    }
                }

                bool h = true;
                while (h)
                {
                    Console.WriteLine("Enter UserName :");
                    UserName = Console.ReadLine();
                    foreach (string data in dbUser)
                    {
                        string[] ary = data.Split('#');
                        if (UserName.Length == 0)
                        {
                            h = true;
                            Console.WriteLine("UserName is null, Please Enter Again :");
                            break;
                        }
                        else if (ary[8].Equals(UserName))
                        {
                            h = true;
                            Console.WriteLine("UserName already used");
                            break;
                        }
                        else if (rgxpass.IsMatch(UserName))
                        {
                            h = false;
                        }
                    }
                }

                bool w = true;
                while (w)
                {
                    Console.WriteLine("Enter Password :");
                    Password = Console.ReadLine();
                    if (Password.Length == 0)
                    {
                        w = true;
                        Console.WriteLine("Password is null, Please Enter Again :");
                    }
                    else if (rgxpass.IsMatch(Password))
                    {
                        w = false;
                    }
                    else
                    {
                        w = true;
                    }
                }

                bool q = true;
                while (q)
                {
                    Console.WriteLine("Enter Your Account Type (Silver / Gold / Premium):");
                    AccountType = Console.ReadLine();
                    switch (AccountType)
                    {
                        case "Silver":
                            q = false;
                            break;
                        case "Gold":
                            q = false;
                            break;
                        case "Premium":
                            q = false;
                            break;
                        default:
                            Console.WriteLine("Your Input not Valid, Please Enter Again :");
                            break;
                    }
                }
                Console.Clear();
                Console.WriteLine("=================================================================");
                Console.WriteLine("Number KTP\t:\t {0}", KTP);
                Console.WriteLine("Name\t\t:\t {0}", Name);
                Console.WriteLine("Gender\t\t:\t {0}", Gender);
                Console.WriteLine("Address\t\t:\t {0}", Address);
                Console.WriteLine("Place of Birth\t:\t {0}", PlaceOfBirth);
                Console.WriteLine("E-Mail\t\t:\t {0}", Email);
                Console.WriteLine("Handphone Number:\t {0}", HandphoneN);
                Console.WriteLine("Employment\t:\t {0}", Employment);
                Console.WriteLine("\nUserName\t:\t {0}", UserName);
                Console.WriteLine("Password\t:\t {0}", Password);
                Console.WriteLine("\nAccount Type\t:\t {0}", AccountType);
                Console.WriteLine("Account Number\t:\t {0}", AccountN);
                Console.WriteLine("=================================================================\n\n");
                Console.WriteLine("Are data above correct (Y/N)");
                choice = Console.ReadLine().ToLower();
                Console.Clear();    
            }
            FileStream fs = new FileStream("UserData.txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);

            sw.WriteLine(KTP + "#" + Name + "#" + Gender + "#" + Address + "#" + PlaceOfBirth + "#" + Email + "#" + HandphoneN +
            "#" + Employment + "#" + UserName + "#" + Password + "#" + AccountType + "#" + AccountN + "#" + PIN + "#" + Balance + "#" + FBalance + "#" + "user" + "#" + NoKartu);
            sw.Flush();
            sw.Close();
            fs.Close();
            Console.WriteLine("Input another new data (Y/N) :");
            choice = Console.ReadLine();
            Console.Clear();
        }

        public static void DisplayUserData()
        {
            Console.Clear();
            FileStream fs = new FileStream( path + "UserData.txt", FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs);
            string data = sr.ReadLine();
            while (data != null)
            {
                string[] ary = data.Split('#');
                Console.WriteLine("=================================================================");
                Console.WriteLine("Number KTP\t:\t {0}", ary[0]);
                Console.WriteLine("Name\t\t:\t {0}", ary[1]);
                Console.WriteLine("Gender\t\t:\t {0}", ary[2]);
                Console.WriteLine("Address\t\t:\t {0}", ary[3]);
                Console.WriteLine("Place of Birth\t:\t {0}", ary[4]);
                Console.WriteLine("E-Mail\t\t:\t {0}", ary[5]);
                Console.WriteLine("Handphone Number:\t {0}", ary[6]);
                Console.WriteLine("Employment\t:\t {0}", ary[7]);
                Console.WriteLine("\nUserName\t:\t {0}", ary[8]);
                Console.WriteLine("Password\t:\t {0}", ary[9]);
                Console.WriteLine("\nAccount Type\t:\t {0}", ary[10]);
                Console.WriteLine("Account Number\t:\t {0}", ary[11]);
                Console.WriteLine("PIN\t\t:\t {0}", ary[12]);
                Console.WriteLine("\nBalance\t\t:\t {0}", ary[13]);
                Console.WriteLine("As\t\t:\t {0}", ary[15]);
                Console.WriteLine("=================================================================\n\n");
                data = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            Console.ReadKey();
            Console.Clear();
        }
 
        static string path = (@"" + Environment.CurrentDirectory + "\\");
        public static void SearchUserData()
        {
            Console.Clear();
            string keyword;
            var ary = new object[20];
            Console.WriteLine("Enter Keyword (KTP) : ");
            keyword = Console.ReadLine();
            foreach (string data in File.ReadLines(path+"UserData.txt"))
            {
                ary = data.Split('#');
                if (keyword.Equals(Convert.ToString(ary[0])))
                {
              
                    Console.WriteLine("===================     DATA IS AVALIABLE     ===================");
                    Console.WriteLine("Number KTP\t:\t {0}", ary[0]);
                    Console.WriteLine("Name\t\t:\t {0}", ary[1]);
                    Console.WriteLine("Gender\t\t:\t {0}", ary[2]);
                    Console.WriteLine("Address\t\t:\t {0}", ary[3]);
                    Console.WriteLine("Place of Birth\t:\t {0}", ary[4]);
                    Console.WriteLine("E-Mail\t\t:\t {0}", ary[5]);
                    Console.WriteLine("Handphone Number:\t {0}", ary[6]);
                    Console.WriteLine("Employment\t:\t {0}", ary[7]);
                    Console.WriteLine("\nUserName\t:\t {0}", ary[8]);
                    Console.WriteLine("Password\t:\t {0}", ary[9]);
                    Console.WriteLine("\nAccount Type\t:\t {0}", ary[10]);
                    Console.WriteLine("Account Number\t:\t {0}", ary[11]);
                    Console.WriteLine("PIN\t\t:\t {0}", ary[12]);
                    Console.WriteLine("\nBalance\t\t:\t {0}", ary[13]);
                    Console.WriteLine("As\t\t:\t {0}", ary[15]);
                    Console.WriteLine("Number Card\t:\t {0}", ary[16]);
                    Console.WriteLine("=================================================================\n\n");
                    Console.WriteLine("Press any key to continue");
                    Console.ReadKey();
                    break;
                }
            }
        }

        public static void UpdateUserData()
        {
            Console.Clear();
            StringBuilder newFile = new StringBuilder();
            var dUser = File.ReadAllLines("UserData.txt");
            string keyword;
            int choice;
            Regex rgxstr = new Regex("^[a-zA-Z ]+$");
            Regex rgxint = new Regex("^[0-9]+$");
            Regex rgxmail = new Regex(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$");
            Regex rgxpass = new Regex("^[A-Za-z0-9]+$");
            bool g = true;
            Console.WriteLine("Enter Keyword ( KTP ):");
            keyword = Console.ReadLine();
            if (keyword.Length == 0)
            {
                Console.WriteLine("Keyword is null, please enter again");
                Console.ReadLine();
                ProgramAdmin.UpdateUserData();
            }
            foreach (string data in dUser)
            {
                if (data.Contains(keyword) && rgxint.IsMatch(keyword))
                {
                    var result = data.Split('#');
                    string temp = "";
                    string KTP = "", Name = "", Address = "", PlaceOfBirth = "", UserName = "", Password = "", Email = "",
                           HandphoneN = "", AccountType = "", Employment = "", Gender = "";
                    Console.Clear();
                    Console.WriteLine("===================     DATA IS AVALIABLE     ===================");
                    Console.WriteLine("Number KTP\t:\t {0}", result[0]);
                    Console.WriteLine("Name\t\t:\t {0}", result[1]);
                    Console.WriteLine("Gender\t\t:\t {0}", result[2]);
                    Console.WriteLine("Address\t\t:\t {0}", result[3]);
                    Console.WriteLine("Place of Birth\t:\t {0}", result[4]);
                    Console.WriteLine("E-Mail\t\t:\t {0}", result[5]);
                    Console.WriteLine("Handphone Number:\t {0}", result[6]);
                    Console.WriteLine("Employment\t:\t {0}", result[7]);
                    Console.WriteLine("\nUserName\t:\t {0}", result[8]);
                    Console.WriteLine("Password\t:\t {0}", result[9]);
                    Console.WriteLine("\nAccount Type\t:\t {0}", result[10]);
                    Console.WriteLine("Account Number\t:\t {0}", result[11]);
                    Console.WriteLine("PIN\t\t:\t {0}", result[12]);
                    Console.WriteLine("\nBalance\t\t:\t {0}", result[13]);
                    Console.WriteLine("As\t\t:\t {0}", result[15]);
                    Console.WriteLine("=================================================================\n");
                    Console.WriteLine("===============      S E L E C T  N U M B E R     ===============");
                    Console.WriteLine("1. Update Number KTP");
                    Console.WriteLine("2. Update Name");
                    Console.WriteLine("3. Update Gender");
                    Console.WriteLine("4. Update Address");
                    Console.WriteLine("5. Update Place of Birth");
                    Console.WriteLine("6. Update e-Mail");
                    Console.WriteLine("7. Update Phone Number");
                    Console.WriteLine("8. Update Employment");
                    Console.WriteLine("9. Update User Name");
                    Console.WriteLine("10. Update Password");
                    Console.WriteLine("11. Update Account Type");
                    Console.WriteLine("12. Back to Menu");
                    Console.WriteLine(" Enter Number : ");
                    choice = int.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[0]);
                                Console.WriteLine("Enter New Number : ");
                                KTP = Console.ReadLine();
                                foreach (string data1 in dUser)
                                {
                                    string[] ary = data.Split('#');
                                    if (KTP.Length == 0)
                                    {
                                        g = true;
                                        Console.WriteLine("Your Number Of KTP is null, Please Enter Again");
                                    }
                                    else if (KTP.Length < 10)
                                    {
                                        g = true;
                                        Console.WriteLine("Number of KTP Must 10 Digit, please Enter Again");
                                    }
                                    else if (ary[0].Equals(KTP))
                                    {
                                        g = true;
                                        Console.WriteLine("Nomor KTP already used, Please Enter Again");
                                    }
                                    else if (rgxint.IsMatch(KTP))
                                    {
                                        g = false;
                                    }
                                    else
                                    {
                                        g = true;
                                    }
                                }
                            }
                            temp = data.Replace(result[0], KTP);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New Number KTP : {0}", KTP);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 2:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[1]);
                                Console.WriteLine("Enter New Name : ");
                                Name = Console.ReadLine();
                                if (Name.Length == 0)
                                {
                                    g = true;
                                    Console.WriteLine("Your Name is Null, Please Enter Your Name Again ");
                                }
                                else if (rgxstr.IsMatch(Name))
                                {
                                    g = false;
                                }
                                else
                                {
                                    g = true;
                                    Console.WriteLine("Your name is not valid");
                                }
                            }
                            temp = data.Replace(result[1], Name);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New Name : {0}", Name);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 3:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[2]);
                                Console.WriteLine("Enter New Gender ( M / F ) : ");
                                Gender = Console.ReadLine();
                                switch (Gender)
                                {
                                    case "M":
                                        g = false;
                                        break;
                                    case "F":
                                        g = false;
                                        break;
                                    default:
                                        Console.WriteLine("Your Input not Valid, Please Enter Again :");
                                        break;
                                }
                            }
                            temp = data.Replace(result[2], Gender);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New Gender : {0}", Gender);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 4:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[3]);
                                Console.WriteLine("Enter New Address : ");
                                Address = Console.ReadLine();
                                if (Address.Length == 0)
                                {
                                    g = true;
                                    Console.WriteLine("Your Address is Null, Please Enter Your Address Again");
                                }
                                else
                                {
                                    g = false;
                                }
                            }
                            temp = data.Replace(result[3], Address);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New Address : {0}", Address);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 5:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[4]);
                                Console.WriteLine("Enter New Place Of Birth : ");
                                PlaceOfBirth = Console.ReadLine();
                                if (PlaceOfBirth.Length == 0)
                                {
                                    g = true;
                                    Console.WriteLine("Your Place of Birth is Null, Please Enter Again");
                                }
                                else if (rgxstr.IsMatch(PlaceOfBirth))
                                {
                                    g = false;
                                }
                                else
                                {
                                    g = true;
                                    Console.WriteLine("Your Place of Birth is not valid");
                                }
                            }
                            temp = data.Replace(result[4], PlaceOfBirth);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New Place Of Birth : {0}", PlaceOfBirth);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 6:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[5]);
                                Console.WriteLine("Enter New e-Mail : ");
                                Email = Console.ReadLine();
                                foreach (string data1 in dUser)
                                {
                                    string[] ary = data.Split('#');
                                    if (Email.Length == 0)
                                    {
                                        g = true;
                                        Console.WriteLine("Your e-Mail is Null, Please Enter Again");
                                        break;
                                    }
                                    else if (ary[5].Equals(Email))
                                    {
                                        g = true;
                                        Console.WriteLine("E-Mail already used, Please Enter Again");
                                    }
                                    else if (rgxmail.IsMatch(Email))
                                    {
                                        g = false;
                                    }
                                    else
                                    {
                                        g = true;
                                        Console.WriteLine("Your e-Mail is not valid");
                                    }
                                }
                            }

                            temp = data.Replace(result[5], Email);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New e-Mail : {0}", Email);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 7:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[6]);
                                Console.WriteLine("Enter New Number Phone : ");
                                HandphoneN = Console.ReadLine();
                                foreach (string data1 in dUser)
                                {
                                    string[] ary = data.Split('#');
                                    if (HandphoneN.Length == 0)
                                    {
                                        g = true;
                                        Console.WriteLine("Your Number of Phone is Null, Please Enter Again");
                                        break;
                                    }
                                    else if (ary[6].Equals(HandphoneN))
                                    {
                                        g = true;
                                        Console.WriteLine("Number Phone already used, Please Enter Again");
                                    }
                                    else if (rgxint.IsMatch(HandphoneN))
                                    {
                                        g = false;
                                    }
                                    else
                                    {
                                        g = true;
                                        Console.WriteLine("Your Phone Number is not valid");
                                    }
                                }
                            }
                            temp = data.Replace(result[6], HandphoneN);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New Number Phone : {0}", HandphoneN);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 8:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[7]);
                                Console.WriteLine("Enter New Employment : ");
                                Employment = Console.ReadLine();
                                if (Employment.Length == 0)
                                {
                                    g = true;
                                    Console.WriteLine("Your Employment is null, Please Enter Again :");
                                }
                                else if (rgxstr.IsMatch(Employment))
                                {
                                    g = false;
                                }
                                else
                                {
                                    g = true;
                                    Console.WriteLine("Your Employment is not valid");
                                }

                            }
                            temp = data.Replace(result[7], Employment);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New Employment : {0}", Employment);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 9:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[8]);
                                Console.WriteLine("Enter New User Name : ");
                                UserName = Console.ReadLine();
                                foreach (string data1 in dUser)
                                {
                                    string[] ary = data1.Split('#');
                                    if (UserName.Length == 0)
                                    {
                                        g = true;
                                        Console.WriteLine("UserName is null, Please Enter Again :");
                                        break;
                                    }
                                    else if (ary[8].Equals(UserName))
                                    {
                                        g = true;
                                        Console.WriteLine("UserName already used");
                                    }
                                    else if (rgxpass.IsMatch(UserName))
                                    {
                                        g = false;
                                    }
                                    else
                                    {
                                        g = true;
                                        Console.WriteLine("Your UserName is not valid");
                                    }
                                }
                            }
                            temp = data.Replace(result[8], UserName);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New User Name : {0}", UserName);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 10:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[9]);
                                Console.WriteLine("Enter New Password : ");
                                Password = Console.ReadLine();
                                if (Password.Length == 0)
                                {
                                    g = true;
                                    Console.WriteLine("Password is null, Please Enter Again :");
                                }
                                else if (rgxpass.IsMatch(Password))
                                {
                                    g = false;
                                }
                                else
                                {
                                    g = true;
                                    Console.WriteLine("Your Password is not valid");
                                }
                            }
                            temp = data.Replace(result[9], Password);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New Password : {0}", Password);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 11:
                            while (g)
                            {
                                Console.WriteLine("Old Data : {0}", result[10]);
                                Console.WriteLine("Enter New Account Type ( Silver / Gold / Premium ) : ");
                                AccountType = Console.ReadLine();
                                switch (AccountType)
                                {
                                    case "Silver":
                                        g = false;
                                        break;
                                    case "Gold":
                                        g = false;
                                        break;
                                    case "Premium":
                                        g = false;
                                        break;
                                    default:
                                        Console.WriteLine("Your Input not Valid, Please Enter Again :");
                                        break;
                                }
                            }
                            temp = data.Replace(result[10], AccountType);
                            newFile.Append(temp + "\r\n");
                            Console.WriteLine("New Type Account : {0}", AccountType);
                            Console.ReadKey();
                            Console.Clear();
                            continue;
                        case 12:
                            MasterMenuAdmin.Admin();
                            break;
                        default:
                            Console.WriteLine("Invalid Number");
                            Console.ReadKey();
                            break;
                    }
                }
                newFile.Append(data + "\r\n");
            }
            File.WriteAllText(@"UserData.txt", newFile.ToString());
        }

        public static void DeleteLines(string strLineToDelete)
        {
            string strSearchText = strLineToDelete;
            string strOldText;
            string a = "";
            StreamReader sr = File.OpenText("UserData.txt");
            while ((strOldText = sr.ReadLine()) != null)
            {
                if (!strOldText.Contains(strSearchText))
                {
                    a += strOldText + Environment.NewLine;
                }
            }
            sr.Close();
            File.WriteAllText("UserData.txt", a);
        }

        public static void SearchDataUserForDelete()
        {
            Console.Clear();
            var dbUser = File.ReadAllLines("UserData.txt");
            string keyword;
            Regex rgxint = new Regex("^[0-9]+$");
            Console.WriteLine("Enter Keyword (KTP) : ");
            keyword = Console.ReadLine();
            foreach (string data in dbUser)
            {
                if (data.Contains(keyword) && rgxint.IsMatch(keyword))
                {
                    string[] ary = data.Split('#');
                    Console.WriteLine("===================     DATA IS AVALIABLE     ===================");
                    Console.WriteLine("Number KTP\t:\t {0}", ary[0]);
                    Console.WriteLine("Name\t\t:\t {0}", ary[1]);
                    Console.WriteLine("Gender\t\t:\t {0}", ary[2]);
                    Console.WriteLine("Address\t\t:\t {0}", ary[3]);
                    Console.WriteLine("Place of Birth\t:\t {0}", ary[4]);
                    Console.WriteLine("E-Mail\t\t:\t {0}", ary[5]);
                    Console.WriteLine("Handphone Number:\t {0}", ary[6]);
                    Console.WriteLine("Employment\t:\t {0}", ary[7]);
                    Console.WriteLine("\nUserName\t:\t {0}", ary[8]);
                    Console.WriteLine("Password\t:\t {0}", ary[9]);
                    Console.WriteLine("\nAccount Type\t:\t {0}", ary[10]);
                    Console.WriteLine("Account Number\t:\t {0}", ary[11]);
                    Console.WriteLine("PIN\t\t:\t {0}", ary[12]);
                    Console.WriteLine("\nBalance\t\t:\t {0}", ary[13]);
                    Console.WriteLine("As\t\t:\t {0}", ary[15]);
                    Console.WriteLine("=================================================================\n\n");
                    string choice;
                    Console.WriteLine("Are you sure you want to delete this User? (Y/N)");
                    choice = Console.ReadLine();
                    if ((choice == "Y") || (choice == "y"))
                    {
                        ProgramAdmin.DeleteLines(keyword);
                    }
                    else
                    {
                        Console.WriteLine("Press any key to continue");
                        Console.Clear();
                        MasterMenuAdmin.Admin();
                    }
                }
            }
        }
    }
}