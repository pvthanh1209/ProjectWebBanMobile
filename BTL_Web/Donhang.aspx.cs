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
    public partial class Donhang : System.Web.UI.Page
    {
        DataProvider data = new DataProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SqlCommand cmd = new SqlCommand("Select * FROM tblHoaDon WHERE sUserName = @user ORDER BY dNgaylap DESC", data.conn);
                cmd.Parameters.AddWithValue("@user", Session["Username"]);
                data.connDB();
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        ListView1.DataSource = dt;
                        ListView1.DataBind();
                    }
                    else
                    {
                        wrapOrder.Attributes.Add("style", "display:none");
                        notiOrder.InnerHtml = "Bạn chưa có đơn hàng nào";
                        notiOrder.Attributes.Add("style", "padding-bottom: 70px; margin-top: 50px; font-size: 30px; margin-left: 33%;");
                        backShop.Attributes.Add("style", "display:inline;");
                    }
                }
            }
        }

        double tongtien = 0;
        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblTrangthai = (Label)e.Item.FindControl("lblStatus");
                TextBox lblSL = (TextBox)e.Item.FindControl("txtNumm");
                Label lblTongtien = (Label)e.Item.FindControl("lblTotal");
                Label lblThanhTien = (Label)e.Item.FindControl("txtMoneyItem");
                tongtien = float.Parse(lblTongtien.Text);
                lblTongtien.Text = Server.HtmlEncode(String.Format("{0:0,0}", tongtien)) + "<sup>đ</sup>";

                if(lblTrangthai.Text == "HỦY")
                {
                    lblTrangthai.Attributes.Add("style", "color:red");
                }
                else if (lblTrangthai.Text == "ĐÃ XÁC NHẬN")
                {
                    lblTrangthai.Attributes.Add("style", "color:#00d400");
                }
            }
        }

        protected void ListView1_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if(e.CommandName == "Select")
            {
                Response.Redirect("Chitiethoadon.aspx?idhd=" + e.CommandArgument);
            }
        }
    }
}