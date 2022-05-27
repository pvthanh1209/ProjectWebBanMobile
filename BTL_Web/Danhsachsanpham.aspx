<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/core.Master" AutoEventWireup="true" CodeBehind="Danhsachsanpham.aspx.cs" Inherits="BTL_Web.Danhsachsanpham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        div.pager {
            margin-top: 45px;
            text-align: center;
        }

            div.pager a {
                text-decoration: none;
                border: 1px solid black;
                padding: 3px 8px;
                display: inline-block;
                margin: auto 2px;
                background-color: white;
                color: black;
                font-weight: bold;
                border-radius: 50%;
            }
            div.pager span span {
                border: 1px solid black;
                padding: 3px 8px;
                display: inline-block;
                margin: auto 2px;
                background-color: black;
                color: white;
                font-weight: bold;
                border-radius: 50%;
            }

        .current {
            color: black;
        }

        .numeric {
            color: black;
        }
    </style>
    <div>
        <img width="100%;" src="images/black-friday.jpg">
    </div>
    <div class="body-shop">
        <div class="list-product">
            <div class="row-shop">
                <div class="col-shop danhmuc">

                    <div class="danhmuc-header">
                        <span>
                            <asp:Label ID="Label1" runat="server"></asp:Label></span>
                    </div>

                    <div class="filter">
                        <span>Lọc theo giá</span>
                        <div class="btn-filter">
                            <input style="width: 35%;" type="number" value="Từ" class="form-control" id="cost_1">
                            <input style="width: 35%;" type="number" value="Đến" class="form-control" id="cost_2">
                            <button type="button" class="btn btn-default" onclick="loc_click" runat="server"><i class="fa fa-filter" aria-hidden="true"></i></button>
                        </div>
                    </div>
                    <div id="listSearch" runat="server" class="list-Search">
                        <span><b>Hãng sản xuất</b></span>
                        <br>
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click"><span>APPLE</span></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="LinkButton2_Click"><span>SAMSUNG</span></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton3" runat="server" OnClick="LinkButton3_Click"><span>OPPO</span></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton4" runat="server" OnClick="LinkButton4_Click"><span>XIAOMI</span></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton5" runat="server" OnClick="LinkButton5_Click"><span>VIVO</span></asp:LinkButton>
                        <asp:LinkButton ID="LinkButton6" runat="server" OnClick="LinkButton6_Click"><span>HUAWEI</span></asp:LinkButton>
                    </div>
                    <div class="video-introduce">
                        <iframe width="100%" src="https://www.youtube.com/embed/MMdQ-gWBNZE" title="YouTube video player" frameborder="0" allow="accelerometer; autoplay; clipboard-write; encrypted-media; gyroscope; picture-in-picture" allowfullscreen=""></iframe>
                    </div>
                </div>
                <div class="col-shop list-sanpham">
                    <div class="best-product">
                        <div class="filter-sort">
                            <asp:DropDownList ID="DropDownList1" CssClass="product-option" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                                <asp:ListItem Value="Default">Thứ tự mặc định</asp:ListItem>
                                <asp:ListItem Value="DESC">Thứ tự theo giá: Cao đến thấp</asp:ListItem>
                                <asp:ListItem Value="ASC">Thứ tự theo giá: Thấp đến cao</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div id="listProduct" runat="server" class="wide-listsp">
                            <asp:ListView ID="lvProduct" runat="server" OnItemCommand="lvProduct_ItemCommand" OnPagePropertiesChanging="lvProduct_PagePropertiesChanging" OnDataBound="lvProduct_DataBound" OnItemDataBound="lvProduct_ItemDataBound">
                                <ItemTemplate>
                                    <div class="product-selling-main ">
                                        <div class="product-img">
                                            <asp:Label ID="lblIDSP" Visible="false" runat="server" Text='<%# Eval("sID_SanPham") %>' />
                                            <a href="Chitietsanpham.aspx?sID_SanPham=<%# Eval("sID_SanPham") %>">
                                                <img src="<%# Eval("sImg") %>"><h1>XEM NGAY</h1>
                                            </a>
                                        </div>
                                        <div class="product-selling-name"><span><%# Eval("sTenSanPham") %></span></div>
                                        <div class="product-selling-price">
                                            <asp:Panel ID="idSaleGiaCu" CssClass="old-price price" runat="server">
                                                <asp:Label ID="lblGiaCu" runat="server" Text='<%# Eval("fDongia","{0:0,0}") %>'></asp:Label><span><sup>đ</sup></span>
                                            </asp:Panel>
                                            <div class="new-price price">
                                                <asp:Label ID="lblGiaMoi" runat="server" Text='<%# Eval("fGiamgia","{0:0,0}") %>' /><span><sup>đ</sup></span>
                                            </div>
                                        </div>
                                        <div class="product-addCart">
                                            <asp:Button runat="server" CssClass="btnAddCart" ID="btnAdd" Text="Thêm vào giỏ hàng" CommandArgument='<%# Eval("sID_SanPham") %>' CausesValidation="False" />
                                        </div>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <div class="pager">
                            <asp:DataPager ID="DataPager1" runat="server" PagedControlID="lvProduct" PageSize="6">
                                <Fields>
                                    <asp:NumericPagerField CurrentPageLabelCssClass="current"
                                        NextPreviousButtonCssClass="next" NumericButtonCssClass="numeric"
                                        ButtonCount="10" NextPageText=">" PreviousPageText="<"
                                        RenderNonBreakingSpacesBetweenControls="false" />
                                </Fields>
                            </asp:DataPager>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
