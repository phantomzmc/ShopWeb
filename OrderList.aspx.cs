using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using ShopCafeWebForm.Controller;

namespace ShopCafeWebForm
{
    public partial class OrderList : BaseController
    {
        OrderRepro movieRepo = new OrderRepro();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fetchData();
            }


        }
        void fetchData()
        {
            GridView1.DataSource = movieRepo.getOrderList();
            GridView1.DataBind();
            Debug.WriteLine(GridView1);
            Debug.Write(GridView1);
        }
        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                var btnDelete = (Button)sender;
                var row = (GridViewRow)btnDelete.NamingContainer;
                int id = int.Parse(row.Cells[0].Text);
                movieRepo.deleteOrder(id);
                fetchData();
                showAlertSuccess("alertDelSuccess", "Delete success");
            }
            catch (SqlException sqlEx)
            {
                showAlertError("alertSqlErr", sqlEx.Message);
            }
            catch (Exception ex)
            {
                showAlertError("alertErr", ex.Message);
            }
        }
        protected void btnEdit_Click(object sender, EventArgs e)
        {
            var btnEdit = (Button)sender;
            var row = (GridViewRow)btnEdit.NamingContainer;
            int id = int.Parse(row.Cells[0].Text);
            Response.Redirect("~/OrderEdit.aspx?id=" + id);
        }
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