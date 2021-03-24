using System;

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

        public MeetingSearchModel(string meetingId, string userId, string name, string alias, int? duration, long? actionTime, bool? isSnoozed)
        {
            MeetingId = meetingId;
            UserId = userId;
            Name = name;
            Alias = alias;
            this.duration = duration;
            this.actionTime = actionTime;
            this.isSnoozed = isSnoozed;
        }

        public MeetingSearchModel(string meetingId, string userId, string name, int? duration, long? actionTime, bool? isSnoozed)
        {
            MeetingId = meetingId;
            UserId = userId;
            Name = name;
            this.duration = duration;
            this.actionTime = actionTime;
            this.isSnoozed = isSnoozed;
        }
    }
}
