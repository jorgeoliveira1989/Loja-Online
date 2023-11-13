<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice_top_side.Master" AutoEventWireup="true" CodeBehind="editar_produto.aspx.cs" Inherits="loja_online.editar_produto" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
         function validarNumeros(evt) {
             var charCode = (evt.which) ? evt.which : event.keyCode;
             if (charCode != 44 && charCode > 31 && (charCode < 48 || charCode > 57))
                 return false;

             return true;
         }
     </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center align-items-center" style="height: 100vh;">
    <div class="p-4 border rounded bg-light">
        <h3 class="mb-4 text-center"><b>Editar Produto</b></h3>
        <div>
            <div class="mb-3">
                <label for="txtid" class="form-label">ID</label>
                <asp:DropDownList ID="ddl_id" AppendDataBoundItems="true" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddl_id_SelectedIndexChanged" DataSourceID="SqlDataSource1" DataTextField="id_produto" DataValueField="id_produto">
                <asp:ListItem>-----</asp:ListItem>
                </asp:DropDownList>

                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:lojaOnline_aulaTesteConnectionString %>" SelectCommand="SELECT [id_produto] FROM [produtos]"></asp:SqlDataSource>

            </div>
            <div class="mb-3">
                <label for="txtProduto" class="form-label">Nome</label>
                <asp:TextBox ID="txt_produto" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDesignacao" class="form-label">Designação</label>
                <asp:TextBox ID="txt_designacao" class="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="mb-3">
                <label for="txtDescricao" class="form-label">Descrição</label>
                <asp:TextBox ID="txt_descricao" class="form-control" Rows="3" runat="server" TextMode="MultiLine"></asp:TextBox>
            </div>
            <div class="row g-3">
                <div class="col">
                    <label for="txtPreco" class="form-label">Preço</label>
                    <asp:TextBox ID="txt_preco" class="form-control" onkeypress="return validarNumeros(event);" runat="server"></asp:TextBox>
                </div>
                <div class="col">
                    <label for="txtQuantidade" class="form-label">Quantidade</label>
                    <asp:TextBox ID="txt_quantidade" class="form-control" runat="server" TextMode="Number"></asp:TextBox>
                </div>
            </div>
            <div class="mb-3">
                <label for="fileUpload" class="form-label">Upload de Foto</label>
                <asp:FileUpload ID="FileUpload1" class="form-control" runat="server" />
            </div>
            <div class="d-grid">
                <asp:Button ID="btn_editar_produto" class="btn btn-danger w-100" runat="server" Text="Editar Produto" Font-Bold="True" Font-Size="Medium" OnClick="btn_editar_produto_Click" />
            </div>
            <br />
            <div class="mb-3">
                <asp:Label ID="lbl_mensagem" runat="server" Font-Bold="True" Font-Size="Medium" ForeColor="Red"></asp:Label>
            </div>

        </div>
    </div>
</div>
</asp:Content>
