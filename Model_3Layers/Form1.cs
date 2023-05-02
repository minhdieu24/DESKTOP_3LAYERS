using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace Model_3Layers
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //Tạo các đối tượng từ tầng BLL, DTO
        SanPham_BLL spBLL = new SanPham_BLL();
        SanPham_DTO spDTO = null;
        LoaiSanPham_BLL lspBLL = new LoaiSanPham_BLL();
        private void Form1_Load(object sender, EventArgs e)
        {
            dgvSanPham.DataSource = spBLL.LoadSanPham();
            cmbLoaiSP.DataSource = lspBLL.LoadLoaiSanPham();
            cmbLoaiSP.DisplayMember = "TenLoai";
            cmbLoaiSP.ValueMember = "MaLoai";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            //Lấy giá trị từ các control gán vào đối tượng spDTO
            spDTO = new SanPham_DTO();
            spDTO.MaSP = txtMaSP.Text;
            spDTO.TenSP = txtTenSP.Text;
            spDTO.DVTinh = txtDVTinh.Text;
            spDTO.DonGia = int.Parse(txtDonGia.Text);
            spDTO.MaLoai = cmbLoaiSP.SelectedValue.ToString();
            
            //Gọi nghiệp vụ thêm SanPham
            //Kiểm tra đã thêm SP vào CSDL hay chưa
            if (spBLL.ThemSanPham(spDTO) == true )
            {
                MessageBox.Show("Thêm thành công", "THÔNG BÁO");
                dgvSanPham.DataSource= spBLL.LoadSanPham();
            }
            else
            {
                MessageBox.Show("Thêm thất bại", "THÔNG BÁO");
            }
        }

        private void dgvSanPham_Click(object sender, EventArgs e)
        {
            //Kiểm tra có dòng nào được chọn không
            if (dgvSanPham.SelectedRows != null)
            {
                //Load dữ liệu từ dòng được chọn trong dgv vào các control
                DataGridViewRow dr = dgvSanPham.SelectedRows[0];
                txtMaSP.Text = dr.Cells["MaSP"].Value.ToString();
                txtTenSP.Text = dr.Cells["TenSP"].Value.ToString();
                txtDVTinh.Text = dr.Cells["DVTinh"].Value.ToString();
                txtDonGia.Text = dr.Cells["DonGia"].Value.ToString();
                cmbLoaiSP.SelectedValue = dr.Cells["MaLoai"].Value;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            //B1: Lấy giá trị từ các control gán vào đối tượng spDTO
            spDTO = new SanPham_DTO();
            spDTO.MaSP = txtMaSP.Text;
            spDTO.TenSP = txtTenSP.Text;
            spDTO.DVTinh = txtDVTinh.Text;
            spDTO.DonGia = int.Parse(txtDonGia.Text);
            spDTO.MaLoai = cmbLoaiSP.SelectedValue.ToString();

            //B2: Gọi nghiệp vụ sửa SanPham
            //Kiểm tra đã sửa SP vào CSDL hay chưa
            if (spBLL.SuaSanPham(spDTO) == true)
            {
                MessageBox.Show("Sửa thành công", "THÔNG BÁO");
                dgvSanPham.DataSource = spBLL.LoadSanPham();
            }
            else
            {
                MessageBox.Show("Sửa thất bại", "THÔNG BÁO");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            spDTO = new SanPham_DTO();
            //Kiểm tra có dòng nào được chọn không
            if (dgvSanPham.SelectedRows != null)
            {
                DialogResult kq = MessageBox.Show("Bạn muốn xoá sản phẩm có mã là " + txtMaSP.Text.Trim() + "?", "THÔNG BÁO", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (kq == DialogResult.OK)
                {
                    spDTO.MaSP = txtMaSP.Text;
                    //Gọi nghiệp vụ xoá SanPham
                    //Kiểm tra đã xoá SP vào CSDL hay chưa
                    if (spBLL.XoaSanPham(spDTO) == true)
                    {
                        MessageBox.Show("Xoá thành công", "THÔNG BÁO");
                        dgvSanPham.DataSource = spBLL.LoadSanPham();
                    }
                    else
                    {
                        MessageBox.Show("Xoá thất bại", "THÔNG BÁO");
                    }
                }
            }          
        }
    }
}
