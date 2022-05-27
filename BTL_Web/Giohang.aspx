<%@ Page Title="" Language="C#" MasterPageFile="~/core.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Giohang.aspx.cs" Inherits="BTL_Web.Giohang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<style>
    .cart-show {
        margin-top: 60px;
        text-align: center;
    }

        .cart-show img {
            width: 30%;
        }

        .cart-show .empty-detail {
            margin-top: 20px;
            margin-right: 75px;
        }

    .empty-detail p {
        font-size: 30px;
        font-weight: bold;
    }

    .empty-detail .btnEmpty {
        margin-top: 20px;
        background-color: black;
        color: white;
        padding: 10px 20px;
        font-weight: bold;
        font-size: 18px;
    }

    .format-money {
        display: flex;
    }

    .cart {
        pointer-events: none;
    }
</style>
    <div style="display:none;" class="cart-show" id="emptyCart" runat="server">
        <img  src="images/cart-empty.png" />
        <div class="empty-detail">
            <p>Giỏ hàng trống</p>
            <asp:Button ID="Button1" CssClass="btnEmpty" PostBackUrl="~/Trangchu.aspx" runat="server" Text="Quay lại cửa hàng" />
        </div>
    </div>
    <div class="main-cart" id="idCart" runat="server" >
	    <div><h1 class="title-hr"><hr/>GIỎ HÀNG CỦA BẠN<hr/ style="width: 385px;"></h1></div>
	    <div  class="body-cart" >
		    <div class="left-cart">
		    <div id="myLv" runat="server">
		        <table class="table-cart">
		            <tr >
					    <th class="cart-product">SẢN PHẨM</th>
					    <th class="cart-price">GIÁ</th>
					    <th>SỐ LƯỢNG</th>
					    <th>TẠM TÍNH</th>
				    </tr>

                    <asp:ListView ID="lvCart" runat="server" OnItemDataBound="lvCart_ItemDataBound" OnItemCommand="lvCart_ItemCommand" OnItemDeleting="lvCart_ItemDeleting">
                        <ItemTemplate>
                            <tr class="cart-list">
							    <td class="cart-product space-cart">
								    <div class="cart-cancel">
                                        <asp:ImageButton ID="ImageButton1" ImageUrl="images/cancel.png" CommandArgument='<%# Eval("sID_CTGioHang") %>' CommandName="Delete" runat="server" />
								    </div>
								    <div class="cart-image">
									    <img src="<%# Eval("sImg") %>">
								    </div>
                                    <asp:Label Visible="false" ID="lblIDSP" runat="server" Text='<%# Eval("sID_SanPham") %>'></asp:Label>
								    <div class="cart-name"><span><%# Eval("sTenSanPham") %></span></div>
						        </td>
							    <td class="space-cart" style="font-weight: 600; text-align: center; ">
                                        <asp:Label style="padding-top:21px;" CssClass="item-cart" ID="txtGia" runat="server" Text='<%# Eval("fGiamgia","{0:0,0}") %>'></asp:Label>
         
                                    
							    </td>
							    <td class="num" style="font-weight: 600; text-align: center;">
							        <div class="mount-product">
								       <input type="button" class="btnDec" value="-" onclick="giam(this)"/><asp:TextBox CssClass="txtNum" ID="txtSL" Text='<%# Eval("iSoluongmua") %>' runat="server"></asp:TextBox><input type="button" class="btnIcr" value="+" onclick="    tang(this)" />
								    </div>
							    </td>
							    <td class="quantity-product space-cart">
                                    <asp:Label style="padding-top:21px;" ID="txtMoneyItem" runat="server" Text="Label"><sup>đ</sup></asp:Label>
							    </td>
						    </tr>
                        </ItemTemplate>
                    </asp:ListView>		    						    
		        </table>
			    <div class="cart-footer">
				    <a href="Trangchu.aspx">
					    <div class="continue-view"><i class="fas fa-arrow-left"></i>
						    <span>Tiếp tục xem sản phẩm</span>
					    </div>
				    </a>
                    <asp:Button ID="btnUpdateCart" CssClass="update-cart" runat="server" CommandArgument='<%# Eval("sID_CTGioHang") %>' Text="Cập nhật giỏ hàng" OnClick="btnUpdateCart_Click" />
			    </div>
		    </div>
	    </div>
	        <div class="right-cart">
		            <div class="header-right-cart">
			            <span><b>CỘNG GIỎ HÀNG</b></span>
		            </div>
		            <div class="cart-money cart-row space-right-cart">
		                <span>Tạm tính</span>
                        <b><asp:Label style="padding-bottom:5px;" ID="txtCart" runat="server" Text=""></asp:Label></b>
		            </div>
	            <div class="ship-money cart-row space-right-cart">
		            <span>Phí giao hàng</span>
		            <span>Đồng giá: <b>20.000<sup>đ</sup></b></span>
	            </div>
		        <div class="ticket space-right-cart">
		            <i class="fas fa-ticket"></i>
			        <span><b>Phiếu ưu đãi</b></span>
		        </div>
                 <div class="ticket-text space-right-cart">
			        <form>
				        <input type="text" class="txtTicket" placeholder="Mã ưu đãi..." name="">
				        <br>
				        <button type="submit" class="btnTicket">Áp dụng</button>	
			        </form>						
		        </div>
		        <div class="total-money cart-row space-right-cart">
			        <span><b>Tổng tiền:</b></span>
                    <b><asp:Label ID="txtTotalCart" runat="server" Text=""></asp:Label></b>
		        </div>
		        <div class="submit-cart space-right-cart">
                    <asp:Button ID="btnSubmit" CssClass="btnCart" runat="server" Text="TIẾN HÀNH THANH TOÁN" OnClick="btnSubmit_Click" />
		        </div>
	        </div>
        </div>
    </div>
</asp:Content>
