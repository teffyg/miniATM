using System;
using System.Collections.Generic;


namespace DataLib.Models
{
    public class User
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }
        public int _pin; //TODO: writing data in file
        public List<Account> accountList;

        public User(string user, int pin)
        {
            
        }
        public bool login(int pin)
        {
            return pin == _pin;
        }
        
    }
}