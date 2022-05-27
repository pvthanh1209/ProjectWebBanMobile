<%@ Page Title="" EnableEventValidation="false" Language="C#" MasterPageFile="~/core.Master" AutoEventWireup="true" CodeBehind="Trangchu.aspx.cs" Inherits="BTL_Web.Trangchu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="main-content">
        <div class="slider">
            <div class="slides">
                <input type="radio" checked="checked" name="radio-btn" id="radio1" value="1">
                <input type="radio" name="radio-btn" id="radio2" value="2">
                <input type="radio" name="radio-btn" id="radio3" value="3">
                <input type="radio" name="radio-btn" id="radio4" value="4">
                <div id="slide1" class="slide first">
                    <div class="img"></div>
                    <div class="description">
                        <span>SIÊU SALE CHÚC MỪNG SINH NHẬT</span>
                        <span>Apple Watch Series 7</span>
                        <span>Giảm ngay 1 triệu động từ 15/2-28/2</span>
                        <a href="">
                            <button class="btnDetail" type="submit">Xem ngay ></button></a>
                    </div>
                </div>
                <div id="slide2" class="slide" style="cursor: pointer;" onclick="javascript:window.location.href='thanhtoan.html'">
                    <div class="img"></div>
                </div>


                <div id="slide3" class="slide">
                    <div class="img"></div>
                    <div class="description2">
                        <span>Pin cực khủng</span>
                        <a href="">
                            <button class="btnDetail2" type="submit">XEM NGAY ></button></a>
                    </div>
                </div>
                <div id="slide4" class="slide">
                    <div class="img"></div>
                    <div class="description">
                        <span>Từ 25/3-14/4</span>
                        <span>Samsung Galaxy S22 Ultra</span>
                        <span>Ưu đãi lên tới 8 triệu đồng</span>
                        <a href="">
                            <button class="btnDetail" type="submit">Xem ngay ></button></a>
                    </div>
                </div>

                <div class="navigation-auto">
                    <div class="auto-btn1"></div>
                    <div class="auto-btn2"></div>
                    <div class="auto-btn3"></div>
                    <div class="auto-btn4"></div>
                </div>

            </div>

            <div class="navigation-manual">
                <label for="radio1" class="manual-btn"></label>
                <label for="radio2" class="manual-btn"></label>
                <label for="radio3" class="manual-btn"></label>
                <label for="radio4" class="manual-btn"></label>
            </div>

        </div>

        <div class="wrap-banner wide">
            <a href="Danhsachsanpham.aspx?lh='LH01'" class="tag">
                <div class="product1">
                    <div class="img-product">
                        <img src="images/anh1.jpg">
                    </div>
                    <div class="sale-detail-1 chung">
                        <span><b>ĐIỆN THOẠI</b></span><br>
                        <center><span class="sale-product">Giảm 50%</span></center>
                    </div>
                </div>
            </a>
            <a href="Danhsachsanpham.aspx?lh='LH02'" class="tag">
                <div class="product1">
                    <div class="img-product ">
                        <img src="images/anh2.jpg">
                    </div>
                    <div class="sale-detail-2 chung">
                        <span><b>MÁY TÍNH BẢNG</b></span><br>
                        <center><span class="sale-product">Giảm 10%</span></center>
                    </div>
                </div>
            </a>
            <a href="Danhsachsanpham.aspx?lh='LH03'" class="tag">
                <div class="product1">
                    <div class="img-product">
                        <img src="images/anh3.jpg">
                    </div>
                    <div class="sale-detail-3 chung">
                        <span><b>PHỤ KIỆN</b></span><br>
                        <center><span class="sale-product">Giảm 30%</span></center>
                    </div>
                </div>
            </a>
        </div>

        <div class="best-product">
            <div class="product-selling-title">
                <h1 class="title-hr">
                    <hr />
                    SẢN PHẨM BÁN CHẠY<hr />
                </h1>
                <hr>
            </div>
            <div class="all-product">
                <asp:ListView ID="lvHotProduct" runat="server" OnItemCommand="lvHotProduct_ItemCommand">
                    <ItemTemplate>
                        <div class="product-selling-main ">
                            <div class="product-img">
                                <asp:Label ID="Label1" Visible="false" runat="server" Text='<%# Eval("sID_SanPham") %>' />
                                <a href="Chitietsanpham.aspx?sID_SanPham=<%# Eval("sID_SanPham") %>">
                                    <img src="<%# Eval("sImg") %>"><h1>XEM NGAY</h1>
                                </a>
                            </div>
                            <div class="product-selling-name"><span><%# Eval("sTenSanPham") %></span></div>
                            <div class="product-selling-price">
                                <asp:Panel ID="idHotGiaCu" CssClass="old-price price" runat="server">
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
        </div>

        <div class="new-product">
            <div class="product-selling-title">
                <h1 class="title-hr">
                    <hr />
                    SẢN PHẨM GIẢM GIÁ<hr />
                </h1>
                <hr>
            </div>
            <div class="all-product">
                <asp:ListView ID="lvSaleProduct" runat="server" OnItemCommand="lvSaleProduct_ItemCommand" OnItemDataBound="lvSaleProduct_ItemDataBound">
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
        </div>
        <div class="policy">
            <div class="row wide">
                <div class="col">
                    <div class="policy-icon"><i class="fas fa-truck"></i></div>
                    <div class="policy-title"><span>Giao Hàng Toàn Quốc</span></div>
                    <div class="policy-content"><span>Ship COD toàn quốc. Nhận hàng trong vòng 2-3 ngày</span></div>
                </div>
                <div class="col  undo-icon">
                    <div class="policy-icon"><i class="fas fa-undo"></i></div>
                    <div class="policy-title"><span>Hoàn Trả Miễn Phí</span></div>
                    <div class="policy-content"><span>Xem hàng trước khi nhận. Hoàn trả miễn phí nếu không hài lòng</span></div>
                </div>
                <div class="col">
                    <div class="policy-icon"><i class="fas fa-home"></i></div>
                    <div class="policy-title"><span>Bảo hành 1 năm</span></div>
                    <div class="policy-content"><span>Bảo hành 1 năm. Lỗi 1 đổi 1 tất cả các sản phẩm của Apple</span></div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
