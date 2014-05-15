using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Sql;
using System.Data;
using System.IO;
using System.Data.SqlClient;
namespace Bet_Frankfurt_NewsLetter
{
    public partial class RemoveMe : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=4d0a9a5b-3c6c-457c-b6e4-a32b012a926d.sqlserver.sequelizer.com;Initial Catalog=db4d0a9a5b3c6c457cb6e4a32b012a926d;Persist Security Info=True;User ID=vjyfbkussiygpjsr;Password=3ELEn7FUzjJEgnqRKdYNbfUgTNKoWgvfj2iRjVA2XnU3WrLDdoMGFcNVTDUFvr6s"); 
            Con.Open();
            SqlCommand Com = new SqlCommand("DELETE Contacts WHERE [email] = @n", Con);
            Com.Parameters.Add(new SqlParameter("@n", SqlDbType.NVarChar)).Value = Request.QueryString["user"];
            Com.ExecuteNonQuery();
            Con.Close();
            Response.Write("הוסרת בהצלחה מרשימת התפוצה");
        }
    }
}