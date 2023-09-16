using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace Phan_Mem_Quan_Ly_Khach_San
{
    public partial class FrmDoiMatKhau : Form
    {
        public FrmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDoiMK_Click(object sender, EventArgs e)
        {
            //kiểm tra mật khẩu cũ đúng
            if (NguoiDung_BUS.LayNguoiDung(txtTenDangNhap.Text, txtMKCu.Text) == null)
            {
                MessageBox.Show("Mật khẩu cũ không đúng!");
                return;
            }

            //thì mới đổi
            NguoiDungDTO nd = new NguoiDungDTO();
            nd.STen = txtTenDangNhap.Text;
            nd.SMatkhau = txtMKMoi.Text;
            if (!NguoiDung_BUS.CaiLaiMkNguoiDung(nd))
            {
                MessageBox.Show("Không cập nhật được mật khẩu.");
                return;
            }
            MessageBox.Show("Đã cập nhật mật khẩu thành công.");

        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtTenDangNhap.Text = FrmMenu.NguoiDung.STen;
            txtTenDangNhap.Enabled = false;

            txtMKCu.UseSystemPasswordChar = true;
            txtMKMoi.UseSystemPasswordChar = true;

        }

        private void chkHienThiMK_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienThiMK.Checked == true)
            {
                txtMKCu.UseSystemPasswordChar = false;
                txtMKMoi.UseSystemPasswordChar = false;
            }
            else
            {
                txtMKCu.UseSystemPasswordChar = true;
                txtMKMoi.UseSystemPasswordChar = true;
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
