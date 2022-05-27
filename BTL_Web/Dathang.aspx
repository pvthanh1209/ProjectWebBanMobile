<%@ Page Title="" Language="C#" MasterPageFile="~/core.Master" AutoEventWireup="true" CodeBehind="Dathang.aspx.cs" Inherits="BTL_Web.Dathang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="main-pay">
        <div class="row-pay">
            <form>
                <div class="form-pay">
                    <div class="left-pay">
                        <div class="pay-title">
                            <span>THÔNG TIN THANH TOÁN</span>
                        </div>
                        <div class="pay-name ">
                            <label><b>Tên người nhận:</b></label>
                            <span>Cao Xuân Cường</span>
                        </div>
                        <div class="pay-phone ">
                            <label><b>Số điện thoại:</b></label>
                            <input type="text" name="" class="">
                        </div>
                        <div class="pay-diachi">
                            <label>Địa chỉ nhận hàng:</label>
                            <div class="option-diachi">
                                <div class="tinh-tp flex">
                                    <label>Tỉnh/Thành phố:</label>
                                    <select class="ma-tp">
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                    </select>
                                </div>
                                <div class="quan-huyen flex">
                                    <label>Quận/Huyện:</label>
                                    <select class="ma-qh">
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                    </select>
                                </div>
                                <div class="xa-phuong flex">
                                    <label>Thị trấn/Xã/Phường:</label>
                                    <select class="ma-xaphuong">
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                        <option>Hà Nội</option>
                                    </select>
                                </div>
                            </div>
                        </div>
                        <div class="noti-pay">
                            <label>Ghi chú</label>
                            <br>
                            <input type="text" class="txtNoti" name="">
                        </div>
                    </div>
                    <div class="right-pay">
                        <div class="your-order">
                            <div class="pay-title">
                                <span>ĐƠN HÀNG CỦA BẠN</span>
                            </div>
                            <div class="pay-san-pham flex-order">
                                <span>Sản phẩm</span>
                                <span>Tạm tính</span>
                            </div>
                            <div class="pay-sp-main flex-order">
                                <div class="soluong-sp">
                                    <span>Điện thoại Samsung Galaxy Z Fold3 5G 512GB</span>
                                    <p>x</p>
                                    <p>2</p>
                                </div>
                                <div class="pay-item">
                                    <span>20.000.000<sup>đ</sup></span>
                                </div>
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
                                <span>40.000.000<sup>đ</sup></span>
                            </div>
                            <div class="phuong-thuc-pay">
                                <div class="phuong-thuc-pay-item">
                                    <input type="radio" name="radio">
                                    <span>Thanh toán khi nhận hàng</span>
                                </div>
                                <div class="phuong-thuc-pay-item">
                                    <input type="radio" name="radio">
                                    <span>Chuyển khoản ngân hàng</span>
                                </div>
                                <div class="phuong-thuc-pay-item">
                                    <input type="radio" name="radio">
                                    <span>Thanh toán với PayPal</span>
                                </div>
                                <div class="phuong-thuc-pay-item">
                                    <input type="radio" name="radio">
                                    <span>Quét mã MoMo</span>
                                </div>
                                <div class="phuong-thuc-pay-item">
                                    <input type="radio" name="radio">
                                    <span>Cổng thanh toán nội địa OnePay</span>
                                </div>
                                <div class="phuong-thuc-pay-item">
                                    <input type="radio" name="radio">
                                    <span>Cổng thanh toán Quốc tế OnePay</span>
                                </div>
                            </div>
                        </div>
                        <button type="submit" class="btnPay">ĐẶT HÀNG</button>
                    </div>
                </div>
            </form>
        </div>
    </div>
</asp:Content>
