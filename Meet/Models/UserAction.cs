using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meet.Models
{
    public class UserAction
    {
        public int MeetingId { get; set; }

        public string UserName { get; set; }

        public string Alias { get; set; }

        public string status { get; set; }

        public int? duration { get; set; }

        public long? actionTime { get; set; }

        public UserAction(int meetingId, string userName, string alias, string status, int? duration = null, long? actionTime = null)
        {
            MeetingId = meetingId;
            UserName = userName;
            this.Alias = alias;
            this.status = status;
            this.duration = duration;
            this.actionTime = actionTime;
        }
    }
}
