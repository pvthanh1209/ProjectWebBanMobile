using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web
{
    public partial class Thanhtoan : System.Web.UI.Page
    {

        DataProvider data = new DataProvider();
        List<string> list;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                list = Session["NumberCart"] as List<string>;
                string total = Request.QueryString["total"];
                lblUser.Text = Session["Hoten"].ToString();
                string query = "SELECT tbl_CTGioHang.*, tbl_SanPham.sTenSanPham, tbl_CTGioHang.sUserName FROM tbl_CTGioHang JOIN tbl_SanPham ON tbl_SanPham.sID_SanPham = tbl_CTGioHang.sID_SanPham WHERE tbl_CTGioHang.sUserName=@user AND tbl_CTGioHang.sCheck IS NULL";
                SqlCommand cmd = new SqlCommand(query, data.conn);
                cmd.Parameters.AddWithValue("@user", Session["Username"].ToString());
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    ListView1.DataSource = dt;
                    ListView1.DataBind();
                }
                int index = 0;
                foreach (ListViewDataItem lv in ListView1.Items)
                {
                    Label lblThanhtien = lv.FindControl("lblTamtinh") as Label;
                    lblThanhtien.Text = list[index] + "<sup>đ</sup>";
                    index++;
                }
                lblTongTien.Text = total + "<sup>đ</sup>";
            }
        }


        string maSP;
        int index = 0;
        protected void Pay_Click1(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            list = Session["NumberCart"] as List<string>;
            DataTable dt = data.getDT("SELECT * FROM tblHoaDon");
            int count = dt.Rows.Count + 1;
            data.closeDB();
            string idCount = "CTCMOBILE" + count.ToString();
            string query = "INSERT INTO tblHoaDon VALUES (@idHD,@user,@diachi,@trangthai,@sdt,@ghichu,@tongtien,@phuongthuc,@ngaylap)";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.AddWithValue("@idHD", idCount);
            cmd.Parameters.AddWithValue("@user", Session["Username"].ToString());
            cmd.Parameters.AddWithValue("@diachi", txtDiaChi.Text);
            cmd.Parameters.AddWithValue("@trangthai", "CHỜ XÁC NHẬN");
            cmd.Parameters.AddWithValue("@sdt", lblPhone.Text);
            cmd.Parameters.AddWithValue("@ghichu", txtGhichu.Text);
            cmd.Parameters.AddWithValue("@tongtien", float.Parse(Request.QueryString["total"]));
            cmd.Parameters.AddWithValue("@phuongthuc", RadioButtonList1.SelectedValue);
            cmd.Parameters.AddWithValue("@ngaylap", now);
            data.connDB();
            cmd.ExecuteNonQuery();
            data.closeDB();
            foreach (ListViewDataItem lv in ListView1.Items)
            {
                Label lblSP = lv.FindControl("lblTenSP") as Label;
                Label lblSL = lv.FindControl("lblSoluong") as Label;
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

                SqlCommand cmd2 = new SqlCommand("INSERT INTO tbl_CTHoaDon VALUES(@HD,@SP,@sl,@gia,null)", data.conn);
                cmd2.Parameters.AddWithValue("@HD", idCount);
                cmd2.Parameters.AddWithValue("@SP", maSP);
                cmd2.Parameters.AddWithValue("@sl", lblSL.Text);
                cmd2.Parameters.AddWithValue("@gia", float.Parse(list[index]));
                index++;
                data.connDB();
                cmd2.ExecuteNonQuery();
                data.closeDB();

                SqlCommand cmd3 = new SqlCommand("UPDATE tbl_SanPham SET iSoluong_Kho = iSoluong_Kho - @sl WHERE sID_SanPham = @idsp", data.conn);
                cmd3.Parameters.AddWithValue("@idsp", maSP);
                cmd3.Parameters.AddWithValue("@sl", int.Parse(lblSL.Text));
                data.connDB();
                cmd3.ExecuteNonQuery();
                data.closeDB();

                SqlCommand cmd4 = new SqlCommand("UPDATE tbl_CTGioHang SET sCheck = 'X' WHERE sID_SanPham = @id AND sUserName = @user AND sCheck IS NULL", data.conn);
                cmd4.Parameters.AddWithValue("@id", maSP);
                cmd4.Parameters.AddWithValue("@user", Session["Username"]);
                data.connDB();
                cmd4.ExecuteNonQuery();
                data.closeDB();
            }


            string body = "";
            string listOrder = "";
            StreamReader str = new StreamReader(Server.MapPath("~/EmailBody.html"));
            body = str.ReadToEnd();
            str.Close();

            //using (MailMessage mail = new MailMessage())
            //{
            //    foreach (ListViewDataItem lv in ListView1.Items)
            //    {
            //        Label lblSL = lv.FindControl("lblSoluong") as Label;
            //        Label lblSP = lv.FindControl("lblTenSP") as Label;
            //        listOrder += "<tr style=\"display: block; padding-bottom: 10px;\">";
            //        listOrder += "<td width=\"600px;\" style=\"text-align: left; vertical-align: middle; color: #555555; font-size: 18px; font-weight: 600;\">" + lblSP.Text + "</td>";
            //        listOrder += "<td width=\"500px;\" style=\"text-align: right; vertical-align: top; font-size: 18px; color: #555555;font-weight: 600;\">Số lượng: " + lblSL.Text + "</td>";
            //        listOrder += "</tr>";
            //    }
            //    mail.From = new MailAddress("thanhpham12092000@gmail.com");
            //    mail.To.Add("nguyendung112999@gmail.com");
            //    mail.Subject = "[CTC MOBILE]Thông báo đặt đơn hàng " + idCount + " thành công";
            //    body = body.Replace("{idDonHang}", idCount);
            //    body = body.Replace("{Username}", Session["Hoten"].ToString());
            //    body = body.Replace("{ListOrder}", listOrder);
            //    body = body.Replace("{TotalProduct}", Server.HtmlEncode(String.Format("{0:0,0}", (double.Parse(Request.QueryString["total"]) - 20000))) + "đ");
            //    body = body.Replace("{TotalOrder}", lblTongTien.Text);
            //    body = body.Replace("{Phone}", lblPhone.Text);
            //    body = body.Replace("{Address}", txtDiaChi.Text);
            //    body = body.Replace("{Ship}", RadioButtonList1.SelectedValue);
            //    body = body.Replace("{Noti}", txtGhichu.Text);
            //    mail.Body = body;
            //    mail.IsBodyHtml = true;
            //    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            //    {
            //        smtp.Credentials = new System.Net.NetworkCredential("thanhpham12092000@gmail.com", "yenthanh");
            //        smtp.EnableSsl = true;
            //        smtp.Send(mail);

            //    }

            //}
            Response.Redirect("OrderSuccess.aspx?idhd=" + idCount);
        }
    }
}