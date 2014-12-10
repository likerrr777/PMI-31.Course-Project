﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PMI31CourseProject;
using PMI31CourseProject.Repository;
using DAL;
using System.Linq.Expressions;
using ProjectDatabase;

namespace BLL
{
     /// <summary>
    /// class Manage Users
    /// </summary>
    public class ManageUsers
    {
         /// <summary>
        /// This method takes users contacts
        /// </summary>
        /// <returns></returns>
        public IEnumerable<User> GetContacts()
        {
            IEnumerable<User> users;
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                users = unitOfWork.ContactRepository.GetAll();
            }
            return users;
        }

        /// <summary>
        /// This method Add User
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public bool AddUser(User user)
        {
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                unitOfWork.ContactRepository.Add(user);
                unitOfWork.Save();
            }
            return true;
        }
        
        /// <summary>
        /// This method Update user information user
        /// </summary>
        /// <param name="user"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool UpdateUser(User user, string login)
        {
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                var contactEntity = unitOfWork.ContactRepository.GetById(GetIdByLogin(login));
                contactEntity.Login = user.Login;
                contactEntity.Password = Security.HashPassword(user.Password);
                contactEntity.Role = user.Role;
                contactEntity.FullName = user.FullName;
                contactEntity.IsRegistered = user.IsRegistered;
                unitOfWork.Save();
            }
            return true;
        }
        
        /// <summary>
        /// This method delete user
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public bool DeleteUser(string login)
        {
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                User user = unitOfWork.ContactRepository.GetById(GetIdByLogin(login));
                unitOfWork.ContactRepository.Delete(user);
                unitOfWork.Save();
            }
            return true;
        }

        /// <summary>
        /// This method Get Id By Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        private int GetIdByLogin(string login)
        {
            int id;
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                Expression<Func<User, bool>> expr = G => G.Login == login;
                var temp = unitOfWork.ContactRepository.GetMany(expr).ToList();
                if(temp.Count == 0) id = -1; else
                    id = temp[0].Id;
            }
            return id;
        }
        
        /// <summary>
        /// This method Get user By Id
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public User GetById(string login)
        {
            User user;
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                user = unitOfWork.ContactRepository.GetById(GetIdByLogin(login));
            }
            return user;
        }
        
        /// <summary>
        /// This method Get All Users By Graduate Year
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public List<User> GetAllUsersByGraduateYear(int graduationYear)
        {
            List<User> users = new List<User>();
            using (UnitOfWork<User> unitOfWork = new UnitOfWork<User>())
            {
                Expression<Func<User, bool>> expr = G => G.UserInfo.GraduateInfo.GraduationYear == graduationYear;
                users = unitOfWork.ContactRepository.GetMany(expr).ToList<User>();
            }
            return users;
        }
    }
}
