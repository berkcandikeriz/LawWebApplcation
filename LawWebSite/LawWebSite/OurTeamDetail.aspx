<%@ Page Title="Page Title" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="OurTeamDetail.aspx.cs" Inherits="LawWebSite.OurTeamDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="ftco-section">
        <div class="container">
            <div class="row mb-3">
                <div class="col-12">
                    <h1 class="mb-1">
                        <asp:Label runat="server" ID="LblLawyerName"></asp:Label>
                    </h1>
                    <h5 class="mb-3">
                        <asp:Label runat="server" ID="LblLawyerTitle"></asp:Label></h5>
                    <small>
                        <a runat="server" href='<%# Eval("Twitter") %>' target="_blank">
                              <i class="fa fa-twitter"></i>&nbsp;
                            <asp:Label runat="server" ID="LblLawyerTwitter"></asp:Label>
                        </a>
                    </small>
                    <small>
                        <a runat="server" href='<%# Eval("Email") %>' target="_blank">
                            <i class="fa fa-envelope"></i>
                            <asp:Label runat="server" ID="LblLawyerMail"></asp:Label>
                               </a>
                    </small>
                    <small>
                        <a runat="server" href='<%# Eval("Linkedin") %>' target="_blank">
                            <i class="fa fa-linkedin"></i>
                            <asp:Label runat="server" ID="LblLawyerLinkdln"></asp:Label>
                               </a>
                    </small>
                    <small>
                        <a runat="server" href='<%# Eval("Instagram") %>' target="_blank">
                            <i class="fa fa-instagram"></i>
                            <asp:Label runat="server" ID="LblLawyerInstagram"></asp:Label>
                               </a>
                    </small>
                    <small>
                        <a runat="server" href='<%# Eval("PhoneNumber") %>' target="_blank">
                            <i class="fa fa-phone"></i>
                            <asp:Label runat="server" ID="LblLawyerPhone"></asp:Label>
                               </a>
                    </small>
                    <hr />
                </div>
            </div>
            <div class="row">
                <div class="col-lg-8 order-lg-last ftco-animate">
                    <p>
                        <asp:Label runat="server" ID="LblLawyerDescription" CssClass="text-dark"></asp:Label>
                    </p>
                </div>

                <div class="col-lg-4 sidebar pr-lg-5 ftco-animate">
                    <div class="sidebar-box ftco-animate">
                        <asp:Image runat="server" ID="ImgImageUrl" CssClass="img-fluid img-thumbnail" />
                    </div>
                </div>
            </div>
        </div>
    </section>

</asp:Content>
