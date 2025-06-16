
using MySql.Data.MySqlClient;
using Model;

namespace DAL
{
    public class UserDAL
    {
        private readonly string connectionString = "server=localhost;database=Chat;uid=root;pwd=zZhoang030905Zz;";

        public int GetUserCount()
        {
            int count = 0;
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT COUNT(*) FROM Users";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    count = Convert.ToInt32(cmd.ExecuteScalar());
                }
            }
            return count;
        }

        public UserModel GetUserByUsername(string username)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM users WHERE username = @username LIMIT 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new UserModel
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    Password = reader.GetString("password"),
                    Email = reader.GetString("email"),
                    Gender = reader.GetString("gender"),
                    BirthDate = reader.GetDateTime("birth_date"),
                    Bio = reader.GetString("bio"),
                    Status = Convert.ToBoolean(reader["is_online"]) ? "Online" : "Offline"

                };
            }
            return null;
        }
        public UserModel GetUsername(string username)
        {
            UserModel user = null;

            string query = "SELECT Id, Username, ... FROM Users WHERE Username = @username";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new UserModel
                            {
                                Id = reader.GetInt32("Id"),
                                Username = reader.GetString("Username"),
                            };
                        }
                    }
                }
            }

            return user;
        }
        public List<UserModel> GetOnlineUsers()
        {
            var users = new List<UserModel>();
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT id, username, is_online FROM users WHERE is_online = TRUE";
            using var cmd = new MySqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new UserModel
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    Status = "Đang hoạt động",
                    IsOnline = true
                });
            }
            return users;
        }
        public List<UserModel> GetOfflineUser()
        {
            var users = new List<UserModel>();
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT id, username, is_online FROM users WHERE is_online = FALSE";
            using var cmd = new MySqlCommand(query, conn);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                users.Add(new UserModel
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    Status = "Ngoại tuyến",
                    IsOnline = false
                });
            }
            return users;

        }

        public void UpdateUserOnlineStatus(int userId, bool isOnline)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "UPDATE users SET is_online = @isOnline WHERE id = @userId"; // LIMIT 1
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@isOnline", isOnline);
            cmd.Parameters.AddWithValue("@userId", userId);
            cmd.ExecuteNonQuery();
        }

        public UserModel GetUserById(int userId)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT * FROM users WHERE id = @userId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@userId", userId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new UserModel
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                };
            }
            return null;
        }
        
        public UserModel Login(string username, string password)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT id, username, password FROM users WHERE username = @username AND password = @password LIMIT 1";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@password", password);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new UserModel
                {
                    Id = reader.GetInt32("id"),
                    Username = reader.GetString("username"),
                    Password = reader.GetString("password")
                };
            }

            return null;
        }


    }
}
