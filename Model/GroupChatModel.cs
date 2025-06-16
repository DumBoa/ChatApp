using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class GroupChatModel
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int SenderId { get; set; }
        public string Message { get; set; }
        public DateTime SentAt { get; set; }
    }
}
