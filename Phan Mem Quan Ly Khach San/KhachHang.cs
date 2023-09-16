using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DTO;
using BUS;

namespace Phan_Mem_Quan_Ly_Khach_San
{
    public partial class FrmKhachHang : Form
    {
        public FrmKhachHang()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtMaKH.Clear();
            txtHoKH.Clear();
            txtTenKH.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
            txtCMND.Clear();
            txtQuocTich.Clear();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {          
                this.Close();
        }
        private void HienThiDSKhachHangLenDatagrid()
        {
            List<KhachHangDTO> lstKhachHang = KhachHangBUS.LayDSKhachHang();
            dgvKhachHang.DataSource = lstKhachHang;
            dgvKhachHang.Columns["SMaKH"].HeaderText = "Mã số";
            dgvKhachHang.Columns["SHoKH"].HeaderText = "Họ và lót";
            dgvKhachHang.Columns["STen"].HeaderText = "Tên";
            dgvKhachHang.Columns["SGioiTinh"].HeaderText = "Phái";
            dgvKhachHang.Columns["DTNgaySinh1"].HeaderText = "Ngày sinh";
            dgvKhachHang.Columns["SDiaChi"].HeaderText = "Địa chỉ";
            dgvKhachHang.Columns["SSDT"].HeaderText = "Số điện thoại";
            dgvKhachHang.Columns["SCMMND"].HeaderText = "CMND";
            dgvKhachHang.Columns["sQuocTich"].HeaderText = "Quốc Tịch";
            dgvKhachHang.Columns["SMaKH"].Width = 80;
            dgvKhachHang.Columns["SHoKH"].Width = 120;
            dgvKhachHang.Columns["STen"].Width = 50;
            dgvKhachHang.Columns["SGioiTinh"].Width = 50;
            dgvKhachHang.Columns["DTNgaySinh1"].Width = 120;
            dgvKhachHang.Columns["SCMMND"].Width = 120;         
            dgvKhachHang.Columns["SDiaChi"].Width = 280;
            

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaKH.Text == "" || txtHoKH.Text == "" || txtTenKH.Text == ""|| txtDiaChi.Text == ""||txtSDT.Text == ""|| txtCMND.Text == ""|| txtQuocTich.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã khách hàng có độ dài chuỗi hợp lệ hay không
            if (txtMaKH.Text.Length > 5)
            {
                MessageBox.Show("Mã nhân viên tối đa 5 ký tự!");
                return;
            }
            if (txtCMND.Text.Length > 9 || txtCMND.Text.Length <= 8)
            {
                MessageBox.Show("Chứng minh nhân dân phải có đủ 9 chữ số");
                return;
            }
            if (txtSDT.Text.Length > 10 || txtSDT.Text.Length <= 9)
            {
                MessageBox.Show("Số điện thoại phải phải có đủ 10 chữ số");
                return;
            }
            // Kiểm tra mã khách hàng có bị trùng không
            if (KhachHangBUS.TimKhachHangTheoMa(txtMaKH.Text) != null)
            {
                MessageBox.Show("Mã khách hàng đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu KhachHangDTO
            KhachHangDTO kh = new KhachHangDTO();
            kh.SMaKH = txtMaKH.Text;
            kh.SHoKH = txtHoKH.Text;
            kh.STen = txtTenKH.Text;
            if (radNam.Checked == true)
            {
                kh.SGioiTinh = "Nam";
            }
            else
            {
                kh.SGioiTinh = "Nữ";
            }
            kh.DTNgaySinh1 = DateTime.Parse(DTNgaySinh.Text);
            kh.SCMMND = txtCMND.Text;
            kh.SSDT = txtSDT.Text;
            kh.SDiaChi = txtDiaChi.Text;
            kh.SQuocTich = txtQuocTich.Text;
            // Thực hiện thêm
            if (KhachHangBUS.ThemKhachHang(kh) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiDSKhachHangLenDatagrid();
            MessageBox.Show("Đã thêm khách hàng thành công.");

        }

        private void FrmKhachHang_Load(object sender, EventArgs e)
        {
           
            HienThiDSKhachHangLenDatagrid();
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaKH.Text == "" || txtHoKH.Text == "" || txtTenKH.Text == "" || txtDiaChi.Text == "" || txtSDT.Text == "" || txtCMND.Text == "" || txtQuocTich.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            if (txtCMND.Text.Length > 9 || txtCMND.Text.Length <= 8)
            {
                MessageBox.Show("Chứng minh nhân dân phải có đủ 9 chữ số");
                return;
            }
            if (txtSDT.Text.Length > 10 || txtSDT.Text.Length <= 9)
            {
                MessageBox.Show("Số điện thoại phải phải có đủ 10 chữ số");
                return;
            }         
            if (KhachHangBUS.TimKhachHangTheoMa(txtMaKH.Text) == null)
            {
                MessageBox.Show("Mã khách hàng không tồn tại");
                return;
            }
            // Gán dữ liệu vào kiểu KhachHangDTO
            KhachHangDTO kh = new KhachHangDTO();
            kh.SMaKH = txtMaKH.Text;
            kh.SHoKH = txtHoKH.Text;
            kh.STen = txtTenKH.Text;
            if (radNam.Checked == true)
            {
                kh.SGioiTinh = "Nam";
            }
            else
            {
                kh.SGioiTinh = "Nữ";
            }
            kh.DTNgaySinh1 = DateTime.Parse(DTNgaySinh.Text);
            kh.SCMMND = txtCMND.Text;
            kh.SSDT = txtSDT.Text;
            kh.SDiaChi = txtDiaChi.Text;
            kh.SQuocTich = txtQuocTich.Text;
            // Thực hiện cập nhật
            if (KhachHangBUS.CapNhatKhachHang(kh) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            Reset();
            HienThiDSKhachHangLenDatagrid();
            MessageBox.Show("Đã cập nhật khách hàng thành công.");
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã khách hàng có tồn tại không
            if (KhachHangBUS.TimKhachHangTheoMa(txtMaKH.Text) == null)
            {
                MessageBox.Show("Mã khách hàng không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu KhachHangDTO
            KhachHangDTO kh = new KhachHangDTO();
            kh.SMaKH = txtMaKH.Text;

            // Thực hiện xóa 
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa khách hàng này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (KhachHangBUS.XoaKhachHang(kh) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiDSKhachHangLenDatagrid();
                MessageBox.Show("Đã xóa khách hàng thành công.");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<KhachHangDTO> ds = KhachHangBUS.LayDSKhachHang();
            List<KhachHangDTO> kq = (from kh in ds
                                    where kh.SMaKH.Contains(txtTimMaKH.Text)
                                    where kh.STen.Contains(txtTimTenKH.Text)
                                    select kh).ToList();
            dgvKhachHang.DataSource = kq;

        }

        private void dgvKhachHang_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvKhachHang.SelectedRows[0];
            txtMaKH.Text = r.Cells["SMaKH"].Value.ToString();
            txtHoKH.Text = r.Cells["SHoKH"].Value.ToString();
            txtTenKH.Text = r.Cells["STen"].Value.ToString();
            if (r.Cells["SGioiTinh"].Value.ToString() == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;
            DTNgaySinh.Text = r.Cells["DTNgaySinh1"].Value.ToString();
            txtDiaChi.Text = r.Cells["SDiaChi"].Value.ToString();
            txtSDT.Text = r.Cells["SSDT"].Value.ToString();
            txtCMND.Text = r.Cells["SCMMND"].Value.ToString();
            txtQuocTich.Text = r.Cells["SQuocTich"].Value.ToString();
           
         }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Xin vui lòng nhập số vào !");
            }
        }

        private void txtCMND_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Xin vui lòng nhập số vào !");
            }
        }
    }
}

        
    

