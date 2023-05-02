using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DataProvider
    {
        //Phương thức dùng để mở kết nối đến CSDL
        public SqlConnection KetNoi()
        {
            string sChuoiKetNoi = @"Data Source=ADMIN\DAISY;Initial Catalog=DMSP;Integrated Security=True";
            SqlConnection conn = new SqlConnection(sChuoiKetNoi);
            conn.Open();
            return conn;
        }

        //Phương thức truy vấn đến CSDL trả về dataTable 
        public DataTable TruyVanDataTable(string sChuoiTruyVan)
        {
            SqlConnection conn = KetNoi();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sChuoiTruyVan, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                da.Dispose();
                conn.Close();
                return dt;
            }
            catch (Exception ex)
            {
                conn.Close();
                return null;
            }         
        }

        //Phương thức thực hiện các câu lệnh kiểm tra Insert, Update, Delete
        public bool TruyVanExecuteNonQuery(string sChuoiTruyVan)
        {
            SqlConnection conn = KetNoi();
            try
            {
                SqlCommand cmd = new SqlCommand(sChuoiTruyVan, conn);
                int iCMD = cmd.ExecuteNonQuery();
                conn.Close();
                if (iCMD > 0)
                {
                    return true;//Truy vấn thành công
                }
                else
                {
                    return false;//Truy vấn thất bại
                }
            }
            catch (Exception e)
            {
                conn.Close();
                return false;
            }
        }


        ////Phương thức truy vấn đến CSDL trả về dataTable (tương ứng với câu lệnh select) => Đối vs dữ liệu nhiều nên dùng dataReader
        //public DataTable TruyVanDataReader(string sChuoiTruyVan)
        //{
        //    SqlConnection conn = KetNoi();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(sChuoiTruyVan,conn);  
        //        SqlDataReader dr = cmd.ExecuteReader();
        //        DataTable dt = new DataTable();
        //        dt.Load(dr);
        //        conn.Close();
        //        return dt;
        //    }
        //    catch (Exception ex)
        //    {
        //        conn.Close();
        //        return null;
        //    }
        //}


        ////Phương thức trả về 1 giá trị => Dùng để đếm số dòng, tính tổng tiền, Select 1 dòng SP
        //public string TruyVanExecuteScalar(string sChuoiTruyVan)
        //{
        //    SqlConnection conn = KetNoi();
        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(sChuoiTruyVan, conn);
        //        string sKQ = cmd.ExecuteScalar().ToString();
        //        conn.Close();
        //        return sKQ;
        //    }
        //    catch (Exception e)
        //    {
        //        conn.Close();
        //        return null;
        //    }
        //}
    }
}
