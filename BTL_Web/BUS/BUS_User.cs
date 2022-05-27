using BTL_Web.DAO_USER;
using BTL_Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BTL_Web.BUS
{
    public class BUS_User
    {
        public void GhiThongTinUser(User user)
        {
            DAO_user dao = new DAO_user();
            dao.GhiThongTinUser(user);
        }

        public int LaDangNhapThanhCong(string Username, string Password)
        {
            DAO_user dao = new DAO_user();
            return dao.LaDangNhapThanhCong(Username, Password);
        }

        public int TrungTenDangNhap(string TenTaiKhoan)
        {
            DAO_user dao = new DAO_user();
            return dao.TrungTenDangNhap(TenTaiKhoan);
        }
        public User PhanQuyenAdminUser(string username)
        {
            DAO_user dao = new DAO_user();
            return dao.PhanQuyenAdminUser(username);
        }
    }
}