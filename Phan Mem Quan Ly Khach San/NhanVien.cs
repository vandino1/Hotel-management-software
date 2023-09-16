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
    public partial class FrmNhanVien : Form
    {
        public FrmNhanVien()
        {
            InitializeComponent();
        }     
        private void Reset()
        {
            txtMaNV.Clear();
            txtHoNV.Clear();
            txtTenNV.Clear();
            txtCMND.Clear();
            txtSDT.Clear();
            txtDiaChi.Clear();
        }
        private void HienThiChucVuLenCombobox()
        {
            List<ChucVuDTO> lstChucVu = ChucVuBUS.LayChucVu();
            cmbCV.DataSource = lstChucVu;
            cmbCV.DisplayMember = "STenCV";
            cmbCV.ValueMember = "SMaCV";
        }
        private void HienThiDSNhanVienLenDatagrid()
        {
            List<NhanVienDTO> lstNhanVien = NhanVienBUS.LayDSNhanVien();
            dgvNhanVien.DataSource = lstNhanVien;
            dgvNhanVien.Columns["SMaNV"].HeaderText = "Mã số";
            dgvNhanVien.Columns["SHoNV"].HeaderText = "Họ và lót";
            dgvNhanVien.Columns["STen"].HeaderText = "Tên";
            dgvNhanVien.Columns["SGioiTinh"].HeaderText = "Phái";
            dgvNhanVien.Columns["DTNgaySinh1"].HeaderText = "Ngày sinh";
            dgvNhanVien.Columns["SCMMND"].HeaderText = "CMND";
            dgvNhanVien.Columns["SSDT"].HeaderText = "Số điện thoại";
            dgvNhanVien.Columns["SDiaChi"].HeaderText = "Địa chỉ";
            dgvNhanVien.Columns["SMaCV"].HeaderText = "Chức vụ";
            dgvNhanVien.Columns["SMaNV"].Width = 80;
            dgvNhanVien.Columns["SHoNV"].Width = 120;
            dgvNhanVien.Columns["STen"].Width = 50;
            dgvNhanVien.Columns["SGioiTinh"].Width = 50;
            dgvNhanVien.Columns["DTNgaySinh1"].Width = 120;
            dgvNhanVien.Columns["SCMMND"].Width = 120;
            dgvNhanVien.Columns["SDiaChi"].Width = 280;

        }


        private void btnThoat_Click_1(object sender, EventArgs e)
        {         
                this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaNV.Text == "" || txtHoNV.Text == "" || txtTenNV.Text == ""|| txtCMND.Text == ""|| txtSDT.Text == ""|| txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã nhân viên có độ dài chuỗi hợp lệ hay không
            if (txtMaNV.Text.Length > 5)
            {
                MessageBox.Show("Mã nhân viên tối đa 5 ký tự!");
                return;
            }
            if(txtCMND.Text.Length > 9 || txtCMND.Text.Length <=8)
            {
                MessageBox.Show("Chứng minh nhân dân phải có đủ 9 chữ số");
                return;
            }       
            if (txtSDT.Text.Length > 10 || txtSDT.Text.Length <= 9)
            {
                MessageBox.Show("Số điện thoại phải phải có đủ 10 chữ số");
                return;
            }
            // Kiểm tra mã nhân viên có bị trùng không
            if (NhanVienBUS.TimNhanVienTheoMa(txtMaNV.Text) != null)
            {
                MessageBox.Show("Mã nhân viên đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu NhanVienDTO
            NhanVienDTO nv = new NhanVienDTO();
            nv.SMaNV = txtMaNV.Text;
            nv.SHoNV = txtHoNV.Text;
            nv.STen = txtTenNV.Text;
            if (radNam.Checked == true)
            {
                nv.SGioiTinh = "Nam";
            }
            else
            {
                nv.SGioiTinh = "Nữ";
            }
            nv.DTNgaySinh1 = DateTime.Parse(DTNgaySinh.Text);
            nv.SCMMND = txtCMND.Text;
            nv.SSDT = txtSDT.Text;
            nv.SDiaChi = txtDiaChi.Text;
            nv.SMaCV = cmbCV.SelectedValue.ToString();
            // Thực hiện thêm
            if (NhanVienBUS.ThemNhanVien(nv) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiDSNhanVienLenDatagrid();
            MessageBox.Show("Đã thêm nhân viên thành công.");
        }

        private void FrmNhanVien_Load(object sender, EventArgs e)
        {
            // Combobox chức vụ
            HienThiChucVuLenCombobox();

            // Datagrid nhân viên
            HienThiDSNhanVienLenDatagrid();

        }

        private void dgvNhanVien_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvNhanVien.SelectedRows[0];
            txtMaNV.Text = r.Cells["sMaNV"].Value.ToString();
            txtHoNV.Text = r.Cells["sHoNV"].Value.ToString();
            txtTenNV.Text = r.Cells["sTen"].Value.ToString();
            if (r.Cells["sGioiTinh"].Value.ToString() == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;
            DTNgaySinh.Text = r.Cells["DTNgaySinh1"].Value.ToString();
            txtCMND.Text = r.Cells["sCMMND"].Value.ToString();
            txtSDT.Text = r.Cells["sSDT"].Value.ToString();
            txtDiaChi.Text = r.Cells["sDiaChi"].Value.ToString();
            cmbCV.SelectedValue = r.Cells["SMaCV"].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã nhân viên có tồn tại không
            if (NhanVienBUS.TimNhanVienTheoMa(txtMaNV.Text) == null)
            {
                MessageBox.Show("Mã nhân viên không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu NhanVienDTO
            NhanVienDTO nv = new NhanVienDTO();
            nv.SMaNV = txtMaNV.Text;

            // Thực hiện xóa 
            if (MessageBox.Show("Bạn có muốn xóa nhân viên này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (NhanVienBUS.XoaNhanVien(nv) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiDSNhanVienLenDatagrid();
                MessageBox.Show("Đã xóa nhân viên thành công.");
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<NhanVienDTO> ds = NhanVienBUS.LayDSNhanVien();
            List<NhanVienDTO> kq = (from nv in ds
                                    where nv.SHoNV.Contains(txtTimHoNV.Text)
                                    where nv.STen.Contains(txtTimTenNV.Text)
                                    select nv).ToList();
            dgvNhanVien.DataSource = kq;

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaNV.Text == "" || txtHoNV.Text == "" || txtTenNV.Text == "" || txtCMND.Text == "" || txtSDT.Text == "" || txtDiaChi.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            if (txtSDT.Text.Length > 10 || txtSDT.Text.Length <= 9)
            {
                MessageBox.Show("Số điện thoại phải phải có đủ 10 chữ số");
                return;
            }
            // Kiểm tra mã nhân viên có tồn tại không
            if (NhanVienBUS.TimNhanVienTheoMa(txtMaNV.Text) == null)
            {
                MessageBox.Show("Mã nhân viên không tồn tại");
                return;
            }
            // Gán dữ liệu vào kiểu NhanVienDTO
            NhanVienDTO nv = new NhanVienDTO();
            nv.SMaNV = txtMaNV.Text;
            nv.SHoNV = txtHoNV.Text;
            nv.STen = txtTenNV.Text;
            if (radNam.Checked == true)
            {
                nv.SGioiTinh = "Nam";
            }
            else
            {
                nv.SGioiTinh = "Nữ";
            }
            nv.DTNgaySinh1 = DateTime.Parse(DTNgaySinh.Text);
            nv.SCMMND = txtCMND.Text;
            nv.SSDT = txtSDT.Text;
            nv.SDiaChi = txtDiaChi.Text;
            nv.SMaCV = cmbCV.SelectedValue.ToString();
            // Thực hiện cập nhật
            if (NhanVienBUS.CapNhatNhanVien(nv) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            Reset();
            HienThiDSNhanVienLenDatagrid();
            MessageBox.Show("Đã cập nhật nhân viên thành công.");
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
    }
}
