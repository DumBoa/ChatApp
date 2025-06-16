using DAL;
using Model;

public class GroupChatBLL
{
    private readonly ChatGroupDAL groupDal = new ChatGroupDAL();

    public bool CreateGroup(string groupName, string password, int creatorId) => groupDal.CreateGroup(groupName, password, creatorId);

    public bool IsGroupNameExists(string groupName) => groupDal.IsGroupExists(groupName);
    public List<GroupModel> GetGroupsByUser(int userId) => groupDal.GetGroupsByUser(userId);
    public bool AddMessageToGroup(GroupChatModel msg) => groupDal.AddMessageToGroup(msg);
    public List<GroupChatModel> GetMessagesByGroupId(int groupId) => groupDal.GetMessagesByGroupId(groupId);
    public string GetGroupName(int groupID) => groupDal.GetGroupNameById(groupID);
    public bool JoinGroup(string groupName, string password, int userId, out string errorMessage)
    {
        errorMessage = "";

        if (!groupDal.IsGroupExists(groupName))
        {
            errorMessage = "Phòng không tồn tại.";
            return false;
        }

        if (!groupDal.IsPasswordCorrect(groupName, password))
        {
            errorMessage = "Mật khẩu không đúng.";
            return false;
        }

        int groupId = groupDal.GetGroupId(groupName);
        if (groupId == -1)
        {
            errorMessage = "Không thể lấy ID phòng.";
            return false;
        }

        if (!groupDal.IsUserInGroup(groupId, userId))
        {
            groupDal.AddUserToGroup(groupId, userId);
        }

        return true;
    }

    
}
