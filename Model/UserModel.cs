
namespace Model
{

    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public DateTime BirthDate { get; set; }
        public string Bio { get; set; }
        public string Status { get; set; }

        public bool IsOnline { get; set; }
        public UserModel() { }

    }

}