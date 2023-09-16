using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PhongDTO
    {
        private string sSoPhong;
        private string sMaLoaiPhong;
        private string sTinhTrang;

        public string SSoPhong { get => sSoPhong; set => sSoPhong = value; }
        public string SMaLoaiPhong { get => sMaLoaiPhong; set => sMaLoaiPhong = value; }
        public string STinhTrang { get => sTinhTrang; set => sTinhTrang = value; }
    }
}
