using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meet.Models
{
    public class MeetingDetails
    {
        public int MeetingId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string UserAlias { get; set; }

        public string MeetingTitle { get; set; }

        public string Organizer { get; set; }
        
        public bool IsActive { get; set; }

        public int? duration { get; set; }

        public long? actionTime { get; set; }

        public bool? isSnoozed { get; set; }

        public List<UserAction> userActions { get; set; }
        public List<UserAction> joinedUsers { get; set; }
        public List<UserAction> lateUsers { get; set; }
        public List<UserAction> declinedUsers { get; set; }
        public List<UserAction> noResponseUsers { get; set; }

    }
}
