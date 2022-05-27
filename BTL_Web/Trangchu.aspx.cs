using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace BTL_Web
{
    public partial class Trangchu : System.Web.UI.Page
    {
        DataProvider data = new DataProvider();
        String query = "";
        string id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                hot_product();
                sale_product();
            }

        }
        void hot_product()
        {
            query = "SELECT TOP 8 * FROM [tbl_SanPham];";
            DataTable dataTable = data.getDT(query);

            lvHotProduct.DataSource = dataTable;
            lvHotProduct.DataBind();
        }
        void sale_product()
        {
            query = "SELECT TOP 8 * FROM [tbl_SanPham] WHERE fSale>10;";
            DataTable dataTable = data.getDT(query);
            
                    lvSaleProduct.DataSource = dataTable;
                    lvSaleProduct.DataBind();
    
        }

        protected void lvHotProduct_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if ((bool)Session["login"] == true)
            {
                AddToCart add = new AddToCart();
                add.addItemCart((Label)e.Item.FindControl("Label1"), (Label)e.Item.FindControl("lblGiaMoi"), 1, Session["Username"].ToString(),this);
                Response.Redirect("Giohang.aspx");      
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Bạn cần đăng nhập để sử dụng chức năng này.');", true);
            }
        }

        protected void lvSaleProduct_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if ((bool)Session["login"] == true)
            {
                AddToCart add = new AddToCart();
                add.addItemCart((Label)e.Item.FindControl("lblIDSP"), (Label)e.Item.FindControl("lblGiaMoi"), 1, Session["Username"].ToString(),this);
                Response.Redirect("Giohang.aspx");
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(Page), "alert", "alert('Bạn cần đăng nhập để sử dụng chức năng này.');", true);
            }
        }

        protected void lvHotProduct_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                showGia((Label)e.Item.FindControl("lblGiaCu"), (Label)e.Item.FindControl("lblGiaMoi"), (Panel)e.Item.FindControl("idHotGiaCu"));
            }
        }

        protected void lvSaleProduct_ItemDataBound(object sender, ListViewItemEventArgs e)
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
        private DataSet getCart(string user)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-HEUQBNO\XUANCUONG;Initial Catalog=WebNC;Integrated Security=True"))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandType = System.Data.CommandType.Text;
                        cmd.CommandText = "Select tbl_SanPham.*, tbl_CTGioHang.* FROM tbl_SanPham INNER JOIN tbl_CTGioHang ON tbl_SanPham.sID_SanPham = tbl_CTGioHang.sID_SanPham WHERE tbl_CTGioHang.sUserName = @user AND tbl_CTGioHang.sCheck IS NULL";
                        cmd.Parameters.AddWithValue("@user", user);
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataSet ds = new DataSet();
                            da.Fill(ds);
                            if (ds.Tables[0].Rows.Count > 0)
                            {
                                return ds;
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
    }
}