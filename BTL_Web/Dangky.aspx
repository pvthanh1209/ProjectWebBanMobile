<%@ Page Title="" Language="C#" MasterPageFile="~/core.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="Dangky.aspx.cs" Inherits="BTL_Web.Dangky" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="main-regis">
                <div style="height: 91%" class="noi-dung">
                    <div class="form">
                        <h2>Đăng Ký</h2>
                        <form id="form1">
                            <asp:Panel ID="Panel1" runat="server" DefaultButton="btnDangKy">
                                <div class="input-form txtRegis" style="text-align: center">
                                    <asp:Label ID="lblThongBao" runat="server" ForeColor="Red"></asp:Label>
                                </div>
                                <div class="input-form txtRegis">
                                    <span>Họ và tên:</span>
                                    <asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHoTen"
                                        ErrorMessage="Không được để trống" ForeColor="Red"></asp:RequiredFieldValidator>
                                </div>
                                <div class="input-form txtRegis">
                                    <asp:Label ID="lblTenTaiKhoan" runat="server" Text="Tên tài khoản"></asp:Label>
                                    <asp:TextBox ID="txtTenTaiKhoan" runat="server"></asp:TextBox>

                                    <br />
                                    <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtTenTaiKhoan" ErrorMessage="Vui lòng nhập đúng định dạng địa chỉ email" ForeColor="#FF3300" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                                </div>
                                <div class="input-form txtRegis">
                                    <span>Mật khẩu:</span>
                                    <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password"></asp:TextBox>
                                    <br />
                                    <asp:CustomValidator ID="CustomValidator2" ControlToValidate="txtMatKhau" ForeColor="red" runat="server" ErrorMessage="Mật khẩu cần dài hơn 6 ký tự" OnServerValidate="CustomValidator2_ServerValidate"></asp:CustomValidator>


                                </div>
                                <div class="input-form txtRegis">
                                    <span>Nhập lại mật khẩu:</span>
                                    <asp:TextBox ID="txtMatKhau1" runat="server" TextMode="Password"></asp:TextBox><br />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic" ControlToValidate="txtMatKhau1" ForeColor="red" runat="server" ErrorMessage="Không được để trống"></asp:RequiredFieldValidator>
                                    <asp:CompareValidator
                                        ID="CompareValidator1" runat="server" Display="Dynamic" ErrorMessage="Mật khẩu không giống nhau" ForeColor="Red" ControlToValidate="txtMatKhau1"
                                        ControlToCompare="txtMatKhau"></asp:CompareValidator>
                                </div>
                                <br>
                                <div class="input-form txtRegis">
                                    <asp:Button ID="btnDangKy" runat="server" OnClick="btnDangKy_Click" Text="ĐĂNG KÝ" />
                                </div>
                            </asp:Panel>
                            <div class="input-form is-user">
                                <p>Bạn Đã Có Tài Khoản? <a href="Dangnhap.aspx">Đăng Nhập</a></p>
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
