using System;

namespace miniATM
{
    public class Account
    {
        int id;
        int amount;
        int maxWithdrawal;

        public Account()
        {
            Console.WriteLine("clase account working");
            Random rnd = new Random();
            id = rnd.Next(0,9999);
            amount = 0;
            maxWithdrawal = 1000;
        }

        public int getId()
        {
            return id;
        }
        public int getAmount()
        {
            return amount;
        }

        public int Withdraw(int value)
        {
            if(value<=amount&&value<=maxWithdrawal)
            {
            amount = amount - value;
            } else {
                Console.Write("El monto excede los limites permitidos");
            }
            return amount;
        }

        public int Deposit(int value)
        {
            amount+= value;
            return amount;
        }
    }
}