<%@ Page Title="Sorularınız" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="Question.aspx.cs" Inherits="LawWebSite.Question" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="container">
  
        <form class="form" role="form" autocomplete="off">

            <div class="form-group row">
                <label class="col-md-3 col-form-label form-control-label">Ad</label>
                <div class="col-md-9">
                    <asp:TextBox runat="server" ID="questionName" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-lg-3 col-form-label form-control-label">Soyad</label>
                <div class="col-lg-9">
                    <asp:TextBox runat="server" ID="questionSurname" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-lg-3 col-form-label form-control-label">E-posta:</label>
                <div class="col-lg-9">
                    <asp:TextBox runat="server" ID="questionMail" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="form-group row">
                <label class="col-lg-3 col-form-label form-control-label">Telefon:</label>
                <div class="col-lg-9">
                    <asp:TextBox runat="server" ID="questionPhoneNumber" CssClass="form-control"></asp:TextBox>
                </div>
            </div>
            <div class="form-group row">
                <label class="col-lg-3 col-form-label form-control-label">Soru:</label>
                <div class="col-lg-9">
                    <asp:TextBox runat="server" TextMode="MultiLine" Rows="5" ID="question" CssClass="form-control"></asp:TextBox>
                </div>
            </div>

            <div class="modal-footer justify-content-between">

                <asp:LinkButton runat="server" ID="questionSubmitBtn" CssClass="btn btn-black" OnClick="lnkAddQuestion_Click">Gönder</asp:LinkButton>
            </div>
        </form>
    </div>


</asp:Content>
