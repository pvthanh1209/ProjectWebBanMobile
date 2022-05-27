using BTL_Web.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BTL_Web.DAO_USER
{
    public class DAO_user:DataProvider
    {
        public void GhiThongTinUser(User user)
        {
            DAO_user dao = new DAO_user();
            dao.connDB();
            string sql = "INSERT INTO tbl_User(sUserName, sPassWord, sHoTen, iType, sMoTa) values ('" + user.sUSERNAME + "', '" + user.sPASSWORD + "', N'" + user.sHOTEN + "', '" + "1" + "', '" + "User" + "')";
            SqlCommand cmd = new SqlCommand(sql, dao.conn);
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            dao.closeDB();
        }

        public int LaDangNhapThanhCong(string Username, string Password)
        {
            int flag = -1;
            DAO_user dao = new DAO_user();
            dao.connDB();
            string sql = "SELECT *FROM tbl_User WHERE sUserName='" + Username + "' AND sPassWord='" + Password + "'";
            SqlCommand cmd = new SqlCommand(sql, dao.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                flag = 1;
            }
            cmd.Dispose();
            reader.Dispose();
            dao.closeDB();
            return flag;
        }

        public int TrungTenDangNhap(string TenTaiKhoan)
        {
            DAO_user dao = new DAO_user();
            dao.connDB();
            string sql = "SELECT *FROM tbl_User WHERE sUserName='" + TenTaiKhoan + "'";
            SqlCommand cmd = new SqlCommand(sql, dao.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                return 1;
            }
            return 0;
        }

        public User PhanQuyenAdminUser(string username)
        {
            DAO_user dao = new DAO_user();
            dao.connDB();
            string sql = "SELECT *FROM tbl_User WHERE sUserName='" + username + "'";
            SqlCommand cmd = new SqlCommand(sql, dao.conn);
            SqlDataReader reader = cmd.ExecuteReader();
            User user = new User();
            if (reader.HasRows)
            {
                reader.Read();
                user.sUSERNAME = username;
                user.sHOTEN = reader.GetValue(2).ToString();
                user.iTYPE = reader.GetInt32(3);
                user.sMOTA = reader.GetValue(4).ToString();
            }

            reader.Dispose();
            cmd.Dispose();
            dao.closeDB();
            return user;
        }
    }
}