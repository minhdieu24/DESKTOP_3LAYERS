using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;

namespace BLL
{
    public class SanPham_BLL
    {
        //Tạo đối tượng spDAL từ class SanPham_DAL ở tầng DAL
        SanPham_DAL spDAL = new SanPham_DAL();

        //Xây dựng nghiệp vụ Load SanPham
        public DataTable LoadSanPham()
        {
            return spDAL.LoadSanPham();
        }

        //Xây dựng nghiệp vụ thêm SanPham
        public bool ThemSanPham(SanPham_DTO spDTO)
        {
            //Gọi phương thức xử lý từ tầng DAL_ThemSanPham()
            bool ketQua = spDAL.ThemSanPham(spDTO);
            return ketQua;
        }

        //Xây dựng nghiệp vụ cập nhật SanPham
        public bool SuaSanPham(SanPham_DTO spDTO)
        {
            //Gọi phương thức xử lý từ tầng DAL_SuaSanPham()
            bool ketQua = spDAL.SuaSanPham(spDTO);
            return ketQua;
        }

        //Xây dựng nghiệp vụ xoá SanPham
        public bool XoaSanPham(SanPham_DTO spDTO)
        {
            bool ketQua = spDAL.XoaSanPham(spDTO);
            return ketQua;
        }
    }
}
