using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace ShopCafeWebForm
{
    public partial class OrderList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fetchData();
            }


        }
        void fetchData()
        {
            OrderRepro movieRepo = new OrderRepro();
            GridView1.DataSource = movieRepo.getOrderList();
            GridView1.DataBind();
            Debug.WriteLine(GridView1);
            Debug.Write(GridView1);
        }

    }
}