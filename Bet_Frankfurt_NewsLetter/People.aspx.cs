using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.Sql;
using System.IO;
using System.Data.SqlClient;
namespace Bet_Frankfurt_NewsLetter
{
    public partial class People : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count == 0)
            {
                if (Session["pass"] == null)
                    Response.Redirect("CPANEL.aspx");
                SqlConnection Con = new SqlConnection(@"Data Source=4d0a9a5b-3c6c-457c-b6e4-a32b012a926d.sqlserver.sequelizer.com;Initial Catalog=db4d0a9a5b3c6c457cb6e4a32b012a926d;Persist Security Info=True;User ID=vjyfbkussiygpjsr;Password=3ELEn7FUzjJEgnqRKdYNbfUgTNKoWgvfj2iRjVA2XnU3WrLDdoMGFcNVTDUFvr6s"); 
                Con.Open();
                SqlCommand Com = new SqlCommand("SELECT * FROM Contacts", Con);
                SqlDataReader r = Com.ExecuteReader();
                while (r.Read())
                {
                    string first = r.IsDBNull(1) ? "" : r.GetString(1);
                    string last = r.IsDBNull(2) ? "" : r.GetString(2);
                    string email = r.IsDBNull(3) ? "" : r.GetString(3);
                    string phone = r.IsDBNull(4) ? "" : r.GetString(4);
                    string children =r.IsDBNull(5)?"":( r.GetInt32(5)==1?"ילדים":"");
                    string adults = r.IsDBNull(6)?"":(r.GetInt32(6) == 1 ? "מבוגרים" : "");
                    ListBox1.Items.Add(string.Format("{0}-{1}-{2}-{3}-{4}-{5}",last,first,email,phone,children,adults));
                }
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection(@"Data Source=4d0a9a5b-3c6c-457c-b6e4-a32b012a926d.sqlserver.sequelizer.com;Initial Catalog=db4d0a9a5b3c6c457cb6e4a32b012a926d;Persist Security Info=True;User ID=vjyfbkussiygpjsr;Password=3ELEn7FUzjJEgnqRKdYNbfUgTNKoWgvfj2iRjVA2XnU3WrLDdoMGFcNVTDUFvr6s"); 
            Con.Open();
            foreach (ListItem n in ListBox1.Items)
            {
                if (n.Selected)
                {
                    string v = n.ToString().Split('-')[2];

                    SqlCommand Com = new SqlCommand("DELETE Contacts WHERE [phone] = @p", Con);
                    Com.Parameters.Add(new SqlParameter("@p", SqlDbType.NVarChar)).Value = v;
                    Com.ExecuteNonQuery();
                    ListBox1.Items.Remove(n);
                    break;
                    

                }

            }
        }
    }
}