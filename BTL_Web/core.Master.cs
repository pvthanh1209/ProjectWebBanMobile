using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web
{
    public partial class core : System.Web.UI.MasterPage
    {

        string name, lh;
        DataProvider data = new DataProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";
            if (!IsPostBack)
            {
                if ((bool)Session["login"] == true)
                {
                    fillData();
                    linkCart.Attributes["href"] = "Giohang.aspx";
                    btnOut.Visible = true;
                    txtUser.Visible = true;
                    login.Attributes.Add("style", "width: 240px; height: 130px");
                    txtUser.Text = "Xin chào, " + Session["Username"];
                    html += " <table class=\"table-login\">" +
                            "<tr>" +
                            "<td><i class=\"fa fa-money-bill\" style=\"font-size: 15px; color: black;\" aria-hidden=\"true\"></i></td>" +
                            "<td><a href=\"Donhang.aspx\"><span>Xem thông tin đơn hàng</span></a></td>" +
                            "</tr>" +
                            "</table>";
                    showlogin.InnerHtml = html;
                }
                else
                {
                    mainCart.Attributes.Add("style", "display:none");
                    wrapCart.InnerHtml = "Chưa có sản phẩm trong giỏ hàng";
                    linkCart.Attributes["href"] = "Dangnhap.aspx";
                    html += " <table class=\"table-login\">" +
                            "<tr>" +
                            "<td><i class=\"fa fa-sign-in\" style=\"font-size: 15px; color: black;\" aria-hidden=\"true\"></i></td>" +
                            "<td><a href =\"Dangnhap.aspx\"><span>Đăng nhập</span></a></td>" +
                            "</tr>" +
                            "<tr>" +
                            "<td><i class=\"fa fa-user-plus\" style=\"font-size: 15px; color: black;\" aria-hidden=\"true\"></i></td>" +
                            "<td><a href =\"Dangky.aspx\"><span>Đăng ký</span></a></td>" +
                            "</tr>" +
                            "</table>";

                    showlogin.InnerHtml = html;
                }

            }
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            lh = "'LH01'";
            name = "Điện thoại";
            Response.Redirect(@"Danhsachsanpham.aspx?lh=" + lh + "&name=" + name);
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            lh = "'LH02'";
            name = "Máy tính bảng";
            Response.Redirect(@"Danhsachsanpham.aspx?lh=" + lh + "&name=" + name);
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            lh = "'LH03'";
            name = "Phụ kiện";
            Response.Redirect(@"Danhsachsanpham.aspx?lh=" + lh + "&name=" + name);
        }

        protected void btnOut_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("Dangnhap.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            lh = string.Empty;
            string search = textbox1.Value;
            name = "Search '" + search + "'";
            Response.Redirect(@"Danhsachsanpham.aspx?lh=" + lh + "&name=" + name + "&search=" + search);
        }

        protected void lvCart_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_CTGioHang WHERE sID_CTGioHang = @idGH", data.conn);
                cmd.Parameters.AddWithValue("@idGH", e.CommandArgument);
                data.connDB();
                cmd.ExecuteNonQuery();
                data.closeDB();
                Response.Redirect("Giohang.aspx");
            }
        }

        double thanhtien, total_cart = 0;
        protected void lvCart_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblSL = (Label)e.Item.FindControl("txtSL");
                Label lblGia = (Label)e.Item.FindControl("txtGia");

                thanhtien = double.Parse(lblSL.Text) * double.Parse(lblGia.Text);
                total_cart += thanhtien;
                totalCart.Text = "Tổng tiền: <b>" + Server.HtmlEncode(String.Format("{0:0,0}", total_cart)) + "<sup>đ</sup></b>";
            }
        }

        void fillData()
        {
            SqlCommand cmd = new SqlCommand("Select tbl_SanPham.*, tbl_CTGioHang.* FROM tbl_SanPham INNER JOIN tbl_CTGioHang ON tbl_SanPham.sID_SanPham = tbl_CTGioHang.sID_SanPham WHERE tbl_CTGioHang.sUserName = @user AND tbl_CTGioHang.sCheck IS NULL", data.conn);
            cmd.Parameters.AddWithValue("@user", Session["UserName"].ToString());
            data.connDB();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    lvCart.DataSource = dt;
                    lvCart.DataBind();
                }
                else
                {
                    mainCart.Attributes.Add("style", "display:none");
                    wrapCart.InnerHtml = "Chưa có sản phẩm trong giỏ hàng";
                }
                data.closeDB();
            }
        }
    }
}