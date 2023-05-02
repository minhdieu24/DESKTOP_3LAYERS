using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiSanPham_BLL
    {
        LoaiSanPham_DAL lspDAL = new LoaiSanPham_DAL();

        //Xây dựng nghiệp vụ Load LoaiSanPham
        public DataTable LoadLoaiSanPham()
        {
            return lspDAL.LoadLoaiSanPham();
        }

    }
}
