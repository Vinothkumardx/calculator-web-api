using Calculatorwebapi.Database;
using Calculatorwebapi.model;
using Calculatorwebapi.Repository;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Calculatorwebapi.Service
{
    public class Userservice : Iuser
    {
        private readonly Dbcontextclass _dbcontextclass;

        public Userservice(Dbcontextclass dbcontextclass)
        {
            _dbcontextclass = dbcontextclass;
        }


        public User Authenticate(string username, string password)
        {
            User user = null;

            using (var connection = new SqlConnection(_dbcontextclass.Database.GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[Loginuser]", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                   

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new User
                            {
                                Id = (int)reader["Id"],
                                Username = (string)reader["Username"],
                                Email = (string)reader["Email"]
                                // You might not need to retrieve password here for security reasons
                                // Password = (string)reader["Password"]
                            };
                        }
                    }
                }
            }

            return user;
        }

        public User Create(User user, string password,string Email,string FirstName,string Lastname)
        {
            using (var connection = new SqlConnection(_dbcontextclass.Database.GetConnectionString()))
            {
                connection.Open();
                using (var command = new SqlCommand("[dbo].[Registeruser]", connection))
                {
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@Username", user.Username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.Parameters.AddWithValue("@Email", Email);
                    command.Parameters.AddWithValue("@FirstName", FirstName);
                    command.Parameters.AddWithValue("@LastName", Lastname);

                    command.ExecuteNonQuery();
                }
            }

            return user;
        }
    }


}

