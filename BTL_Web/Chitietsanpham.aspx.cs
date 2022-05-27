using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web
{
    public partial class Chitietsanpham : System.Web.UI.Page
    {
        string id;
        String query = "";
        DataProvider data = new DataProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                display_product();
                display_info();
                display_spLienquan();
                display_Danhgia();
                dataBound();
                if ((bool)Session["login"] == true)
                {
                    notiLogin.Attributes.Add("style", "display: none;");
                    infoCMT.Attributes.Add("style", "display:flex");
                }

                DataSet ds = getComment(id);
                if (ds == null)
                {
                    Xemthem.Attributes.Add("style", "display:none");
                    Label_danhgia.Text = "ĐÁNH GIÁ(0)";
                }
                else
                {
                    if (ds.Tables[0].Rows.Count > 4)
                    {
                        Xemthem.Attributes.Add("style", "display:block;");
                    }
                    Label_danhgia.Text = "ĐÁNH GIÁ(" + ds.Tables[0].Rows.Count + ")";
                }
                Xemthem.Attributes.Add("onclick", "javascript:napDanhsachDanhgia('" + Request.QueryString["sID_SanPham"].ToString() + "')");
                btn_danhgia.Attributes.Add("onclick", "javascript:themCmt('" + Request.QueryString["sID_SanPham"].ToString() + "')");
            }

            if (Request["act"] == "lay")
            {
                if (Request["sID_SanPham"] != null)
                {
                    DataSet ds = getComment(HttpContext.Current.Request["sID_SanPham"].ToString());
                    Response.Flush();
                    Response.Write(ds.GetXml());
                    Response.End();
                }
            }
            //else if (Request["act"] == "them")
            //{
            //    if (Request["sID_SanPham"] != null)
            //    {
            //        Response.Clear();
            //        //insertComment(Request["sID_SanPham"].ToString(), Request["cmt"].ToString());
            //        Response.Flush();
            //        Response.End();
            //    }
            //}

        }
        void display_product()
        {
            id = Convert.ToString(HttpContext.Current.Request.QueryString["sID_SanPham"]);
            DataTable dt = getSanpham(id);
            FormView1.DataSource = dt;
            FormView1.DataBind();
        }
        void display_info()
        {
            id = Convert.ToString(HttpContext.Current.Request.QueryString["sID_SanPham"]);
            DataTable dt = getSanpham(id);
            FormView2.DataSource = dt;
            FormView2.DataBind();

        }
        void display_spLienquan()
        {
            Label tenlh = FormView2.FindControl("txtTenLH") as Label;
            Label tennsx = FormView2.FindControl("txtNSX") as Label;
            query = "select TOP 4 tbl_SanPham.* from tbl_SanPham join tbl_LoaiHang on tbl_SanPham.sID_LoaiHang = tbl_LoaiHang.sID_LoaiHang WHERE tbl_LoaiHang.sTenLoaiHang = @tenlh AND tbl_SanPham.sNhaSanXuat= @nsx AND tbl_SanPham.sID_SanPham NOT IN (@idsp)";
            id = Convert.ToString(Request.QueryString["sID_SanPham"]);
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.AddWithValue("@tenlh", tenlh.Text);
            cmd.Parameters.AddWithValue("@nsx", tennsx.Text);
            cmd.Parameters.AddWithValue("@idsp", id);
            data.connDB();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
                lvSPLienQuan.DataSource = dt;
                lvSPLienQuan.DataBind();
                data.closeDB();
            }
        }

        void display_Danhgia()
        {
            query = "select TOP 4 * from tbl_DanhGia inner join tbl_User on tbl_DanhGia.sUserName = tbl_User.sUserName where sID_SanPham = @id and sID_DanhGia like '%DG%' order by dThoigian DESC";
            id = Convert.ToString(Request.QueryString["sID_SanPham"]);
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.AddWithValue("@id", id);
            data.connDB();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
                Danhgia.DataSource = dt;
                Danhgia.DataBind();
                data.closeDB();
            }
        }

        void dataBound()
        {
            Label lblTinhtrang = FormView1.FindControl("lblStatus") as Label;
            showGia(FormView1.FindControl("txtGiaCu") as Label, FormView1.FindControl("txtGia") as Label, FormView1.FindControl("spGiaCu") as Panel);
            Label lblSoluong = FormView2.FindControl("txtSL") as Label;
            if (int.Parse(lblSoluong.Text) > 0)
            {
                lblTinhtrang.Text = "Tình trạng: " + "<b style=\"color: green;\">Còn hàng</b>";
            }
            else
            {
                lblTinhtrang.Text = "Tình trạng: " + "<b style=\"color: red;\">Hết hàng</b>";
            }
        }

        private DataTable getSanpham(string maSP)
        {
            query = "select tbl_SanPham.*, tbl_LoaiHang.sTenLoaiHang from tbl_SanPham JOIN tbl_LoaiHang ON tbl_SanPham.sID_LoaiHang = tbl_LoaiHang.sID_LoaiHang WHERE sID_SanPham = @id";
            id = Convert.ToString(HttpContext.Current.Request.QueryString["sID_SanPham"]);
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.AddWithValue("@id", id);
            data.connDB();
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
                data.closeDB();
                if (dt.Rows.Count > 0)
                {
                    return dt;
                }
                else
                    return null;
            }
        }

        protected void lvSPLienQuan_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if ((bool)Session["login"] == true)
            {
                AddToCart add = new AddToCart();
                add.addItemCart((Label)e.Item.FindControl("lblIDSP"), (Label)e.Item.FindControl("lblGiaMoi"), 1, Session["Username"].ToString(), this);
                Response.Redirect("Giohang.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Bạn cần đăng nhập để sử dụng chức năng này.');", true);
            }
        }

        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            TextBox txtSL = FormView1.FindControl("txtSL") as TextBox;

            if (e.CommandName == "Them")
            {
                if ((bool)Session["login"] == true)
                {
                    AddToCart add = new AddToCart();
                    add.addItemCart(FormView1.FindControl("txtIDSP") as Label, FormView1.FindControl("txtGia") as Label, int.Parse(txtSL.Text), Session["Username"].ToString(), this);
                    Response.Redirect("Giohang.aspx");
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Bạn cần đăng nhập để sử dụng chức năng này.');", true);
                }
            }

        }
        private DataSet getComment(string sID_SanPham)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8PT3G6R\SQLEXPRESS;Initial Catalog=WebNC;User ID=sa;Password=1234$"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "select tbl_User.sHoTen, tbl_DanhGia.sBinhLuan, tbl_DanhGia.dThoigian from tbl_DanhGia inner join tbl_User on tbl_DanhGia.sUserName = tbl_User.sUserName where sID_SanPham = @id order by dThoigian DESC";
                        cmd.Parameters.AddWithValue("@id", sID_SanPham);
                        using (SqlDataAdapter daDanhGia = new SqlDataAdapter(cmd))
                        {
                            DataSet dsDanhGia = new DataSet();
                            daDanhGia.Fill(dsDanhGia);
                            if (dsDanhGia.Tables[0].Rows.Count > 0)
                            {
                                return dsDanhGia;
                            }
                            else
                                return null;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private void insertComment(string sID_SanPham, string sBinhLuan)
        {
            try
            {
                DataProvider data = new DataProvider();
                int incID;
                string getCount = "SELECT * FROM tbl_DanhGia where sID_DanhGia like '%DG%'";
                DataTable dtcount = data.getDT(getCount);
                incID = dtcount.Rows.Count + 1;
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-8PT3G6R\SQLEXPRESS;Initial Catalog=WebNC;User ID=sa;Password=1234$"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "insert into tbl_DanhGia(sID_DanhGia, sBinhLuan, sUserName, sID_SanPham, dThoigian) values(@id_dg, @bl, @username, @id_sp, @time)";
                        cmd.Parameters.AddWithValue("@id_sp", sID_SanPham);
                        cmd.Parameters.AddWithValue("@bl", sBinhLuan);
                        cmd.Parameters.AddWithValue("@username", Session["Username"].ToString());
                        cmd.Parameters.AddWithValue("@id_dg", "DG" + incID.ToString());
                        cmd.Parameters.AddWithValue("@time", DateTime.Now);
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void lvSPLienQuan_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                showGia((Label)e.Item.FindControl("lblGiaCu"), (Label)e.Item.FindControl("lblGiaMoi"), (Panel)e.Item.FindControl("idSaleGiaCu"));
            }
        }
        void showGia(Label lblGiacu, Label lblGiamoi, Panel lblDiv)
        {
            if (float.Parse(lblGiacu.Text.ToString()) == float.Parse(lblGiamoi.Text.ToString()))
            {
                lblDiv.Visible = false;
            }
        }
    }
}