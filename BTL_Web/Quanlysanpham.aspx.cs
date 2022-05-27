using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

namespace BTL_Web
{
    public partial class Quanlysanpham : System.Web.UI.Page
    {
        DataProvider data = new DataProvider();
        String query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                NapLoaiHang();

                NapSanPham(drMaLoai.SelectedValue);

                napDanhSachSP();
            }
        }

        public DataTable DanhMucLoaiHang()
        {
            query = "SELECT sID_LoaiHang, sTenLoaiHang FROM tbl_LoaiHang ";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public void NapSanPham(string MaSP)
        {
            // data.connDB();
            query = "SELECT * FROM tbl_SanPham WHERE sID_LoaiHang = @sID_LoaiHang";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.AddWithValue("@sID_LoaiHang", MaSP);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();

            // cmd.Dispose();
            // da.Dispose();
            //data.closeDB();
        }

        public void NapLoaiHang()
        {
            //data.connDB();
            query = "SELECT sID_LoaiHang, sTenLoaiHang FROM tbl_LoaiHang ";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            drMaLoai.DataSource = dt;
            drMaLoai.DataValueField = "sID_LoaiHang";
            drMaLoai.DataTextField = "sTenLoaiHang";
            drMaLoai.DataBind();

            // cmd.Dispose();
            //data.closeDB();
        }


        protected void drMaLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (drMaLoai.SelectedValue != "")
            {
                NapSanPham(drMaLoai.SelectedValue);
            }

        }
        protected void btnThemMoi_Click(object sender, EventArgs e)
        {
            data.closeDB();
            query = "INSERT INTO tbl_SanPham (sID_SanPham, sTenSanPham, fDongia, sImg, sMota_1, sMota_2, sMota_3 , sID_LoaiHang, sNhaSanXuat, fSale) "
                + "Values(@sID_SanPham, @sTenSanPham, @fDongia, @sImg, @sMota_1, @sMota_2, @sMota_3, @sID_LoaiHang, @sNhaSanXuat, @fSale)";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sID_SanPham", txtMaSP.Text);
            cmd.Parameters.AddWithValue("@sTenSanPham", txtTenSP.Text);
            cmd.Parameters.AddWithValue("@fDongia", txtGiaban.Text);
            string taptin = fHinhanh.FileName;
            cmd.Parameters.AddWithValue("@sImg", @"images/" + taptin);
            cmd.Parameters.AddWithValue("@sMota_1", txtMota1.Text);
            cmd.Parameters.AddWithValue("@sMota_2", txtMota2.Text);
            cmd.Parameters.AddWithValue("@sMota_3", txtMota3.Text);
            cmd.Parameters.AddWithValue("@sID_LoaiHang", drMaLoai.SelectedValue);
            cmd.Parameters.AddWithValue("@sNhaSanXuat", txtNSX.Text);
            cmd.Parameters.AddWithValue("@fSale", txtSale.Text);
            data.connDB();
            cmd.ExecuteNonQuery();
            data.closeDB();
            if (fHinhanh.FileName != "")
            {
                fHinhanh.PostedFile.SaveAs(Server.MapPath("images") + @"\" + taptin);
                Image1.ImageUrl = "images/" + taptin;
            }
            lblThongBao.Text = "Bạn vừa thêm mới thành công! ";
            NapSanPham(drMaLoai.SelectedValue);

            cmd.Dispose();

        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            NapSanPham(drMaLoai.SelectedValue);
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            NapSanPham(drMaLoai.SelectedValue);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string MaSP = GridView1.Rows[e.RowIndex].Cells[0].Text;
            TextBox tenSP = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox giaBan = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox soLuong = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
            FileUpload Img = (FileUpload)GridView1.Rows[e.RowIndex].Cells[4].Controls[1];
            TextBox moTa1 = (TextBox)GridView1.Rows[e.RowIndex].Cells[5].Controls[0];
            TextBox moTa2 = (TextBox)GridView1.Rows[e.RowIndex].Cells[6].Controls[0];
            TextBox moTa3 = (TextBox)GridView1.Rows[e.RowIndex].Cells[7].Controls[0];
            DropDownList maLoaiH = (DropDownList)GridView1.Rows[e.RowIndex].Cells[8].Controls[1];
            TextBox Nsx = (TextBox)GridView1.Rows[e.RowIndex].Cells[9].Controls[0];
            TextBox sale = (TextBox)GridView1.Rows[e.RowIndex].Cells[10].Controls[0];
            //data.closeDB();
            query = "UPDATE tbl_SanPham set  sTenSanPham = @sTenSanPham, fDongia = @fDongia, iSoluong_Kho = @iSoluong_Kho ,  sMota_1 = @sMota_1, sMota_2 = @sMota_2, sMota_3 = @sMota_3, " +
                "sID_LoaiHang = @sID_LoaiHang, sNhaSanXuat = @sNhaSanXuat, fSale = @fSale";
            if (Img.FileName != "")
                query += ", sImg = @sImg";
            query += " WHERE sID_SanPham = @sID_SanPham ";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sID_SanPham", MaSP);
            cmd.Parameters.AddWithValue("@sTenSanPham", tenSP.Text);
            cmd.Parameters.AddWithValue("@fDongia", giaBan.Text);
            cmd.Parameters.AddWithValue("@iSoluong_Kho", soLuong.Text);
            if (Img.FileName != "")
            {
                cmd.Parameters.AddWithValue("@sImg", @"images/" + Img.FileName);
                Img.PostedFile.SaveAs(Server.MapPath("images") + @"\" + Img.FileName);
            }

            cmd.Parameters.AddWithValue("@sMota_1", moTa1.Text);
            cmd.Parameters.AddWithValue("@sMota_2", moTa2.Text);
            cmd.Parameters.AddWithValue("@sMota_3", moTa3.Text);
            cmd.Parameters.AddWithValue("@sID_LoaiHang", maLoaiH.SelectedValue);
            cmd.Parameters.AddWithValue("@sNhaSanXuat", Nsx.Text);
            cmd.Parameters.AddWithValue("@fSale", sale.Text);
            data.connDB();
            cmd.ExecuteNonQuery();

            data.closeDB();
            cmd.Dispose();
            lblThongBao.Text = "Bạn vừa sửa đổi một sản phẩm!";
            GridView1.EditIndex = -1;
            NapSanPham(drMaLoai.SelectedValue);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string MaSP = GridView1.Rows[e.RowIndex].Cells[0].Text;
            query = "DELETE tbl_SanPham WHERE sID_SanPham = @sID_SanPham";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sID_SanPham", MaSP);
            data.connDB();
            cmd.ExecuteNonQuery();
            data.closeDB();
            cmd.Dispose();
            lblThongBao.Text = "Bạn vừa xóa một sản phẩm!";
            NapSanPham(drMaLoai.SelectedValue);
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            NapSanPham(drMaLoai.SelectedValue);
        }

        /*        public DataTable TenSP()
                {
                    query = "SELECT sID_SanPham, sTenSanPham FROM tbl_SanPham ";
                    SqlCommand cmd = new SqlCommand(query, data.conn);
                    cmd.Parameters.Clear();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    return dt;
                }*/

        public void napDanhSachSP()
        {
            query = "SELECT sID_SanPham, sTenSanPham FROM tbl_SanPham ";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            ddlTenSP.DataSource = dt;
            ddlTenSP.DataValueField = "sID_SanPham";
            ddlTenSP.DataTextField = "sTenSanPham";
            ddlTenSP.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            lblTenSP.Text = Convert.ToString(ddlTenSP.SelectedItem.Value);
            lblTenSP.Text = Convert.ToString(ddlTenSP.SelectedItem.Text);
            string soLuong = txtSlgN.Text;
            query = "update tbl_SanPham set iSoluong_Kho = iSoluong_Kho + @soluong where sTenSanPham = @tenSP";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@tenSP", lblTenSP.Text);
            cmd.Parameters.AddWithValue("@soluong", soLuong);
            data.connDB();
            cmd.ExecuteNonQuery();
            data.closeDB();
            cmd.Dispose();
            lblThongBao.Text = "Bạn vừa nhập thêm số lượng phẩm thành công!";
            NapSanPham(drMaLoai.SelectedValue);
        }
    }
}