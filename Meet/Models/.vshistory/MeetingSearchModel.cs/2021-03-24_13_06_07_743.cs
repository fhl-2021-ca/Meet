using System;
using System.Collections.Generic;

namespace Meet.Models
{
    public class MeetingSearchModel
    {
        public string MeetingId { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public string Alias { get; set; }

        public int? duration { get; set; }

        public long? actionTime { get; set; }

        public bool? isSnoozed { get; set; }

        public List<UserAction> userActions { get; set; }

        public List<UserAction> joinedUsers { get; set; }
        public List<UserAction> lateUsers { get; set; }
        public List<UserAction> declinedUsers { get; set; }
        public List<UserAction> noResponseUsers { get; set; }


        public MeetingSearchModel(string meetingId, string userId, string name, List<UserAction> userActions, string alias, int? duration, long? actionTime, bool? isSnoozed)
        {
            this.MeetingId = meetingId;
            this.UserId = userId;
            this.Name = name;
            this.Alias = alias;
            this.duration = duration;
            this.actionTime = actionTime;
            this.isSnoozed = isSnoozed;
            this.userActions = userActions;
        }
    }
}
