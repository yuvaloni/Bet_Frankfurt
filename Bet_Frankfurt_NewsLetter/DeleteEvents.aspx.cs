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
    public partial class DeleteEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["pass"] == null)
                Response.Redirect("CPANEL.aspx");
            if (ListBox1.Items.Count == 0 && ListBox2.Items.Count == 0)
            {
                SqlConnection Con = new SqlConnection(@"Data Source=4d0a9a5b-3c6c-457c-b6e4-a32b012a926d.sqlserver.sequelizer.com;Initial Catalog=db4d0a9a5b3c6c457cb6e4a32b012a926d;Persist Security Info=True;User ID=vjyfbkussiygpjsr;Password=3ELEn7FUzjJEgnqRKdYNbfUgTNKoWgvfj2iRjVA2XnU3WrLDdoMGFcNVTDUFvr6s"); 
                Con.Open();
                SqlCommand Com = new SqlCommand("SELECT * FROM Children", Con);
                SqlDataReader r = Com.ExecuteReader();
                while (r.Read())
                {
                    ListBox1.Items.Add(r.GetString(1));
                }
                r.Close();
                SqlCommand Com2 = new SqlCommand("SELECT * FROM Adults", Con);
                SqlDataReader r2 = Com2.ExecuteReader();
                while (r2.Read())
                {
                    ListBox2.Items.Add(r2.GetString(1));
                }
                r2.Close();
                Con.Close();
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

                    SqlCommand Com = new SqlCommand("DELETE Children WHERE [event] = @n", Con);
                    Com.Parameters.Add(new SqlParameter("@n", SqlDbType.NVarChar)).Value = n.Text;
                    Com.ExecuteNonQuery();
                    ListBox1.Items.Remove(n);
                    break;

                }

            }
            foreach (ListItem n in ListBox2.Items)
            {
                if (n.Selected)
                {

                    SqlCommand Com = new SqlCommand("DELETE Adults WHERE [event] = @n", Con);
                    Com.Parameters.Add(new SqlParameter("@n", SqlDbType.NVarChar)).Value = n.Text;
                    Com.ExecuteNonQuery();
                    ListBox2.Items.Remove(n);
                    break;

                }
            }


            Con.Close();
        }
    }
}