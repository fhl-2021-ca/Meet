using System;

namespace Meet.Models
{
    public class MeetingSearchModel
    {
        public string MeetingId { get; set; }

        public string UserId { get; set; }

        public string Name { get; set; }

        public MeetingSearchModel(string meetingId, string userId, string name)
        {
            MeetingId = meetingId;
            UserId = userId;
            Name = name;
        }
    }
}
