using Meet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace Meet.Repository
{
    public class MeetRepository : IMeetRepository
    {
        public MeetingDetails GetMeetingDetails(int meetingId, string alias)
        {
            var con = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ToString();

            MeetingDetails details = new MeetingDetails();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = $"Select * from dbo.MeetingDetails where Id={meetingId} and IsActive = 1";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                var userDetails = this.GetUserDetails(alias);
                var userAction = this.GetParticipantStatus(meetingId, alias);  // this is fetching all user details for a particular meeting id
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        details.MeetingId = (int)oReader["ID"];
                        details.MeetingTitle = oReader["Title"].ToString();
                        details.Organizer = oReader["Organizer"].ToString();
                        details.IsActive = (bool)oReader["IsActive"];
                        details.duration = (int)oReader["Duration"];
                        details.UserId = userDetails.UserId;
                        details.UserName = userDetails.UserName;
                        details.UserAlias = userDetails.UserAlias;
                        details.userActions = userAction;
                    }

                    myConnection.Close();
                }
            }
            return details;
        }

        public List<UserAction> GetParticipantStatus(int meetingId, string alias)
        {
            var con = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ToString();

            List<UserAction> details = new List<UserAction>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = $"Select * from dbo.UserAction where MeetingId = {meetingId}";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                using SqlDataReader oReader = oCmd.ExecuteReader();
                while (oReader.Read())
                {
                    UserAction action = new UserAction();
                    action.MeetingId = (int)oReader["MeetingId"];
                    var userId = (int)oReader["UserId"];
                    action.UserName = GetUserDetailsFromUserId(userId).UserName;
                    action.UserId = GetUserDetailsFromUserId(userId).UserId;
                    action.Alias = GetUserDetailsFromUserId(userId).UserAlias;
                    action.status = (status)oReader["Status"];
                    action.duration = Convert.IsDBNull(oReader["TimerDuration"]) ? null : (double?)oReader["TimerDuration"];
                    details.Add(action);
                }

                myConnection.Close();
            }
            return details;
        }

        private UserDetails GetUserDetails(string alias)
        {
            UserDetails user = new UserDetails();
            var con = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ToString();

            MeetingDetails details = new MeetingDetails();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = $"Select * from dbo.UserDetails where UserAlias='{alias}'";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader.HasRows)
                    {
                        while (oReader.Read())
                        {
                            user.UserName = oReader["UserName"].ToString();
                            user.UserAlias = oReader["UserAlias"].ToString();
                            user.UserId = (int)oReader["ID"];

                        }
                    }


                    myConnection.Close();
                }
            }
            return user;
        }

        private UserDetails GetUserDetailsFromUserId(int userId)
        {
            UserDetails user = new UserDetails();
            var con = ConfigurationManager.ConnectionStrings["SqlServerConnectionString"].ToString();

            MeetingDetails details = new MeetingDetails();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = $"Select * from dbo.UserDetails where ID='{userId}'";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader.HasRows)
                    {
                        while (oReader.Read())
                        {
                            user.UserName = oReader["UserName"].ToString();
                            user.UserAlias = oReader["UserAlias"].ToString();
                            user.UserId = (int)oReader["ID"];

                        }
                    }


                    myConnection.Close();
                }
            }
            return user;
        }

        public void UpdateUserDetails(string name, string alias)
        {
            SqlConnection con = new SqlConnection("Server=tcp:fhl2021.database.windows.net,1433;Initial Catalog=TeamsProject-FHL;Persist Security Info=False;User ID=defaultuser;Password=Helloworld@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd;

            SqlDataAdapter da = new SqlDataAdapter($"Select * from dbo.UserDetails where UserAlias='{alias}'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count < 1)
            {
                con.Open();
                cmd = new SqlCommand("insert into UserDetails (UserName,UserAlias) values('" + name + "','" + alias + "')", con);
                cmd.ExecuteNonQuery();
            }

            con.Close();
        }

        public int GetUserIdFromAlias(string alias)
        {
            SqlConnection con = new SqlConnection("Server=tcp:fhl2021.database.windows.net,1433;Initial Catalog=TeamsProject-FHL;Persist Security Info=False;User ID=defaultuser;Password=Helloworld@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd;

            SqlDataAdapter da = new SqlDataAdapter($"Select * from dbo.UserDetails where UserAlias='{alias}'", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            con.Close();
            int ID = Convert.ToInt32(ds.Tables[0].Rows[0]["ID"]);
            return ID;
        }

        public void UpdateParticipantAwaitingStatus(int meetingId, int userId)
        {
            SqlConnection con = new SqlConnection("Server=tcp:fhl2021.database.windows.net,1433;Initial Catalog=TeamsProject-FHL;Persist Security Info=False;User ID=defaultuser;Password=Helloworld@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd;

            SqlDataAdapter da = new SqlDataAdapter($"Select * from dbo.UserAction where UserId = {userId} and MeetingId = {meetingId}", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count < 1)
            {
                con.Open();
                cmd = new SqlCommand($"insert into UserAction (UserId,MeetingId,Status) values({userId}, {meetingId} , {(int)status.AwaitingResponses})", con);
                cmd.ExecuteNonQuery();
            }

            con.Close();
            return;
        }

        public void UpdateParticipantStatus(int meetingId, int userId, int Status, double? time)
        {
            SqlConnection con = new SqlConnection("Server=tcp:fhl2021.database.windows.net,1433;Initial Catalog=TeamsProject-FHL;Persist Security Info=False;User ID=defaultuser;Password=Helloworld@123;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            SqlCommand cmd;

            SqlDataAdapter da = new SqlDataAdapter($"Select * from dbo.UserAction where UserId = {userId} and MeetingId = {meetingId}", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count > 0)
            {
                con.Open();
                if((int)status.Snooze == Status)
                {
                    cmd = new SqlCommand($"update UserAction set status = {Status} , Timerduration = {time}  where UserId = {userId} and MeetingId = {meetingId}", con);
                }
                else
                {
                    cmd = new SqlCommand($"update UserAction set status = {Status}  where UserId = {userId} and MeetingId = {meetingId}", con);
                }
                cmd.ExecuteNonQuery();
            }

            con.Close();
            return;
        }
    }
}
