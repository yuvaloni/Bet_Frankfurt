using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.OleDb;
using System.Threading;
using System.IO;

namespace Bet_Frankfurt_NewsLetter
{
    public partial class Mailer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["pass"] == "Alumot12")
                send();
        }
        public void send()
        {

            var fromAddress = new MailAddress("bet.frankfurt.newsletter@gmail.com", "בית פרנקפורט");
            const string fromPassword = "1a2b3c!?!?";
            int m = DateTime.Now.Month;
            SmtpClient c = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Path.Combine(Server.MapPath("~"), "Frankfurt.mdb") + "'");
            Con.Open();
            string children = "<h3> אירועים לילדים </h3> </br> <table>";
            OleDbCommand Com = new OleDbCommand("SELECT * FROM Children WHERE [month] = @month", Con);
            Com.Parameters.Add("@month", OleDbType.Integer).Value = m;
            OleDbDataReader r = Com.ExecuteReader();
            while (r.Read())
            {
                children += "<tr><td><h4>" + r.GetString(1) + "</h4></br><h5>" + r.GetString(2) + "</h5></br>" + r.GetString(3) + "</br></td></tr>";
            }
            children += "</table>";
            string adults = "<h3> אירועים למבוגרים </h3> </br> <table>";
            OleDbCommand Com2 = new OleDbCommand("SELECT * FROM Adults WHERE [month] = @month", Con);
            Com2.Parameters.Add("@month", OleDbType.Integer).Value = m;
            OleDbDataReader r2 = Com2.ExecuteReader();
            while (r2.Read())
            {
                adults += "<tr><td><h4>" + r2.GetString(1) + "</h4></br><h5>" + r2.GetString(2) + "</h5></br>" + r2.GetString(3) + "</br></td></tr>";
            }
            adults += "</table>";
            OleDbCommand Com3 = new OleDbCommand("SELECT * FROM Contacts", Con);
            OleDbDataReader r3 = Com3.ExecuteReader();
            while (r3.Read())
            {
                var toAddress = new MailAddress(r3.GetString(3));
                string msg = "<html Content-Type: text/html> <body>";
                if (r3.GetInt32(5) == 1)
                    msg += children;
                msg += "</br>";
                if (r3.GetInt32(6) == 1)
                    msg += adults;
                msg += "</body></html>";
                var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = "ניוזלטר מבית פרנקפורט",
                    Body = msg
                };
                message.IsBodyHtml = true;
                c.Send(message);
            }
            OleDbCommand e1 = new OleDbCommand("DELETE * FROM Children WHERE [month] = @month", Con);
            e1.Parameters.Add("@month", OleDbType.Integer).Value = m;
            e1.ExecuteNonQuery();
            OleDbCommand e2 = new OleDbCommand("DELETE * FROM Adults WHERE [month] = @month", Con);
            e2.Parameters.Add("@month", OleDbType.Integer).Value = m;
            e2.ExecuteNonQuery();
            Con.Close();
        }
    }
}