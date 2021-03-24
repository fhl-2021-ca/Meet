using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Meet.Models
{
    public class Useraction
    {
        public int MeetingId { get; set; }

        public string UserName { get; set; }

        public string status { get; set; }

        public int? duration { get; set; }

        public long? actionTime { get; set; }


    }
}
