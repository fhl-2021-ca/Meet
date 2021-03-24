using System;

namespace Meet.Models
{
    public class MeetingSearchModel
    {
        public string MeetingId { get; set; }

        public string UserId { get; set; }

        public MeetingSearchModel(string meetingId, string userId)
        {
            MeetingId = meetingId;
            UserId = userId;
        }
    }
}
