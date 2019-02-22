﻿using System;
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

            OrderRepro movieRepo = new OrderRepro();

            ModelOrder data = new ModelOrder()
            {
                ProductName = Convert.ToString(productName.Text),
                ProductPrice = Convert.ToInt16(productPrice.Text) ,
                ProductDetail = Convert.ToString(productDetail.Text),
                TypeProduct = Convert.ToInt16(typeProduct.Text),
            };
            movieRepo.insertOrder(data);
        }


        protected void cancel_Click(object sender, EventArgs e)
        {
            Console.WriteLine("You click me ...................");
            System.Diagnostics.Debug.WriteLine("You click me ..................");
            System.Diagnostics.Trace.WriteLine("You click me ..................");
        }
    }
}