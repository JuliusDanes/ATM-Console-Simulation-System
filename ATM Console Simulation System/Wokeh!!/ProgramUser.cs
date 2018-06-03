using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using ConsoleTables;
using System.Data;
using System.Threading;
using System.Text.RegularExpressions;


namespace Wokeh
{
    class ProgramUser
    {
        static string path = @"D:\Wokeh!! - fix banget\Wokeh!!\bin\Debug\";
        private static string TID;

        public static void GetTID(int b)
        {
            int NoRek = b;
            int count = 1;
            if (File.Exists(path + "mutasi-"+NoRek+".txt"))
            {
                var dbTransaction = File.ReadAllLines(path + "mutasi-" + NoRek + ".txt");
                Array.Reverse(dbTransaction);
                foreach (string line in dbTransaction)
                {
                    var data = line.Split(','); 

                        count = int.Parse(data[1].Substring(data[1].Length - 4)) + 1;
                        break;
                }
            }
            if (count < 10)
            {
                TID = "TRX000" + Convert.ToString(count);
            }
            else if (count < 100)
            {
                TID = "TRX00" + Convert.ToString(count);
            }
            else if (count < 1000)
            {
                TID = "TRX0" + Convert.ToString(count);
            }
            else if (count < 10000)
            {
                TID = "TRX" + Convert.ToString(count);
            }
            else
            {
                TID = "TID Limited";
                TID = null;
            }
        }
        public static void CashDeposit(int a)
        {
            Console.Clear();
            int NoRek = a;
            var dbUserData = File.ReadAllLines(path + "UserData.txt");
            int packet;
            double nominal = 0;
            bool chk;

            do
            {
                chk = false;
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("\t//\t\t\t\t SELECT THE NOMIMAL OF PACKAGE DEPOSITS \t\t\t\t//");
                Console.WriteLine("\t//\t\t\t\t\t\t\t\t\t\t\t\t\t//");
                Console.WriteLine("\t//\t\t\t 1 <= 50.000 \t\t\t 6 <= 750.000   \t\t\t\t//");
                Console.WriteLine("\t//\t\t\t 2 <= 100.000 \t\t\t 7 <= 1.000.000 \t\t\t\t//");
                Console.WriteLine("\t//\t\t\t 3 <= 150.000 \t\t\t 8 <= 1.500.000 \t\t\t\t//");
                Console.WriteLine("\t//\t\t\t 4 <= 250.000 \t\t\t 9 <= 2.000.000 \t\t\t\t//");
                Console.WriteLine("\t//\t\t\t 5 <= 500.000 \t\t\t 10 <= Adjust Nominal\t\t\t\t//");
                Console.WriteLine("\t//\t\t\t              \t\t\t 11 <= Back To Menu\t\t\t\t//");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                packet = Convert.ToInt32(Console.ReadLine());
                switch (packet)
                {
                    default:
                        Console.WriteLine("Please input 1-10");
                        Console.ReadKey();
                        Console.Clear();
                        CashDeposit(NoRek);
                        break;
                    case 1:
                        nominal = 50000;
                        break;
                    case 2:
                        nominal = 100000;
                        break;
                    case 3:
                        nominal = 150000;
                        break;
                    case 4:
                        nominal = 250000;
                        break;
                    case 5:
                        nominal = 500000;
                        break;
                    case 6:
                        nominal = 750000;
                        break;
                    case 7:
                        nominal = 1000000;
                        break;
                    case 8:
                        nominal = 1500000;
                        break;
                    case 9:
                        nominal = 2000000;
                        break;
                    case 10:
                        do
                        {
                            Console.WriteLine("Please Enter The Nominal");
                            nominal = Convert.ToDouble(Console.ReadLine());
                            chk = false;
                            if (((nominal % 50000) != 0) || (nominal > 5000000) || nominal < 50000)
                            {
                                Console.WriteLine("Please enter nominal multiples of Rp50.000 AND minimum nominal is Rp50.000 AND maximum nominal is Rp5.000.000");
                                Console.ReadKey();
                                chk = true;
                            }
                        } while (chk);
                        break;
                    case 11:
                        MasterMenuUser.User(NoRek);
                        Console.Clear();
                        break;

                }
                ScanMoney(nominal,NoRek);
            } while (chk);
        }
        public static void CashWithdraw(int b)
        {
            int NoRek = b;
            Console.Clear();
            GetTID(NoRek);
            StringBuilder newfile = new StringBuilder();
            var dbUserData = File.ReadAllLines(path + "UserData.txt");
            int packet;
            double nominal = 0;
            double remain = 0;
            bool chk;
            do
            {
                chk = false;
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                Console.WriteLine("\t//\t\t\t\t   SELECT THE NUMBER OF CASH PACKETS \t\t\t\t\t//");
                Console.WriteLine("\t//\t\t\t\t\t\t\t\t\t\t\t\t\t//");
                Console.WriteLine("\t//\t\t\t 1 <= 50.000 \t\t\t 6 <= 750.000 \t\t\t\t\t//");
                Console.WriteLine("\t//\t\t\t 2 <= 100.000 \t\t\t 7 <= 1.000.000 \t\t\t\t//");
                Console.WriteLine("\t//\t\t\t 3 <= 150.000 \t\t\t 8 <= 1.500.000 \t\t\t\t//");
                Console.WriteLine("\t//\t\t\t 4 <= 250.000 \t\t\t 9 <= 2.000.000 \t\t\t\t//");
                Console.WriteLine("\t//\t\t\t 5 <= 500.000 \t\t\t 10 <= Random\t\t\t\t\t//");
                Console.WriteLine("\t//\t\t\t              \t\t\t 11 <= Back To Menu\t\t\t\t//");
                Console.WriteLine("////////////////////////////////////////////////////////////////////////////////////////////////////////////////////");
                packet = Convert.ToInt32(Console.ReadLine());
                switch (packet)
                {
                    default:
                        Console.WriteLine("Please input 1-10");
                        Console.ReadKey();
                        Console.Clear();
                        CashWithdraw(NoRek);
                        break;
                    case 1:
                        nominal = 50000;
                        break;
                    case 2:
                        nominal = 100000;
                        break;
                    case 3:
                        nominal = 150000;
                        break;
                    case 4:
                        nominal = 250000;
                        break;
                    case 5:
                        nominal = 500000;
                        break;
                    case 6:
                        nominal = 750000;
                        break;
                    case 7:
                        nominal = 1000000;
                        break;
                    case 8:
                        nominal = 1500000;
                        break;
                    case 9:
                        nominal = 2000000;
                        break;
                    case 10:
                        do
                        {
                            Console.WriteLine("Please Enter The Nominal");
                            nominal = Convert.ToDouble(Console.ReadLine());
                            chk = false;
                            if (((nominal % 50000) != 0) || (nominal > 5000000) || (nominal < 50000))
                            {
                                Console.WriteLine("Please enter nominal multiples of Rp50.000 AND minimum nominal is Rp50.000 AND maximum nominal is Rp5.000.000");
                                Console.ReadKey();
                                chk = true;
                            }
                            foreach (string line in dbUserData)
                            {
                                var data = line.Split('#');
                                if (long.Parse(data[11]).Equals(NoRek))
                                {
                                    remain = Convert.ToDouble(data[13]) - nominal;
                                    if (remain < Convert.ToDouble(data[14]))
                                    {
                                        Console.WriteLine("Your saldo is Rp{0} \nPlease Leave Rp{1} balance", data[13], data[14]);
                                        Console.ReadKey();
                                        chk = true;
                                        break;
                                    }
                                }
                            }
                        } while (chk);
                        break;
                    case 11:
                        MasterMenuUser.User(NoRek);
                        Console.Clear();
                        break;
                }
                foreach (string line in dbUserData)
                {
                    var data = line.Split('#');
                    string temp = "";
                    if (long.Parse(data[11]).Equals(NoRek))
                    {
                        remain = Convert.ToDouble(data[13]) - nominal;
                        if (remain < Convert.ToDouble(data[14]))
                        {
                            Console.WriteLine("Your saldo is Rp{0} \nPlease Leave Rp{1} balance", data[13], data[14]);
                            Console.ReadKey();
                            chk = true;
                            CashWithdraw(NoRek);
                            break;
                        }
                        else
                        {
                            temp = line.Replace(Convert.ToString(data[13]), Convert.ToString(remain));
                            newfile.Append(temp + "\r\n");
                            continue;
                        }
                    }
                    newfile.Append(line + "\r\n");
                }
                File.WriteAllText(@"UserData.txt", newfile.ToString());
                FileStream fs = new FileStream(path + "mutasi-" + NoRek + ".txt.", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs);

                sw.WriteLine(DateTime.Now + "," + TID + "," + NoRek + "," + NoRek +"," + "C" + "," + nominal + "," + remain + "," + "Cash Withdraw");
                sw.Flush();
                sw.Close();
                fs.Close();
            } while (chk);
            Console.Clear();
            Console.WriteLine("\n\t\t\t\t\t~~~~~~~~  Transaction Success  ~~~~~~~~");
            Console.WriteLine("\t\t\t\t\t~~~~~~~~                       ~~~~~~~~");
            Console.WriteLine("\t\t\t\t\t~~~~~~~~ Please Take The Money ~~~~~~~~");
            Console.ReadKey();
        }

        private static void ScanMoney(double nominals,int c)
        {
            Console.Clear();
            int NoRek = c;
            GetTID(NoRek);
            StringBuilder newfile = new StringBuilder();
            FileStream fs = new FileStream(path + "mutasi-"+NoRek+".txt", FileMode.Append, FileAccess.Write);
            StreamWriter sw = new StreamWriter(fs);
            var dbUserData = File.ReadAllLines(path + "UserData.txt");
            var dbMoneyData = File.ReadAllLines(path + "MoneyData.txt");
            dynamic[] MID = new dynamic[1000];
            MID[0] = "0003456596";
            MID[1] = "0003452961";
            //string InpMID = "MD5E"; /*When using RFID*/
            double SnMoney = 0, remain = 0, NewSaldo = 0;
            bool chk, chkCD = true;
            int j = 0;

            do
            {
                chk = false;
                while (chkCD)
                {
                    for (int i = j; i < MID.GetLength(0); i++)
                    {
                        Console.Clear();
                        Console.WriteLine("The amount of money you input Rp{0}", SnMoney);
                        bool GotKey = false;
                        DateTime start = DateTime.Now;
                        string countdown = "";
                        int k = 5;
                        while (((DateTime.Now - start).TotalSeconds < 5) && (SnMoney < nominals))
                        {
                            countdown = String.Format("Waiting for input for {0} seconds...", k);
                            Console.Write(countdown);
                            Thread.Sleep(1000);
                            for (Int32 l = 0; l < countdown.Length; l++)
                            {
                                Console.Write("\b \b"); // backspace - space - backspace
                            }
                            if ((Console.KeyAvailable) == true)
                            {
                                GotKey = true;
                                break;
                            }
                            k--;
                            //Console.WriteLine((DateTime.Now - start).TotalSeconds);
                            
                        }

                        if (GotKey)
                        {
                            chkCD = true;
                            string InpMID="";
                            Console.WriteLine("Waiting for card swipe...");
                            if (true)
                            {
                                InpMID = Console.ReadLine();
                            }
                            MID[i] = InpMID; /*When using RFID*/
                            //MID[i] = Console.ReadLine(); /*When not using RFID*/
                            foreach (string line in dbMoneyData)
                            {
                                var data = line.Split('*');
                                if (data[0].Equals(Convert.ToString(MID[i])))
                                {
                                    SnMoney += Convert.ToDouble(data[1]);
                        
                                    //Console.WriteLine("The amount of money you input {0}", SnMoney);
                                }
                            }
                            j = i + 1;
                        }
                        
                        else
                        {
                            if(SnMoney >= nominals)
                            {
                                //Console.WriteLine("The amount of money you input {0}", SnMoney);
                                Console.WriteLine("Succes please any key to continue");
                                Console.ReadKey();
                            }
                            Console.WriteLine("Timed out");
                            chkCD = false;
                            break;
                        }
                    }
                }
                

                if (SnMoney < nominals)
                {
                    remain = nominals - SnMoney;
                    Console.WriteLine("the money you input is still less Rp{0}, please input the lack of money.", remain);
                    Console.ReadKey();
                    chk = true;
                    chkCD = true;
                }
                else
                {
                    if (SnMoney > nominals)
                    {
                        remain = SnMoney - nominals;
                        Console.WriteLine("Money you input excess Rp{0}, please take the money.", remain);
                        Console.ReadKey();
                    }
                    foreach (string line in dbUserData)
                    {
                        var data = line.Split('#');
                        string temp = "";
                        if (long.Parse(data[11]).Equals(NoRek))
                        {
                            NewSaldo = Convert.ToDouble(data[13]) + nominals;
                            temp = line.Replace(data[13], Convert.ToString(NewSaldo));
                            newfile.Append(temp + "\r\n");
                            continue;

                        }
                        newfile.Append(line + "\r\n");
                    }
                    File.WriteAllText(@"UserData.txt", newfile.ToString());

                    sw.WriteLine(DateTime.Now + "," + TID + "," + NoRek + "," + NoRek + "," + "D" + "," + nominals + "," + NewSaldo + "," + "Cash Deposit");
                    sw.Flush();
                    sw.Close();
                    fs.Close();

                    Console.Clear();
                    Console.WriteLine("\n\t\t\t\t\t~~~~~~~~  Transaction Success  ~~~~~~~~");
                    Console.WriteLine("\t\t\t\t\t~~~~~~~~                       ~~~~~~~~");
                    Console.WriteLine("\t\t\t\t\t~~~~~~~~    Cash Deposit       ~~~~~~~~");
                    Console.ReadKey();
                }
            } while (chk);

        }

        public static void Mutation(int asd)    
        {
            int NoRek = asd;
            Console.Clear();
            bool chk = false;
            Random rnd = new Random();
            int choice = 0, diff = 0;
            DateTime now = System.DateTime.Now;
            DateTime dateF = System.DateTime.Now;
            DateTime dateT = System.DateTime.Now;

            Console.WriteLine("\n\t\t\t\t\t~~~~~~~~     Mutation       ~~~~~~~~");
            Console.WriteLine("\t\t\t\t\t~~~~~~~~                    ~~~~~~~~");
            Console.WriteLine("\t\t\t\t\t~~~~~~~~  1 <= Last 30 days ~~~~~~~~");
            Console.WriteLine("\t\t\t\t\t~~~~~~~~  2 <= Last 7 days  ~~~~~~~~");
            Console.WriteLine("\t\t\t\t\t~~~~~~~~  3 <= Last today  ~~~~~~~~");
            Console.WriteLine("\t\t\t\t\t~~~~~~~~  4 <= Adjust date  ~~~~~~~~");
            Console.WriteLine("\t\t\t\t\t~~~~~~~~  5 <= Back To Menu  ~~~~~~~~");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                default:
                    Console.WriteLine("Please input 1-4");
                    Console.ReadKey();
                    Console.Clear();
                    Mutation(NoRek);
                    break;
                case 1:
                    dateF = Convert.ToDateTime((now.AddDays(diff = -30)));
                    break;
                case 2:
                    dateF = Convert.ToDateTime((now.AddDays(diff = -7)));
                    break;
                case 3:
                    dateF = Convert.ToDateTime((now.AddDays(diff = -1)));
                    break;
                case 4:
                    do
                    {
                        try
                        {
                            Console.Clear();
                            Console.WriteLine("Enter date form in the format dd-mm-yyyy");
                            Console.WriteLine("Example 02 March 2018 = 02-04-2018");
                            dateF = DateTime.Parse(Console.ReadLine());
                            Console.WriteLine("Enter date to in the format dd-mm-yyyy");
                            Console.WriteLine("Example 02 March 2018 = 02-04-2018");
                            dateT = DateTime.Parse(Console.ReadLine()).AddHours(23.9999);
                            diff = (dateT - dateF).Days;
                        }
                        catch
                        {
                            Console.WriteLine("Your date input does not match the format, Please Enter The Date Again ");
                            chk = true;
                            Console.ReadKey();
                        }
                        if (((now - dateF).Days > 30) || ((now - dateT).Days > 30))
                        {
                            Console.WriteLine("Please enter a maximum of the last 30 days");
                            chk = true;
                            Console.ReadKey();
                        }
                        else if (diff < 0)
                        {
                            Console.WriteLine("Input your date reversed, Please Check And Enter Your The Date Again ");
                            Math.Abs(diff);
                            chk = true;
                            Console.ReadKey();
                        }
                        
                    } while (chk);
                    break;
                case 5:
                    MasterMenuUser.User(NoRek);
                    Console.Clear();
                    break;
            }
            

            Console.Clear();
            ProgramMain.Emphasis(@"
                                                           IOIOIOIOIOIOIOIOIOIOIOIO
                                IOIOIOIOIOIOIOIOIOIOIOIOIOIO   MUTATION REPORTS   IOIOIOIOIOIOIOIOIOIOIOIOIOIO
                                                           IOIOIOIOIOIOIOIOIOIOIOIO ");
            Console.WriteLine("Date\t: {0} \nTime\t: {1} \nMachine\t: {2} \n", now.ToShortDateString(), now.ToLongTimeString(), Environment.MachineName + "#" + rnd.Next(100, 999));
            Console.WriteLine("Account Number\t:" + NoRek + "\n");
            Console.SetWindowSize(150, 30);
            var table = new ConsoleTable("TransID", "Date", "Acc Recipient", "Acc Sender", "Nominal", "D/C", "Balance", "Information");
            foreach (string line in File.ReadLines(path + "mutasi-" + NoRek + ".txt"))
            {
                var data = line.Split(',');

                if (Convert.ToDateTime(data[0]) > dateF && Convert.ToDateTime(data[0]) <= dateT)
                {
                    table.AddRow(data[1], data[0], data[3], data[2], data[5], data[4], data[6], data[7]);
                }
            }
            table.Write();
            Console.WriteLine();
            Console.ReadKey();
        }
        public static void CheckBalance(int asd)
        {
            int NoRek = asd;
            var data = new dynamic[20];
            foreach (string lines in File.ReadLines(path + "UserData.txt"))
            {
                data = lines.Split('#');
                if (NoRek.Equals(Convert.ToInt32(data[11])))
                {
                    Console.WriteLine("#####################################");
                    Console.WriteLine("Account Number\t: " + data[11]);
                    Console.WriteLine("Account Type\t: " + data[10]);
                    Console.WriteLine("Balance\t\t: " + data[13]);
                    Console.WriteLine("Time \t\t: " + DateTime.Now);
                    Console.WriteLine("#####################################");
                    Console.ReadKey();
                }
                
            }

        }
        public static void ChangePIN(int asd)
        {
            
            var data = new object[20];
            var data_input = new object[4];
            int rek_pengirim = asd;
            int linenumber = 0;
            string[] line_detect;
            string[] line_specific;
            foreach (string line in File.ReadLines(path + "UserData.txt"))
            {
                data = line.Split('#');
                linenumber++;
                if (rek_pengirim.Equals(Convert.ToInt32(data[11])))
                {
                    break;
                }

            }
            Console.WriteLine("Enter Old PIN");
            data_input[0] = Console.ReadLine();
            Console.WriteLine("Enter New PIN");
            data_input[1] = Console.ReadLine();
            Console.WriteLine("Confirm New PIN");
            data_input[2] = Console.ReadLine();
            if (true)
            {

                if (!data_input[0].Equals(data[12]))
                {
                    Console.WriteLine("Wrong Old PIN");
                    Console.ReadKey();
                    Console.Clear();
                    ChangePIN(rek_pengirim);
                }
                else
                {
                    if (!data_input[1].Equals(data_input[2]))
                    {
                        Console.WriteLine("Confirmation PIN Not Valid");
                        Console.ReadKey();
                        Console.Clear();
                        ChangePIN(rek_pengirim);

                    }
                    else if ((Convert.ToInt32(data_input[1]) > 100000) && (Convert.ToInt32(data_input[1]) < 999999))
                    {
                        Console.WriteLine("Must be 6 digits");
                        Console.ReadKey();
                        Console.Clear();
                        ChangePIN(rek_pengirim);
                    }
                    else
                    {
                        line_detect = File.ReadAllLines(path + "UserData.txt");
                        line_specific = line_detect[linenumber - 1].Split('#');
                        File.WriteAllText(path + "UserData.txt", File.ReadAllText(path + "UserData.txt").Replace(line_detect[linenumber - 1], line_detect[linenumber - 1].Replace(line_specific[12], Convert.ToString(data_input[1]))));
                        Console.WriteLine("Change PIN Successfuly, Please press any key to continue");
                        Console.ReadKey();
                        Console.Clear();
                        MasterMenuUser.User(rek_pengirim);
                    }
                }
            }
        }
        public static void Transfer(int asd)
        {
            int NoRek = asd;
            Console.WriteLine("1. Transfer Between Account");
            Console.WriteLine("2. Transfer Between Bank ");
            Console.WriteLine("3. Back to Menu");
            Console.WriteLine();
            Console.Write("Input : ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                default:
                    Console.WriteLine("Please input 1-3");
                    break;
                case 1:
                    TransferRek(NoRek);
                    break;
                case 2:
                    TransferBank(NoRek);
                    break;
                case 3:
                    MasterMenuUser.User(NoRek);
                    break;
            }
        }
        public static void TransferRek(int asd)
        {
            int num = new Random().Next(1000, 99999);
            string[] line_detect;
            string[] line_specific;
            int linenumber;
            int rek_pengirim = asd;
            var data = new object[20];
            var data_trf = new object[5];
            var rmv_empty_line = File.ReadAllLines(path + "UserData.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(path + "UserData.txt", rmv_empty_line);
            bool a = true;
            while (a)
            {
                linenumber = 0;
                Console.WriteLine("Enter Account Destination :");
                data_trf[0] = Console.ReadLine();
                Console.WriteLine("Enter Total Transfer");
                data_trf[1] = Console.ReadLine();
                Console.WriteLine("Enter Description");
                data_trf[2] = Console.ReadLine();

                foreach (string line in File.ReadLines(path + "UserData.txt"))
                {

                    data = line.Split('#');
                    linenumber++;
                    if (data_trf[0].Equals(data[11]))
                    {
                        break;
                    }
                }
                Console.Clear();
                Console.WriteLine("Account Destination : " + data_trf[0]);
                Console.WriteLine("Account Name Destination : " + data[1]);
                Console.WriteLine("Total Transfer : " + data_trf[1]);
                Console.WriteLine("Are you sure? (y/n)");
                Console.Write("Enter : ");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    if (true)
                    {
                        foreach (string line in File.ReadLines(path + "UserData.txt"))
                        {

                            data = line.Split('#');
                            if (rek_pengirim.Equals(Convert.ToInt32(data[11])))
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (Convert.ToInt32(data_trf[1]) > Convert.ToInt32(data[13]))
                        {
                            Console.Clear();
                            Console.WriteLine("Transaction Failed!!");
                            Console.WriteLine("Not Enought Balance");
                        }
                        else
                        {
                            foreach (string line in File.ReadLines(path + "UserData.txt"))
                            {

                                data = line.Split('#');
                                if (data_trf[0].Equals(data[11]))
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (!data_trf[0].Equals(data[11]))
                            {
                                Console.Clear();
                                Console.WriteLine("Transaction Failed!!");
                                Console.WriteLine("Data not Found");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Transaction success!!");
                                Console.WriteLine("Ref : " + "TRX" + num);
                                Console.WriteLine("Transfer Destination : " + data_trf[0]);
                                Console.WriteLine("Total Transfer : " + data_trf[1]);
                                Console.WriteLine("Time : " + DateTime.Now);
                                line_detect = File.ReadAllLines(path + "UserData.txt");
                                line_specific = line_detect[linenumber - 1].Split('#');
                                File.WriteAllText(path + "UserData.txt", File.ReadAllText(path + "UserData.txt").Replace(line_detect[linenumber - 1], line_detect[linenumber - 1].Replace(line_specific[13], Convert.ToString((Convert.ToInt32(data[13]) + Convert.ToInt32(data_trf[1]))))));
                                using (var sw = new StreamWriter(path + ("mutasi-" + data[11] + ".txt"), true))
                                {
                                    sw.WriteLine(DateTime.Now + "," + "TRX" + num + "," + rek_pengirim + "," + data[11] + "," + "D" + "," + data_trf[1]+","+ Convert.ToString((Convert.ToInt32(data[13]) + Convert.ToInt32(data_trf[1]))) + "," + data_trf[2]);
                                }
                                linenumber = 0;
                                foreach (string line in File.ReadLines(path + "UserData.txt"))
                                {
                                    data = line.Split('#');
                                    linenumber++;
                                    if (rek_pengirim.Equals(Convert.ToInt32(data[11])))
                                    {
                                        break;
                                    }
                                }

                                line_detect = File.ReadAllLines(path + "UserData.txt");
                                line_specific = line_detect[linenumber - 1].Split('#');
                                File.WriteAllText(path + "UserData.txt", File.ReadAllText(path + "UserData.txt").Replace(line_detect[linenumber - 1], line_detect[linenumber - 1].Replace(line_specific[13], Convert.ToString((Convert.ToInt32(data[13]) - Convert.ToInt32(data_trf[1]))))));


                                using (var sw = new StreamWriter(path + ("mutasi-" + data[11] + ".txt"), true))
                                {
                                    sw.WriteLine(DateTime.Now + "," + "TRX" + num + "," + rek_pengirim + "," + data_trf[0] + "," + "C" + "," + data_trf[1] + ","+ Convert.ToString((Convert.ToInt32(data[13]) - Convert.ToInt32(data_trf[1]))) + "," + data_trf[2]);
                                }
                                
                            }
                        }
                    }

                    Console.Write("do you want to transaction again? (y/n) : ");
                    string ask_2 = Console.ReadLine().ToLower();
                    if (ask_2 == "y")
                    {
                        Console.Clear();

                    }
                    if (ask_2 == "n")
                    {
                        Console.Clear();
                        MasterMenuUser.User(asd);
                    }

                }
                else
                {
                    Console.Clear();
                }


            }
        }
        public static void TransferBank(int asd)
        {
            int num = new Random().Next(1000, 99999);
            string[] line_detect;
            string[] line_specific;
            int linenumber;
            int rek_pengirim = asd;
            var data = new object[20];
            var data_trf = new object[5];
            var rmv_empty_line = File.ReadAllLines(path + "UserData.txt").Where(arg => !string.IsNullOrWhiteSpace(arg));
            File.WriteAllLines(path + "UserData.txt", rmv_empty_line);
            bool a = true;
            while (a)
            {
                linenumber = 0;
                Console.WriteLine("Enter Bank Code");
                data_trf[3] = Console.ReadLine();
                Console.WriteLine("Enter Account Destination :");
                data_trf[0] = Console.ReadLine();
                Console.WriteLine("Enter Total Transfer");
                data_trf[1] = Console.ReadLine();
                Console.WriteLine("Enter Description :");
                data_trf[2] = Console.ReadLine();
                string nama_other_bank = "";
                foreach (string line in File.ReadLines(path + "kodebank.txt"))
                {

                    data = line.Split(',');
                    linenumber++;
                    if (data_trf[3].Equals(data[0]))
                    {
                        nama_other_bank = Convert.ToString(data[0]);
                        break;
                    }
                    else
                    {
                        continue;
                    }
                }
                Console.Clear();
                Console.WriteLine("Bank Destination : " + data[1]);

                foreach (string line in File.ReadLines(path + "UserData.txt"))
                {
                    data = line.Split('#');
                    linenumber++;
                    if (data_trf[0].Equals(data[11]))
                    {
                        break;
                    }
                }
                Console.WriteLine("Account Destination : " + data_trf[0]);
                Console.WriteLine("Account Name Destination : " + data[1]);
                Console.WriteLine("Total Transfer : " + data_trf[1]);
                Console.WriteLine("Are you sure? (y/n)");
                Console.Write("Enter : ");
                string input = Console.ReadLine().ToLower();
                if (input == "y")
                {
                    if (true)
                    {
                        foreach (string line in File.ReadLines(path + "UserData.txt"))
                        {

                            data = line.Split('#');
                            if (rek_pengirim.Equals(Convert.ToInt32(data[11])))
                            {
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                        if (Convert.ToInt32(data_trf[1]) + 6500 > Convert.ToInt32(data[13]))
                        {
                            Console.Clear();
                            Console.WriteLine("Transaction Failed!!");
                            Console.WriteLine("Not Enought Balance");
                        }
                        else
                        {
                            foreach (string line in File.ReadLines(path + "bank-" + data_trf[3] + ".txt"))
                            {

                                data = line.Split('#');
                                if (data_trf[0].Equals(data[11]))
                                {
                                    break;
                                }
                                else
                                {
                                    continue;
                                }
                            }
                            if (!data_trf[0].Equals(data[11]))
                            {
                                Console.Clear();
                                Console.WriteLine(data_trf[0]);
                                Console.WriteLine(data[11]);
                                Console.WriteLine("Transaction Failed!!");
                                Console.WriteLine("Data Not Found");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Transaction Success!");
                                Console.WriteLine("Ref : " + "TRX" + num);
                                Console.WriteLine("Bank Destination : " + nama_other_bank);
                                Console.WriteLine("Account Destination : " + data_trf[0]);
                                Console.WriteLine("Total Transfer : " + data_trf[1]);
                                Console.WriteLine("Time : " + DateTime.Now);
                                linenumber = 0;
                                foreach (string line in File.ReadLines(path + "UserData.txt"))
                                {
                                    data = line.Split('#');
                                    linenumber++;
                                    if (rek_pengirim.Equals(Convert.ToInt32(data[11])))
                                    {
                                        break;
                                    }
                                }
                                line_detect = File.ReadAllLines(path + "UserData.txt");
                                line_specific = line_detect[linenumber - 1].Split('#');
                                File.WriteAllText(path + "UserData.txt", File.ReadAllText(path + "UserData.txt").Replace(line_detect[linenumber - 1], line_detect[linenumber - 1].Replace(line_specific[13], Convert.ToString((Convert.ToInt32(data[13]) - Convert.ToInt32(data_trf[1]))))));


                                using (var sw = new StreamWriter(path + ("mutasi-" + data[11] + ".txt"), true))
                                {
                                    sw.WriteLine(DateTime.Now + "," + "TRX" + num + "," + rek_pengirim   + "," + data_trf[3] + "+" + data_trf[0] + "," + "C"+ "," + data_trf[1] + "," + Convert.ToString((Convert.ToInt32(data[13]) - Convert.ToInt32(data_trf[1]))) + "," + data_trf[2]);
                                }
                            }
                        }
                    }
                    Console.Write("Do you want to Transaction Again? (y/n) : ");
                    string ask_2 = Console.ReadLine().ToLower();
                    if (ask_2 == "y")
                    {
                        Console.Clear();

                    }
                    if (ask_2 == "n")
                    {
                        Console.Clear();
                        MasterMenuUser.User(asd);
                    }

                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
}
