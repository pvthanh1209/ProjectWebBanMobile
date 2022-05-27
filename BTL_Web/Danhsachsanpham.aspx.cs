using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BTL_Web
{
    public partial class Danhsachsanpham : System.Web.UI.Page
    {
        string query = "";
        DataProvider data = new DataProvider();
        public string nsx = "";
        public string choose = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                fillData(nsx, choose);
            }
        }

        void fillData(string nsx, string choose)
        {
            string name = Request.QueryString["name"];
            string lh = Request.QueryString["lh"];
            string search = "";
            if (lh != string.Empty)
            {
                query = "Select * from tbl_SanPham where sID_LoaiHang = " + lh;
            }
            else
            {
                search = Request.QueryString["search"];
                query = "Select * from tbl_SanPham where sTenSanPham Like '%" + search + "%'";
                listSearch.Visible = false;
            }
            if (nsx != name && String.Compare(nsx, search, true) != 0 && nsx != "")
            {
                name = nsx;
                query += "And sNhaSanXuat = " + nsx + choose;
            }
            else
            {
                query += choose;
            }
            DataTable dataTable = data.getDT(query);
            lvProduct.DataSource = dataTable;
            lvProduct.DataBind();
            lvProduct.Visible = true;

            Label1.Text = name;
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            nsx = "'Apple'";
            fillData(nsx, choose);
            Label1.Text = nsx;
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            nsx = "'Samsung'";
            fillData(nsx, choose);
            Label1.Text = nsx;
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            nsx = "'Oppo'";
            fillData(nsx, choose);
            Label1.Text = nsx;
        }
        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            nsx = "'Xiaomi'";
            fillData(nsx, choose);
            Label1.Text = nsx;
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            nsx = "'Vivo'";
            fillData(nsx, choose);
            Label1.Text = nsx;
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            nsx = "'Huawei'";
            fillData(nsx, choose);
            Label1.Text = nsx;
        }

        protected void lvProduct_ItemCommand(object sender, ListViewCommandEventArgs e)
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

        public void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string desc = "ORDER BY fGiamgia DESC";
            string asc = "ORDER BY fGiamgia ASC";
            if (DropDownList1.SelectedValue == "ASC")
            {
                fillData(Label1.Text, asc);
            }
            else if (DropDownList1.SelectedValue == "DESC")
            {
                fillData(Label1.Text, desc);
            }
            else if (DropDownList1.SelectedValue == "Default")
            {
                fillData(Label1.Text, choose);
            }
            Label1.Text = Label1.Text;
        }

        protected void lvProduct_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

            this.DataPager1.SetPageProperties(e.StartRowIndex, DataPager1.PageSize, false);
            fillData(nsx, choose);
        }

        protected void lvProduct_DataBound(object sender, EventArgs e)
        {
            DataPager1.Visible = (DataPager1.PageSize < DataPager1.TotalRowCount);
        }

        protected void lvProduct_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            Panel lblDiv = (Panel)e.Item.FindControl("idSaleGiaCu");
            Label lblGiacu = (Label)e.Item.FindControl("lblGiaCu");
            Label lblGiamoi = (Label)e.Item.FindControl("lblGiaMoi");
            if (float.Parse(lblGiacu.Text.ToString()) == float.Parse(lblGiamoi.Text.ToString()))
            {
                lblDiv.Visible = false;
            }
        }
    }
}