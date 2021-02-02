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
        //setear path del archivo
        private const string FILE_PATH = "Data/UserData.json";

        public DataManager() 
        {
            //leer el contenido del archivo
            string text = File.ReadAllText(FILE_PATH);
            _fileData = JsonConvert.DeserializeObject<User[]>(text);
            //deserializar contenido y asignarlo a la variable _fileData
            //para esto tendras que usar la libreria Newtonsoft - href: https://www.newtonsoft.com/json/help/html/SerializingJSON.htm 
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
            //busco el User a traves del username que paso como parametro
            var currentUser = Array.Find(_fileData, elem => elem.Username.ToLower() == username.ToLower());
            //obtengo el index de la Account en el currentUser
            var indexAcc = currentUser.accountList.IndexOf(account);
            //asigno el valor de account que paso como parametro en la ubicacion donde esta la cuenta a actualizar en accountList
            currentUser.accountList[indexAcc] = account;
            //hago lo mismo en _fileData con el currentUser
            _fileData[Array.IndexOf(_fileData, currentUser)] = currentUser;
        }
    }
}