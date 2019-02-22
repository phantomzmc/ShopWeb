using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ShopCafeWebForm
{
   
    public partial class OrderAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void submit_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(productName.Text))
                {
                    showAlertError("null Name","not name");
                    return;
                }
                if (string.IsNullOrEmpty(productPrice.Text))
                {
                    showAlertError("null Price", "not price");
                }
                if (string.IsNullOrEmpty(productDetail.Text))
                {
                    showAlertError("null Detail", "not detail");

                }
                if (string.IsNullOrEmpty(typeProduct.Text))
                {
                    showAlertError("null type", "not insert data");
                }
                else
                {
                    OrderRepro movieRepo = new OrderRepro();
                    ModelOrder data = new ModelOrder()
                    {
                        ProductName = Convert.ToString(productName.Text),
                        ProductPrice = Convert.ToInt16(productPrice.Text),
                        ProductDetail = Convert.ToString(productDetail.Text),
                        TypeProduct = Convert.ToInt16(typeProduct.Text),
                    };
                    movieRepo.insertOrder(data);
                    showAlertSuccess("alertSuccess", "Insert success");
                }
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

        protected void cancel_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("You click me ..................");
            System.Diagnostics.Trace.WriteLine("You click me ..................");
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