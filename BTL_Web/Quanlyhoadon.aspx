<%@ Page Title="" Language="C#" MasterPageFile="~/coreAdmin.Master" AutoEventWireup="true" CodeBehind="Quanlyhoadon.aspx.cs" Inherits="BTL_Web.Quanlyhoadon" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <center><h1>QUẢN LÝ HÓA ĐƠN</h1></center>
    <table style="padding-top: 20px;">
        <tr>
            <td>Trạng thái</td>
            <td>
                <asp:DropDownList ID="ddlHoaDon" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlHoaDon_SelectedIndexChanged">
                    <asp:ListItem Value="HỦY" Selected="True">HỦY</asp:ListItem>
                    <asp:ListItem Value="CHỜ XÁC NHẬN">CHỜ XÁC NHẬN</asp:ListItem>
                    <asp:ListItem Value="ĐÃ XÁC NHẬN">ĐÃ XÁC NHẬN</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td></td>
        </tr>
    </table>
    <div style="overflow-x: auto; width: 1024px">
        <table>
            <tr>
                <td>
                    <asp:GridView ID="grvHD" runat="server" Width="1019px" ViewStateMode="Enabled" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="grvHD_RowCancelingEdit" OnRowEditing="grvHD_RowEditing" OnRowUpdating="grvHD_RowUpdating" OnPageIndexChanging="grvHD_PageIndexChanging" OnSelectedIndexChanging="grvHD_SelectedIndexChanging">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="sID_HoaDon" HeaderText="Mã hóa đơn" ReadOnly="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sHoTen" HeaderText="Tên khách hàng" ReadOnly="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sDiachi" HeaderText="Địa chỉ GH">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Trạng thái">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem Value="HỦY" Selected="True">HỦY</asp:ListItem>
                                        <asp:ListItem Value="CHỜ XÁC NHẬN">CHỜ XÁC NHẬN</asp:ListItem>
                                        <asp:ListItem Value="ĐÃ XÁC NHẬN">ĐÃ XÁC NHẬN</asp:ListItem>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("sTrangthai") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="sSdt" HeaderText="Số điện thoại">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sGhichu" HeaderText="Ghi chú">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sTongtien" HeaderText="Tổng tiền">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Phương thức TT">
                                <EditItemTemplate>
                                    <asp:DropDownList ID="DropDownList2" runat="server">
                                        <asp:ListItem Value="Thanh toán Paypal" Selected="True">Thanh toán Paypal</asp:ListItem>
                                        <asp:ListItem Value="Thanh toán MoMo">Thanh toán MoMo</asp:ListItem>
                                        <asp:ListItem Value="Thanh toán Banking">Thanh toán Banking</asp:ListItem>
                                        <asp:ListItem Value="Thanh toán khi nhận hàng">Thanh toán khi nhận hàng</asp:ListItem>

                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("sPhuongthuc") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="dNgaylap" HeaderText="Ngày lập HĐ">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:CommandField CancelText="Bỏ qua" EditText="Sửa" ShowEditButton="True" UpdateText="Cập nhật">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>

                            <asp:CommandField SelectText="Chi tiết" ShowSelectButton="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblThongBao" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
    <div style="padding-top: 20px; overflow-x: auto; width: 1024px">
        <table>
            <tr>
                <td colspan="4">
                    <h2>Chi tiết hóa đơn</h2>
                </td>
            </tr>
            <tr>
                <td colspan="4">
                    <asp:GridView Width="1019px" ID="grvCTHD" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowCancelingEdit="grvCTHD_RowCancelingEdit" OnRowEditing="grvCTHD_RowEditing" OnRowUpdating="grvCTHD_RowUpdating" OnRowDeleting="grvCTHD_RowDeleting"   >
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="sID_CTHoaDon" HeaderText="Mã CTHĐ">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sID_HoaDon" HeaderText="Mã HĐ" ReadOnly="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sID_SanPham" HeaderText="Mã SP" ReadOnly="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="iSoluongmua" HeaderText="Số lượng">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fDongia" HeaderText="Đơn giá">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CommandField CancelText="Hủy" EditText="Sửa" ShowEditButton="True"
                                UpdateText="Xác nhận" HeaderText="Cập nhật">
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:CommandField>
                            <asp:TemplateField HeaderText="Xóa ?" ItemStyle-HorizontalAlign="Center">
                                <ItemTemplate>
                                    <span onclick="return confirm('Bạn có chắc chắn muốn xóa không ?')">
                                        <asp:LinkButton ID="lbtnXoa" runat="server" CommandName="Delete">Xóa</asp:LinkButton>
                                    </span>
                                </ItemTemplate>

                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        </Columns>
                        <EditRowStyle BackColor="#2461BF" />
                        <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <RowStyle BackColor="#EFF3FB" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <SortedAscendingCellStyle BackColor="#F5F7FB" />
                        <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                        <SortedDescendingCellStyle BackColor="#E9EBEF" />
                        <SortedDescendingHeaderStyle BackColor="#4870BE" />
                    </asp:GridView>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label runat="server" ID="lblThongBao1" ForeColor="Red"></asp:Label>
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
