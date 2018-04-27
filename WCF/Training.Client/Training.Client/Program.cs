using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test;
using Training.Client.Models;
using Training.Client.UserService;
using Training.Client.ViewModel;

namespace Training.Client
{
    class Program
    {
        private static UserManagementViewModel userManagementViewModel = new UserManagementViewModel();
        private static UserManagement userManagement = new UserManagement(userManagementViewModel);

        static void Main(string[] args)
        {
            Class1.printa();

            while (true)
            {
                PrintMenu();
                HandleOperation();
            }
        }

        public static void HandleOperation()
        {
            string opStr = Console.ReadLine().Trim();

            int opNum = -1;
            if (!string.IsNullOrEmpty(opStr) && int.TryParse(opStr, out opNum))
            {
                switch (opNum)
                {
                    case 1 :
                        userManagementViewModel.AddUser();
                        break;
                    case 2 : 
                        ShowUsers();
                        break;
                    case 3:
                        Environment.Exit(0);
                        break;
                    default:
                        ShowErrMsg(opStr);
                        break;
                }
            }
            else
            {
                ShowErrMsg(opStr);
            }
        }

       

        public static void ShowUsers()
        {
            userManagementViewModel.Initialization();
            userManagement.PrintList();
        }

        public static void ShowErrMsg(string opStr)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("[Error Message] invalid parameter : Expected valid number but given '" + opStr + "'");
            Console.ResetColor();
            Console.WriteLine();
        }

        public static void PrintMenu()
        {
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("|                     UserManagement                       |");
            Console.WriteLine("|          1: Add User   2. Show Users   3. Exit           |");
            Console.WriteLine("|                 Press number to continue                 |");
            Console.WriteLine("------------------------------------------------------------");
            Console.Write("Operation you want to do : ");
        }
    }
}
