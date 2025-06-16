using Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PrivateChatDAL
    {
        private readonly string connectionString = "server=localhost;database=chat;uid=root;pwd=zZhoang030905Zz;";

        public List<PrivateChatModel> GetPrivateMessages(int user1Id, int user2Id)
        {
            var messages = new List<PrivateChatModel>();
            string query = @"
            SELECT Id, SenderId, ReceiverId, Message, SentAt FROM PrivateMessages
            WHERE (SenderId = @User1Id AND ReceiverId = @User2Id)
               OR (SenderId = @User2Id AND ReceiverId = @User1Id)
            ORDER BY SentAt ASC";

            using var conn = new MySqlConnection(connectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@User1Id", user1Id);
            cmd.Parameters.AddWithValue("@User2Id", user2Id);
            conn.Open();

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                messages.Add(new PrivateChatModel
                {
                    Id = reader.GetInt32("Id"),
                    SenderId = reader.GetInt32("SenderId"),
                    ReceiverId = reader.GetInt32("ReceiverId"),
                    Message = reader.GetString("Message"),
                    SentAt = reader.GetDateTime("SentAt")
                });
            }
            return messages;
        }

        public bool AddPrivateMessage(PrivateChatModel message)
        {
            string query = "INSERT INTO PrivateMessages (SenderId, ReceiverId, Message, SentAt) VALUES (@SenderId, @ReceiverId, @Message, @SentAt)";
            using var conn = new MySqlConnection(connectionString);
            using var cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@SenderId", message.SenderId);
            cmd.Parameters.AddWithValue("@ReceiverId", message.ReceiverId);
            cmd.Parameters.AddWithValue("@Message", message.Message);
            cmd.Parameters.AddWithValue("@SentAt", message.SentAt);
            conn.Open();
            return cmd.ExecuteNonQuery() > 0;
        }
    }

}