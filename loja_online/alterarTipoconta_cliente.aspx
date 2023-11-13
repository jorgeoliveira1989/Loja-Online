<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice_top_side.Master" AutoEventWireup="true" CodeBehind="alterarTipoconta_cliente.aspx.cs" Inherits="loja_online.alterarTipoconta_cliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
<div class="p-4 border rounded bg-light">
    <h3 class="mb-4 text-center"><b>Alterar Tipo Conta</b></h3>
    <div>
        <div class="mb-3">
            <label for="txtid" class="form-label">ID</label>
            <asp:DropDownList ID="ddl_id" runat="server" AppendDataBoundItems="true" AutoPostBack="True" DataSourceID="SqlDataSource1" DataValueField="id_cliente" OnSelectedIndexChanged="ddl_id_SelectedIndexChanged">
                <asp:ListItem>-----</asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lojaOnline_aulaTesteConnectionString %>" SelectCommand="SELECT [id_cliente] FROM [clientes]"></asp:SqlDataSource>
        </div>
        <div class="mb-3">
            <label for="txt_tipoConta" class="form-label">Tipo Conta Atual</label>
            <br />
            <asp:Label runat="server" ID="lbl_tipoConta" class="form-control"></asp:Label>
        </div>
        <div class="mb-3">
            <label for="txt_opcao" class="form-label">Alterar Tipo Conta</label>
            <br />
            <asp:Label runat="server" ID="lbl_altera_conta" class="form-control"></asp:Label>
        </div>
            <br />
        <div class="d-grid">
            <asp:Button ID="btn_alterar_tipo_conta" class="btn btn-danger w-100" runat="server" Text="Alterar Tipo Conta" Font-Bold="True" Font-Size="Medium" OnClick="btn_alterar_tipo_conta_Click" />
        </div>
            <br />
        <div class="mb-3">
            <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
        </div>
   </div>
</div>
</div>

</asp:Content>
