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
            var userID = this.repository.UpdateUserDetails(name, alias);


            // update default status to invited
            this.repository.UpdateParticipantAwaitingStatus((Int32.Parse(meetingId)), userID);

            //Check for Valid meeting and return meeting model
            var model = repository.GetMeetingDetails((Int32.Parse(meetingId)), alias);

            return View("MeetingPageView", model);
        }

        // GET: /Meeting/Join?userId=1234&meetingId=4 
        public IActionResult Join(string meetingId, string userId)
        {
            // TODO : emit userData here
            var name = "dummyName";
            var alias = "testalias";
            List<UserAction> userActions = new List<UserAction>();
            userActions.Add(new UserAction(132, "Joined User", "alias1",  status.Joined));
            userActions.Add(new UserAction(132, "Declined User", "alias2", status.Declined));
            userActions.Add(new UserAction(132, "Late User", "alias3", status.Snooze, 5));
            userActions.Add(new UserAction(132, "NoResponse User", "alias4" , status.AwaitingResponses));

            var model = new MeetingSearchModel(meetingId, userId, name, alias, userActions, null, null, false);
            model.joinedUsers = userActions.FindAll(x => x.status.Equals("Joined"));
            model.declinedUsers = userActions.FindAll(x => x.status.Equals("Declined"));
            model.noResponseUsers = userActions.FindAll(x => x.status.Equals("Invited"));
            model.lateUsers = userActions.FindAll(x => x.status.Equals("Late"));
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
