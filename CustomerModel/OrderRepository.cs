using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.CustomerModel
{
    internal class OrderRepository
    {
        private readonly string _connectionString;

        public OrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        //public List<orderdetailInfo> GetOrderDetails(int orderId)
        //{
        //    List<orderdetailInfo> details = new List<orderdetailInfo>();

        //    using (SqlConnection conn = new SqlConnection(_connectionString))
        //    {
        //        string sql = @"SELECT od.*, p.ProductName 
        //                      FROM [Order Details] od
        //                      INNER JOIN Products p ON od.ProductID = p.ProductID
        //                      WHERE od.OrderID = @OrderID";

        //        SqlCommand cmd = new SqlCommand(sql, conn);
        //        cmd.Parameters.AddWithValue("@OrderID", orderId);

        //        conn.Open();
        //        SqlDataReader reader = cmd.ExecuteReader();

        //        while (reader.Read())
        //        {
        //            details.Add(new orderdetailInfo
        //            {
        //                OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]),
        //                ProductID = Convert.ToInt32(reader["ProductID"]),
        //                roductName = reader["ProductName"].ToString(),
        //                UnitPrice = Convert.ToDecimal(reader["UnitPrice"]),
        //                Quantity = Convert.ToInt32(reader["Quantity"]),
        //                Ice = reader["Ice"].ToString(),
        //                Size = reader["Size"].ToString(),
        //                Sugar = reader["Sugar"].ToString()
        //            });
        //        }
        //    }

        //    return details;
        //}
    }
}
