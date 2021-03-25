using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meet.Models
{
    public class UserAction
    {
        public int MeetingId { get; set; }

        public int UserId { get; set; }

        public string UserName { get; set; }

        public string Alias { get; set; }

        public status status { get; set; }

        public int? duration { get; set; }

        public UserAction(int meetingId, string userName, string alias, status status, int? duration = null, long? actionTime = null)
        {
            MeetingId = meetingId;
            UserName = userName;
            this.Alias = alias;
            this.status = status;
            this.duration = duration;
        }

        public UserAction()
        {
        }

    }

        public enum status
        {
            Joined = 1,
            Declined,
            Snooze,
            AwaitingResponses
        }
}
