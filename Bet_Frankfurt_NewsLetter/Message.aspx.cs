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
    public partial class Message : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Path.Combine(Server.MapPath("~"), "Pics"))) Directory.CreateDirectory(Path.Combine(Server.MapPath("~"), "Pics"));
            if (Session["pass"] == null)
                Response.Redirect("CPANEL.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string s = "0aA1bB2cC3dD4eE5fF6gG7hH8iI9jJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            string f = "";
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                f += s[rnd.Next(0, s.Length - 1)];
            f += ".jpg";
            File.WriteAllBytes(Path.Combine(Server.MapPath("~"), "Pics", f), FileUpload1.FileBytes);
            var fromAddress = new MailAddress("bet.frankfurt.newsletter@gmail.com", "בית פרנקפורט");
            const string fromPassword = "1a2b3c!?!?";
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
            OleDbCommand Com3 = new OleDbCommand("SELECT * FROM Contacts", Con);
            OleDbDataReader r3 = Com3.ExecuteReader();
            while (r3.Read())
            {
                try
                {

                    if (r3.GetInt32(5) == 1 && !r3.IsDBNull(3))
                    {

                        var toAddress = new MailAddress(r3.GetString(3));
                        string msg = "<html Content-Type: text/html> <body>";
                        msg += @" <br/> זוהי הודעה אוטומטית";
                        msg += @"<br/><a href='http://betfrankufrtnewsletter.apphb.com\/removeme?user=" + r3.GetString(3) + "'>אם אתה מעוניין להפסיק לקבל הודעות אלו לחץ כאן</a>";
                        msg += @"<br/> או העתק את הכתובת הבאה לשורת הדפדפן: http://betfrankufrtnewsletter.apphb.com\/removeme?user=" + r3.GetString(3);
                        msg += @"<br/><h3>" + TextBox1.Text + "</h3>";
                        msg += @"<br/>" + TextBox2.Text;
                        msg += @"<br/><img  src='http://betfrankufrtnewsletter.apphb.com/pics/" + f + "'></img>";
                        var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = TextBox1.Text,
                            Body = msg
                        };
                        message.IsBodyHtml = true;
                        c.Send(message);
                    }
                }
                catch
                {

                }
            }
            Con.Close();
            var backup = new MailMessage(fromAddress, fromAddress);
            File.Copy(Path.Combine(Server.MapPath("~"), "Frankfurt.mdb"), Path.Combine(Server.MapPath("~"), "Backup.mdb"));
            backup.Attachments.Add(new Attachment(Path.Combine(Server.MapPath("~"), "BackUp.mdb")));
            backup.Subject = "Backup " + DateTime.Now.ToString();
            c.Send(backup);
            backup.Attachments.Dispose();
            File.Delete(Path.Combine(Server.MapPath("~"), "BackUp.mdb"));
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string s = "0aA1bB2cC3dD4eE5fF6gG7hH8iI9jJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            string f = "";
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                f += s[rnd.Next(0, s.Length - 1)];
            f += ".jpg";
            File.WriteAllBytes(Path.Combine(Server.MapPath("~"), "Pics", f), FileUpload1.FileBytes);
            var fromAddress = new MailAddress("bet.frankfurt.newsletter@gmail.com", "בית פרנקפורט");
            const string fromPassword = "1a2b3c!?!?";
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
            OleDbCommand Com3 = new OleDbCommand("SELECT * FROM Contacts", Con);
            OleDbDataReader r3 = Com3.ExecuteReader();
            while (r3.Read())
            {
                try
                {
                    if (r3.GetInt32(6) == 1 && !r3.IsDBNull(3))
                    {

                        var toAddress = new MailAddress(r3.GetString(3));
                        string msg = "<html Content-Type: text/html> <body>";
                        msg += @" <br/> זוהי הודעה אוטומטית";
                        msg += @"<br/><a href='http://betfrankufrtnewsletter.apphb.com\/removeme?user=" + r3.GetString(3) + "'>אם אתה מעוניין להפסיק לקבל הודעות אלו לחץ כאן</a>";
                        msg += @"<br/> או העתק את הכתובת הבאה לשורת הדפדפן: http://betfrankufrtnewsletter.apphb.com\/removeme?user=" + r3.GetString(3);
                        msg += @"<br/><h3>" + TextBox1.Text + "</h3>";
                        msg += @"<br/>" + TextBox2.Text;
                        msg += @"<br/><img  src='http://betfrankufrtnewsletter.apphb.com/pics/" + f + "'></img>";
                        var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = TextBox1.Text,
                            Body = msg
                        };
                        message.IsBodyHtml = true;
                        c.Send(message);
                    }
                }
                catch { }
            }
            Con.Close();
            var backup = new MailMessage(fromAddress, fromAddress);
            File.Copy(Path.Combine(Server.MapPath("~"), "Frankfurt.mdb"), Path.Combine(Server.MapPath("~"), "Backup.mdb"));
            backup.Attachments.Add(new Attachment(Path.Combine(Server.MapPath("~"), "BackUp.mdb")));
            backup.Subject = "Backup " + DateTime.Now.ToString();
            c.Send(backup);
            backup.Attachments.Dispose();
            File.Delete(Path.Combine(Server.MapPath("~"), "BackUp.mdb"));
            TextBox1.Text = "";
            TextBox2.Text = "";
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string s = "0aA1bB2cC3dD4eE5fF6gG7hH8iI9jJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            string f = "";
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                f += s[rnd.Next(0, s.Length - 1)];
            f += ".jpg";
            File.WriteAllBytes(Path.Combine(Server.MapPath("~"), "Pics", f), FileUpload1.FileBytes);
            var fromAddress = new MailAddress("bet.frankfurt.newsletter@gmail.com", "בית פרנקפורט");
            const string fromPassword = "1a2b3c!?!?";
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
            OleDbCommand Com3 = new OleDbCommand("SELECT * FROM Contacts", Con);
            OleDbDataReader r3 = Com3.ExecuteReader();
            while (r3.Read())
            {
                try { 
                if (!r3.IsDBNull(3))
                {
                    var toAddress = new MailAddress(r3.GetString(3));
                    string msg = "<html Content-Type: text/html> <body>";
                    msg += @" <br/> זוהי הודעה אוטומטית";
                    msg += @"<br/><a href='http://betfrankufrtnewsletter.apphb.com\/removeme?user=" + r3.GetString(3) + "'>אם אתה מעוניין להפסיק לקבל הודעות אלו לחץ כאן</a>";
                    msg += @"<br/> או העתק את הכתובת הבאה לשורת הדפדפן: http://betfrankufrtnewsletter.apphb.com\/removeme?user=" + r3.GetString(3);
                    msg += @"<br/><h3>" + TextBox1.Text + "</h3>";
                    msg += @"<br/>" + TextBox2.Text;
                    msg += @"<br/><img  src='http://betfrankufrtnewsletter.apphb.com/pics/" + f + "'></img>";
                    var message = new MailMessage(fromAddress, toAddress)
                    {
                        Subject = TextBox1.Text,
                        Body = msg
                    };
                    message.IsBodyHtml = true;
                    c.Send(message);
                }
                    ]
                    catch{

                    }
            }
            Con.Close();
            var backup = new MailMessage(fromAddress, fromAddress);
            File.Copy(Path.Combine(Server.MapPath("~"), "Frankfurt.mdb"), Path.Combine(Server.MapPath("~"), "Backup.mdb"));
            backup.Attachments.Add(new Attachment(Path.Combine(Server.MapPath("~"), "BackUp.mdb")));
            backup.Subject = "Backup " + DateTime.Now.ToString();
            c.Send(backup);
            backup.Attachments.Dispose();
            File.Delete(Path.Combine(Server.MapPath("~"), "BackUp.mdb"));
            TextBox1.Text = "";
            TextBox2.Text = "";
        }
    }
}