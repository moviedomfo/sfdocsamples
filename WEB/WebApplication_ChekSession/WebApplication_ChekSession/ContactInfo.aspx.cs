using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace WebApplication_ChekSession
{
    public partial class ContactInfo : System.Web.UI.Page
    {

        public string LIST2;
        protected void Page_Load(object sender, EventArgs e)
        {
            

            StringBuilder str = new StringBuilder();

            
            

            str.Clear();
            Contact c = (Contact)Session["Contact"];
            if (c != null)
            {
                str.AppendLine(String.Concat("ContactID :", c.ContactID));
                str.AppendLine(String.Concat("FirstName :", c.FirstName));
                str.AppendLine(String.Concat("LastName :", c.LastName));
                str.AppendLine(String.Concat("Phone :", c.Phone));
            }
            else
            {
                str.AppendLine(" Se perdieron los datos del contacto");
            }
            LIST2 = str.ToString();

        }
    }
}
