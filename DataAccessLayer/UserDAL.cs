using Interfaces;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class UserDAL: IUserContainer, IUserDAL
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

        string connectionstring = @"Server=mssqlstud.fhict.local;Database=dbi487346;User Id=dbi487346;Password=YeetWithYeet@1;";

        public void Add(UserDTO userDTO)
        {
            throw new NotImplementedException();
        }

        public List<UserDTO> getAllUsers()
        {
            cn = new SqlConnection(connectionstring);
            cn.Open();

            var sql = "SELECT * FROM Users";
            cmd = new SqlCommand(sql, cn);

            dr = cmd.ExecuteReader();

            List<UserDTO> userDTOs = new List<UserDTO>();

            while (dr.Read())
            {

                UserDTO dto = new UserDTO
                {
                    Name = Convert.ToString(dr["Name"]),
                    Password = Convert.ToString(dr["Password"])
                };

                userDTOs.Add(dto);
            }

            cn.Close();

            return userDTOs;
        }

        public UserDTO getById(int id)
        {
            return getAllUsers()[0];
        }

        
    }
}