using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class NguoiDungDTO
    {
        private string Sten;
        private string Smatkhau;
        private int Iquyen;

        public string STen { get => Sten; set => Sten = value; }
        public string SMatkhau { get => Smatkhau; set => Smatkhau = value; }
        public int IQuyen { get => Iquyen; set => Iquyen = value; }
    }
}
