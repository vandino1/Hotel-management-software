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
    public partial class FrmThietBi : Form
    {
        public FrmThietBi()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtMaTB.Clear();
            txtTenTB.Clear();
            txtSoLuong.Clear();
            txtDVT.Clear();
            txtHangSX.Clear();
            
        }
        private void HienThiThietBiLenDataGrid()
        {
            List<ThietBiDTO> lstThietBi = ThietBiBUS.LayDSThietBi();
            dgvThietBi.DataSource = lstThietBi;
        }
        private void HienThiDSThietBiLenDatagrid()
        {
            List<ThietBiDTO> lstThietBi = ThietBiBUS.LayDSThietBi();
            dgvThietBi.DataSource = lstThietBi;
            dgvThietBi.Columns["SMATB"].HeaderText = "Mã Thiết Bị";
            dgvThietBi.Columns["STenTB"].HeaderText = "Tên Thiết Bị";
            dgvThietBi.Columns["ISoLuong1"].HeaderText = "Số Lượng";
            dgvThietBi.Columns["SDonViTinh"].HeaderText = "Đơn Vị Tính";
            dgvThietBi.Columns["SHangSanXuat"].HeaderText = "Hãng Sản Xuất";
            dgvThietBi.Columns["DTNamSX1"].HeaderText = "Năm Sản Xuất";

            dgvThietBi.Columns["SMATB"].Width = 100;
            dgvThietBi.Columns["STenTB"].Width = 200;
            dgvThietBi.Columns["ISoLuong1"].Width = 100;
            dgvThietBi.Columns["SDonViTinh"].Width = 150;
            dgvThietBi.Columns["SHangSanXuat"].Width = 200;
            dgvThietBi.Columns["DTNamSX1"].Width = 150;

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {   
                this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaTB.Text == "" || txtTenTB.Text == "" || txtSoLuong.Text == ""|| txtDVT.Text == ""|| txtHangSX.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã thiết bị có độ dài chuỗi hợp lệ hay không
            if (txtMaTB.Text.Length > 5)
            {
                MessageBox.Show("Mã thiết bị tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã thiết bị có bị trùng không
            if (ThietBiBUS.TimThietBiTheoMa(txtMaTB.Text) != null)
            {
                MessageBox.Show("Mã thiết bị đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu MaTBDTO
           ThietBiDTO tb = new ThietBiDTO();
            tb.SMATB = txtMaTB.Text;
            tb.STenTB = txtTenTB.Text;
            tb.ISoLuong1 = int.Parse(txtSoLuong.Text);
            tb.SDonViTinh = txtDVT.Text;
            tb.SHangSanXuat = txtHangSX.Text;
            tb.DTNamSX1 = DateTime.Parse(DTNamSX.Text);
            // Thực hiện thêm
            if (ThietBiBUS.ThemThietBi(tb) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiDSThietBiLenDatagrid();
            MessageBox.Show("Đã thêm thiết bị thành công.");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaTB.Text == "" || txtTenTB.Text == "" || txtSoLuong.Text == "" || txtDVT.Text == "" || txtHangSX.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            
            // Kiểm tra mã thiết bị có bị trùng không
            if (ThietBiBUS.TimThietBiTheoMa(txtMaTB.Text) == null)
            {
                MessageBox.Show("Mã thiết bị đã tồn tại! Vui lòng chọn số thứ tự khác.");
                return;
            }
            // Gán dữ liệu vào kiểu MaTBDTO
            ThietBiDTO tb = new ThietBiDTO();
            tb.SMATB = txtMaTB.Text;
            tb.STenTB = txtTenTB.Text;
            tb.ISoLuong1 = int.Parse(txtSoLuong.Text);
            tb.SDonViTinh = txtDVT.Text;
            tb.SHangSanXuat = txtHangSX.Text;
            tb.DTNamSX1 = DateTime.Parse(DTNamSX.Text);
            // Thực hiện thêm
            if (ThietBiBUS.CapNhatThietBi(tb) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            Reset();
            HienThiDSThietBiLenDatagrid();
            MessageBox.Show("Đã cập nhật thiết bị thành công.");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã thiết bị còn tồn tại không
            if (ThietBiBUS.TimThietBiTheoMa(txtMaTB.Text) == null)
            {
                MessageBox.Show("Mã thiết bị đã tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu MaTBDTO
            ThietBiDTO tb = new ThietBiDTO();
            tb.SMATB = txtMaTB.Text;

            // Thực hiện xóa
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa thiết bị này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (ThietBiBUS.XoaThietBi(tb) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiDSThietBiLenDatagrid();
                MessageBox.Show("Đã xóa thiết bị thành công.");
            }
        }

        private void FrmThietBi_Load(object sender, EventArgs e)
        {
            HienThiDSThietBiLenDatagrid();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<ThietBiDTO> ds = ThietBiBUS.LayDSThietBi();
            List<ThietBiDTO> kq = (from tb in ds
                                        where tb.SMATB.Contains(txtTimMaTB.Text)
                                        where tb.STenTB.Contains(txtTimTenTB.Text)
                                        select tb).ToList();
           dgvThietBi.DataSource = kq;

        }

        private void dgvThietBi_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvThietBi.SelectedRows[0];
            txtMaTB.Text = r.Cells["SMATB"].Value.ToString();
            txtTenTB.Text = r.Cells["STenTB"].Value.ToString();
            txtSoLuong.Text = r.Cells["ISoLuong1"].Value.ToString();
            txtDVT.Text = r.Cells["SDonViTinh"].Value.ToString();
            txtHangSX.Text = r.Cells["SHangSanXuat"].Value.ToString();
            DTNamSX.Text = r.Cells["DTNamSX1"].Value.ToString();

        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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
