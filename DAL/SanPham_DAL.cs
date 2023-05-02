using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SanPham_DAL : DataProvider
    {
        //Phương thức xử lý load SanPham
        public DataTable LoadSanPham() 
        {
            string sChuoiTruyVan = "select * from SanPham";
            DataTable dt = new DataTable();
            dt = TruyVanDataTable(sChuoiTruyVan);
            return dt;
        }

        //Phương thức xử lý thêm SanPham
        public bool ThemSanPham(SanPham_DTO spDTO)
        {
            //B4: Tạo truy vấn và gọi về phương thức xử lý của class DataProvider.TruyVanExecuteNonQuery
            string sChuoiTruyVan = string.Format("INSERT INTO SanPham (MaSP, TenSP, DVTinh, DonGia, MaLoai) VALUES ('{0}',N'{1}',N'{2}',{3},'{4}')", spDTO.MaSP, spDTO.TenSP, spDTO.DVTinh, spDTO.DonGia, spDTO.MaLoai);
            bool ketQua = TruyVanExecuteNonQuery(sChuoiTruyVan);
            return ketQua;
        } 
        
        //Phương thức xử lý sửa SanPham
        public bool SuaSanPham(SanPham_DTO spDTO)
        {
            string sChuoiTruyVan = string.Format("UPDATE SanPham SET TenSP = N'{0}', DVTinh = N'{1}', DonGia = {2}, MaLoai = '{3}' WHERE MaSP = '{4}'", spDTO.TenSP, spDTO.DVTinh, spDTO.DonGia, spDTO.MaLoai, spDTO.MaSP);
            bool ketQua = TruyVanExecuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }

        //Phương thức xử lý xoá SanPham
        public bool XoaSanPham(SanPham_DTO spDTO)
        {
            string sChuoiTruyVan = string.Format("DELETE FROM SanPham WHERE MaSP = '{0}'", spDTO.MaSP);
            bool ketQua = TruyVanExecuteNonQuery(sChuoiTruyVan);
            return ketQua;
        }
    }
}
