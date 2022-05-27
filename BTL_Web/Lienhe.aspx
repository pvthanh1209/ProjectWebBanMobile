<%@ Page Title="" Language="C#" MasterPageFile="~/core.Master" AutoEventWireup="true" CodeBehind="Lienhe.aspx.cs" Inherits="BTL_Web.Lienhe" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style type="text/css">
        .lienhe-main {
            width: 1080px;
            margin: 0 auto;
        }

        .lienhe-body {
            margin-top: 90px;
            display: flex;
            flex-direction: column;
            align-items: center;
            padding-bottom: 50px;
        }

        .wrap-icon {
            margin-top: 40px;
            width: 270px;
            display: flex;
            justify-content: space-between;
        }

        .contact-phone {
            background-color: #51CB5A;
            height: 50px;
            width: 50px;
            display: flex;
            justify-content: center;
            align-items: center;
            border-radius: 50%;
            transition: 0.6s;
        }

            .contact-phone:hover {
                background-color: #1B8F22;
                transition: 0.6s;
            }

        .contact-fb {
            background-color: #3A589D;
            height: 50px;
            width: 50px;
            display: flex;
            justify-content: center;
            align-items: center;
            border-radius: 50%;
            transition: 0.6s;
        }

            .contact-fb:hover {
                background-color: #193679;
                transition: 0.6s;
            }

        .contact-insta {
            background-color: #3B6994;
            height: 50px;
            width: 50px;
            display: flex;
            justify-content: center;
            align-items: center;
            border-radius: 50%;
            transition: 0.6s;
        }

            .contact-insta:hover {
                background-color: #225585;
                transition: 0.6s;
            }

        .contact-twitter {
            background-color: #2478BA;
            height: 50px;
            width: 50px;
            display: flex;
            justify-content: center;
            align-items: center;
            border-radius: 50%;
            transition: 0.6s;
        }

            .contact-twitter:hover {
                background-color: #115283;
                transition: 0.6s;
            }

        .contact-youtube {
            background-color: #C33223;
            height: 50px;
            width: 50px;
            display: flex;
            justify-content: center;
            align-items: center;
            border-radius: 50%;
            transition: 0.6s;
        }

            .contact-youtube:hover {
                background-color: #961F12;
                transition: 0.6s;
            }

        .contact i {
            font-size: 25px;
            color: white;
        }

        .wrap-icon {
            display: flex;
        }

        .lienhe-body img {
            margin-top: 30px;
            margin-bottom: 20px;
        }

        span.contact-hr hr {
            display: inline-block;
            width: 280px;
            margin: 5px 10px;
            border-top: 2px solid #e5e5e5;
        }
    </style>
    <div class="lienhe-main">
        <div class="lienhe-body">
            <h1>HÃY KẾT NỐI VỚI CHÚNG TÔI</h1>
            <div class="wrap-icon">
                <div>
                    <div class="contact-phone contact"><a href=""><i class="fas fa-phone"></i></a></div>
                </div>
                <div>
                    <div class="contact-fb contact"><a href=""><i class="fab fa-facebook-f"></i></a></div>
                </div>
                <div>
                    <div class="contact-insta contact"><a href=""><i class="fab fa-instagram"></i></a></div>
                </div>
                <div>
                    <div class="contact-twitter contact"><a href=""><i class="fab fa-twitter"></i></a></div>
                </div>
                <div>
                    <div class="contact-youtube contact"><a href=""><i class="fab fa-youtube"></i></a></div>
                </div>
            </div>
            <img src="images/img-shop.png">
            <span style="font-size: 30px; font-weight: bold;">Thông tin liên hệ</span>
            <hr />
            <span style="font-size: 20px; font-weight: bold;">Số 96 Định Công, Hoàng Mai, Hà Nội</span>
            <span style="font-size: 18px">SĐT: 0335167431</span>
            <span style="font-size: 18px">Email: CTCMOBILE@gmail.com</span>
            <br />
            <br />
            <span style="font-size: 25px; font-weight: bold; margin-bottom: 20px; margin-top: 30px;" class="contact-hr">
                <hr />
                VỊ TRÍ CỬA HÀNG TRÊN BẢN ĐỒ<hr />
            </span>
            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3725.2778667871657!2d105.82993626767997!3d20.98149590510524!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135ac5f17bd8c43%3A0x665ed8e8059205c3!2zOTYgxJDhu4tuaCBDw7RuZywgSG_DoG5nIE1haSwgSMOgIE7hu5lpLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2s!4v1648029292650!5m2!1svi!2s" width="80%" height="450" style="border: 0;" allowfullscreen="" loading="lazy"></iframe>
        </div>
    </div>
</asp:Content>
