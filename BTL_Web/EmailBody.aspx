<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmailBody.aspx.cs" Inherits="BTL_Web.EmailBody" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
    <style>
        .pay-title span{
	font-weight: bold;
	font-size: 20px;
}
.flex-order{
	display: flex;
	justify-content: space-between;
}
.pay-san-pham{
	margin-top: 15px;
	border-bottom: 4px solid #EAEAEE;
	padding-bottom: 10px;
}
.pay-sp-main{
	border-bottom: 1px solid #eaeaee;
	margin-top: 15px;
	padding-bottom: 15px;
}
.soluong-sp{
	display: flex;
}
.soluong-sp p{
	margin-left: 10px;
	font-weight: bold;
}
.pay-item{
	font-weight: bold;
}
    </style>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>CTC MOBILE</h1>
            <span>Đơn hàng {idDonHang}</span>
        </div>
        <div>
            <span>Cảm ơn bạn đã mua hàng!
            </span>
            <span>Xin chào {Username}, Chúng tôi đã nhận được đơn đặt hàng của bạn. Chúng tôi sẽ thông báo sau khi nhân viên xác nhận đơn hàng của bạn.</span>
        </div>
        <hr />
        <div>
            <span>Thông tin đơn hàng</span>
            <div id="yourOrder" runat="server" class="your-order">
                <div class="pay-title">
                    <span>ĐƠN HÀNG CỦA BẠN</span>
                </div>
                <div class="pay-san-pham flex-order">
                    <span>Sản phẩm</span>
                    <span>Tạm tính</span>

                </div>
                <asp:ListView ID="ListView1" runat="server" >
                    <ItemTemplate>
                        <div class="pay-sp-main flex-order">
                            <div class="soluong-sp">
                                <asp:Label ID="lblTenSP" runat="server" Text='<%# Eval("sTenSanPham") %>'></asp:Label>
                                <p>x</p>
                                <asp:Label ID="lblSoluong" runat="server" Text='<%# Eval("iSoluongmua") %>'></asp:Label>
                            </div>
                            <div class="pay-item">
                                <asp:Label ID="lblTamtinh" runat="server" Text=""></asp:Label>
                            </div>
                        </div>
                    </ItemTemplate>
                </asp:ListView>
            </div>
        </div>
    </form>
</body>
</html>
