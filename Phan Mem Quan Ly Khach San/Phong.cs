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
    public partial class FrmPhong : Form
    {
        public FrmPhong()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtSoPhong.Clear();                   
        }
        private void HienThiMaLoaiPhongLenCombobox()
        {
            List<LoaiPhongDTO> lstLoaiPhong = LoaiPhongBUS.LayDSLoaiPhong();
            cmbMaLoaiPhong.DataSource = lstLoaiPhong;
            cmbMaLoaiPhong.DisplayMember = "SMaLoaiPhong";
            cmbMaLoaiPhong.ValueMember = "SMaLoaiPhong";
        }
 
        private void HienThiPhongLenDataGrid()
        {
            List<PhongDTO> lstPhong = PhongBUS.LayDSPhong();
            dgvPhong.DataSource = lstPhong;
        }
        private void HienThiPhongLenDatagrid()
        {
            List<PhongDTO> lstPhong = PhongBUS.LayDSPhong();
            dgvPhong.DataSource = lstPhong;
            dgvPhong.Columns["SSoPhong"].HeaderText = "Số Phòng";
            dgvPhong.Columns["SMaLoaiPhong"].HeaderText = "Mã Loại Phòng";
            dgvPhong.Columns["STinhTrang"].HeaderText = "Tình Trạng";

            dgvPhong.Columns["SSoPhong"].Width = 150;
            dgvPhong.Columns["SMaLoaiPhong"].Width = 150;
            dgvPhong.Columns["STinhTrang"].Width = 250;
            
        }

        

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtSoPhong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra số phòng có độ dài chuỗi hợp lệ hay không
            if (txtSoPhong.Text.Length > 5)
            {
                MessageBox.Show("Mã phòng tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra số phòng có bị trùng không
            if (PhongBUS.TimPhongTheoMa(txtSoPhong.Text) != null)
            {
                MessageBox.Show("Số phòng đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu SoPhongDTO
            PhongDTO p = new PhongDTO();
            p.SSoPhong = txtSoPhong.Text;
            p.SMaLoaiPhong = cmbMaLoaiPhong.SelectedValue.ToString();
            p.STinhTrang = cmbTinhTrang.Text;

            // Thực hiện thêm
            if (PhongBUS.ThemPhong(p) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiPhongLenDatagrid();
            MessageBox.Show("Đã thêm phòng thành công.");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtSoPhong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }

            // Kiểm tra số phòng có bị trùng không
            if (PhongBUS.TimPhongTheoMa(txtSoPhong.Text) == null)
            {
                MessageBox.Show("Số phòng đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu PhongDTO
            PhongDTO p = new PhongDTO();
            p.SSoPhong = txtSoPhong.Text;
            p.SMaLoaiPhong = cmbMaLoaiPhong.SelectedValue.ToString();
            p.STinhTrang = cmbTinhTrang.Text;

            // Thực hiện thêm
            if (PhongBUS.CapNhatPhong(p) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            Reset();
            HienThiPhongLenDatagrid();
            MessageBox.Show("Đã cập nhật phòng thành công.");


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra số phòng có tồn tại không
            if (PhongBUS.TimPhongTheoMa(txtSoPhong.Text) == null)
            {
                MessageBox.Show("Số phòng không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu PhongDTO
            PhongDTO p = new PhongDTO();
            p.SSoPhong = txtSoPhong.Text;

            // Thực hiện xóa 
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phòng này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (PhongBUS.XoaPhong(p) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiPhongLenDatagrid();
                MessageBox.Show("Đã xóa phòng thành công.");
            }

        }

        private void dgvPhong_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvPhong.SelectedRows[0];
            txtSoPhong.Text = r.Cells["sSoPhong"].Value.ToString();
            cmbMaLoaiPhong.SelectedValue = r.Cells["sMaLoaiPhong"].Value.ToString();
            cmbTinhTrang.SelectedValue= r.Cells["STinhTrang"].Value.ToString();
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
                this.Close();
        }

        private void FrmPhong_Load(object sender, EventArgs e)
        {
            HienThiMaLoaiPhongLenCombobox();
            HienThiPhongLenDatagrid();
       

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<PhongDTO> ds = PhongBUS.LayDSPhong();
            List<PhongDTO> kq = (from p in ds
                                    where p.SSoPhong.Contains(txtTimSoPhong.Text)
                                    where p.SMaLoaiPhong.Contains(txtTimMaLP.Text)
                                    select p).ToList();
            dgvPhong.DataSource = kq;
        }
    }
}
