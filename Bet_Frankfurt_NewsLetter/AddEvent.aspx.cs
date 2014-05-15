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
    public partial class AddEvent : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(Path.Combine(Server.MapPath("~"), "Pics"))) Directory.CreateDirectory(Path.Combine(Server.MapPath("~"), "Pics"));
            if (Session["pass"] == null)
                Response.Redirect("CPANEL.aspx");
            if(DropDownList1.Items.Count==0)
            {
                for (int i = 1; i <= 12; i++)
                    DropDownList1.Items.Add(i.ToString());
            }
            if (DropDownList2.Items.Count == 0)
            {
                    DropDownList2.Items.Add(1.ToString());
                
                    DropDownList2.Items.Add(15.ToString());
            }


        }
        protected void AddChildren(object sender, EventArgs e)
        {
            string s = "0aA1bB2cC3dD4eE5fF6gG7hH8iI9jJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            string f = "";
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                f += s[rnd.Next(0, s.Length - 1)];
            f += ".jpg";
            SqlConnection Con = new SqlConnection(@"Data Source=4d0a9a5b-3c6c-457c-b6e4-a32b012a926d.sqlserver.sequelizer.com;Initial Catalog=db4d0a9a5b3c6c457cb6e4a32b012a926d;Persist Security Info=True;User ID=vjyfbkussiygpjsr;Password=3ELEn7FUzjJEgnqRKdYNbfUgTNKoWgvfj2iRjVA2XnU3WrLDdoMGFcNVTDUFvr6s");
            Con.Open();
            SqlCommand Com = new SqlCommand("INSERT INTO Children ([event],[EventDate],[Description],[month],[day],[pic]) VALUES (@name, @date, @description, @month, @day,@file)", Con);
            Com.Parameters.Add("@name", SqlDbType.NVarChar).Value = TextBox1.Text;
            Com.Parameters.Add("@date", SqlDbType.NVarChar).Value = TextBox2.Text;
            Com.Parameters.Add("@description", SqlDbType.NVarChar).Value = TextBox3.Text;
            Com.Parameters.Add("@month",SqlDbType.Int).Value=DropDownList1.SelectedItem.Value;
            Com.Parameters.Add("@day", SqlDbType.Int).Value = DropDownList2.SelectedItem.Value;
            Com.Parameters.Add("@file", SqlDbType.NVarChar).Value = f;
            File.WriteAllBytes(Path.Combine(Server.MapPath("~"), "Pics", f),FileUpload1.FileBytes);

            Com.ExecuteNonQuery();
            Con.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
        protected void AddAdults(object sender, EventArgs e)
        {
            string s = "0aA1bB2cC3dD4eE5fF6gG7hH8iI9jJkKlLmMnNoOpPqQrRsStTuUvVwWxXyYzZ";
            string f = "";
            Random rnd = new Random();
            for (int i = 0; i < 5; i++)
                f += s[rnd.Next(0, s.Length - 1)];
            f += ".jpg";
            SqlConnection Con = new SqlConnection(@"Data Source=4d0a9a5b-3c6c-457c-b6e4-a32b012a926d.sqlserver.sequelizer.com;Initial Catalog=db4d0a9a5b3c6c457cb6e4a32b012a926d;Persist Security Info=True;User ID=vjyfbkussiygpjsr;Password=3ELEn7FUzjJEgnqRKdYNbfUgTNKoWgvfj2iRjVA2XnU3WrLDdoMGFcNVTDUFvr6s"); 
            Con.Open();
            SqlCommand Com = new SqlCommand("INSERT INTO Adults ([event],[EventDate],[Description], [month], [day],[pic]) VALUES (@name, @date, @description,@month, @day,@file)", Con);
            Com.Parameters.Add("@name", SqlDbType.NVarChar).Value = TextBox1.Text;
            Com.Parameters.Add("@date", SqlDbType.NVarChar).Value = TextBox2.Text;
            Com.Parameters.Add("@description", SqlDbType.NVarChar).Value = TextBox3.Text;
            Com.Parameters.Add("@month", SqlDbType.Int).Value = DropDownList1.SelectedItem.Value;
            Com.Parameters.Add("@day", SqlDbType.Int).Value = DropDownList2.SelectedItem.Value;
            Com.Parameters.Add("@file", SqlDbType.NVarChar).Value = f;
            File.WriteAllBytes(Path.Combine(Server.MapPath("~"), "Pics", f), FileUpload1.FileBytes);


            Com.ExecuteNonQuery();
            
            Con.Close();
            TextBox1.Text = "";
            TextBox2.Text = "";
            TextBox3.Text = "";
        }
        
    }
}