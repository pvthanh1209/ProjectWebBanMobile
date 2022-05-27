<%@ Page Title="" Language="C#" MasterPageFile="~/core.Master" AutoEventWireup="true" CodeBehind="Thanhtoan.aspx.cs" Inherits="BTL_Web.Thanhtoan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .phuong-thuc-pay tr {
            margin-bottom: 14px;
            display: block;
            border-bottom: 1px solid #f1f1f1;
            padding-bottom: 10px;
            width: 540px;
        }
    
    </style>
    <div class="main-pay">
        <div class="row-pay">
            <div class="form-pay">
                <div class="left-pay">
                    <div class="pay-title">
                        <span>THÔNG TIN THANH TOÁN</span>
                    </div>
                    <div class="pay-name ">
                        <label><b>Tên người nhận:</b></label>
                        <asp:Label ID="lblUser" runat="server" Text="Label"></asp:Label>
                    </div>
                    <div class="pay-phone ">
                        <label><b>Số điện thoại:</b></label>
                        <asp:TextBox ID="lblPhone" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
                    </div>
                    <div class="pay-diachi">
                        <label>Địa chỉ nhận hàng:</label>
                        <div class="option-diachi">
                            <asp:TextBox Style="border: 1px solid #ccc; height: 35px; padding-left: 20px; width: 425px;" ID="txtDiaChi" runat="server"></asp:TextBox>
                        </div>
                    </div>
                    <div class="noti-pay">
                        <label>Ghi chú</label>
                        <br>
                        <asp:TextBox ID="txtGhichu" CssClass="txtNoti" style="overflow:hidden; font-size:16px;" cols="40" rows="5" TextMode="MultiLine" AutoCompleteType="Disabled" runat="server"></asp:TextBox>
                    </div>
                </div>
                <div class="right-pay">
                    <div id="yourOrder" runat="server" class="your-order">
                        <div class="pay-title">
                            <span>ĐƠN HÀNG CỦA BẠN</span>
                        </div>
                        <div class="pay-san-pham flex-order">
                            <span>Sản phẩm</span>
                            <span>Tạm tính</span>

                        </div>
                        <asp:ListView ID="ListView1" runat="server">
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
                    <div class="pay-giao-hang flex-order">
                        <span>Giao hàng</span>
                        <div class="phi-giao-hang">
                            <span>Đồng giá:</span>
                            <span><b>20.000<sup>đ</sup></b></span>
                        </div>
                    </div>
                    <div class="total-pay flex-order">
                        <span>Tổng tiền:</span>
                        <asp:Label ID="lblTongTien" runat="server" Text=""></asp:Label>
                    </div>
                    <asp:RadioButtonList CssClass="phuong-thuc-pay" ID="RadioButtonList1" runat="server">
                        <asp:ListItem Value="Thanh toán COD">Thanh toán khi nhận hàng</asp:ListItem>
                        <asp:ListItem Value="Thanh toán Banking">Chuyển khoản ngân hàng</asp:ListItem>
                        <asp:ListItem Value="Thanh toán Paypal">Thanh toán với PayPal</asp:ListItem>
                        <asp:ListItem Value="Thanh toán MoMo">Quét mã MoMo</asp:ListItem>
                    </asp:RadioButtonList>

                    <asp:Button runat="server" ID="Pay" CssClass="btnPay" Text="Xác nhận thanh toán" OnClick="Pay_Click1" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
