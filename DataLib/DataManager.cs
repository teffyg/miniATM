using DataLib.Interfaces;
using DataLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace DataLib
{
    public class DataManager : IDataManager
    {
        private User[] _fileData;
        //set file path 
        private const string FILE_PATH = "Data/UserData.json";

        public DataManager() 
        {
            
            string text = File.ReadAllText(FILE_PATH);
            _fileData = JsonConvert.DeserializeObject<User[]>(text);
           
        }

        public User[] GetUserData()
        {
            var result = new User[0];
            if (_fileData != null)
            {
                result = _fileData;
            }
            return result;
        }

        public void SaveData() 
        {
            string output = JsonConvert.SerializeObject(_fileData);
            File.WriteAllText(FILE_PATH,output);
        }

        public void UpdateUserAccountData(string username, Account account)
        {
            var currentUser = Array.Find(_fileData, elem => elem.Username.ToLower() == username.ToLower());
            var indexAcc = currentUser.accountList.IndexOf(account);
            currentUser.accountList[indexAcc] = account;
            _fileData[Array.IndexOf(_fileData, currentUser)] = currentUser;
        }
    }
}