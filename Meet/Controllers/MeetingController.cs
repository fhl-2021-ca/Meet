﻿using Meet.Models;
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

        public IActionResult Search(string meetingId, string name, string alias, int? time = null, long? actionTime = null, bool? isSnoozed = false)
        {
            var userid = "user12345"; //To be fetched from backend using alias
            var model = new MeetingSearchModel(meetingId, userid, name, alias, time, actionTime, isSnoozed);
            return View("MeetingPageView", model);
        }

        // GET: /Meeting/Join?userId=1234&meetingId=4 
        public IActionResult Join(string meetingId, string userId)
        {
            // TODO : emit userData here
            var name = "dummyName";
            var alias = "testalias";
            var model = new MeetingSearchModel(meetingId, userId, name, alias, null, null, false);
            return View("MeetingView", model);
        }

        // GET: /Meeting/Decline?userId=1234&meetingId=4 
        public string Decline(string meetingId, string userId)
        {
            // TODO : emit userData here

            return HtmlEncoder.Default.Encode($"User {userId} has declined the meeting : {meetingId}");
        }

        // GET: /Meeting/Snooze?userId=1234&meetingId=4&time=5 
        public IActionResult Snooze(string meetingId, string name, string alias, int time, long actionTime)
        {
            // TODO : emit userData here

            return Search(meetingId, name, alias, time, actionTime, true);
        }

        // GET: /Meeting/ParticipantStatus?meetingId=4 
        public string ParticipantStatus(string meetingId)
        {
            return HtmlEncoder.Default.Encode($"Getting the status of participants for the meeting : {meetingId}");
        }


    }
}
