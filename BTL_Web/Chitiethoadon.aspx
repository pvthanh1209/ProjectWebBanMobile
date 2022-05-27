<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/core.Master" AutoEventWireup="true" CodeBehind="Chitiethoadon.aspx.cs" Inherits="BTL_Web.Chitiethoadon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .total-order-detail {
            margin-top: 40px;
            display: flex;
            justify-content: flex-end;
        }

        .right-order table {
            width: 427px;
        }
    </style>
    <div class="main-order">
			<div><h1 class="title-hr"><hr/>CHI TIẾT ĐƠN HÀNG<hr/ style="width: 380px;"></h1></div>
			<div class="body-order">
				<div class="left-cart">
					<form>
						<table class="table-order">
							<tr >
								<th class="cart-product">SẢN PHẨM</th>
								<th class="cart-price">SỐ LƯỢNG</th>
								<th>TẠM TÍNH</th>
							</tr>
                            <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound">
                                <ItemTemplate>
                                    <tr class="cart-list">
								        <td class="order-product space-cart">
                                                <asp:Label ID="lblTenSP" runat="server" Text='<%# Eval("sTenSanPham") %>'></asp:Label>
								        </td>
								        <td class="space-cart" style="font-weight: 600; text-align: center; ">
									        <span>
                                                <asp:Label ID="lblSoLuong" runat="server" Text='<%# Eval("iSoluongmua") %>'></asp:Label>
									        </span>
								        </td>
								        <td class="quantity-product space-cart">
                                            <asp:Label  ID="lblTamTinh" runat="server" Text='<%# Eval("fDongia") %>'></asp:Label>
								        </td>
							        </tr>
                                </ItemTemplate>
                            </asp:ListView>
						</table>
						<div class="order-footer">
                            <div class="total-order-detail">
                                 <b><asp:Label ID="lblTongTien" runat="server" Text="Label"></asp:Label></b>
                            </div>		  	
						</div>
					</form>
				</div>
				<div class="right-order">
					<div class="header-right-order">
						<span><b>THÔNG TIN ĐƠN HÀNG</b></span>
					</div>
                    <asp:FormView ID="FormView1" runat="server" OnItemCommand="FormView1_ItemCommand">
                        <ItemTemplate>
                            <div class="order-id cart-row space-right-order">
						        <span>MÃ ĐƠN HÀNG: </span>
                                <b><asp:Label ID="lblID" runat="server" Text='<%# Eval("sID_HoaDon") %>'></asp:Label></b>
					        </div>
					        <div class="order-phone cart-row space-right-order">
						        <span>SỐ ĐIỆN THOẠI: </span>
                                <b><asp:Label ID="lblSDT" runat="server" Text='<%# Eval("sSDT") %>'></asp:Label></b>
					        </div>
					        <div class="total-money cart-row space-right-order">
						        <span>ĐỊA CHỈ GIAO HÀNG: </span>
                                <div style="width:161px; overflow-wrap: anywhere; display:flex; justify-content:flex-end;">
                                    <b><asp:Label ID="lblDiachi" runat="server" Text='<%# Eval("sDiachi") %>'></asp:Label></b>
                                </div>
                                
					        </div>
                            <div style="margin-top:10px;">
                                <b>Trạng thái:</b> <asp:Label ID="lblTrangThai" runat="server" Text='<%# Eval("sTrangthai") %>'></asp:Label>
                            </div>
					        <div class="submit-order space-right-order">
                                <asp:Button ID="Button1" CssClass="btnOrder" CommandName="Delete" runat="server" Text="HỦY ĐƠN HÀNG" />
                                <asp:Button ID="Button2" CssClass="btnOrder" PostBackUrl="~/Trangchu.aspx" runat="server" Text="TIẾP TỤC MUA SẮM" />
					        </div>
                        </ItemTemplate>
                    </asp:FormView>			
				</div>
			</div>
		</div>
</asp:Content>
