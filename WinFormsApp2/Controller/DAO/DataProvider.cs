using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using QuanLySuShi.Model.DTO;

namespace QuanLySuShi.Controller.DAO
{
    public class DataProvider
    {
        private static DataProvider instance;
        const string connstring = "Data Source=LAPTOP-EB636979;Initial Catalog=QLShiShu;Integrated Security=True;TrustServerCertificate=True";
        public static SqlConnection connection;


        public static DataProvider Instance
        {
            get
            {
                if (instance == null)
                    instance = new DataProvider();
                return instance;
            }
            private set
            {
                instance = value;
            }
        }
        private DataProvider() { }
        public static void OpenConnection()
        {
            connection = new SqlConnection(connstring);
            connection.Open();
        }
        public static void CloseConnection()
        {
            connection.Close();
        }

        public static DataTable ExecuteSelectQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dataTable = new DataTable();

            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand(query, connection);

                // Thêm tham số nếu có
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                adapter.Fill(dataTable);
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi truy vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            return dataTable;
        }
        public static object ExecuteScalarQuery(string query, Dictionary<string, object> parameters = null)
        {
            object result = null;

            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand(query, connection);

                // Thêm tham số nếu có
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {
                        command.Parameters.AddWithValue(param.Key, param.Value);
                    }
                }

                result = command.ExecuteScalar();  // Trả về giá trị duy nhất (Scalar)
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi truy vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            return result;
        }
        public static bool ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            bool isSuccess = false;

            try
            {
                OpenConnection();

                SqlCommand command = new SqlCommand(query, connection);

                // Thêm tham số nếu có
                if (parameters != null)
                {
                    foreach (var param in parameters)
                    {

                        command.Parameters.AddWithValue(param.Key, param.Value ?? DBNull.Value);
                    }
                }

                int affectedRows = command.ExecuteNonQuery(); // Trả về số lượng bản ghi bị ảnh hưởng
                isSuccess = affectedRows > 0;  // Kiểm tra nếu có bản ghi bị thay đổi
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message, "Lỗi truy vấn", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                CloseConnection();
            }

            return isSuccess;
        }


    }
}
