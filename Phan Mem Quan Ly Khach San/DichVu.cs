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
    public partial class FrmDichVu : Form
    {
        public FrmDichVu()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtMaDV.Clear();
            txtTenDV.Clear();
            txtDonViTinh.Clear();
            txtDonGia.Clear();
            txtGhiChu.Clear();          
        }
        private void HienThiDichVuLenDataGrid()
        {
            List<DichVuDTO> lstDichVu = DichVuBUS.LayDSDichVu();
            dgvDichVu.DataSource = lstDichVu;
        }
       private void HienThiDichVuLenDatagrid()
        {
            List<DichVuDTO> lstDichVu = DichVuBUS.LayDSDichVu();
            dgvDichVu.DataSource = lstDichVu;
            dgvDichVu.Columns["SMaDV"].HeaderText = "Mã Dịch Vụ";
            dgvDichVu.Columns["STenDV"].HeaderText = "Tên Dịch Vụ";
            dgvDichVu.Columns["SDonViTinh"].HeaderText = "Đơn Vị Tính";
            dgvDichVu.Columns["IDonGia"].HeaderText = "Đơn Giá";
            dgvDichVu.Columns["SGhiChu"].HeaderText = "Ghi Chú";

            dgvDichVu.Columns["SMaDV"].Width = 150;
            dgvDichVu.Columns["STenDV"].Width = 250;
            dgvDichVu.Columns["SDonViTinh"].Width = 120;
            dgvDichVu.Columns["IDonGia"].Width = 180;
            dgvDichVu.Columns["SGhiChu"].Width = 180;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {         
                this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaDV.Text == "" || txtTenDV.Text == "" ||  txtDonViTinh.Text == "" || txtDonGia.Text == ""|| txtGhiChu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã dịch vụ có độ dài chuỗi hợp lệ hay không
            if (txtMaDV.Text.Length > 5)
            {
                MessageBox.Show("Mã dịch vụ tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã dịch vụ có bị trùng không
            if (DichVuBUS.TimDichVuTheoMa(txtMaDV.Text) != null)
            {
                MessageBox.Show("Mã dịch vụ đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DichVuDTO
            DichVuDTO dv = new DichVuDTO();
            dv.SMaDV = txtMaDV.Text;          
            dv.STenDV = txtTenDV.Text;
            dv.SDonViTinh = txtDonViTinh.Text;
            dv.IDonGia = int.Parse(txtDonGia.Text);
            dv.SGhiChu = txtGhiChu.Text;

           
            // Thực hiện thêm
            if (DichVuBUS.ThemDichVu(dv) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiDichVuLenDatagrid();
            MessageBox.Show("Đã thêm dịch vụ thành công.");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaDV.Text == "" || txtTenDV.Text == "" || txtDonViTinh.Text == "" || txtDonGia.Text == "" || txtGhiChu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }

            // Kiểm tra mã dịch vụ có bị trùng không
            if (DichVuBUS.TimDichVuTheoMa(txtMaDV.Text) == null)
            {
                MessageBox.Show("Mã Dịch Vụ đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu NhanVienDTO
            DichVuDTO dv= new DichVuDTO();
            dv.SMaDV = txtMaDV.Text;
            dv.STenDV = txtTenDV.Text;
            dv.SDonViTinh = txtDonViTinh.Text;
            dv.IDonGia = int.Parse(txtDonGia.Text);
            dv.SGhiChu = txtGhiChu.Text;
            // Thực hiện thêm
            if (DichVuBUS.CapNhatDichVu(dv) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            Reset();
            HienThiDichVuLenDatagrid();
            MessageBox.Show("Đã cập nhật dịch vụ thành công.");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã dịch vụ có bị trùng không
            if (DichVuBUS.TimDichVuTheoMa(txtMaDV.Text) == null)
            {
                MessageBox.Show("Mã Dịch Vụ đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu DichVuDTO
            DichVuDTO dv = new DichVuDTO();
            dv.SMaDV = txtMaDV.Text;

            // Thực hiện thêm
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa dịch vụ này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (DichVuBUS.XoaDichVu(dv) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiDichVuLenDatagrid();
                MessageBox.Show("Đã xóa dịch vụ thành công.");
            }

        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {

            List<DichVuDTO> ds = DichVuBUS.LayDSDichVu();
            List<DichVuDTO> kq = (from dv in ds
                                     where dv.SMaDV.Contains(txtTimMaDV.Text)
                                     where dv.STenDV.Contains(txtTimTenDV.Text)
                                     select dv).ToList();
            dgvDichVu.DataSource = kq;

        }

        private void FrmDichVu_Load(object sender, EventArgs e)
        {
            HienThiDichVuLenDatagrid();
        }

        private void dgvDichVu_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvDichVu.SelectedRows[0];
            txtMaDV.Text = r.Cells["SMaDV"].Value.ToString();
            txtTenDV.Text = r.Cells["STenDV"].Value.ToString();
            txtDonViTinh.Text = r.Cells["SDonViTinh"].Value.ToString();
            txtDonGia.Text = r.Cells["IDonGia"].Value.ToString();
            txtGhiChu.Text= r.Cells["SGhiChu"].Value.ToString();

        }

        private void txtDonGia_KeyPress(object sender, KeyPressEventArgs e)
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

