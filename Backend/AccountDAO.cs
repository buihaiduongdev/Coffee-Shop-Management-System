using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Management_System.Backend
{
    public class AccountDAO
    {
        // Trả về Employee nếu đăng nhập đúng, null nếu sai
        public static Employee CheckEmployeeLogin(string username, string password)
        {
            string query = "SELECT * FROM Employees WHERE Username = @username AND Password = @password";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];

                int id = Convert.ToInt32(row["EmployeeID"]);
                string lastName = row["LastName"].ToString();
                string firstName = row["FirstName"].ToString();
                string phone = row["Phone"].ToString();
                byte[] image = row["Image"] as byte[];
                decimal salary = Convert.ToDecimal(row["Salary"]);
                string role = row["Role"].ToString();

                return new Employee(id, username, password, lastName, firstName, phone, image, salary, role);
            }

            return null;
        }

        // Trả về true nếu login đúng customer, hoặc bạn có thể trả về một Customer object tùy mục đích
        public static CustomerInfo CheckCustomerLogin(string username, string password)
        {
            string query = "SELECT * FROM Customers WHERE Username = @username AND Password = @password";

            SqlParameter[] parameters = new SqlParameter[]
            {
            new SqlParameter("@username", username),
            new SqlParameter("@password", password)
            };

            DataTable dt = DatabaseHelper.ExecuteQuery(query, parameters);
            if (dt.Rows.Count == 1)
            {
                DataRow row = dt.Rows[0];

                int id = Convert.ToInt32(row["CustomerID"]);
                string lastName = row["LastName"].ToString();
                string firstName = row["FirstName"].ToString();
                string phone = row["Phone"].ToString();
                byte[] image = row["Image"] as byte[];
                string rank = row["Rank"].ToString();

                return new CustomerInfo(id, username, password, lastName, firstName, phone, image, rank);
            }

            return null;
        }
    }

}
