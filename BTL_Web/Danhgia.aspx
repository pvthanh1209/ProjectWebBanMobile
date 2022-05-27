<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/core.Master" AutoEventWireup="true" CodeBehind="Danhgia.aspx.cs" Inherits="BTL_Web.Danhgia" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>
    <style type="text/css">
        .Star {
            background-image: url(images/Star.gif);
            height: 17px;
            width: 17px;
        }

        .WaitingStar {
            background-image: url(images/WaitingStar.gif);
            height: 17px;
            width: 17px;
        }

        .FilledStar {
            background-image: url(images/FilledStar.gif);
            height: 17px;
            width: 17px;
        }

        .ratingStar {
            background-repeat: no-repeat;
            width: 17px;
            height: 17px;
        }

        .wrap-rate {
            z-index: 1;
            width: 100%;
            background-color: #F0F2F5;
        }

        .main-rate {
            padding-bottom: 30px;
            padding-top: 30px;
            width: 1080px;
            margin: 0 auto;
            flex-wrap: wrap;
            display: flex;
            justify-content: space-around;
        }

        .total-rate {
            border-radius: 7px;
            box-shadow: 0px 5px 15px 2px rgba(0,0,0,0.1);
            padding-top: 10px;
            padding-left: 10px;
            width: 300px;
            height: 80px;
            background-color: white;
            display: flex;
            flex-direction: column;
            font-size: 19px;
        }

        .content-rate {
            width: 700px;
            display: flex;
            flex-direction: column;
        }

        .user-rate {
            border-radius: 7px;
            box-shadow: 0px 5px 15px 2px rgba(0,0,0,0.1);
            background-color: white;
            padding: 20px 25px;
        }

        .total-rate > span {
            font-size: 15px;
            color: #65676B;
            margin-left: 20px;
        }

        .txtRate {
            width: 640px;
            padding-bottom: 100px;
            padding-left: 10px;
            padding-top: 10px;
            background-color: #F0F2F5;
            border-color: #F0F2F5;
            border-radius: 5px;
        }

        .btnRate {
            background-color: #dfe1e4;
            font-weight: bold;
            margin-top: 10px;
            padding: 10px 20px;
        }

        .noti-login {
            border: 1px solid #F1F1F1;
            padding: 20px;
        }

        .comment-rate {
            border-radius: 7px;
            box-shadow: 0px 5px 15px 2px rgba(0,0,0,0.1);
            margin-top: 20px;
            padding: 13px 25px;
            display: flex;
            flex-direction: column;
            border: 1px solid #F1F1F1;
            background-color: white;
        }

         .comment-rate span {
                padding-left: 10px;
                margin-bottom: 10px;
                display: block;
        }

        .username-rate {
            font-weight: bold;
            font-size: 18px;
        }

        .time-rate {
            font-size: 13px;
            color: #9D9D9D;
            font-weight: bold;
        }

        .boder-cmt {
            margin-left: 10px;
            width: 97%;
            padding-top: 10px;
            border-top: 1px solid #ccc;
        }

        .txt-rate {
            width: 97%;
        }

        .input-rate {
            display: flex;
            flex-direction: column;
        }

        .avg-rate {
            font-size: 20px;
        }
    </style>
    <div class="wrap-rate">
        <div class="main-rate">
            <div class="total-rate">
                <div class="avg-rate">
                    <span>☆</span>
                    <b>
                        <asp:Label ID="lbresult" runat="server" Text=""></asp:Label></b>
                </div>
                <asp:Label ID="lblTotalRate" runat="server" Text="Dựa trên đánh giá của 12 người<"></asp:Label>
            </div>
            <div class="content-rate">
                <div class="user-rate">
                    <asp:Panel ID="Panel1" runat="server" DefaultButton="Button1">

                        <div class="input-rate">
                            <span style="font-size: 20px; font-weight: bold;">
                                <center>
        				            Hãy để lại phản hồi về chất lượng sản phẩm và dịch vụ của shop
        			            </center>
                            </span>
                            <br />
                            <textarea id="Txt_dg" onkeydown="Trig()" style="font-size:17px; overflow:hidden" runat="server" cols="10" rows="4" class="txtRate" placeholder="Comment..."></textarea>
                            <br />
                            <div class="output-rate">
                                <asp:ToolkitScriptManager ID="ToolkitScriptManager2" runat="server">
                                </asp:ToolkitScriptManager>
                                <asp:Rating ID="Rating1" runat="server" AutoPostBack="true"
                                    StarCssClass="Star" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star"
                                    FilledStarCssClass="FilledStar">
                                </asp:Rating>
                            </div>

                            <asp:Button runat="server" Text="Đăng" CssClass="btnRate" ID="Button1" OnClick="btnsubmit_Click" />
                        </div>
                    </asp:Panel>

                </div>
                <div class="tab">
                    <asp:ListView ID="ListView1" runat="server" OnItemDataBound="ListView1_ItemDataBound">
                        <ItemTemplate>
                            <div class="comment-rate">
                                <span class="username-rate" runat="server"><%# Eval("sUserName") %></span>
                                <span>
                                    <asp:Rating ID="Rating2" CssClass="rating" runat="server"
                                        StarCssClass="ratingStar" WaitingStarCssClass="WaitingStar" EmptyStarCssClass="Star" ClientIDMode="Static"
                                        FilledStarCssClass="FilledStar" CurrentRating='<%# Eval("iStar") %>'>
                                    </asp:Rating>
                                </span>
                                <div class="boder-cmt"></div>
                                <span class="txt-rate"><%# Eval("sBinhLuan") %></span>
                                <span class="time-rate"><%# Eval("dThoigian",  "{0:d/MM/yyyy HH:mm}") %></span>
                            </div>
                        </ItemTemplate>
                    </asp:ListView>
                </div>
            </div>
        </div>
    </div>

    <script>
        window.onload = function () {
            var elems = document.getElementsByClassName('comment-rate');
            elems[0].style.display = "none";
        };
        function Trig() {
            if (window.event.keyCode == 13) {
                document.getElementById('<%=Button1.ClientID%>').focus();
            }
        }
    </script>
</asp:Content>
