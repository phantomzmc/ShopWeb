using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ShopCafeWebForm
{
    public class OrderRepro
    {
  
        string strConnect = WebConfigurationManager.ConnectionStrings["connStrMyDB"].ConnectionString;
        public DataSet getOrderList()
        {
            string strSQL = "SELECT * FROM Product";

            SqlConnection conn = new SqlConnection(strConnect);
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = new SqlCommand(strSQL, conn);
            SqlDataAdapter ad = new SqlDataAdapter(sqlCmd);
            ad.Fill(ds);
            return ds;
        }

        

        public void insertOrder(ModelOrder data)
        {
            SqlConnection conn = new SqlConnection(strConnect);
            string cmdText = "INSERT INTO Product(ProductName,ProductPrice,ProductDetail,TypeID) VALUES (@productName,@productPrice,@productDetail,@typeProduct)";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.AddWithValue("@productName", data.productName);
            cmd.Parameters.AddWithValue("@productPrice", data.productPrice);
            cmd.Parameters.AddWithValue("@productDetail", data.productDetail);
            cmd.Parameters.AddWithValue("@typeProduct", data.typeProduct);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();

        }
        }
    public class ModelOrder
    {
        public string productName { get; set; }
        public int productPrice { get; set; }
        public string productDetail { get; set; }
        public int typeProduct { get; set; }
    }
}