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
        UsersDAO usersDAO = new UsersDAO();

        public void SingUpUser(User user)
        {
            if (usersDAO.GetByName(user) != null)
            {
                throw new Exception("User name already exists in database");
            } 
            usersDAO.Create(user);
        }

        public User GetUserByName(string name)
        {
            User returned = usersDAO.GetByName(name);
            return returned;
        }
        
        public void RemoveUser(User user)
        {
            usersDAO.Delete(user.ID);
        }
    }
}