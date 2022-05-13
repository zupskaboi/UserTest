using DataAccessLayer;
using Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public class UserContainer
    {
        private IUserContainer dal;
        
        public UserContainer(IUserContainer context)
        {
            this.dal = context;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = new List<User>();
            List<UserDTO> dtos = this.dal.getAllUsers();

            foreach (UserDTO dto in dtos)
            {
                users.Add(new User(dto));
            }

            return users;
        }
        public User FindUserById(int id)
        {
            return new User(this.dal.getById(id));
        }
    }
}
