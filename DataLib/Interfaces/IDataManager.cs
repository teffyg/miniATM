using DataLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLib.Interfaces
{
    public interface IDataManager
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Lista de usuarios y cuentas guardados en el almacenamiento</returns>
        User[] GetUserData();

        /// <summary>
        /// sobreescribe el contenido del archivo con los datos actuales en memoria
        /// </summary>
        void SaveData();

        /// <summary>
        /// Actualiza los datos de la cuenta para un respectivo user
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="account"></param>
        void UpdateUserAccountData(int userId, Account account);
    }
}
