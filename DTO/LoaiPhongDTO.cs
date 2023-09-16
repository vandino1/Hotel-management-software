using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
     public class LoaiPhongDTO
    {
        private string sMaLoaiPhong;
        private string sTenLoaiPhong;
        private int iDonGia;
        private string sDonViTinh;

        public string SMaLoaiPhong { get => sMaLoaiPhong; set => sMaLoaiPhong = value; }
        public string STenLoaiPhong { get => sTenLoaiPhong; set => sTenLoaiPhong = value; }
        public int IDonGia { get => iDonGia; set => iDonGia = value; }
        public string SDonViTinh { get => sDonViTinh; set => sDonViTinh = value; }
    }
}
