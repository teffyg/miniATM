using System;
using System.Collections.Generic;


namespace miniATM
{
    public class User
    {
        public string username; //lo declare public para poder hacer el find(), sin tener q definir un get?
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
            accountList = new List<Account>()
            {
                new Account()  // por defecto se asigna una cuenta al crear usuario / evita errores?
            };
        }
        public bool login(int pin)
        {
            if (pin == _pin)
            {
                return true;
            } else {
                return false;
            }
        }
        
    }
}