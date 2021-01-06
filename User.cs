using System;
using System.Collections.Generic;


namespace miniATM
{
    public class User
    {
        private string username;
        private int _pin;
        public List<Account> accountList;

        public User()
        {
            Console.WriteLine("clase user working");
        }

        public User(string user, int pin)
        {
            username = user;
            _pin = pin;
            accountList = new List<Account>();
        }

        public bool login(string user, int pin)//necesito pasar el user?
        {
            if (user == username && pin == _pin)
            {
                return true;
            } else {
                return false;
            }
        }
        
    }
}