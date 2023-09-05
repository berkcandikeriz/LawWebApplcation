<%@ Page Title="" Language="C#" MasterPageFile="~/LawWeb.Master" AutoEventWireup="true" CodeBehind="Faq.aspx.cs" Inherits="LawWebSite.Faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>
        function toggleAccordion(element) {
            var content = element.nextElementSibling;
            var allContents = document.querySelectorAll('.kozanoglu-faq-accordion-section-content');
            var allTitles = document.querySelectorAll('.kozanoglu-faq-accordion-section-title');

            allContents.forEach(function (item) {
                item.style.display = "none";
            });
            allTitles.forEach(function (item) {
                item.classList.remove("active");
            });
            content.style.display = "block";
            element.classList.add("active");
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <section id="section-features" style="background-size: cover;">
        <div class="container" style="background-size: cover;">
            <div class="row" style="background-size: cover;">
                <div class="col-md-12 mb30" style="background-size: cover;">
                    <div class="box-highlight" style="background-size: cover;">
                        <div class="kozanoglu-heading heading text-center text-light" style="background-size: cover;">
                            <h3 class="kozanoglu-heading-text">
                                <asp:Label ID="LblFaq" runat="server"></asp:Label>
                            </h3>
                        </div>
                        <div class="kozanoglu-faq-content" style="background-size: cover;">

                            <div class="kozanoglu-faq-accordion" style="background-size: cover;">
                                <asp:Repeater runat="server" ID="RFaqs">
                                    <ItemTemplate>
                                        <div class="kozanoglu-faq-accordion-section" style="background-size: cover;">
                                            <div class="kozanoglu-faq-accordion-section-title" onclick="toggleAccordion(this)" style="background-size: cover;">
                                               <%#Eval("Question") %>                                  
                                            </div>
                                            <div class="kozanoglu-faq-accordion-section-content" style="background-size: cover;">
                                                <p> <%#Eval("Answer") %> </p>

                                            </div>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </section>
</asp:Content>
