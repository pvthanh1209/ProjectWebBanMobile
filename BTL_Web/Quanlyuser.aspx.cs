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
    public partial class Quanlyuser : System.Web.UI.Page
    {
        DataProvider data = new DataProvider();
        String query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadUser();
            }
        }

        public void LoadUser()
        {
            DataTable dt = new DataTable();
            data.connDB();
            query = "SELECT * FROM tbl_User";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            SqlDataReader reader = cmd.ExecuteReader();
            dt.Load(reader);
            data.closeDB();

            GridView1.DataSource = dt;
            GridView1.DataBind();
        }

        protected void GridView1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex;
            LoadUser();
        }

        protected void GridView1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;
            LoadUser();
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            string userName = GridView1.Rows[e.RowIndex].Cells[0].Text;
            TextBox passWord = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            TextBox hoTen = (TextBox)GridView1.Rows[e.RowIndex].Cells[2].Controls[0];
            TextBox type = (TextBox)GridView1.Rows[e.RowIndex].Cells[3].Controls[0];
            TextBox moTa = (TextBox)GridView1.Rows[e.RowIndex].Cells[4].Controls[0];

            query = "UPDATE tbl_User set sPassWord = @sPassWord, sHoTen = @sHoTen, iType = @iType, sMoTa = @sMoTa WHERE sUserName = @sUserName ";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();

            cmd.Parameters.AddWithValue("@sUserName", userName);
            cmd.Parameters.AddWithValue("@sPassWord", passWord.Text);
            cmd.Parameters.AddWithValue("@sHoTen", hoTen.Text);
            cmd.Parameters.AddWithValue("@iType", type.Text);
            cmd.Parameters.AddWithValue("@sMoTa", moTa.Text);
            data.connDB();
            cmd.ExecuteNonQuery();
            data.closeDB();
            cmd.Dispose();

            lblThongBao.Text = "Bạn đã cập nhật thành công!";

            GridView1.EditIndex = -1;
            LoadUser();
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string userName = GridView1.Rows[e.RowIndex].Cells[0].Text;
            query = "DELETE tbl_User WHERE sUserName = @sUserName";
            SqlCommand cmd = new SqlCommand(query, data.conn);
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@sUserName", userName);
            data.connDB();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            data.closeDB();
            lblThongBao.Text = "Bạn đã xóa thành công!";
            LoadUser();
        }
    }
}