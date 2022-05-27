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
    public partial class Chitiethoadon : System.Web.UI.Page
    {
        DataProvider data = new DataProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fill_lvData();
                fill_fvData();
            }
        }

        double total=0;
        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                Label lblGia = (Label)e.Item.FindControl("lblTamTinh");
                total += double.Parse(lblGia.Text);

                lblTongTien.Text ="Tổng tiền:"+ Server.HtmlEncode(String.Format("{0:0,0}", total + 20000)) + "<sup>đ</sup>";
                lblGia.Text = Server.HtmlEncode(String.Format("{0:0,0}", double.Parse(lblGia.Text))) + "<sup>đ</sup>";
            }
        }
        void fill_lvData()
        {
            string query = "SELECT tblHoaDon.*, tbl_CTHoaDon.iSoluongmua, tbl_CTHoaDon.fDongia, tbl_SanPham.sTenSanPham FROM tblHoaDon INNER JOIN tbl_CTHoaDon ON tblHoaDon.sID_HoaDon = tbl_CTHoaDon.sID_HoaDon INNER JOIN tbl_SanPham ON tbl_CTHoaDon.sID_SanPham = tbl_SanPham.sID_SanPham WHERE tblHoaDon.sID_HoaDon = @idHD ";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.AddWithValue("@idHD", Request.QueryString["idhd"]);
            data.connDB();
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                ListView1.DataSource = dt;
                ListView1.DataBind();
                data.closeDB();
            }
        }
        void fill_fvData()
        {
            string query = "SELECT * FROM tblHoaDon WHERE sID_HoaDon=@idHD ";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.AddWithValue("@idHD", Request.QueryString["idhd"]);
            data.connDB();
            cmd.ExecuteNonQuery();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                FormView1.DataSource = dt;
                FormView1.DataBind();
                data.closeDB();
            }
        }
        string maSP;
        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if(e.CommandName == "Delete")
            {
                SqlCommand cmd = new SqlCommand("UPDATE tblHoaDon SET sTrangthai = N'HỦY' WHERE sID_HoaDon = @id", data.conn);
                cmd.Parameters.AddWithValue("@id", Request.QueryString["idhd"]);
                data.connDB();
                cmd.ExecuteNonQuery();
                data.closeDB();          
                
                foreach (ListViewDataItem lv in ListView1.Items)
                {
                    Label lblSP = lv.FindControl("lblTenSP") as Label;
                    Label lblSL = lv.FindControl("lblSoLuong") as Label;
                    using (SqlCommand cmd1 = new SqlCommand("SELECT sID_SanPham FROM tbl_SanPham WHERE sTenSanPham = @tensp", data.conn))
                    {
                        cmd1.Parameters.AddWithValue("@tensp", lblSP.Text);
                        data.connDB();
                        cmd1.ExecuteNonQuery();
                        DataTable dt1 = new DataTable();
                        SqlDataReader dr;
                        dr = cmd1.ExecuteReader();
                        while (dr.Read())
                        {
                            maSP = dr["sID_SanPham"].ToString();
                        }
                        data.closeDB();
                    }

                    SqlCommand cmd3 = new SqlCommand("UPDATE tbl_SanPham SET iSoluong_Kho = iSoluong_Kho + @sl WHERE sID_SanPham = @idsp", data.conn);
                    cmd3.Parameters.AddWithValue("@idsp", maSP);
                    cmd3.Parameters.AddWithValue("@sl", int.Parse(lblSL.Text));
                    data.connDB();
                    cmd3.ExecuteNonQuery();
                    data.closeDB();
                }
                if ((bool)Session["login"] == true)
                {
                    Response.Redirect("Donhang.aspx");

                }
                else
                {
                    Response.Redirect("Trangchu.aspx");
                }
            }
        }
    }
}