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
    public class AddToCart : DataProvider
    {
        public void addItemCart(Label lblID, Label lblGia, int sl, string user, Page page)
        {
            AddToCart data = new AddToCart();
            /*Tăng ID giỏ hàng*/
            int incID;
            string idCart;
            string getCount = "SELECT max(sID_CTGioHang) FROM tbl_CTGioHang";
            DataTable dt = data.getDT(getCount);
            DataRow dataRow = dt.Rows[0];
            incID = Convert.ToInt32(dataRow[0]) + 1;
            /*incID = dt.Rows.Count + 1;*/
            data.closeDB();


            /*Xử lý thêm giỏ hàng*/
            SqlCommand cmd0 = new SqlCommand("SELECT iSoluong_Kho FROM tbl_SanPham WHERE sID_SanPham = @id", data.conn);
            cmd0.Parameters.AddWithValue("@id", lblID.Text);
            data.connDB();
            cmd0.ExecuteNonQuery();
            SqlDataReader dr;
            dr = cmd0.ExecuteReader();
            if (dr.Read())
            {
                int soluongkho = int.Parse(dr["iSoluong_Kho"].ToString());
                if (soluongkho < sl)
                {
                    ScriptManager.RegisterStartupScript(page, typeof(Page), "alert", "alert('Sản phẩm này hiện không đủ số lượng bạn yêu cầu');", true);
                    data.closeDB();
                }
                else
                {
                    using (SqlCommand cmd = new SqlCommand("Select * From tbl_CTGioHang WHERE sUserName = @user AND sID_SanPham = @sp AND sCheck IS NULL", data.conn))
                    {
                        data.closeDB();
                        cmd.Parameters.AddWithValue("@user", user);
                        cmd.Parameters.AddWithValue("@sp", lblID.Text);
                        data.connDB();
                        cmd.ExecuteNonQuery();
                        DataTable dt1 = new DataTable();
                        SqlDataReader dr1;
                        dr1 = cmd.ExecuteReader();
                        if (dr1.Read())
                        {
                            using (SqlCommand comm = new SqlCommand("UPDATE tbl_CTGioHang SET iSoluongmua = iSoluongmua + 1 WHERE sID_SanPham = @idsp AND sUserName = @idUser AND sCheck IS NULL;", data.conn))
                            {
                                data.closeDB();
                                comm.Parameters.AddWithValue("@idsp", lblID.Text);
                                comm.Parameters.AddWithValue("@idUser", user);
                                data.connDB();
                                comm.ExecuteNonQuery();
                                data.closeDB();
                            }
                        }
                        else
                        {
                            using (SqlCommand comm = new SqlCommand("INSERT INTO tbl_CTGioHang(sID_CTGioHang, sID_SanPham, iSoluongmua, fThanhTien, sUserName, sCheck) values( @idCart, @idSP, @soluong, @thanhtien, @user, null)", data.conn))
                            {
                                data.closeDB();
                                idCart = incID.ToString();
                                comm.Parameters.AddWithValue("@idCart", idCart);
                                comm.Parameters.AddWithValue("@idSP", lblID.Text);
                                comm.Parameters.AddWithValue("@soluong", int.Parse(sl.ToString()));
                                comm.Parameters.AddWithValue("@thanhtien", float.Parse(lblGia.Text));
                                comm.Parameters.AddWithValue("@user", user);
                                data.connDB();
                                comm.ExecuteNonQuery();
                                data.closeDB();
                            }
                        }
                    }
                }
            }
        }
    }
}