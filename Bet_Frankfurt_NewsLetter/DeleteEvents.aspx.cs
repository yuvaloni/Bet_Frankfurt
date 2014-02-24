using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.OleDb;
using System.IO;
namespace Bet_Frankfurt_NewsLetter
{
    public partial class DeleteEvents : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ListBox1.Items.Count == 0 && ListBox2.Items.Count == 0)
            {
                OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Path.Combine(Server.MapPath("~"), "Frankfurt.mdb") + "'");
                Con.Open();
                OleDbCommand Com = new OleDbCommand("SELECT * FROM Children", Con);
                OleDbDataReader r = Com.ExecuteReader();
                while (r.Read())
                {
                    ListBox1.Items.Add(r.GetString(1));
                }
                OleDbCommand Com2 = new OleDbCommand("SELECT * FROM Adults", Con);
                OleDbDataReader r2 = Com2.ExecuteReader();
                while (r2.Read())
                {
                    ListBox2.Items.Add(r2.GetString(1));
                }
                Con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Path.Combine(Server.MapPath("~"), "Frankfurt.mdb") + "'");
            Con.Open();
            foreach (ListItem n in ListBox1.Items)
            {
                if (n.Selected)
                {

                    OleDbCommand Com = new OleDbCommand("DELETE * FROM Children WHERE [event] = @n", Con);
                    Com.Parameters.Add(new OleDbParameter("@n", OleDbType.WChar)).Value = n.Text;
                    Com.ExecuteNonQuery();
                    ListBox1.Items.Remove(n);
                    break;

                }

            }
            foreach (ListItem n in ListBox2.Items)
            {
                if (n.Selected)
                {

                    OleDbCommand Com = new OleDbCommand("DELETE * FROM Adults WHERE [event] = @n", Con);
                    Com.Parameters.Add(new OleDbParameter("@n", OleDbType.WChar)).Value = n.Text;
                    Com.ExecuteNonQuery();
                    ListBox2.Items.Remove(n);
                    break;

                }
            }



        }
    }
}