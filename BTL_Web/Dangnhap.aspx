<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/core.Master" AutoEventWireup="true" CodeBehind="Dangnhap.aspx.cs" Inherits="BTL_Web.Dangnhap" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-login">
        <div class="noi-dung">
            <div class="form">
                <h2>Đăng NhẬp</h2>
                <asp:Panel ID="loginPanel" runat="server" DefaultButton="btndangnhap">
                    <div class="input-form txtlogin">
                        <asp:Label ID="Label1" Visible="false" runat="server" Text='<%# Eval("sHoTen") %>'></asp:Label>
                        <span>Tên tài khoản:</span>
                        <asp:TextBox ID="txtTaikhoan" runat="server"></asp:TextBox>
                    </div>
                    <div class="input-form txtlogin">
                        <span>Mật khẩu:</span>
                        <asp:TextBox ID="txtMatkhau" TextMode="Password" runat="server"></asp:TextBox>
                    </div>
                    <br>
                    <div class="input-form txtlogin">
                        <asp:Button ID="btndangnhap" runat="server" OnClick="btndangnhap_Click" Text="ĐĂNG NHẬP" />
                    </div>
                </asp:Panel>
                <div class="input-form txtlogin">
                    <p>Bạn Chưa Có Tài Khoản? <a href="Dangky.aspx">Đăng Ký</a></p>
                </div>

                <div class="login_message" style="text-align: center; color: red;">
                    <asp:Label ID="lblThongbao" runat="server"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
