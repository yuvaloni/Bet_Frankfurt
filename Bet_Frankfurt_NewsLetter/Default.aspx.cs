using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Data;
using System.Data.OleDb;
using System.IO;

namespace Bet_Frankfurt_NewsLetter
{
   
    public partial class _Default : Page
    {
        bool invalid1;
        bool invalid2;
        bool invalid3 = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            Session["T1"] = TextBox1.Text;
            Session["T2"] = TextBox2.Text;
            Session["T3"] = TextBox3.Text;
            Session["C1"] = CheckBox1.Checked;
            Session["C2"] = CheckBox2.Checked;
            if( Session["I1"]!=null)
                invalid1 = (bool) Session["I1"];
            if ( Session["I2"] != null)
                invalid2 = (bool) Session["I2"];
            if ( Session["I3"] != null)
                invalid3 = (bool) Session["I3"];
            if ( Session["T1"] != null)
                TextBox1.Text = (string) Session["T1"];
            if ( Session["T2"] != null)
                TextBox2.Text = (string) Session["T2"];
            if ( Session["T3"] != null)
                TextBox3.Text = (string) Session["T3"];
            if ( Session["C1"] != null)
                CheckBox1.Checked = (bool) Session["C1"];
            if ( Session["C2"] != null)
                CheckBox2.Checked = (bool) Session["C2"];
            Session["I1"] = invalid1;
            Session["I2"] = invalid2;
            Session["I3"] = invalid3;
        }
        protected void Button1_OnClick(object sender, EventArgs e)
        {

            if (!invalid1 || !invalid2 || !invalid3)
            {
                Response.Write(@"<SCRIPT LANGUAGE=""JavaScript"">alert('You have enterd some invalid details!')</SCRIPT>");
            }
            else
            {

                    string First = TextBox1.Text.Split(' ')[0];
                    string Last = TextBox1.Text.Split(' ')[1];
                    string Phone = TextBox3.Text;
                    string Email = TextBox2.Text;
                    OleDbConnection Con = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=,'"+Path.Combine(Server.MapPath("~"),"Frankfurt.mdb")+"'");
                    Con.Open();
                    OleDbCommand Com = new OleDbCommand("INSERT INTO Contacts ([first],[last],[phone],[email], [children], [adults]) VALUES (@First, @Last, @Phone, @Email, @Children, @Adults)", Con);
                   Com.Parameters.Add("@First", OleDbType.WChar).Value = First;
                   Com.Parameters.Add("@Last", OleDbType.WChar).Value = Last;
                   Com.Parameters.Add("@Email", OleDbType.WChar).Value = Email;
                Com.Parameters.Add("@Phone", OleDbType.WChar).Value = Phone==""?"No":Phone;
                   if(CheckBox1.Checked)
                       Com.Parameters.Add("@Children", OleDbType.Integer).Value = 1;
                   else
                       Com.Parameters.Add("@Children", OleDbType.Integer).Value = 0;
                   if (CheckBox2.Checked)
                       Com.Parameters.Add("@Adults", OleDbType.Integer).Value = 1;
                   else
                       Com.Parameters.Add("@Adults", OleDbType.Integer).Value = 0;


                    Com.ExecuteNonQuery();
                    Con.Close();

               

                Response.Write(
                    @"<SCRIPT LANGUAGE=""JavaScript"">alert('Thank you very much!')</SCRIPT>");

                invalid1 = false;
                invalid2 = false;
                invalid3 = true;
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
            }
        }

        protected void TextBox2_TextChanged(object sender, EventArgs e)
        {

            if (TextBox2.Text.IndexOf('@')==-1 || TextBox2.Text.IndexOf('.')==-1)
            {
                TextBox2.ForeColor = System.Drawing.Color.Red;
                TextBox2.Text = "Invalid email!";
                invalid2 = false;
            }
            else
            {
                 Session["I2"] = true;
                invalid2 = true;
                TextBox2.ForeColor = System.Drawing.Color.Green;

            }
             
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            bool t = true;


            if ( TextBox1.Text.Length == 0 || TextBox1.Text.IndexOf(' ') == -1)
            {
                TextBox1.ForeColor = System.Drawing.Color.Red;
                TextBox1.Text = "Invalid name!";
                invalid1 = false;
            }
            else
            {
                 Session["I1"] = true;
                invalid1 = true;
                TextBox1.ForeColor = System.Drawing.Color.Green;
            }

        }
         protected void TextBox3_TextChanged(object sender, EventArgs e)
        {

                 Session["I3"] = true;
                invalid3 = true;
                TextBox3.ForeColor = System.Drawing.Color.Green;
             

        }





    }
}