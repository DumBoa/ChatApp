using DAL;
using Model;

namespace BLL
{
    public class UserBLL
    {
        private readonly UserDAL userDAL = new UserDAL();
        public UserModel Login(string username, string password) => userDAL.Login(username, password);
        public List<UserModel> GetOnlineUsers() => userDAL.GetOnlineUsers();
        public List<UserModel> GetOfflineUsers() => userDAL.GetOfflineUser();
        public void SetUserStatus(int userId, bool isOnline) => userDAL.UpdateUserOnlineStatus(userId, isOnline);
        public UserModel GetUserById(int userId) => userDAL.GetUserById(userId);
        public UserModel GetUserByUsername(string username) => userDAL.GetUserByUsername(username);
        public int GetUserCount() => userDAL.GetUserCount();
        public UserModel GetUsername(string username) => userDAL.GetUsername(username);
        public bool IsUserExist(int userId)
        {
            var user = userDAL.GetUserById(userId);
            return user != null;
        }
    }
}