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
        DataSet callDbWithValue(string cmdText)
        {
            SqlConnection conn = new SqlConnection(strConnect);
            DataSet ds = new DataSet();
            SqlCommand sqlCmd = new SqlCommand(cmdText, conn);
            SqlDataAdapter ad = new SqlDataAdapter(sqlCmd);
            ad.Fill(ds);
            return ds;
        }
        public DataSet getOrderList()
        {
            string strSQL = "SELECT * FROM Product";
            return callDbWithValue(strSQL);
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

        public DataSet getOrderById(int id)
        {
            string cmdText = "SELECT * FROM Product WHERE ProductID = " + id;
            return callDbWithValue(cmdText);
        }
        public void updateOrder(ModelOrder data , int id)
        {
            Debug.WriteLine("editOrder");

            SqlConnection conn = new SqlConnection(strConnect);
            string cmdEdit = "UPDATE Product SET " +
                                "ProductName = '" + data.ProductName + "'," +
                                "ProductPrice = " + data.ProductPrice + "," +
                                "ProductDatail = '" + data.ProductPrice + "' " +
                               // "TypeID = " + data.TypeProduct + " " +
                             "WHERE ProductID = " + id + "";
            Debug.WriteLine(cmdEdit);
            callDb(cmdEdit);

        }

        internal void updateOrder(ModelOrder data)
        {
            throw new NotImplementedException();
        }
    }
    public class ModelOrder
    {
        private int id;
        private string productName;
        private int productPrice;
        private string productDetail;
        private int typeProduct;

        public string ProductName { get => productName; set => productName = value; }
        public int ProductPrice { get => productPrice; set => productPrice = value; }
        public string ProductDetail { get => productDetail; set => productDetail = value; }
        public int TypeProduct { get => typeProduct; set => typeProduct = value; }
        public int Id { get => id; set => id = value; }
    }
}
