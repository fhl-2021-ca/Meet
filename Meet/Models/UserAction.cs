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

        public int Status { get; set; }

        public int? duration { get; set; }


    }
}
