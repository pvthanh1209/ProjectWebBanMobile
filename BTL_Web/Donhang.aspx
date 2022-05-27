<%@ Page Title="" Language="C#" MasterPageFile="~/core.Master" AutoEventWireup="true" EnableEventValidation="false" CodeBehind="Donhang.aspx.cs" Inherits="BTL_Web.Donhang" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .main-order {
            padding-top: 30px;
            width: 1080px;
            margin: 0 auto;
            flex-wrap: wrap;
        }

        .body-order {
            margin-top: 50px;
        }

        .table-list-order th, .table-list-order tr, .table-list-order td {
            font-size: 17px;
            text-align: center;
        }

        h1.title-hr-order hr {
            display: inline-block;
            width: 339px;
            margin: 5px 10px;
            border-top: 2px solid #e5e5e5;
        }

        .border-order {
            border-bottom: 2px solid #e5e5e5;
        }

        .btnOrderDetail {
            padding: 10px 20px;
            background: black;
            color: white;
            font-weight: bold;
            cursor: pointer;
        }

        .btnBackShop {
            text-decoration: none;
            color: black;
            font-weight: bold;
            border: 1px solid black;
            padding: 10px 20px;
        }

            .btnBackShop:hover {
                background-color: black;
                color: white;
            }
    </style>
   <div class="main-order">
			<div><h1 id="notiOrder" runat="server" class="title-hr-order"><hr/>ĐƠN HÀNG CỦA BẠN<hr/ style="width: 370px;"></h1></div>
             <a id="backShop" class="btnBackShop" runat="server" style="display:none;" href="Trangchu.aspx">◄ Quay lại cửa hàng</a>
			<div id="wrapOrder" class="body-order" runat="server">
					<form>
						<table width="100%" class="table-list-order">
							<tr >
								<th class="border-order">MÃ ĐƠN HÀNG</th>
								<th class="border-order">TRẠNG THÁI</th>
								<th class="border-order">TỔNG TIỀN</th>
								<th class="border-order">CHỨC NĂNG</th>
							</tr>
                            <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound" OnItemCommand="ListView1_ItemCommand">
                                <ItemTemplate>
                                    <tr height="80px;" class="cart-list" >
								        <td class=" space-cart">
                                            <asp:Label ID="lblID" style="padding-top: 17px;" runat="server" Text='<%# Eval("sID_HoaDon") %>'></asp:Label>
								        </td>
								        <td class="space-cart ">
                                            <b><asp:Label ID="lblStatus" style="padding-top: 17px;" runat="server" Text='<%# Eval("sTrangthai") %>'></asp:Label></b>
								        </td>
								        <td class=" space-cart">
                                            <asp:Label ID="lblTotal" style="padding-top: 17px;" runat="server" Text='<%# Eval("sTongtien") %>'></asp:Label>
								        </td>
								        <td class="space-cart">
                                            <asp:Button ID="btnDetailOrder" CssClass="btnOrderDetail" CommandArgument='<%# Eval("sID_HoaDon") %>' CommandName="Select" runat="server" Text="XEM ĐƠN HÀNG" />
								        </td>
							        </tr>
                                </ItemTemplate>
                            </asp:ListView>	
						</table>
					</form>
			</div>
		</div>
</asp:Content>
