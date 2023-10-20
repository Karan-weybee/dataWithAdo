using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdoCourse1
{
    public partial class editData : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string id = TextBoxId.Text;
            string name = TextBoxName.Text;

            Response.Redirect("DataRetrive.aspx?idEdit=" + id + "&nameEdit=" + name);
        }
    }
}