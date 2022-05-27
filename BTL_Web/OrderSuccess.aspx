<%@ Page Title="" Language="C#" MasterPageFile="~/core.Master" AutoEventWireup="true" CodeBehind="OrderSuccess.aspx.cs" Inherits="BTL_Web.OrderSuccess" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .wrap-success {
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 25px;
        }

            .wrap-success img {
                width: 4%;
            }

        .detail-success {
            margin-top: 10px;
            display: flex;
            align-items: center;
            flex-direction: column;
        }

        .btn-success {
            margin-top: 10px;
            display: flex;
            justify-content: center;
        }

        .btnSuccess {
            margin-top: 20px;
            margin-right: 25px;
            padding: 10px 14px;
            background-color: black;
            color: white;
            cursor:pointer;
        }
    </style>
    <div style="margin-top: 50px;">
        <div class="wrap-success">
            <img alt="" src="images/success.jpg" />
            <p>Đặt hàng thành công</p>

        </div>
        <div class="detail-success">
            <p>Cảm ơn bạn đã tin dùng sản phẩm của Shop. Đơn hàng của bạn sẽ sớm được nhân viên xác nhận</p>
            <p>Bạn có thể theo dõi đơn hàng bằng cách nhấn nút xem chi tiết đơn hàng</p>
        </div>
        <div class="btn-success">
            <asp:Button ID="btnOrder" CssClass="btnSuccess" runat="server" Text="Xem chi tiết đơn hàng" OnClick="btnOrder_Click" />
            <asp:Button ID="btnShop" CssClass="btnSuccess" runat="server" PostBackUrl="~/Trangchu.aspx" Text="Tiếp tục mua sắm" />
        </div>

    </div>
</asp:Content>
