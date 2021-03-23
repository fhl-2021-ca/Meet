using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meet.Models
{
    public class MeetingDetails
    {
        public int MeetingId { get; set; }

        public string MeetingTitle { get; set; }

        public string Organizer { get; set; }

        public bool IsActive { get; set; }

        public int? duration { get; set; }

    }
}
