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
    public partial class FrmChucVu : Form
    {
        public FrmChucVu()
        {
            InitializeComponent();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn thoát không?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)
                this.Close();
        }
        private void Reset()
        {
            txtMaCV.Clear();
            txtTenCV.Clear();
            txtSDT.Clear();
        }

        private void FrmChucVu_Load(object sender, EventArgs e)
        {
            HienThiChucVuLenDataGrid();
        }
        private void HienThiChucVuLenDataGrid()
        {
            List<ChucVuDTO> lstChucVu = ChucVuBUS.LayChucVu();
            dgvChucVu.DataSource = lstChucVu;
            
            dgvChucVu.DataSource = lstChucVu;
            dgvChucVu.Columns["SMaCV"].HeaderText = "Mã Chức Vụ";
            dgvChucVu.Columns["STenCV"].HeaderText = "Tên Chức Vụ";
            dgvChucVu.Columns["SSDT"].HeaderText = "Số Điện Thoại";
            dgvChucVu.Columns["SMaCV"].Width = 150;
            dgvChucVu.Columns["STenCV"].Width = 200;
            dgvChucVu.Columns["SSDT"].Width = 300;
        }     
      

        private void btnThoat_Click_1(object sender, EventArgs e)
        {         
                this.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaCV.Text == "" || txtTenCV.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã chức vụ có độ dài chuỗi hợp lệ hay không
            if (txtMaCV.Text.Length > 5)
            {
                MessageBox.Show("Mã chức vụ tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã chuc vu có bị trùng không
            if (ChucVuBUS.TimChucVuTheoMa(txtMaCV.Text) != null)
            {
                MessageBox.Show("Mã chức vụ đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            if (txtSDT.Text.Length > 10 || txtSDT.Text.Length <= 9)
            {
                MessageBox.Show("Số điện thoại phải phải có đủ 10 chữ số");
                return;
            }
            // Gán dữ liệu vào kiểu ChucVuDTO
            ChucVuDTO cv = new ChucVuDTO();
            cv.SMaCV = txtMaCV.Text;
            cv.STenCV = txtTenCV.Text;
            cv.SSDT = txtSDT.Text;
            
            // Thực hiện thêm
            if (ChucVuBUS.ThemChucVu(cv) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiChucVuLenDataGrid();
            MessageBox.Show("Đã thêm chức vụ thành công.");
           
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaCV.Text == "" || txtTenCV.Text == "" || txtSDT.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
           
            // Kiểm tra mã chuc vu có bị trùng không
            if (ChucVuBUS.TimChucVuTheoMa(txtMaCV.Text) == null)
            {
                MessageBox.Show("Mã chức vụ đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            if (txtSDT.Text.Length > 10 || txtSDT.Text.Length <= 9)
            {
                MessageBox.Show("Số điện thoại phải phải có đủ 10 chữ số");
                return;
            }
            // Gán dữ liệu vào kiểu ChucVuDTO
            ChucVuDTO cv = new ChucVuDTO();
            cv.SMaCV = txtMaCV.Text;
            cv.STenCV = txtTenCV.Text;
            cv.SSDT = txtSDT.Text;

            // Thực hiện thêm
            if (ChucVuBUS.CapNhatChucVu(cv) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            Reset();
            HienThiChucVuLenDataGrid();
            MessageBox.Show("Đã cập nhật chức vụ thành công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã chức vụ có tồn tại không
            if (ChucVuBUS.TimChucVuTheoMa(txtMaCV.Text) == null)
            {
                MessageBox.Show("Mã chức vụ không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu ChucVuDTO
            ChucVuDTO cv = new ChucVuDTO();
            cv.SMaCV = txtMaCV.Text;

            // Thực hiện xóa 
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa chức vụ này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (ChucVuBUS.XoaChucVu(cv) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiChucVuLenDataGrid();
                MessageBox.Show("Đã xóa chức vụ thành công.");
            }

        }

        private void dgvChucVu_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvChucVu.SelectedRows[0];
            txtMaCV.Text = r.Cells["sMaCV"].Value.ToString();
            txtTenCV.Text = r.Cells["sTenCV"].Value.ToString();
            txtSDT.Text = r.Cells["sSDT"].Value.ToString();
            
        }

        private void txtSDT_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Cho phép đánh giá trị là số và có thể xóa nó
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;//cho phép đánh vào textbox
            }
            else
            {
                e.Handled = true;//Không cho đánh dữ liệu vào và hiển thị thông báo.
                MessageBox.Show("Xin vui lòng nhập số vào !");
            }               
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<ChucVuDTO> ds = ChucVuBUS.LayChucVu();
            List<ChucVuDTO> kq = (from dkp in ds
                                   where dkp.SMaCV.Contains(txtTimMa.Text)
                                   where dkp.STenCV.Contains(txtTimTen.Text)
                                   select dkp).ToList();
            dgvChucVu.DataSource = kq;
        }    
    }
}
