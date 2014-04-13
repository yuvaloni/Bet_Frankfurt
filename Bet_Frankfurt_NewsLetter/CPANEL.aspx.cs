using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bet_Frankfurt_NewsLetter
{
    public partial class CPANEL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "Alumot12")
            {

                Session["pass"] = "yes";
                Response.Redirect("AddEvent.aspx");

            }
            else
                Response.Write("סיסמה שגויה");
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (TextBox1.Text == "Alumot12")
            {
                Session["pass"] = "yes";
                Response.Redirect("DeleteEvents.aspx");

            }
            else
                Response.Write("סיסמה שגויה");
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
                        if (TextBox1.Text == "Alumot12")
            {
                Session["pass"] = "yes";
                Response.Redirect("People.aspx");

            }
            else
                Response.Write("סיסמה שגויה");
        }
        }
        }
    }
}

