﻿using Meet.Models;

namespace Meet.Repository
{
    public interface IMeetRepository
    {
        int UpdateUserDetails(string name, string alias);

        MeetingDetails GetMeetingDetails(int meetingId, string alias);

        void UpdateParticipantAwaitingStatus(int meetingId, int userId);

        void UpdateParticipantStatus(int meetingId, int userId, int status);

        int GetUserIdFromAlias(string alias);
    }
}