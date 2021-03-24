using Meet.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Meet.Controllers
{
    public class MeetingController : Controller
    {
        // GET: /Meeting/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Meeting/Search?name=Abhishek&meetingId=4 

        public IActionResult Search(string meetingId, string name, int time, long actionTime, bool? isSnoozed)
        {
            var model = new MeetingSearchModel(meetingId, name, time, actionTime, isSnoozed);
            return View("MeetingPageView", model);
        }

        // GET: /Meeting/Join?userId=1234&meetingId=4 
        public string Join(string meetingId, string userId)
        {
            // TODO : emit userData here

            return HtmlEncoder.Default.Encode($"User {userId} has joined the meeting : {meetingId}");
        }

        // GET: /Meeting/Decline?userId=1234&meetingId=4 
        public string Decline(string meetingId, string userId)
        {
            // TODO : emit userData here

            return HtmlEncoder.Default.Encode($"User {userId} has declined the meeting : {meetingId}");
        }

        // GET: /Meeting/Snooze?userId=1234&meetingId=4&time=5 
        public IActionResult Snooze(string meetingId, string userId, string time, string actionTime)
        {
            // TODO : emit userData here

            return Search(meetingId, userId, time, actionTime, true);
/*            return HtmlEncoder.Default.Encode($"User {userId} has snoozed the meeting : {meetingId} for {time} minutes at time {actionTime}");
*/        }

        // GET: /Meeting/ParticipantStatus?meetingId=4 
        public string ParticipantStatus(string meetingId)
        {
            return HtmlEncoder.Default.Encode($"Getting the status of participants for the meeting : {meetingId}");
        }


    }
}
