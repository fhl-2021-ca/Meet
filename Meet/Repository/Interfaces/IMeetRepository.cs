using Meet.Models;

namespace Meet.Repository
{
    public interface IMeetRepository
    {
        void UpdateUserDetails(string name, string alias);

        MeetingDetails GetMeetingDetails(int meetingId, string alias);
    }
}