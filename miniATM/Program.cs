using DataLib;
using DataLib.Interfaces;
using DataLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace miniATM
{
    class Program
    {
        static void Main(string[] args)
        {
            User currentUser;
            IDataManager dataManager;
            //inicializar dataManager
            // obtener la lista de usuarios
            User[] userList = new User[] { };

            while (true)
            {
                Console.WriteLine("Insert your username");
                var inputUser = Console.ReadLine();
                currentUser = userList
                    .Where(x => x.username == inputUser)
                    .FirstOrDefault();

                if (currentUser == null)
                {
                    Console.WriteLine("Invalid user");
                }
                else
                {
                    Console.WriteLine("Insert your pin");
                    int inputPin = int.Parse(Console.ReadLine());
                    if (!currentUser.login(inputPin))
                    {
                        Console.WriteLine("The pin is incorrect");
                    }
                    else
                    {
                        Console.WriteLine($"Welcome {currentUser.username}");
                        foreach (var item in currentUser.accountList)
                        {
                            Console.WriteLine("Account: " + item.getId() + " Total: " + item.getAmount());

                        };

                        DisplayMenu option;
                        do
                        {
                            bool isValid;
                            do
                            {
                                DisplayOptions();
                                option = (DisplayMenu)int.Parse(Console.ReadLine());
                                isValid = Enum.IsDefined(typeof(DisplayMenu), option); // hice esto para poder disparar mensaje de invalid option
                                if (!isValid)
                                {
                                    Console.WriteLine("Invalid Option \n"); 
                                }
                            } while (!isValid);

                            //option = (DisplayMenu)DisplayOptions();

                            if (option == DisplayMenu.Exit)
                            {
                                Console.Clear();
                            } else
                            {
                                Console.WriteLine("Select Account");
                                int inputAccount = int.Parse(Console.ReadLine());
                                Account currentAccount = currentUser.accountList.Find(x => inputAccount == x.getId());
                                if(currentAccount == null)
                                {
                                    Console.WriteLine("Invalid Account \n");
                                } else { 
                                    Console.WriteLine("Insert amount");
                                    decimal amount;
                                    var amountInput = decimal.TryParse(Console.ReadLine(),out amount);

                                    switch (option)
                                    {
                                        case DisplayMenu.Deposit: //validar q la cuenta exista, sino da error . y que el monto sea positivo
                                            currentAccount.Deposit(amount);
                                            break;
                                        case DisplayMenu.Withdrawal:
                                            try
                                            {
                                                currentAccount.Withdraw(amount);
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("El monto excede los limites permitidos \n");
                                            }
                                            break;
                                    } // semicolon? -- no

                                    foreach (var item in currentUser.accountList)
                                    {
                                        Console.WriteLine("Account: " + item.getId() + " Total: " + item.getAmount());
                                    }
                                }
                            }
                        } while (option != DisplayMenu.Exit);
                    }
                }
            }
        }

        static void DisplayOptions() //aplicar enum?
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 - Deposit");
            Console.WriteLine("2 - Withdrawal");
            Console.WriteLine("3 - Exit");
            Console.WriteLine("Insert your option ");
            //return int.Parse(Console.ReadLine());
        }

        enum DisplayMenu
        {
            Deposit = 1,
            Withdrawal,
            //Transfer,
            Exit
        }
    }
}
