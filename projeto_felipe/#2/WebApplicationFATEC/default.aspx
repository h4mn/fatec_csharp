<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="WebApplicationFATEC._default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <div class="flexslider">
      <ul class="slides">
        <li>
            <img src="IMAGENS/banner0.png" />
        </li>
        <li>
            <img src="IMAGENS/banner1.png" />
        </li>
        <li>
            <img src="IMAGENS/banner2.png" />
        </li>
        <li>
            <img src="IMAGENS/banner3.png" />
        </li>
      </ul>
    </div>

    <script>
        // Can also be used with $(document).ready()
        $(window).load(function () {
            $('.flexslider').flexslider({
                animation: "slide"
            });
        });
    </script>

    <div class="margin-top-60">
        <div class="row">
            <div class="col-6">
                <div class="box margin-right-20">
                    <img src="IMAGENS/si1.png" />
                    <h2>Análise de Sistemas</h2>

                    <p>
                        O Tecnólogo em Análise e Desenvolvimento de Sistemas analisa, projeta, documenta, especifica, testa, implanta e mantém sistemas computacionais de informação. Esse profissional trabalha, também, com ferramentas computacionais, equipamentos de informática e metodologia de projetos na produção de sistemas. Raciocínio lógico, emprego de linguagens de programação e de metodologias de construção de projetos, preocupação com a qualidade, usabilidade, robustez, integridade e segurança de programas computacionais são fundamentais à atuação desse profissional.
                    </p>
                </div>
            </div>

            <div class="col-6">
               <div class="box">
                   <img src="IMAGENS/si2.jpg" /> 
                   <h2>Tecnologo em Analise de Sistemas</h2>

                   <p>
                        O Tecnólogo em Análise e Desenvolvimento de Sistemas analisa, projeta, documenta, especifica, testa, implanta e mantém sistemas computacionais de informação. Esse profissional trabalha, também, com ferramentas computacionais, equipamentos de informática e metodologia de projetos na produção de sistemas. Raciocínio lógico, emprego de linguagens de programação e de metodologias de construção de projetos, preocupação com a qualidade, usabilidade, robustez, integridade e segurança de programas computacionais são fundamentais à atuação desse profissional.
                    </p>
               </div>
            </div>
        </div>
    </div>


</asp:Content>


