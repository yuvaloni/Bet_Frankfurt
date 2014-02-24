using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace Bet_Frankfurt_NewsLetter
{
    public partial class Uploaddb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yuv"] == null)
                Response.Redirect("CPANLE.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            File.WriteAllBytes(Path.Combine(Server.MapPath("~"), "Frankfurt.mdb"), FileUpload1.FileBytes);
            Response.Write("ok");
        }
    }
}