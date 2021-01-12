using System;

namespace DataLib.Models
{
    public class Account
    {
        int id;
        uint amount;
        int maxWithdrawal;

        public Account()
        {
            Random rnd = new Random();
            id = rnd.Next(0,9999);
            amount = 0;
            maxWithdrawal = 1000;
        }

        public int getId()
        {
            return id;
        }
        public uint getAmount()
        {
            return amount;
        }

        public uint Withdraw(uint value)
        {
            if(value<=amount && value<=maxWithdrawal)
            {
            amount = amount - value;
            } 
            else 
            {
                Console.WriteLine("El monto excede los limites permitidos");
            } 
            return amount;
        }

        public uint Deposit(uint value)
        {   
            amount = amount + value;
            return amount;
        }
    }
}