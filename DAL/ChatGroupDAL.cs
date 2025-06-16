using Model;
using MySql.Data.MySqlClient;
namespace DAL
{
    public class ChatGroupDAL
    {
        private readonly string connectionString = "server=localhost;database=chat;uid=root;pwd=zZhoang030905Zz;";

        public bool IsGroupExists(string groupName)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT COUNT(*) FROM ChatGroups WHERE GroupName = @GroupName";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@GroupName", groupName);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        public bool IsPasswordCorrect(string groupName, string password)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT COUNT(*) FROM ChatGroups WHERE GroupName = @GroupName AND Password = @Password";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@GroupName", groupName);
            cmd.Parameters.AddWithValue("@Password", password);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        public int GetGroupId(string groupName)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT Id FROM ChatGroups WHERE GroupName = @GroupName";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@GroupName", groupName);

            var result = cmd.ExecuteScalar();
            return result != null ? Convert.ToInt32(result) : -1;
        }

        public bool IsUserInGroup(int groupId, int userId)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT COUNT(*) FROM GroupMembers WHERE GroupId = @GroupId AND UserId = @UserId";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@GroupId", groupId);
            cmd.Parameters.AddWithValue("@UserId", userId);

            long count = (long)cmd.ExecuteScalar();
            return count > 0;
        }

        public void AddUserToGroup(int groupId, int userId)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "INSERT INTO GroupMembers (GroupId, UserId) VALUES (@GroupId, @UserId)";
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@GroupId", groupId);
            cmd.Parameters.AddWithValue("@UserId", userId);
            cmd.ExecuteNonQuery();
        }

        public bool CreateGroup(string groupName, string password, int creatorId)
        {
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = @"
                INSERT INTO ChatGroups (GroupName, Password, CreatorId)
                VALUES (@GroupName, @Password, @CreatorId);

                INSERT INTO GroupMembers (GroupId, UserId)
                VALUES (LAST_INSERT_ID(), @CreatorId);
            ";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@GroupName", groupName);
            cmd.Parameters.AddWithValue("@Password", password);
            cmd.Parameters.AddWithValue("@CreatorId", creatorId);

            try
            {
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Lỗi tạo phòng: " + ex.Message);
                return false;
            }
        }
        public string GetGroupNameById(int roomId)
        {
            string groupName = null;

            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = "SELECT GroupName FROM ChatGroups WHERE Id = @RoomId LIMIT 1";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@RoomId", roomId);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                groupName = reader.GetString("GroupName");
            }

            return groupName;
        }

        public List<GroupModel> GetGroupsByUser(int userId)
        {
            var groups = new List<GroupModel>();
            using var conn = new MySqlConnection(connectionString);
            conn.Open();

            string query = @"
        SELECT cg.Id, cg.GroupName
        FROM ChatGroups cg
        JOIN GroupMembers gm ON cg.Id = gm.GroupId
        WHERE gm.UserId = @UserId";

            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@UserId", userId);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                groups.Add(new GroupModel
                {
                    Id = reader.GetInt32("Id"),
                    GroupName = reader.GetString("GroupName")
                });
            }

            return groups;
        }
        public List<GroupChatModel> GetMessagesByGroupId(int groupId)
        {
            List<GroupChatModel> messages = new List<GroupChatModel>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM GroupMessages WHERE GroupId = @GroupId ORDER BY SentAt";


                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@GroupId", groupId);

                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    GroupChatModel msg = new GroupChatModel()
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        GroupId = Convert.ToInt32(reader["GroupId"]),
                        SenderId = Convert.ToInt32(reader["SenderId"]),
                        Message = reader["Message"].ToString(),
                        SentAt = Convert.ToDateTime(reader["SentAt"])
                    };

                    messages.Add(msg);
                }

                reader.Close();
            }

            return messages;
        }

        public bool AddMessageToGroup(GroupChatModel msg)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = "INSERT INTO GroupMessages (GroupId, SenderId, Message, SentAt) VALUES (@GroupId, @SenderId, @Message, @SentAt)";
                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@GroupId", msg.GroupId);
                cmd.Parameters.AddWithValue("@SenderId", msg.SenderId);
                cmd.Parameters.AddWithValue("@Message", msg.Message);
                cmd.Parameters.AddWithValue("@SentAt", msg.SentAt);

                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

    }
}
