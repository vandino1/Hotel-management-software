using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using DTO;
using System.Security.Cryptography;

namespace BUS
{
    public class NguoiDung_BUS
    {
        public static List<NguoiDungDTO> LayNguoiDung_XuatDS()
        {
            return NguoiDungDAO.LayNguoiDung_XuatDS();
        }
        public static bool ThemNguoiDung(NguoiDungDTO nd)
        {
            MD5 md5Hash = MD5.Create();
            string matkhauMH = NguoiDung_BUS.GetMd5Hash(md5Hash, nd.SMatkhau);
            nd.SMatkhau = matkhauMH;
            return NguoiDungDAO.ThemNguoiDung(nd);
        }
        public static NguoiDungDTO LayNguoiDung(string ten, string matkhau)
        {
            MD5 md5Hash = MD5.Create();
            string matkhauMH = NguoiDung_BUS.GetMd5Hash(md5Hash, matkhau);
            return NguoiDungDAO.LayNguoiDung(ten, matkhauMH);
        }
        public static bool XoaNguoiDung(NguoiDungDTO nd)
        {
            return NguoiDungDAO.XoaNguoiDung(nd);
        }
        public static bool SuaQuyenNguoiDung(NguoiDungDTO nd)
        {
            return NguoiDungDAO.SuaQuyenNguoiDung(nd);
        }

        public static bool CaiLaiMkNguoiDung(NguoiDungDTO nd)
        {
            MD5 md5Hash = MD5.Create();
            string matkhauMH = NguoiDung_BUS.GetMd5Hash(md5Hash, nd.SMatkhau);
            nd.SMatkhau = matkhauMH;
            return NguoiDungDAO.CaiLaiMkNguoiDung(nd);
        }
        public static bool SuaMKNguoiDung(NguoiDungDTO nd)
        {
            MD5 md5Hash = MD5.Create();
            string matkhauMH = NguoiDung_BUS.GetMd5Hash(md5Hash, nd.SMatkhau);
            nd.SMatkhau = matkhauMH;
            return NguoiDungDAO.SuaMKNguoiDung(nd);
        }
        // Hàm mã hóa
        // Tham khảo tại https://msdn.microsoft.com/enus/library/system.security.cryptography.md5.aspx
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {
            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));
            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();
            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            // Return the hexadecimal string.
            return sBuilder.ToString();

        }
    }
}
