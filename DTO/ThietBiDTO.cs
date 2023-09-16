using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThietBiDTO
    {
        private string sMATB;
        private string sTenTB;
        private int ISoLuong;
        private string sDonViTinh;
        private string sHangSanXuat;
        private DateTime DTNamSX;

        public string SMATB { get => sMATB; set => sMATB = value; }
        public string STenTB { get => sTenTB; set => sTenTB = value; }
        public int ISoLuong1 { get => ISoLuong; set => ISoLuong = value; }
        public string SDonViTinh { get => sDonViTinh; set => sDonViTinh = value; }
        public string SHangSanXuat { get => sHangSanXuat; set => sHangSanXuat = value; }
        public DateTime DTNamSX1 { get => DTNamSX; set => DTNamSX = value; }
    }
}
