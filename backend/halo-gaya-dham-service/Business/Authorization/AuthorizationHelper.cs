using System.Data;
using Common.DTOs;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Business.Authorization
{
    public class AuthorizationHelper : IAuthorizationHelper
    {
        private readonly IConfiguration _configuration;
        public AuthorizationHelper(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        private string GetConnectionString()
        {
            return _configuration.GetConnectionString("dBConnectionString");
        }

        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        private bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }

        public void AddNewUser(string username, string password)
        {
            string encodedPassword = HashPassword(password);
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("dbo.InsertAdminLogin", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", encodedPassword);

                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Login Login(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(GetConnectionString()))
            {
                SqlCommand command = new SqlCommand("dbo.CheckAdminLogin", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Username", username);

                connection.Open();
                var result = command.ExecuteScalar();

                if (result != null)
                {
                    var hashedPassword = result.ToString();
                    if (string.IsNullOrEmpty(hashedPassword))
                    {
                        return new Login { isUser = false, doesPasswordMatch = false };
                    }
                    else if (VerifyPassword(password, hashedPassword))
                    {
                        return new Login { isUser = true, doesPasswordMatch = true };
                    }
                    else
                    {
                        return new Login { isUser = true, doesPasswordMatch = false };
                    }
                }
                return new Login { isUser = false, doesPasswordMatch = false };
            }
        }

    }
}
