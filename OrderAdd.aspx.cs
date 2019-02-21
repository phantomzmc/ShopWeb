using System;
using System.Collections.Generic;
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
            OrderRepro repro = new OrderRepro();
            ModelOrder data = new ModelOrder()
            {
                productName = productName.Text,
                productPrice = 55,
                productDetail = productDetail.Text,
                typeProduct = 3
            };
            repro.insertOrder();
        }

        protected void cancal_Click(object sender, EventArgs e)
        {

        }
    }
}