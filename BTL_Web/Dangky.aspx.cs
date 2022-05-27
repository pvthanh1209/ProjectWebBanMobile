using BTL_Web.BUS;
using BTL_Web.DTO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web
{
    public partial class Dangky : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Username"] != null)
            {
                Response.Redirect("Trangchu.aspx");
            }
        }

        protected void btnDangKy_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                BUS_User bus = new BUS_User();
                int taikhoan = bus.TrungTenDangNhap(txtTenTaiKhoan.Text.Trim());
                if (taikhoan == 1)
                {
                    lblTenTaiKhoan.Text = "<p style='color:red;'> Tài khoản này đã có người sử dụng!</p>";
                    lblThongBao.Text = "Đăng ký không thành công!";
                }
                else
                {
                    User user = new User();
                    user.sUSERNAME = txtTenTaiKhoan.Text;
                    user.sPASSWORD = txtMatKhau.Text;
                    user.sHOTEN = txtHoTen.Text;
                    lblTenTaiKhoan.Text = "Tên tài khoản";
                    Encoding.UTF8.GetString(Encoding.Default.GetBytes(user.sHOTEN));
                    bus.GhiThongTinUser(user);
                    lblThongBao.Text = "<p style=\"color:green\">Tài khoản: "+user.sHOTEN + " đã đăng ký thành công!</p>";
                    XoaThongTin();
                }
            }
        }

        public void XoaThongTin()
        {
            txtHoTen.Text = "";
            txtTenTaiKhoan.Text = "";
            txtMatKhau.Text = "";
            txtMatKhau1.Text = "";
        }

        protected void CustomValidator2_ServerValidate(object source, ServerValidateEventArgs args)
        {
            if (txtMatKhau.Text.ToString().Length > 5)
                args.IsValid = true;
            else
                args.IsValid = false;
        }
    }
}
