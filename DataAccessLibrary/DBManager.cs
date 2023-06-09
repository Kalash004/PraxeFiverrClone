﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLibrary.DAOS;
using DataAccessLibrary.Models;

namespace DataAccessLibrary
{
    public class DBManager
    {
        private DBUserManager userManager = new DBUserManager();

        /// <summary>
        /// Saves user to database and creates and retrievs his id
        /// </summary>
        /// <param name="user">User to save</param>
        /// <returns>Original user with updated id</returns>
        public User SingUpUser(User user)
        {
            return userManager.SingUpUser(user);
        }

        /// <summary>
        /// Reads database and returns a user with specific name
        /// </summary>
        /// <param name="name">Name of the user you want to read</param>
        /// <returns>User from database with the specified name</returns>
        public User ReadUserByName(string name)
        {
            return userManager.GetUserByName(name);
        }
             
    }
}
