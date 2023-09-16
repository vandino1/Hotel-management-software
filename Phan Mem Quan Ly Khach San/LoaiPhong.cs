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
using BUS;

namespace Phan_Mem_Quan_Ly_Khach_San
{
    public partial class FrmLoaiPhong : Form
    {
        public FrmLoaiPhong()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtMaLP.Clear();
            txtTenLP.Clear();
            txtDonGia.Clear();
            txtDonViTinh.Clear();
        }
        private void HienThiLoaiPhongLenDataGrid()
        {
            List<LoaiPhongDTO> lstLoaiPhong = LoaiPhongBUS.LayDSLoaiPhong();
            dgvLoaiPhong.DataSource = lstLoaiPhong;
        }
        private void HienThiLoaiPhongLenDatagrid()
        {
            List<LoaiPhongDTO> lstLoaiPhong = LoaiPhongBUS.LayDSLoaiPhong();
            dgvLoaiPhong.DataSource = lstLoaiPhong;
            dgvLoaiPhong.Columns["SMaLoaiPhong"].HeaderText = "Mã Loại Phòng";
            dgvLoaiPhong.Columns["STenLoaiPhong"].HeaderText = "Tên Loại Phòng";
            dgvLoaiPhong.Columns["IDonGia"].HeaderText = "Đơn giá";
            dgvLoaiPhong.Columns["SDonViTinh"].HeaderText = "Đơn Vị Tính";

            dgvLoaiPhong.Columns["SMaLoaiPhong"].Width = 180;
            dgvLoaiPhong.Columns["STenLoaiPhong"].Width = 250;
            dgvLoaiPhong.Columns["IDonGia"].Width = 200;
            dgvLoaiPhong.Columns["SDonViTinh"].Width = 120;

        }



        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaLP.Text == "" || txtTenLP.Text == "" || txtDonGia.Text == "" || txtDonViTinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã loại phòng có độ dài chuỗi hợp lệ hay không
            if (txtMaLP.Text.Length > 5)
            {
                MessageBox.Show("Mã loại phòng tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã loại phòng có bị trùng không
            if (LoaiPhongBUS.TimLoaiPhongTheoMa(txtMaLP.Text) != null)
            {
                MessageBox.Show("Mã Loại Phòng đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu NhanVienDTO
            LoaiPhongDTO lp = new LoaiPhongDTO();
            lp.SMaLoaiPhong = txtMaLP.Text;
            lp.STenLoaiPhong = txtTenLP.Text;
            lp.IDonGia = int.Parse(txtDonGia.Text);
            lp.SDonViTinh = txtDonViTinh.Text;


            // Thực hiện thêm
            if (LoaiPhongBUS.ThemLoaiPhong(lp) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiLoaiPhongLenDatagrid();
            MessageBox.Show("Đã thêm loại phòng thành công.");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaLP.Text == "" || txtTenLP.Text == "" || txtDonGia.Text == "" || txtDonViTinh.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }

            // Kiểm tra mã loại phòng có bị trùng không
            if (LoaiPhongBUS.TimLoaiPhongTheoMa(txtMaLP.Text) == null)
            {
                MessageBox.Show("Mã Loại Phòng đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu LoaiPhongDTO
            LoaiPhongDTO lp = new LoaiPhongDTO();
            lp.SMaLoaiPhong = txtMaLP.Text;
            lp.STenLoaiPhong = txtTenLP.Text;
            lp.IDonGia = int.Parse(txtDonGia.Text);
            lp.SDonViTinh = txtDonViTinh.Text;


            // Thực hiện thêm
            
                if (LoaiPhongBUS.CapNhatLoaiPhong(lp) == false)
                {
                    MessageBox.Show("Không cập nhật được.");
                    return;
                }
                Reset();
                HienThiLoaiPhongLenDatagrid();
                MessageBox.Show("Đã cập nhật loại phòng thành công.");
            

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã chức vụ có tồn tại không
            if (LoaiPhongBUS.TimLoaiPhongTheoMa(txtMaLP.Text) == null)
            {
                MessageBox.Show("Mã Loại Phòng không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu LoaiPhongDTO
            LoaiPhongDTO lp = new LoaiPhongDTO();
            lp.SMaLoaiPhong = txtMaLP.Text;
            // Thực hiện xóa
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa loại phòng này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (LoaiPhongBUS.XoaLoaiPhong(lp) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiLoaiPhongLenDatagrid();
                MessageBox.Show("Đã xóa loại phòng thành công.");
            }

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {      
                this.Close();
        }

        private void FrmLoaiPhong_Load(object sender, EventArgs e)
        {
            HienThiLoaiPhongLenDatagrid();

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<LoaiPhongDTO> ds = LoaiPhongBUS.LayDSLoaiPhong();
            List<LoaiPhongDTO> kq = (from lp in ds
                                 where lp.SMaLoaiPhong.Contains(txtTimMaLP.Text)
                                 where lp.STenLoaiPhong.Contains(txtTimTenLP.Text)
                                 select lp).ToList();
            dgvLoaiPhong.DataSource = kq;
        }

        private void dgvLoaiPhong_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvLoaiPhong.SelectedRows[0];
            txtMaLP.Text = r.Cells["SMaLoaiPhong"].Value.ToString();
            txtTenLP.Text = r.Cells["STenLoaiPhong"].Value.ToString();
            txtDonGia.Text = r.Cells["IDonGia"].Value.ToString();
            txtDonViTinh.Text = r.Cells["SDonViTinh"].Value.ToString();
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

