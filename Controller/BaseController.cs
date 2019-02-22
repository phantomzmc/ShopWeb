using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopCafeWebForm.Controller
{
    public partial class BaseController : System.Web.UI.Page
    {
        void showAlertSuccess(string key, string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertSuccess('" + msg + "');", true);
        }

        void showAlertError(string key, string msg)
        {
            ClientScript.RegisterStartupScript(GetType(), key, "showAlertError('" + msg + "');", true);
        }
    }

}