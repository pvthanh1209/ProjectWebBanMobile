<%@ Page Title="" Language="C#" MasterPageFile="~/coreAdmin.Master" AutoEventWireup="true" CodeBehind="Quanlysanpham.aspx.cs" Inherits="BTL_Web.Quanlysanpham" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style1 {
            height: 33px;
        }

        .content table {
            display: flex;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <center><h1>QUẢN LÝ SẢN PHẨM</h1></center>
    <div class="content">
        <table>
        </table>

        <table>
            <tr style="padding: 10px 0px;">
                <td>
                    <h2 style="text-align: center;">Thêm mới sản phẩm</h2>
                </td>
                <td></td>
                <td>
                    <h2>Nhập só lượng sản phẩm</h2>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lblLoaiHang" runat="server" Text="Chọn loại hàng:"></asp:Label>
                </td>
                <td>
                    <asp:DropDownList ID="drMaLoai" runat="server" AutoPostBack="true" OnSelectedIndexChanged="drMaLoai_SelectedIndexChanged">
                        <asp:ListItem Selected="True" Value="LH01">Điện thoại</asp:ListItem>
                        <asp:ListItem Value="LH02">Máy tính bảng</asp:ListItem>
                        <asp:ListItem Value="LH03">Phụ kiện</asp:ListItem>
                    </asp:DropDownList>

                </td>

                <td>

                    <asp:Label ID="lblTenSP" runat="server" Text="Tên sản phẩm "></asp:Label>
                </td>
                <td runat="server" id="tbTenSP">
                    <asp:DropDownList ID="ddlTenSP" runat="server"></asp:DropDownList>
                    <%--<asp:TextBox ID="txtTenSP1" runat="server"></asp:TextBox>--%>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Mã sản phẩm"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMaSP" runat="server"></asp:TextBox>
                </td>

                <td>
                    <asp:Label ID="Label7" runat="server" Text="Số lượng nhập"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSlgN" runat="server"></asp:TextBox>
                    <%--<input id="slgN" runat="server" />--%>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Tên sản phẩm"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtTenSP" runat="server"></asp:TextBox>
                </td>
                <td>
                    <asp:Button ID="btnAdd" runat="server" Text="Cập nhật" OnClick="btnAdd_Click" />
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Giá bán"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtGiaban" runat="server"></asp:TextBox>
                </td>

            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label4" runat="server" Text="Số lượng"></asp:Label>
                </td>

                <td>
                    <asp:TextBox ID="txtSoluong" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label5" runat="server" Text="Hình ảnh"></asp:Label>
                </td>

                <td>
                    <asp:FileUpload ID="fHinhanh" runat="server" />
                    <asp:Image ID="Image1" runat="server" Width="100px" />
                </td>
            </tr>
            <!--Mô tả-->
            <tr>
                <td>
                    <asp:Label ID="Label6" runat="server" Text="Mô tả 1"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMota1" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label10" runat="server" Text="Mô tả 2"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMota2" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label11" runat="server" Text="Mô tả 3"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtMota3" runat="server" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <!--/Mô tả-->
            <tr>
                <td>
                    <asp:Label ID="Label8" runat="server" Text="Nhà sản xuất"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtNSX" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td>
                    <asp:Label ID="Label9" runat="server" Text="Sale"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="txtSale" runat="server"></asp:TextBox>
                </td>
            </tr>

            <tr>
                <td class="auto-style1"></td>
                <td class="auto-style1">
                    <asp:Button ID="btnThemMoi" runat="server" Text="Thêm mới" OnClick="btnThemMoi_Click" />
                </td>
            </tr>

            <tr>
                <td></td>
                <td>
                    <asp:Label ID="lblThongBao" runat="server" ForeColor="Red"></asp:Label>
                </td>
            </tr>

        </table>


    </div>
    <br />
    <br />
    <div style="overflow-x: auto; width: 1024px">
        <table>
            <tr>
                <td>
                    <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" AllowSorting="True" GridLines="None" PageSize="10" AllowPaging="True" AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" ViewStateMode="Enabled" OnRowCancelingEdit="GridView1_RowCancelingEdit" OnRowUpdating="GridView1_RowUpdating" OnRowDeleting="GridView1_RowDeleting" OnPageIndexChanging="GridView1_PageIndexChanging">
                        <AlternatingRowStyle BackColor="White" />
                        <Columns>
                            <asp:BoundField DataField="sID_SanPham" HeaderText="Mã sản phẩm" ReadOnly="True">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sTenSanPham" HeaderText="Tên sản phẩm">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fDongia" HeaderText="Giá bán">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="iSoluong_Kho" HeaderText="Số lượng">
                                <ItemStyle HorizontalAlign="Center" Width="20px" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="Hình ảnh">
                                <EditItemTemplate>
                                    <asp:FileUpload ID="FileUpload1" runat="server" />
                                </EditItemTemplate>
                                <ItemTemplate>

                                    <asp:Image ID="Image2" runat="server" ImageUrl='<%# Bind("sImg") %>' Width="50px" Height="50px" />
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:TemplateField>

                            <asp:BoundField DataField="sMota_1" HeaderText="Mô tả 1">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sMota_2" HeaderText="Mô tả 2">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="sMota_3" HeaderText="Mô tả 3">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>

                            <asp:TemplateField HeaderText="Mã loại">
                                <EditItemTemplate>

                                    <asp:DropDownList ID="DropDownList1" runat="server" DataSource='<%#DanhMucLoaiHang()%>' DataValueField="sID_LoaiHang"
                                        DataTextField="sTenLoaiHang" SelectedValue='<%# Bind("sID_LoaiHang") %>'>
                                    </asp:DropDownList>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("sID_LoaiHang") %>'></asp:Label>
                                </ItemTemplate>
                                <ItemStyle HorizontalAlign="Center" Width="100px" />
                            </asp:TemplateField>
                            <asp:BoundField DataField="sNhaSanXuat" HeaderText="Nhà sản xuất">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField DataField="fSale" HeaderText="Sale">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:CommandField CancelText="Bỏ qua" EditText="Sửa" ShowEditButton="True" UpdateText="Cập nhật">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:CommandField>
                            <asp:TemplateField ShowHeader="False">
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Delete"
                                        Text="Xóa" OnClientClick="return confirm('Bạn có chắc muốn xóa không!');">

                                    </asp:LinkButton>
                                </ItemTemplate>
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
        </table>
    </div>
</asp:Content>
