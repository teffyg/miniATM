using DataLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Interfaces
{
    public interface IDataManager
    {
      
        User[] GetUserData();

       
        void SaveData();

       
        void UpdateUserAccountData(string username, Account account);
    }
}
