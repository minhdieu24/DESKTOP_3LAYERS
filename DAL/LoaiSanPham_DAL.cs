using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiSanPham_DAL : DataProvider
    {
        //Phương thức xử lý Load LoaiSanPham
        public DataTable LoadLoaiSanPham()
        {
            string sChuoiTruyVan = "select * from LoaiSanPham";
            DataTable dt = new DataTable();
            dt = TruyVanDataTable(sChuoiTruyVan);
            return dt;
        }
    }
}
