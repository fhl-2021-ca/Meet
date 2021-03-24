using System;

namespace Meet.Models
{
    public class MeetingSearchModel
    {
        public string MeetingId { get; set; }

        public string UserId { get; set; }

<<<<<<< HEAD
        public int? duration { get; set; }

        public long? actionTime { get; set; }

        public bool? isSnoozed { get; set; }

        public MeetingSearchModel(string meetingId, string userId, int? duration, long? actionTime, bool? isSnoozed)
        {
            MeetingId = meetingId;
            UserId = userId;
            this.duration = duration;
            this.actionTime = actionTime;
            this.isSnoozed = isSnoozed;
=======
        public string Name { get; set; }

        public MeetingSearchModel(string meetingId, string userId, string name)
        {
            MeetingId = meetingId;
            UserId = userId;
            Name = name;
>>>>>>> 189aaf697ac4b51549443af857bc11023099d122
        }
    }
}
