using System;

namespace DataLib.Models
{
    public class Account
    {
        int id;
        decimal amount;
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
        public decimal getAmount()
        {
            return amount;
        }

        public decimal Withdraw(decimal value)
        {
            if(value<=amount && value<=maxWithdrawal)
            {
            amount = amount - value;
            } 
            else 
            {
                 throw new Exception();
            } 
            return amount;
        }

        public decimal Deposit(decimal value)
        {   
            amount = amount + value;
            return amount;
        }
    }
}