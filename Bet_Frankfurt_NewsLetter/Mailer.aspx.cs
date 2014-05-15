using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using System.Data;
using System.Data.Sql;
using System.Threading;
using System.IO;
using System.Data.SqlClient;

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

            int m = DateTime.Now.Month;
            int d = DateTime.Now.Day >= 15 ? 15 : 1;
            var fromAddress = new MailAddress("bet.frankfurt.newsletter@gmail.com", "בית פרנקפורט");
            const string fromPassword = "1wJxMrhhBGwKxk2HNkk_xQ";
            SmtpClient c = new SmtpClient
            {
                Host = "smtp.mandrillapp.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            }; 
            SqlConnection Con = new SqlConnection(@"Data Source=4d0a9a5b-3c6c-457c-b6e4-a32b012a926d.sqlserver.sequelizer.com;Initial Catalog=db4d0a9a5b3c6c457cb6e4a32b012a926d;Persist Security Info=True;User ID=vjyfbkussiygpjsr;Password=3ELEn7FUzjJEgnqRKdYNbfUgTNKoWgvfj2iRjVA2XnU3WrLDdoMGFcNVTDUFvr6s"); 
            Con.Open();
            string children = "<h3> אירועים לילדים </h3> </br> <table>";
            SqlCommand Com = new SqlCommand("SELECT * FROM Children WHERE [month] = @month AND [day] = @day", Con);
            Com.Parameters.Add("@month", SqlDbType.Int).Value = m;
            Com.Parameters.Add("@day", SqlDbType.Int).Value = d;
            SqlDataReader r = Com.ExecuteReader();
            while (r.Read())
            {
                children += "<tr><td><h4>" + r.GetString(1) + "</h4></br><h5>" + r.GetString(2) + "</h5></br>" + r.GetString(3) + @"</br><img src='http://betfrankufrtnewsletter.apphb.com/pics/"+r.GetString(6)+"'></img></br></td></tr>";
            }
            children += "</table>";
            r.Close();
            string adults = "<h3> אירועים למבוגרים </h3> </br> <table>";
            SqlCommand Com2 = new SqlCommand("SELECT * FROM Adults WHERE [month] = @month AND [day] = @day", Con);
            Com2.Parameters.Add("@month", SqlDbType.Int).Value = m;
            Com2.Parameters.Add("@day", SqlDbType.Int).Value = d;
            SqlDataReader r2 = Com2.ExecuteReader();
            while (r2.Read())
            {
                adults += "<tr><td><h4>" + r2.GetString(1) + "</h4></br><h5>" + r2.GetString(2) + "</h5></br>" + r2.GetString(3) + "</br><img  src='http://betfrankufrtnewsletter.apphb.com/pics/" + r2.GetString(6) + "'></img></br></td></tr>";
            }
            adults += "</table>";
            r2.Close();
            SqlCommand Com3 = new SqlCommand("SELECT * FROM Contacts", Con);
            SqlDataReader r3 = Com3.ExecuteReader();
            while (r3.Read())
            {
                try
                {
                    var toAddress = new MailAddress(r3.GetString(3));
                    string msg = "<html Content-Type: text/html> <body>";
                    msg += @" <br/> זוהי הודעה אוטומטית";
                    msg += @"<br/><a href='http://betfrankufrtnewsletter.apphb.com\/removeme?user=" + r3.GetString(3) + "'>אם אתה מעוניין להפסיק לקבל הודעות אלו לחץ כאן</a>";
                    msg += @"</br> או העתק את הכתובת הבאה לשורת הדפדפן: http://betfrankufrtnewsletter.apphb.com\/removeme?user=" + r3.GetString(3);
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
                    r3.Close();
                } 
                catch
                {

                }
            }
            IEnumerable<string> shit =  Directory.EnumerateFiles(Path.Combine(Server.MapPath("~"), "Pics" ));
           foreach(string file in shit)
           {
            SqlCommand p11 = new SqlCommand("SELECT * FROM Adults WHERE [pic] = @f", Con);
            p11.Parameters.Add("@f",SqlDbType.NVarChar).Value=file.Split('\\')[file.Split('\\').Length-1];
            SqlDataReader rp11=p11.ExecuteReader();
            if(!rp11.Read())
            {
                             SqlCommand p21 = new SqlCommand("SELECT * FROM Children WHERE [pic] = @f", Con);
                            p21.Parameters.Add("@f",SqlDbType.NVarChar).Value=file.Split('\\')[file.Split('\\').Length-1];
                            SqlDataReader rp21=p21.ExecuteReader();
                            if(!rp21.Read()) File.Delete(file);
                            rp21.Close();
            }
            rp11.Close();
               
           }
            SqlCommand e1 = new SqlCommand("DELETE * FROM Children WHERE [month] = @month  AND [day] = @day", Con);
            e1.Parameters.Add("@month", SqlDbType.Int).Value = m;
            e1.Parameters.Add("@day", SqlDbType.Int).Value = d;

            e1.ExecuteNonQuery();
            SqlCommand e2 = new SqlCommand("DELETE * FROM Adults WHERE [month] = @month  AND [day] = @day", Con);
            e2.Parameters.Add("@month", SqlDbType.Int).Value = m;
            e2.Parameters.Add("@day", SqlDbType.Int).Value = d;

            e2.ExecuteNonQuery();
            Con.Close();
            
        }
    }
}
//shit