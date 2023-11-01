<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice_top_side.Master" AutoEventWireup="true" CodeBehind="desativar_produto.aspx.cs" Inherits="loja_online.desativar_produto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
<div class="p-4 border rounded bg-light">
    <h3 class="mb-4 text-center"><b>Desativar Produto</b></h3>
    <div>
        <div class="mb-3">
            <label for="txtid" class="form-label">ID</label>
            <asp:DropDownList ID="ddl_id" runat="server" AutoPostBack="True" DataSourceID="SqlDataSource1" DataValueField="id_produto" OnSelectedIndexChanged="ddl_id_SelectedIndexChanged"></asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lojaOnline_aulaTesteConnectionString %>" SelectCommand="SELECT [id_produto] FROM [produtos] WHERE ([ativo] = @ativo)">
                <SelectParameters>
                    <asp:Parameter DefaultValue="True" Name="ativo" Type="Boolean" />
                </SelectParameters>
            </asp:SqlDataSource>
        </div>
        <div class="mb-3">
            <label for="txtProduto" class="form-label">Nome</label>
            <br />
            <asp:Label runat="server" ID="lbl_produto" class="form-control"></asp:Label>
        </div>
            <br />
        <div class="d-grid">
            <asp:Button ID="btn_desativar_produto" class="btn btn-danger w-100" runat="server" Text="Desativar Produto" Font-Bold="True" Font-Size="Medium" OnClick="btn_desativar_produto_Click" />
        </div>
            <br />
        <div class="mb-3">
            <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
   </div>
</div>
</div>

</asp:Content>
