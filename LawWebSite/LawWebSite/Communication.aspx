<%@ Page Title="İletişim" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="Communication.aspx.cs" Inherits="LawWebSite.Communication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="mb-5">
        <div class="container mt-5">
            <div class="row d-flex justify-content-center">
                <div class="col-lg-6 text-end">
                 
                    <h4 class="heading-primary text-center"><asp:Label ID="LblContactInformation" runat="server" ></asp:Label></h4>
                    <ul class="list-group list list-icons list-icons-style-3 mt-4 text-center">

                        <li class="list-group-item">İstanbul/Türkiye</li>

                        <li class="list-group-item"><a href="https://api.whatsapp.com/send?phone=9+90 544 651 0420">+90 544 651 0420 </a></li>

                        <li class="list-group-item"><strong></strong><a href="mailto:#">İnfo@kozanoglu.av.tr</a></li>

                    </ul>
                </div>

                <div class="col-lg-6" style="border-left: 1px solid #e2e2e2;">
                    <h4 class="heading-primary text-center"><asp:Label runat="server" ID="LblWorkHour" /></h4>
                    <ul class="list-group list list-icons list-dark mt-4 text-center">

                        <li class="list-group-item"><i class="far fa-clock"></i>Hafta içi - 09:00 - 19.00</li>
                        <li class="list-group-item"><i class="far fa-clock"></i>Cumartesi - 09:00 - 19.00</li>
                        <li class="list-group-item"><i class="far fa-clock"></i>Pazar - Kapalı</li>

                    </ul>
                </div>
            </div>

        </div>
    </section>

    <section>
        <div class="container">
            <div class="row">
                <div class="col-12" style="width: 100%;">
                    <iframe width="100%" height="600" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="https://maps.google.com/maps?width=100%25&amp;height=600&amp;hl=tr&amp;q=Levent+(My%20Business%20Name)&amp;t=&amp;z=14&amp;ie=UTF8&amp;iwloc=B&amp;output=embed"><a
                        href="https://www.maps.ie/distance-area-calculator.html">measure area map</a></iframe>
                </div>
            </div>
        </div>
    </section>

</asp:Content>

