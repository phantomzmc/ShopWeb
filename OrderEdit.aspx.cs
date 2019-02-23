using ShopCafeWebForm.Controller;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;


namespace ShopCafeWebForm
{
    public partial class EditCoffee : BaseController
    {
        
        OrderRepro movieRepo = new OrderRepro();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                setData();
            }
        }

        void setData()
        {
            try
            {
                string paramId = Request["id"];
                int id = 0;
                if (string.IsNullOrEmpty(paramId) || !int.TryParse(paramId, out id))
                {
                    showAlertError("alertIdErr", "ไม่พบข้อมูลรายการภาพยนต์นี้");
                    return;
                }
                else
                {
                    id = int.Parse(paramId);
                }
                var data = movieRepo.getOrderById(id);
                if (data.Tables[0].Rows.Count == 0)
                {
                    showAlertError("alertIdErr", "ไม่พบข้อมูลรายการภาพยนต์นี้");
                    return;
                }
                var row = data.Tables[0].Rows[0];
                productName.Text = row["ProductName"].ToString();
                productPrice.Text = row["ProductPrice"].ToString();
                productDetail.Text = row["ProductDetail"].ToString();
                typeProduct.Text = row["TypeProduct"].ToString();
                //txtDate.Value = ((DateTime)row["releaseDate"]).ToString("yyyy/MM/dd");
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
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate
                string paramId = Request["id"];
                int id = 0;
                if (string.IsNullOrEmpty(paramId) || !int.TryParse(paramId, out id))
                {
                    showAlertError("alertIdErr", "ไม่พบข้อมูลรายการภาพยนต์นี้");
                    return;
                }
                else
                {
                    id = int.Parse(paramId);
                }
                if (string.IsNullOrEmpty(productName.Text))
                {
                    showAlertError("alertTitleErr", "กรุณากรอกชื่อภาพยนต์");
                    return;
                }
                if (string.IsNullOrEmpty(productDetail.Text))
                {
                    showAlertError("alertDurErr", "กรุณากรอกความยาว(นาที)");
                    return;
                }
                int numDuration;
                if (!int.TryParse(productPrice.Text, out numDuration))
                {
                    showAlertError("alertDurNotNumErr", "กรุณากรอกความยาว(นาที) ให้เป็นตัวเลขเท่านั้น");
                    return;
                }
                numDuration = int.Parse(typeProduct.Text);
                if (numDuration > 200)
                {
                    showAlertError("alertMoreThen200Min", "กรุณากรอกความยาว(นาที) น้อยกว่า 200 นาที");
                    return;
                }
                else
                {
                    OrderRepro movieRepo = new OrderRepro();
                    ModelOrder data = new ModelOrder()
                    {
                        Id = id,
                        ProductName = Convert.ToString(productName.Text),
                        ProductPrice = Convert.ToInt16(productPrice.Text),
                        ProductDetail = Convert.ToString(productDetail.Text),
                        //TypeProduct = Convert.ToInt16(typeProduct.Text),

                    };
                    Debug.WriteLine(data);
                    Debug.WriteLine("update");
                    movieRepo.updateOrder(data,id);
                    Response.Redirect("~/OrderList.aspx");

                    
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