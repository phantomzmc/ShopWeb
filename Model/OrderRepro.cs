using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Diagnostics;



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
        void callDb(string cmdText)
        {
            SqlConnection conn = new SqlConnection(strConnect);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }


        public void insertOrder(ModelOrder data)
        {
            SqlConnection conn = new SqlConnection(strConnect);
            string cmdTextRaw = "INSERT INTO Product(ProductName,ProductPrice,ProductDatail,TypeID) VALUES ('" + data.ProductName + "'," + data.ProductPrice + ",'" + data.ProductDetail + "'," + data.TypeProduct + ")";
            Debug.WriteLine(cmdTextRaw);
            callDb(cmdTextRaw);
        }

        public void deleteOrder(int id)
        {
            SqlConnection conn = new SqlConnection(strConnect);
            string cmdDel = "DELETE FROM Product WHERE ProductID = " + id;
            Debug.WriteLine(id);
            callDb(cmdDel);
        }
    }
    public class ModelOrder
    {
        private string productName;
        private int productPrice;
        private string productDetail;
        private int typeProduct;

        public string ProductName { get => productName; set => productName = value; }
        public int ProductPrice { get => productPrice; set => productPrice = value; }
        public string ProductDetail { get => productDetail; set => productDetail = value; }
        public int TypeProduct { get => typeProduct; set => typeProduct = value; }
    }
}
