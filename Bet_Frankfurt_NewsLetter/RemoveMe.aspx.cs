using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OleDb;
using System.Data;
using System.IO;

namespace Bet_Frankfurt_NewsLetter
{
    public partial class RemoveMe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Path.Combine(Server.MapPath("~"), "Frankfurt.mdb") + "'");
            Con.Open();
            OleDbCommand Com = new OleDbCommand("DELETE * FROM Contacts WHERE [email] = @n", Con);
            Com.Parameters.Add(new OleDbParameter("@n", OleDbType.WChar)).Value = Request.QueryString["user"];
            Com.ExecuteNonQuery();
            Con.Close();
            Response.Write("הוסרת בהצלחה מרשימת התפוצה");
        }
    }
}