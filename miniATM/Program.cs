using DataLib;
using DataLib.Interfaces;
using DataLib.Models;
using System;
using System.IO;
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
            dataManager = new DataManager();
            // obtener la lista de usuarios
            User[] userList = dataManager.GetUserData();

            while (true)
            {
                Console.WriteLine("Insert your username");
                //valida si existe el usuario
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
                    //llama al metodo login para comprobar si el pin matchea con el user
                    int inputPin;
                    int.TryParse(Console.ReadLine(),out inputPin);
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
                        //menu options
                        DisplayMenu option;
                        do
                        {
                            bool isValid;
                            do
                            {
                                DisplayOptions();
                                int intOption;
                                int.TryParse(Console.ReadLine(),out intOption);
                                option = (DisplayMenu)intOption;
                                isValid = Enum.IsDefined(typeof(DisplayMenu), option); // hice esto para poder disparar mensaje de invalid option
                                if (!isValid)
                                {
                                    Console.WriteLine("Invalid Option \n"); 
                                }
                            } while (!isValid);

                            if (option == DisplayMenu.Exit)
                            {
                                dataManager.SaveData();
                                Console.Clear();
                            } else
                            {
                                //ingreso y validacion de la cuenta
                                Console.WriteLine("Select Account");
                                int inputAccount;
                                int.TryParse(Console.ReadLine(),out inputAccount);
                                Account currentAccount = currentUser.accountList.Find(x => inputAccount == x.getId());
                                if(currentAccount == null)
                                {
                                    Console.WriteLine("Invalid Account \n");
                                } else { 
                                    //ingreso y validacion del monto
                                    Console.WriteLine("Insert amount");
                                    decimal amount;
                                    var amountInput = decimal.TryParse(Console.ReadLine(),out amount);


                                    switch (option)
                                    {
                                        case DisplayMenu.Deposit: 
                                            currentAccount.Deposit(amount);
                                            dataManager.UpdateUserAccountData(currentUser.username, currentAccount);
                                            break;
                                        case DisplayMenu.Withdrawal:
                                            try
                                            {
                                                currentAccount.Withdraw(amount);
                                                dataManager.UpdateUserAccountData(currentUser.username, currentAccount);
                                            }
                                            catch (Exception)
                                            {
                                                Console.WriteLine("El monto excede los limites permitidos \n");
                                            }
                                            break;
                                        case DisplayMenu.Transfer:
                                            //try
                                            //{
                                                //se puede mejorar exceptions handling & amount negativo
                                                Console.WriteLine("Insert receiver's username");
                                                string receiverName = Console.ReadLine();
                                                Console.WriteLine("Insert receiver's account number");
                                                int receiverAccount;
                                                int.TryParse(Console.ReadLine(), out receiverAccount);
                                                      //Transfer(amount, currentAccount, receiverName, receiverAccount); // No aplica
                                                var currentReceiver = userList
                                                    .Where(x => x.username == receiverName)
                                                    .FirstOrDefault();
                                                var recAccount = currentReceiver.accountList.Find(elem => elem.id == receiverAccount);
                                                if (currentReceiver != null && recAccount != null)
                                                {
                                                    currentAccount.Withdraw(amount);
                                                    recAccount.Deposit(amount);
                                                    //updateo el sender
                                                    dataManager.UpdateUserAccountData(currentUser.username, currentAccount);
                                                    //updateo el receiver
                                                    dataManager.UpdateUserAccountData(receiverName, recAccount);
                                                }
                                            //}
                                            ////catch
                                            ////{
                                                ////Console.WriteLine("Oops..something went wrong.. \nTry again\n");
                                            //}
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
            //exit  savedata()
            
        }

        static void DisplayOptions() //aplicar enum?
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("1 - Deposit");
            Console.WriteLine("2 - Withdrawal");
            Console.WriteLine("3 - Transfer");
            Console.WriteLine("4 - Exit");
            Console.WriteLine("Insert your option ");
            //return int.Parse(Console.ReadLine());
        }

        static void Transfer(decimal amount, Account senderAccount, string receiverName, int recAccountNo)
        {
            //IDataManager dataManager;
            //dataManager = new DataManager();
            //User[] userList = dataManager.GetUserData();
            //var currentReceiver = userList
            //.Where(x => x.username == receiverName)
            //.FirstOrDefault();
            //senderAccount.Withdraw(amount);
            //var recAccount = currentReceiver.accountList.Find(elem => elem.id == recAccountNo);
            //recAccount.Deposit(amount);
            //dataManager.UpdateUserAccountData(receiverName, recAccount);
        }

        enum DisplayMenu
        {
            Deposit = 1,
            Withdrawal,
            Transfer,
            Exit
        }
    }
}
