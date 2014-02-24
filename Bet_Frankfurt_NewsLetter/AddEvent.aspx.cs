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
    public partial class AddEvent : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(DropDownList1.Items.Count==0)
            {
                for (int i = 1; i <= 12; i++)
                    DropDownList1.Items.Add(i.ToString());
            }

        }
        protected void AddChildren(object sender, EventArgs e)
        {


            OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source='" + Path.Combine(Server.MapPath("~"),"Frankfurt.mdb") + "'"); 
            Con.Open();
            OleDbCommand Com = new OleDbCommand("INSERT INTO Children ([event],[EventDate],[Description],[month]) VALUES (@name, @date, @description, @month)", Con);
            Com.Parameters.Add("@name", OleDbType.WChar).Value = TextBox1.Text;
            Com.Parameters.Add("@date", OleDbType.WChar).Value = TextBox2.Text;
            Com.Parameters.Add("@description", OleDbType.WChar).Value = TextBox3.Text;
            Com.Parameters.Add("@month",OleDbType.Integer).Value=DropDownList1.SelectedItem.Value;


            Com.ExecuteNonQuery();
            Con.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
        protected void AddAdults(object sender, EventArgs e)
        {

            OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=,'" + Path.Combine(Server.MapPath("~"), "Frankfurt.mdb") + "'"); 
            Con.Open();
            OleDbCommand Com = new OleDbCommand("INSERT INTO Adults ([event],[EventDate],[Description], [month]) VALUES (@name, @date, @description,@month)", Con);
            Com.Parameters.Add("@name", OleDbType.WChar).Value = TextBox1.Text;
            Com.Parameters.Add("@date", OleDbType.WChar).Value = TextBox2.Text;
            Com.Parameters.Add("@description", OleDbType.WChar).Value = TextBox3.Text;
            Com.Parameters.Add("@month", OleDbType.Integer).Value = DropDownList1.SelectedItem.Value;


            Com.ExecuteNonQuery();
            Con.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
        
    }
}