using BTL_Web.BUS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web
{
    public partial class Dangnhap : System.Web.UI.Page
    {
        DataProvider data = new DataProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btndangnhap_Click(object sender, EventArgs e)
        {
            string username = txtTaikhoan.Text.Trim();
            string password = txtMatkhau.Text.Trim();

            BUS_User bus = new BUS_User();

            int flag = bus.LaDangNhapThanhCong(username, password);

            if (flag == 0)
            {
                Session["Username"] = username;
                Response.Redirect("Trangchu.aspx");

            }else
            if (flag == 1)
            {
                SqlCommand cmd = new SqlCommand("select sHoTen FROM tbl_User WHERE sUserName = @user", data.conn);
                cmd.Parameters.AddWithValue("@user", username);
                data.connDB();
                cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    Session["login"] = true;
                    Session["Username"] = username;
                    Session["Hoten"] =dr["sHoten"].ToString();
                    data.closeDB();
                }
                Response.Redirect("Admin.aspx");
   
            }
            else
            {
                lblThongbao.Text = "Thông tin tài khoản hoặc mật khẩu không chính xác!";
            }
        }
    }
}