using System;

namespace Meet.Models
{
    public class MeetingSearchModel
    {
        public string MeetingId { get; set; }

        public string UserId { get; set; }

        public int? duration { get; set; }

        public long? actionTime { get; set; }

        public bool isSnoozed { get; set; }

    }
}
