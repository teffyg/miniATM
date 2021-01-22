using System;
using System.Collections.Generic;


namespace DataLib.Models
{
    public class User
    {
        public string username; //lo declare public para poder hacer el find(), sin tener q definir un get?
        public int _pin; //public para poder grabar los datos en el file, otra forma?
        public List<Account> accountList;

        public User()
        {

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