<%@ Page Title="İletişim" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="Communication.aspx.cs" Inherits="LawWebSite.Communication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section class="mb-5">

        <div class="container mt-5">
            <div class="row d-flex justify-content-cen
                ter">
                <div class="col-lg-7">
                    <div class="form" role="form" autocomplete="off">
                        <h4 style="margin-bottom: 28px; text-align: center;">
                            <asp:Label runat="server" ID="LblUserContactForm"></asp:Label>
                        </h4>
                        <div class="form-group row">
                            <label class="col-md-3 col-form-label form-control-label"> <asp:Label runat="server" ID="LblUserName"></asp:Label></label>
                            <div class="col-lg-7">
                                <asp:TextBox runat="server" ID="questionName" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="questionName"
                                    ErrorMessage="Ad alanı boş bırakılamaz." ValidationGroup="validationGroup"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label form-control-label"> <asp:Label runat="server" ID="LblUserSurname"></asp:Label></label>
                            <div class="col-lg-7">
                                <asp:TextBox runat="server" ID="questionSurname" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="questionSurname"
                                    ErrorMessage="Soyad alanı boş bırakılamaz." ValidationGroup="validationGroup"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label form-control-label"> <asp:Label runat="server" ID="LblUserMail"></asp:Label></label>
                            <div class="col-lg-7">
                                <asp:TextBox runat="server" ID="questionMail" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="questionMail"
                                    ErrorMessage="E-posta alanı boş bırakılamaz." ValidationGroup="validationGroup"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="questionMail"
                                    ErrorMessage="Geçerli bir e-posta adresi giriniz." ValidationExpression="^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$"
                                    ValidationGroup="validationGroup"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label form-control-label"> <asp:Label runat="server" ID="LblUserPhone"></asp:Label></label>
                            <div class="col-lg-7">
                                <asp:TextBox runat="server" ID="questionPhoneNumber" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="questionPhoneNumber"
                                    ErrorMessage="Telefon alanı boş bırakılamaz." ValidationGroup="validationGroup"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator runat="server" ControlToValidate="questionPhoneNumber"
                                    ErrorMessage="Geçerli bir telefon numarası giriniz." ValidationExpression="^\d[\d\s-]*\d$"
                                    ValidationGroup="validationGroup"></asp:RegularExpressionValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <label class="col-lg-3 col-form-label form-control-label"> <asp:Label runat="server" ID="LblUserQuestion"></asp:Label></label>
                            <div class="col-lg-7">
                                <asp:TextBox runat="server" TextMode="MultiLine" Rows="5" ID="question" CssClass="form-control"></asp:TextBox>
                                <asp:RequiredFieldValidator runat="server" ControlToValidate="question"
                                    ErrorMessage="Soru alanı boş bırakılamaz." ValidationGroup="validationGroup"></asp:RequiredFieldValidator>
                            </div>
                        </div>
                        <div class="form-group row">
                            <div class="col-lg-12">
                                <asp:Label runat="server" ID="LblKVKK"></asp:Label>
                            </div>
                        </div>
                        <div class="modal-footer justify-content-end">
                            <asp:LinkButton runat="server" ID="questionSubmitBtn" CssClass="btn btn-black" OnClick="lnkAddQuestion_Click" ValidationGroup="validationGroup">
                                <asp:Label runat="server" ID="LblSendTitle"></asp:Label>
                            </asp:LinkButton>
                        </div>
                    </div>
                </div>

                <asp:Repeater runat="server" ID="RCommunication" OnItemDataBound="RCommunication_ItemDataBound">
                    <ItemTemplate>
                        <div class="col-lg-5" style="border-left: 1px solid #e2e2e2;">
                            <h4 class="heading-primary text-center">
                                <asp:Label runat="server" ID="LblContactInfo"></asp:Label>
                            </h4>

                            <ul class="list-group list list-icons list-icons-style-3 mt-4 text-center">
                                <li class="list-group-item"><%#Eval("Address") %></li>
                                <li class="list-group-item"><%#Eval("PhoneNumber") %></li>
                                <li class="list-group-item"><%#Eval("Mail") %></li>
                            </ul>
                            <h4 class="heading-primary text-center mt-5">
                                <asp:Label runat="server" ID="LblWorkHour"></asp:Label>
                            </h4>
                            <ul class="list-group list list-icons list-dark mt-4 text-center">
                                <li class="list-group-item"><i class="far fa-clock"></i><%#Eval("MidWeek") %></li>
                                <li class="list-group-item"><i class="far fa-clock"></i><%#Eval("Saturday") %></li>
                                <li class="list-group-item"><i class="far fa-clock"></i><%#Eval("Sunday") %></li>
                            </ul>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>

    <section>
        <div class="container">
            <div class="row">
                <asp:Repeater runat="server" ID="RMaps">
                    <ItemTemplate>
                        <div class="col-12" style="width: 100%;">
                            <iframe runat="server" src='<%# Eval("MapUrl") %>' width="100%" height="450" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                        </div>

                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
    </section>

    <div class="modal fade" id="ModalKVKK">
        <div class="modal-dialog">
            <div class="modal-content">
                <div class="modal-header">
                    <h4 class="modal-title">
                        <asp:Label runat="server" ID="LblKVKKHeader"></asp:Label></h4>
                    <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true">&times;</span>
                    </button>
                </div>
                <div class="modal-body">
                    <p class="modal-description">
                        <asp:Label runat="server" ID="LblKVKKContent"></asp:Label>
                    </p>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

