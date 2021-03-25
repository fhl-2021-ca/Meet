using Meet.Models;
using Meet.Repository;
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

        /// <summary>
        /// The rest activity
        /// </summary>
        private readonly IMeetRepository repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="MeetingController"/> class.
        /// </summary>
        public MeetingController(IMeetRepository repository)
        {
            this.repository = repository;
        }

        // GET: /Meeting/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Meeting/Search?name=Abhishek&alias=dummy&meetingId=4 

        public IActionResult Search(string meetingId, string name, string alias, int? time = null, long? actionTime = null, bool? isSnoozed = false)
        {
            //var userid = "user12345";

            //Update user details
            this.repository.UpdateUserDetails(name, alias);
            var userID = this.repository.GetUserIdFromAlias(alias);


            // update default status to invited
            this.repository.UpdateParticipantAwaitingStatus((Int32.Parse(meetingId)), userID);

            //Check for Valid meeting and return meeting model
            var model = repository.GetMeetingDetails((Int32.Parse(meetingId)), alias);

            return View("MeetingPageView", model);
        }

        // GET: /Meeting/Join?alias=1234&meetingId=4 
        public IActionResult Join(string meetingId, string alias)
        {
            //Get user details
            var userID = repository.GetUserIdFromAlias(alias);

            //Update status
            this.repository.UpdateParticipantStatus((Int32.Parse(meetingId)), userID, (int)status.Joined, null);

            // TODO : emit userData here
            var model = repository.GetMeetingDetails((Int16.Parse(meetingId)), alias);

            List<UserAction> userActions = model.userActions;

            if(userActions != null) { 
                model.joinedUsers = userActions.FindAll(x => x.status == status.Joined);
                model.declinedUsers = userActions.FindAll(x => x.status == status.Declined);
                model.noResponseUsers = userActions.FindAll(x => x.status == status.AwaitingResponses);
                model.lateUsers = userActions.FindAll(x => x.status == status.Snooze);
            }
            return View("MeetingView", model);
        }

        // GET: /Meeting/Decline?alias=1234&meetingId=4 
        public string Decline(string meetingId, string alias)
        {
            //Get user details
            var userID = repository.GetUserIdFromAlias(alias);

            //Update status
            this.repository.UpdateParticipantStatus((Int32.Parse(meetingId)), userID, (int)status.Declined, null);

            // TODO : emit userData here
            var model = repository.GetMeetingDetails((Int16.Parse(meetingId)), alias);

            return HtmlEncoder.Default.Encode($"User {alias} has declined the meeting : {meetingId}");
        }

        // GET: /Meeting/Snooze?userId=1234&meetingId=4&time=5 
        public IActionResult Snooze(string meetingId, string alias, int? time)
        {
            //Get user details
            var userID = repository.GetUserIdFromAlias(alias);

            //Update status
            this.repository.UpdateParticipantStatus((Int32.Parse(meetingId)), userID, (int)status.Snooze, time);

            // TODO : emit userData here
            var model = repository.GetMeetingDetails((Int16.Parse(meetingId)), alias);

            return View("MeetingPageView", model);
        }

        // GET: /Meeting/ParticipantStatus?meetingId=4 
        public string ParticipantStatus(string meetingId)
        {
            return HtmlEncoder.Default.Encode($"Getting the status of participants for the meeting : {meetingId}");
        }


    }
}
