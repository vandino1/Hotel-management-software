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
    public partial class FrmNguoiDung : Form
    {
        public FrmNguoiDung()
        {
            InitializeComponent();
        }
        private void Reset()
        {
            txtten.Clear();
            txtmk.Clear();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void HienThiDSNguoidungLenDatagrid()
        {
            List<NguoiDungDTO> lstChucVu = NguoiDung_BUS.LayNguoiDung_XuatDS();
            dgvNguoiDung.DataSource = lstChucVu;
            cboquyen.SelectedItem = 1;

            dgvNguoiDung.Columns["STen"].HeaderText = "Tên Đăng Nhập";
            dgvNguoiDung.Columns["SMatkhau"].HeaderText = "Mật Khẩu";
            dgvNguoiDung.Columns["IQuyen"].HeaderText = "Quyền Hạn";
            dgvNguoiDung.Columns["STen"].Width = 180;
            dgvNguoiDung.Columns["SMatkhau"].Width = 300;
            dgvNguoiDung.Columns["IQuyen"].Width = 150;

        }
  

        private void btnSua_Click(object sender, EventArgs e)
        {         
            NguoiDungDTO nd = new NguoiDungDTO();
            nd.STen = txtten.Text;
            nd.IQuyen = cboquyen.SelectedIndex + 1;
            if (NguoiDung_BUS.SuaQuyenNguoiDung(nd) == false)
            {
                MessageBox.Show("Không sửa được.");
                return;
            }
            Reset();
            HienThiDSNguoidungLenDatagrid();
            MessageBox.Show("Đã sửa người dùng thành công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            NguoiDungDTO nd = new NguoiDungDTO();
            nd.STen = txtten.Text;
          
            if (NguoiDung_BUS.XoaNguoiDung(nd) == false)
            {
                MessageBox.Show("Không sửa được.");
                return;
            }
            Reset();
            HienThiDSNguoidungLenDatagrid();
            MessageBox.Show("Đã xóa người dùng thành công.");

        }

        private void FrmNguoiDung_Load(object sender, EventArgs e)
        {
            HienThiDSNguoidungLenDatagrid();
           
        }

        private void dgDSNguoidung_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int count = this.dgvNguoiDung.Rows.Count;
            if (e.RowIndex >= 0 && e.RowIndex < (count))
            {
                txtmk.Enabled = false;
                txtten.Enabled = false;
                DataGridViewRow row = this.dgvNguoiDung.Rows[e.RowIndex];
                txtten.Text = row.Cells[0].Value.ToString();
                txtmk.Text = row.Cells[1].Value.ToString();
                cboquyen.Text = row.Cells[2].Value.ToString();
            }
        }

        private void btnDatLai_Click(object sender, EventArgs e)
        {
            NguoiDungDTO nv = new NguoiDungDTO();
            nv.STen = txtten.Text;
            nv.SMatkhau = "1";
            if (NguoiDung_BUS.CaiLaiMkNguoiDung(nv) == false)
            {
                MessageBox.Show("Không sửa được.");
                return;
            }
            HienThiDSNguoidungLenDatagrid();
            MessageBox.Show("Đã sửa mật khẩu người dùng thành công\n Mật khẩu của bạn là : 1");
            txtmk.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtten.Text == "" || txtmk.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            NguoiDungDTO nd = new NguoiDungDTO();
            nd.STen = txtten.Text;
            nd.SMatkhau = txtmk.Text;
            nd.IQuyen = cboquyen.SelectedIndex + 1;

            if (NguoiDung_BUS.ThemNguoiDung(nd) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiDSNguoidungLenDatagrid();
            MessageBox.Show("Đã thêm  người dùng thành công.");
            txtmk.Enabled = false;
        }
    }
}
