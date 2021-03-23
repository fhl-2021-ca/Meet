using Meet.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
namespace Meet.Repository
{
    public class MeetRepository
    {
        public MeetingDetails GetMeetingDetails(int meetingId)
        {
            var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();

            MeetingDetails details = new MeetingDetails();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from dbo.MeetingDetails where Id=meetingId and IsActive = 1";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        details.MeetingId = (int)oReader["ID"];
                        details.MeetingTitle = oReader["Title"].ToString();
                        details.Organizer = oReader["Organizer"].ToString();
                        details.IsActive = (bool)oReader["IsActive"];
                        details.duration = (int)oReader["Duration"];
                    }

                    myConnection.Close();
                }
            }
            return details;
        }

        public List<UserAction> GetParticipantStatus(int meetingId)
        {
            var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();

            List<UserAction> details = new List<UserAction>();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from dbo.UserAction where Id=meetingId";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        UserAction action = new UserAction();
                        action.MeetingId = (int)oReader["MeetingId"];
                        action.UserName = GetUserNameFromId((int)oReader["UserId"]);
                        action.Status = (int)oReader["Status"];
                        action.duration = (int)oReader["TimerDuration"];
                        details.Add(action);
                    }

                    myConnection.Close();
                }
            }
            return details;
        }

        private string GetUserNameFromId(int userId)
        {
            string userName = string.Empty;
            var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();

            MeetingDetails details = new MeetingDetails();
            using (SqlConnection myConnection = new SqlConnection(con))
            {
                string oString = "Select * from dbo.UserDetails where ID=userId";
                SqlCommand oCmd = new SqlCommand(oString, myConnection);
                myConnection.Open();
                using (SqlDataReader oReader = oCmd.ExecuteReader())
                {
                    if (oReader.HasRows)
                    {
                        userName = oReader["UserName"].ToString();
                    }


                    myConnection.Close();
                }
            }
            return userName;
        }

        public void UpdateUserDetails(UserDetails details)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=;Integrated Security=True");
            SqlCommand cmd;
            SqlCommand cmda;

            string alias = details.UserAlias;

            SqlDataAdapter da = new SqlDataAdapter("Select * from dbo.UserDetails where UserAlias=alias", con);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count < 1)
            {
                cmd = new SqlCommand("insert into UserDetails (UserName,UserAliad) values('" + details.UserName + "','" + details.UserAlias + "')", con);
                cmd.ExecuteNonQuery();
            }

            con.Close();
            return;
        }
    }
}
