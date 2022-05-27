<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/core.Master" AutoEventWireup="true" CodeBehind="Chitietsanpham.aspx.cs" Inherits="BTL_Web.Chitietsanpham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .btnMore:not(.btnMore:last-child) {
            display: none;
        }

        .btnMore {
            background-color: transparent;
            text-align: center;
            padding: 8px 18px;
            border-radius: 4px;
            margin-top: 20px;
            font-weight: bold;
            font-size: 16px;
            margin-left: 42%;
            border: 1px solid black;
        }

            .btnMore:hover {
                color: white;
                background-color: black;
            }

        .table-info {
            width: 300px;
            font-size: 18px;
        }

            .table-info td:first-child {
                font-weight: bold;
            }

            .table-info table {
                border-collapse: collapse;
                width: 100%;
            }

            .table-info td:not(.table-info td:first-child) {
                padding: 8px;
                text-align: left;
                border-left: 1px solid #DDD;
            }


            .table-info tr:hover {
                background-color: #D6EEEE;
            }
    </style>
    <div class="body-detail-product">
        <div class="header-detail-product">
            <asp:FormView ID="FormView1" runat="server" OnItemCommand="FormView1_ItemCommand">
                <ItemTemplate>
                    <div class="row-detail">
                        <div class="col-img img-product">
                            <img width="450px" height="450px" src="<%# Eval("sImg") %>">
                        </div>
                        <div class="col-detail detail-product">
                            <div class="header-detail"><span><%# Eval("sTenLoaiHang") %></span></div>
                            <div class="name-detail"><span><b><%# Eval("sTenSanPham") %></b></span></div>
                            <div class="price-detail">
                                <asp:Panel id="spGiaCu" style="padding-top:1px" CssClass="chitiet-giacu" runat="server"><del>
                                    <asp:Label ID="txtGiaCu" runat="server" Text='<%# Eval("fDongia","{0:0,0}") %>'></asp:Label><sup>đ</sup></del></asp:Panel>
                                <b>
                                    <asp:Label ID="txtGia" runat="server" Text='<%# Eval("fGiamgia","{0:0,0}") %>'></asp:Label><sup>đ</sup></b>
                            </div>

                            <div class="info-detail">
                                <ul>
                                    <li><%# Eval("sMota_1") %></li>
                                    <li><%# Eval("sMota_2") %></li>
                                    <li><%# Eval("sMota_3") %></li>
                                </ul>
                            </div>
                            <div class="rest-detail">
                                <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
                            </div>
                            <form>
                                <div class="mount-product">
                                    <input type="button" onclick="decProduct(this)" class="btnDec" value="-"><asp:TextBox ID="txtSL" Text="1" CssClass="txtNum" runat="server"></asp:TextBox><input type="button" onclick="    incProduct(this)" class="btnIcr" value="+">
                                    <asp:Button ID="Button1" CssClass="btnThem" runat="server" CommandName="Them" Text="THÊM VÀO GIỎ HÀNG" />
                                </div>
                                <asp:Label Visible="false" ID="txtIDSP" runat="server" Text='<%#Eval("sID_SanPham") %>'></asp:Label></td>

                            </form>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:FormView>
        </div>
        <div class="body-detail-product">
            <div class="body-header">
                <div class="tabs">
                    <input type="radio" name="tabs" id="tabone" checked="checked">
                    <label for="tabone">THÔNG TIN</label>
                    <div class="tab">
                        <asp:FormView ID="FormView2" runat="server">
                            <ItemTemplate>
                                <table class="table-info" style="border-color: #96D4D4;">
                                    <tr>
                                        <td>Số lượng kho: </td>
                                        <td>
                                            <asp:Label ID="txtSL" runat="server" Text='<%#Eval("iSoluong_Kho") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Mã sản phẩm:</td>
                                        <td>
                                            <asp:Label ID="txtID" runat="server" Text='<%#Eval("sID_SanPham") %>'></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Danh mục:
                                        </td>
                                        <td>
                                            <asp:Label ID="txtTenLH" runat="server" Text='<%#Eval("sTenLoaiHang") %>'></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Nhà sản xuất: </td>

                                        <td>
                                            <asp:Label ID="txtNSX" runat="server" Text=' <%#Eval("sNhaSanXuat") %>'></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </ItemTemplate>
                        </asp:FormView>
                    </div>
                    <input type="radio" name="tabs" id="tabtwo">
                    <label for="tabtwo">
                        <asp:Label ID="Label_danhgia" runat="server"></asp:Label>
                    </label>

                    <div class="tab" runat="server">
                        <p id="notiLogin" runat="server" class="noti-login">Bạn cần đăng nhập để sử dụng chức năng này</p>
                        <%--<asp:Panel ID="Panel1" runat="server" Visible="false" DefaultButton="btn_danhgia">
							           <div id="infoCMT" style="display:none;" class="info-cmt" runat ="server">
                                            <input id="Txt_danhgia" runat="server" type="text" class="txtComment" placeholder ="Comment...">
							            <asp:Button ID="btn_danhgia" CssClass="btnCmt" runat="server" Text="Đăng" OnClick="btn_danhgia_Click" />
                                           </div>
					            </asp:Panel>--%>
                        <div id="infoCMT" style="display: none;" class="info-cmt" runat="server">
                            <textarea id="Txt_danhgia" style="overflow: hidden; font-size: 16px" cols="20" rows="2" runat="server" onkeydown="Trig()" type="text" class="txtComment" placeholder="Comment..."></textarea>
                            <input id="btn_danhgia" runat="server" class="btnCmt" type="button" value="Đăng" />
                        </div>
                        <div id="myItemview"></div>
                        <div id="myListview"></div>
                        <div id="listview">
                            <asp:ListView ID="Danhgia" runat="server">
                                <ItemTemplate>
                                    <div class="comment" runat="server">
                                        <asp:Label ID="Username" CssClass="username-cmt" runat="server" Text='<%# Eval("sHoTen") %>'></asp:Label>
                                        <asp:Label ID="Comments" runat="server" Text='<%# Eval("sBinhLuan") %>'></asp:Label>
                                        <asp:Label ID="Label1" CssClass="time-cmt" runat="server" Text='<%# Eval("dThoigian") %>'></asp:Label>
                                    </div>
                                </ItemTemplate>
                            </asp:ListView>
                        </div>
                        <div id="test">
                            <input id="Xemthem" style="display: none;" class="btnMore" runat="server" type="button" value="Xem thêm đánh giá ▼" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="body-bottom">
            <span>SẢN PHẨM TƯƠNG TỰ</span>
            <div class="all-product">
                <asp:ListView ID="lvSPLienQuan" runat="server" OnItemCommand="lvSPLienQuan_ItemCommand" OnItemDataBound="lvSPLienQuan_ItemDataBound">
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
                                    <asp:Label ID="lblGiaMoi" runat="server" Text='<%# Eval("fGiamgia","{0:0,0}") %>' /><span><sup>đ</sup></span></div>
                            </div>
                            <div class="product-addCart">
                                <asp:Button runat="server" CssClass="btnAddCart" ID="btnAdd" Text="Thêm vào giỏ hàng" CommandArgument='<%# Eval("sID_SanPham") %>' CausesValidation="False" />
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </div>
</asp:Content>
