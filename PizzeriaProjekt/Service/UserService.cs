﻿using PizzeriaProjekt.DB;
using PizzeriaProjekt.Exceptions;
using PizzeriaProjekt.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PizzeriaProjekt.Service
{
    internal class UserService
    {
        private UserDal userDal = new UserDal();
        /// <summary>
        /// Returns true when User has been properly logged in, returns false when password is wrong. 
        /// Throws UserNotFoundException when login is wrong
        /// </summary>
        /// <param name="username">User login</param>
        /// <param name="password">User Password</param>
        /// <returns></returns>
        /// <exception cref="UserNotFoundException">Thrown when login's wrong.</exception>
        public bool LogIn(string username, string password)
        {
            User user;

            try
            {
                user = userDal.GetUserByLogin(username);
                if (user.Password == password)
                {
                    CurrentUserContainer.currentUser = user;
                    return true;
                }
                else
                {
                    return false;
                }
            }catch(NullReferenceException e)
            {
                throw new UserNotFoundException();
            }
        }

    }

}