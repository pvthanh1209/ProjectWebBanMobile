using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;

namespace BTL_Web
{
    public partial class Danhgia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            if (!Page.IsPostBack)
            {
                DataProvider data = new DataProvider();
                string query = "select ISNULL(AVG(iStar), 0) AverageRating, count(sID_DanhGia) cou from tbl_DanhGia where sID_DanhGia like '%R%'";
                dt = data.getDT(query);
                Rating1.CurrentRating = Convert.ToInt32(dt.Rows[0]["AverageRating"]);
                lbresult.Text = string.Format("{0}/5", dt.Rows[0]["AverageRating"]);
                int numRate = int.Parse(dt.Rows[0]["cou"].ToString()) - 1;
                lblTotalRate.Text = string.Format("Dựa trên đánh giá của {0} người", numRate.ToString());
                filldata();
                
            }
        }
        void filldata()
        {
            string query = "select * from tbl_DanhGia where sID_DanhGia like '%R%' order by dThoigian DESC";
            DataProvider data = new DataProvider();
            DataTable dataTable = data.getDT(query);
            ListView1.DataSource = dataTable;
            ListView1.DataBind();
        }

        protected void btnsubmit_Click(object sender, EventArgs e)
        {
            if ((bool)Session["login"] == true)
            {
                if (Txt_dg.Value != string.Empty)
                {
                    DataProvider data = new DataProvider();
                    int incID;
                    string getCount = "SELECT * FROM tbl_DanhGia where sID_DanhGia like '%R%'";
                    DataTable dtcount = data.getDT(getCount);
                    incID = dtcount.Rows.Count + 1;
                    string query = "insert into tbl_DanhGia values (@id_dg, @bl, @username, null, @time, @star)";
                    SqlCommand cmd = new SqlCommand(query, data.conn);
                    cmd.Parameters.AddWithValue("@bl", Txt_dg.Value);
                    cmd.Parameters.AddWithValue("@username", Session["Username"].ToString());
                    cmd.Parameters.AddWithValue("@id_dg", "R" + incID.ToString());
                    cmd.Parameters.AddWithValue("@time", DateTime.Now);
                    cmd.Parameters.AddWithValue("@star", Rating1.CurrentRating);
                    data.connDB();
                    cmd.ExecuteNonQuery();
                    data.closeDB();
                    Txt_dg.Value = string.Empty;
                    filldata();
                    filldata();
                }
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Bạn cần đăng nhập để sử dụng chức năng này.');", true);
                Txt_dg.Value = string.Empty;
            }
        }

        protected void ListView1_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
           
            
        }
    }
}