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
    public partial class EmailBody : System.Web.UI.Page
    {
        DataProvider data = new DataProvider();
        protected void Page_Load(object sender, EventArgs e)
        {
            string query = "SELECT tbl_CTGioHang.*, tbl_SanPham.sTenSanPham, tbl_CTGioHang.sUserName FROM tbl_CTGioHang JOIN tbl_SanPham ON tbl_SanPham.sID_SanPham = tbl_CTGioHang.sID_SanPham WHERE tbl_CTGioHang.sUserName=@user AND tbl_CTGioHang.sCheck IS NULL";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.AddWithValue("@user", "salasovo10000@gmail.com");
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                DataTable dt = new DataTable();
                da.Fill(dt);
                ListView1.DataSource = dt;
                ListView1.DataBind();
            }
        }
    }
}