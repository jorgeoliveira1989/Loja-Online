<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice_top_side.Master" AutoEventWireup="true" CodeBehind="visualizar_vendas.aspx.cs" Inherits="loja_online.visualizar_encomendas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">



</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container d-flex justify-content-center align-items-center">
   <div class="p-4 border rounded bg-light">
       <br />
           <h1>Visualizar Vendas</h1>
       <br />
       <asp:Repeater ID="rpt_verVendas" runat="server" OnItemDataBound="rpt_verVendas_ItemDataBound">
           <HeaderTemplate>
               <table border="1" width="1000">
                   <tr>
                       <td><b>ID</b></td>
                       <td><b>Username</b></td>
                       <td><b>Produto</b></td>
                       <td><b>Quantidade</b></td>
                       <td><b>Data da Compra</b></td>
                   </tr>
           </HeaderTemplate>
           <ItemTemplate>
                <tr>
                    <td><%# Eval("id_venda")%></td>
                    <td><%# Eval("username")%></td>
                    <td><%# Eval("produto")%></td>
                    <td><%# Eval("quantidade")%></td>
                    <td><asp:Label ID="lblDataVenda" runat="server"></asp:Label></td>
               </tr>
           </ItemTemplate>
           <FooterTemplate>
               </table>
           </FooterTemplate>
       </asp:Repeater>
   </div>
</div>

</asp:Content>
