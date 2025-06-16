using System.Collections.Generic;
using DAL;
using Model;

namespace BLL
{
    public class PrivateChatBLL
    {
        private readonly PrivateChatDAL dal = new PrivateChatDAL();

        public List<PrivateChatModel> GetPrivateMessages(int user1Id, int user2Id)
        {
            return dal.GetPrivateMessages(user1Id, user2Id);
        }

        public bool AddPrivateMessage(PrivateChatModel message)
        {
            if (string.IsNullOrWhiteSpace(message.Message))
                return false; 

            return dal.AddPrivateMessage(message);
        }
    }

}
