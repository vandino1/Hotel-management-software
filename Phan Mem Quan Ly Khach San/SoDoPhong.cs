using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Phan_Mem_Quan_Ly_Khach_San
{
    public partial class FrmSoDoPhong : Form
    {
        public FrmSoDoPhong()
        {
            InitializeComponent();
        }

        private void MenuThoatVIP_Click(object sender, EventArgs e)
        {          
                this.Close();
        }

        private void MenuThoatThuong_Click(object sender, EventArgs e)
        {    
                this.Close();
        }

        private void btnDatPhong_Click(object sender, EventArgs e)
        {
            FrmDangKyPhong f10 = new FrmDangKyPhong();
            this.Hide();
            f10.ShowDialog();
            this.Show();         
        }

        private void btnDatPhongVip_Click(object sender, EventArgs e)
        {
            FrmDangKyPhong f11 = new FrmDangKyPhong();
            this.Hide();
            f11.ShowDialog();
            this.Show();
        }
    }
  }

