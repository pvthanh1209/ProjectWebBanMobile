using BTL_Web.BUS;
using BTL_Web.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web
{
    public partial class coreAdmin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadThongTin();
        }

        public void LoadThongTin()
        {
            if (Session["Username"] != null)
            {
                string username = Session["Username"].ToString();
                BUS_User bus = new BUS_User();
                User user = new User();
                user = bus.PhanQuyenAdminUser(username);
                if (user.sMOTA.Equals("Admin"))
                {
                    lblTenDangNhap.Text = username;
                    //Response.Redirect("Admin.aspx");
                }
                else if (user.sMOTA.Equals("User"))
                {
                    Response.Redirect("Trangchu.aspx");
                }
            }
            else
            {
                Response.Redirect("Dangnhap.aspx");
            }
        }
    }
}