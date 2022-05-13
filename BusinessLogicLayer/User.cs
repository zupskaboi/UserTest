using DataAccessLayer;
using Interfaces;

namespace BusinessLogicLayer
{
    public class User
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public User()
        {

        }
        public User(string name, string password)
        {
            this.Name = name;
            this.Password = password;
        }

        public User(UserDTO dto)
        {
            this.Name = dto.Name;
            this.Password = dto.Password;
        }
    }
}