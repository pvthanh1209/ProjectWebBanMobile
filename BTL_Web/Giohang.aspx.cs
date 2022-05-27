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
    public partial class Giohang : System.Web.UI.Page
    {
        DataProvider data = new DataProvider();
        public List<string> List_item = new List<string>();
        DataTable dt;
        String query = "";
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                fillData();
            }
        }

        /*Xóa sản phẩm trong giỏ hàng*/
        protected void lvCart_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Delete")
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM tbl_CTGioHang WHERE sID_CTGioHang = @idGH", data.conn);
                cmd.Parameters.AddWithValue("@idGH", e.CommandArgument);
                data.connDB();
                cmd.ExecuteNonQuery();
                data.closeDB();
            }
        }

        /*Cập nhật giỏ hàng sau khi xóa*/
        protected void lvCart_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {
            fillData();
        }

        /*Xử lý, Cập nhật tổng tiền trong giỏ hàng*/
        public double thanhtien;
        public double total_cart;
        protected void lvCart_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                TextBox lblSL = (TextBox)e.Item.FindControl("txtSL");
                Label lblGia = (Label)e.Item.FindControl("txtGia");
                Label lblThanhTien = (Label)e.Item.FindControl("txtMoneyItem");

                thanhtien = double.Parse(lblSL.Text) * double.Parse(lblGia.Text);
                total_cart += thanhtien;
                lblThanhTien.Text = Server.HtmlEncode(String.Format("{0:0,0}", thanhtien)) + "<sup>đ</sup>";
                txtCart.Text = Server.HtmlEncode(String.Format("{0:0,0}", total_cart)) + "<sup>đ</sup>";
                txtTotalCart.Text = Server.HtmlEncode(String.Format("{0:0,0}", total_cart + 20000)) + "<sup>đ</sup>";
                lblGia.Text += "<sup>đ</sup>";
            }
        }

        /*Cập nhật giỏ hàng*/
        protected void btnUpdateCart_Click(object sender, EventArgs e)
        {
            foreach (ListViewDataItem lv in lvCart.Items)
            {
                Label idSP = lv.FindControl("lblIDSP") as Label;
                TextBox newSL = lv.FindControl("txtSL") as TextBox;
                SqlCommand cmd = new SqlCommand("SELECT iSoluong_Kho, sTenSanPham FROM tbl_SanPham WHERE sID_SanPham = @id", data.conn);
                cmd.Parameters.AddWithValue("@id", idSP.Text);
                data.connDB();
                cmd.ExecuteNonQuery();
                SqlDataReader dr;
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    int soluongkho = int.Parse(dr["iSoluong_Kho"].ToString());
                    string tensp = dr["sTenSanPham"].ToString();
                    data.closeDB();
                    if (soluongkho < int.Parse(newSL.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('" + tensp + " hiện không đủ số lượng bạn yêu cầu');", true);
                    }
                    else
                    {
                        data.closeDB();
                        SqlCommand comm = new SqlCommand("UPDATE tbl_CTGioHang SET iSoluongmua = @newSL WHERE sID_SanPham = @idsp", data.conn);
                        comm.Parameters.AddWithValue("@newSL", newSL.Text);
                        comm.Parameters.AddWithValue("@idsp", idSP.Text);
                        data.connDB();
                        comm.ExecuteNonQuery();
                        data.closeDB();
                    }
                    fillData();
                }
            }
        }

        /*Xác nhận giỏ hàng*/
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string str = txtTotalCart.Text.ToString();
            str = str.Remove(str.Length - 12);
            foreach (ListViewDataItem lv in lvCart.Items)
            {
                Label thanhtien = lv.FindControl("txtMoneyItem") as Label;
                string item = thanhtien.Text.ToString();
                item = item.Remove(item.Length - 12);
                if (item != null)
                {
                    List_item.Add(item);
                }
            }
            Session["NumberCart"] = List_item;
            Response.Redirect("Thanhtoan.aspx?total=" + str);
        }

        /*Lấy dữ liệu giỏ hàng */
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
                    total_cart = 0;
                }
                else
                {
                    emptyCart.Attributes.Add("style", "display:block;");
                    idCart.Attributes.Add("style", "display:none;");
                }
                data.closeDB();
            }
        }

    }
}