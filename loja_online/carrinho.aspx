<%@ Page Title="" Language="C#" MasterPageFile="~/cabecalho_rodapé.Master" AutoEventWireup="true" CodeBehind="carrinho.aspx.cs" Inherits="loja_online.carrinho" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <title>Carrinho de Compras</title>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="form1" runat="server" class="container mt-5">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:Panel ID="Panel1" runat="server">
    <asp:Repeater ID="rptCarrinho" runat="server" OnItemCommand="rptCarrinho_ItemCommand">
        <ItemTemplate>
            <!-- Card para cada item no carrinho -->
            <div class="card mb-3">
                <div class="row g-0">
                    <div class="col-md-4">
                        <asp:Image ID="foto_produto" runat="server" ImageUrl='<%# Eval("imagemSrc") %>' AlternateText="Pré-visualização" CssClass="img-fluid" />
                    </div>
                    <div class="col-md-8">
                        <div class="card-body">
                            <h5 class="card-title"><%# Eval("produto") %></h5>
                            <p class="card-text">Preço: <%# Eval("preco", "{0:C}") %></p>
                            <div class="input-group">
                                <asp:TextBox ID="txtQuantidade" runat="server" Text='<%# Eval("Quantidade") %>' CssClass="form-control" />
                                <span class="input-group-btn">
                                    <asp:Button ID="btnSubtrair" runat="server" Text="-" CommandName="Subtrair" CommandArgument='<%# Container.ItemIndex %>' CssClass="btn btn-outline-danger" />
                                </span>
                                <span class="input-group-btn">
                                    <asp:Button ID="btnAdicionar" runat="server" Text="+" CommandName="Adicionar" CommandArgument='<%# Container.ItemIndex %>' CssClass="btn btn-outline-success" />
                                </span>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>

    <!-- Resumo da Encomenda -->
    <div class="card mt-3 float-right"/>
    <div class="card-body"/>
        
            <h5 class="card-title">Resumo da Encomenda</h5>
             <p class="card-text"><%= CalcularTotalArtigos() %> artigos</p>
            <hr>
            <p class="card-text">Valor Total:</p>
            <asp:Label ID="lbl_valor" runat="server" class="form-control" Font-Size="Large" ForeColor="Black" Font-Bold="true"></asp:Label>
            <hr>
            <asp:Button ID="btn_avançar" runat="server" Text="Avançar &gt;" OnClick="btn_avançar_Click" CssClass="btn btn-danger" Font-Size="Medium" />
            <br />
        </asp:Panel>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                    <asp:Panel ID="Panel2" runat="server" Visible="False">
                        <asp:Label ID="lbl_mail" runat="server" Text="Confirme o seu Email:" Font-Bold="True"></asp:Label>
                        <br />
                         <asp:TextBox ID="txt_email" runat="server" class="form-control" Width="320px"></asp:TextBox><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txt_email" ErrorMessage="Precisa de Preencher com o seu email" Font-Bold="True" ForeColor="Red">*</asp:RequiredFieldValidator> <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="txt_email" ErrorMessage="Precisa de colocar um email valído" Font-Bold="True" ForeColor="Red" ValidationExpression="^[\w\.-]+@[a-zA-Z\d\.-]+\.[a-zA-Z]{2,}$">*</asp:RegularExpressionValidator>
                        <br />
                        <br />
                        <asp:Button ID="btnFinalizarEncomenda" runat="server" Text="Finalizar Encomenda" CssClass="btn btn-danger" />
                        <asp:Button ID="btnlogin" runat="server" Text="Login"  CssClass="btn btn-primary" OnClick="btnlogin_Click"  />
                        <asp:Button ID="btncriarconta" runat="server" Text="Criar Conta" CssClass="btn btn-success" OnClick="btncriarconta_Click"/>
                        <br />
                        <asp:ValidationSummary ID="ValidationSummary1" runat="server" Font-Bold="True" ForeColor="Red" />
                    </asp:Panel>
            </ContentTemplate>
   </asp:UpdatePanel>
    </div>

</asp:Content>
