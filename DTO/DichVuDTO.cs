using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DichVuDTO
    {
        private string sMaDV;
        private string sTenDV;
        private string sDonViTinh;
        private int iDonGia;
        private string sGhiChu;

        public string SMaDV { get => sMaDV; set => sMaDV = value; }
        public string STenDV { get => sTenDV; set => sTenDV = value; }
        public string SDonViTinh { get => sDonViTinh; set => sDonViTinh = value; }
        public int IDonGia { get => iDonGia; set => iDonGia = value; }
        public string SGhiChu { get => sGhiChu; set => sGhiChu = value; }
    }
}
