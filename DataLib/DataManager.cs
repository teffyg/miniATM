using DataLib.Interfaces;
using DataLib.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace DataLib
{
    public class DataManager : IDataManager
    {
        private readonly User[] _fileData;
        //setear path del archivo
        private const string FILE_PATH = "";

        public DataManager() 
        {
            if (!File.Exists(FILE_PATH))
                File.Create(FILE_PATH);
            //leer el contenido del archivo
            //deserializar contenido y asignarlo a la variable _fileData
            //para esto tendras que usar la libreria Newtonsoft - href: https://www.newtonsoft.com/json/help/html/SerializingJSON.htm 
        }

        public User[] GetUserData()
        {
            throw new NotImplementedException();
        }

        public void SaveData()
        {
            throw new NotImplementedException();
        }

        public void UpdateUserAccountData(int userId, Account account)
        {
            throw new NotImplementedException();
        }
    }
}
