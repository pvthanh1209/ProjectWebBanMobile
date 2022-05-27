using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Net.Mail;

namespace BTL_Web
{
    public partial class Quanlyhoadon : System.Web.UI.Page
    {
        DataProvider data = new DataProvider();
        String query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadDSSP(ddlHoaDon.SelectedValue);
                //LoadCTHD();
            }
        }

        public void LoadDSSP(string trangthai)
        {
            query = "SELECT tblHoaDon.*, tbl_User.sHoTen " +
                "from tblHoaDon INNER JOIN tbl_User ON tblHoaDon.sUserName = tbl_User.sUserName " +
                "WHERE tblHoaDon.sTrangthai = @sTrangthai ";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sTrangthai", trangthai);
            data.connDB();
            //SqlDataReader reader = cmd.ExecuteReader();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            // dt.Load(reader);
            da.Fill(dt);

            grvHD.DataSource = dt;
            grvHD.DataBind();
        }

        protected void ddlHoaDon_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlHoaDon.SelectedValue != "")
            {
                LoadDSSP(ddlHoaDon.SelectedValue);
            }
        }

        protected void grvHD_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvHD.EditIndex = e.NewEditIndex;
            LoadDSSP(ddlHoaDon.SelectedValue);
        }

        protected void grvHD_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvHD.EditIndex = -1;
            LoadDSSP(ddlHoaDon.SelectedValue);
        }

        protected void grvHD_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string maHD = grvHD.Rows[e.RowIndex].Cells[0].Text;
            //TextBox tenKH = (TextBox)grvHD.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox diaChi = (TextBox)grvHD.Rows[e.RowIndex].Cells[2].Controls[0];
            DropDownList trangThai = (DropDownList)grvHD.Rows[e.RowIndex].Cells[3].Controls[1];
            TextBox sdt = (TextBox)grvHD.Rows[e.RowIndex].Cells[4].Controls[0];
            TextBox ghiChu = (TextBox)grvHD.Rows[e.RowIndex].Cells[5].Controls[0];
            TextBox tongTien = (TextBox)grvHD.Rows[e.RowIndex].Cells[6].Controls[0];
            DropDownList phuongThuc = (DropDownList)grvHD.Rows[e.RowIndex].Cells[7].Controls[1];
            TextBox ngayLap = (TextBox)grvHD.Rows[e.RowIndex].Cells[8].Controls[0];

            query = "UPDATE tblHoaDon set sDiachi = @sDiachi, sTrangthai = @sTrangthai, sSdt = @sSdt, " +
                "sGhichu = @sGhichu, sTongtien = @sTongtien, sPhuongthuc = @sPhuongthuc, " +
                "dNgaylap = @dNgaylap WHERE sID_HoaDon = @sID_HoaDon";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sID_HoaDon", maHD);
            cmd.Parameters.AddWithValue("@sDiachi", diaChi.Text);
            cmd.Parameters.AddWithValue("@sTrangthai", trangThai.SelectedValue);
            cmd.Parameters.AddWithValue("@sSdt", sdt.Text);
            cmd.Parameters.AddWithValue("@sGhichu", ghiChu.Text);
            cmd.Parameters.AddWithValue("@sTongtien", tongTien.Text);
            cmd.Parameters.AddWithValue("@sPhuongthuc", phuongThuc.SelectedValue);
            cmd.Parameters.AddWithValue("@dNgaylap", ngayLap.Text);
            data.connDB();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            data.closeDB();
            lblThongBao.Text = "Bạn vừa cập nhật hóa đơn thành công!";
            grvHD.EditIndex = -1;
            LoadDSSP(ddlHoaDon.SelectedValue);

        }

        protected void grvHD_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
        {
            string maHD = grvHD.Rows[e.NewSelectedIndex].Cells[0].Text;
            data.closeDB();
            DataTable dt = new DataTable();
            query = "SELECT * FROM tbl_CTHoaDon WHERE sID_HoaDon = @MaHD";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            data.connDB();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@MaHD", maHD);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            data.closeDB();

            grvCTHD.DataSource = dt;
            grvCTHD.DataBind();
        }


        protected void grvHD_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grvHD.EditIndex = e.NewPageIndex;
            LoadDSSP(ddlHoaDon.SelectedValue);
        }

        /*CT Hóa đơn*/

        public void LoadCTHD()
        {
            /*            data.closeDB();
                        DataTable dt = new DataTable();

                        query = "SELECT * FROM tbl_CTHoaDon";
                        SqlCommand cmd = new SqlCommand(query, data.conn);
                        data.connDB();
                        cmd.Parameters.Clear();
                        SqlDataReader reader = cmd.ExecuteReader();
                        dt.Load(reader);
                        data.closeDB();

                        grvCTHD.DataSource = dt;
                        grvCTHD.DataBind();*/

            string maHD = grvCTHD.Rows[0].Cells[1].Text;
            data.closeDB();
            DataTable dt = new DataTable();
            query = "SELECT * FROM tbl_CTHoaDon WHERE sID_HoaDon = @MaHD";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            data.connDB();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@MaHD", maHD);
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            data.closeDB();

            grvCTHD.DataSource = dt;
            grvCTHD.DataBind();

        }
        /*        public void xoaCTHD()
                {
                    string maHD = grvCTHD.Rows[2].Cells[1].Text;
                    data.closeDB();
                    DataTable dt = new DataTable();
                    query = "SELECT * FROM tbl_CTHoaDon WHERE sID_CTHoaDon = @CTHD";
                    SqlCommand cmd = new SqlCommand(query, data.conn);
                    data.connDB();
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@CTHD", maHD);
                    SqlDataReader reader = cmd.ExecuteReader();
                    dt.Load(reader);
                    data.closeDB();

                    grvCTHD.DataSource = dt;
                    grvCTHD.DataBind();
                }*/

        protected void grvCTHD_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvCTHD.EditIndex = e.NewEditIndex;
            LoadCTHD();
        }

        protected void grvCTHD_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvCTHD.EditIndex = -1;
            LoadCTHD();
        }

        protected void grvCTHD_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string CTHD = grvCTHD.Rows[e.RowIndex].Cells[0].Text;
            string maHD = grvCTHD.Rows[e.RowIndex].Cells[1].Text;
            string maSP = grvCTHD.Rows[e.RowIndex].Cells[2].Text;
            TextBox soLuong = (TextBox)grvCTHD.Rows[e.RowIndex].Cells[3].Controls[0];
            TextBox donGia = (TextBox)grvCTHD.Rows[e.RowIndex].Cells[4].Controls[0];

            query = "UPDATE tbl_CTHoaDon set iSoluongmua = @soLuong, fDongia = @donGia WHERE sID_CTHoaDon = @sID_CTHoaDon";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sID_CTHoaDon", CTHD);
            cmd.Parameters.AddWithValue("@soLuong", soLuong.Text);
            cmd.Parameters.AddWithValue("@donGia", donGia.Text);

            data.connDB();
            cmd.ExecuteNonQuery();
            data.closeDB();

            lblThongBao1.Text = "Bạn vừa cập nhật một chi tiết hóa đơn thành công!";
            grvCTHD.EditIndex = -1;
            LoadCTHD();
        }

        protected void grvCTHD_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string CTHD = grvCTHD.Rows[e.RowIndex].Cells[0].Text;
            query = "DELETE tbl_CTHoaDon WHERE sID_CTHoaDon = @CTHD ";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CTHD", CTHD);
            data.connDB();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            data.closeDB();

            lblThongBao1.Text = "Bạn vừa một xóa hóa đơn thành công! ";
            LoadCTHD();
        }


    }
}