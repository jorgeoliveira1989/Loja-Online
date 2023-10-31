<%@ Page Title="" Language="C#" MasterPageFile="~/backoffice_top_side.Master" AutoEventWireup="true" CodeBehind="visualizar_produtos.aspx.cs" Inherits="loja_online.visualizar_produtos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .baixo_stock{
            color:red;
            font-weight:bold;
        }
        .medio_stock{
            color:orange;
            font-weight:bold;
        }
        .alto_stock{
            color:green;
            font-weight:bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container d-flex justify-content-center align-items-center" style="height: 60vh;">
        <div class="p-4 border rounded bg-light">
           <br />
                <h1>Produtos</h1>
            <asp:Repeater ID="rpt_produtos" runat="server">
                <HeaderTemplate>
                    <table border="1" width="1000">
                        <tr>
                            <td><b>ID</b></td>
                            <td><b>Foto</b></td>
                            <td><b>Produtos</b></td>
                            <td><b>Preço</b></td>
                            <td><b>Quantidade</b></td>
                            <td><b>Preço Revenda</b></td>
                            
                        </tr>
                </HeaderTemplate>
                <ItemTemplate>
                     <tr>
                         <td><%# Eval("id_produto")%></td>
                         <td><asp:Image ID="foto_produto" runat="server" Width="50" Height="50" ImageUrl='<%# Eval("imagemSrc") %>' AlternateText="Pré-visualização" /></td>
                         <td><%# Eval("produto")%></td>
                         <td><%# Eval("preco")%></td>
                         <td class="<%# Eval("quantidadeprodutocss")%>"><%# Eval("quantidade")%></td>
                         <td><%# Eval("preco_revenda")%></td>
                         
                    </tr>
                </ItemTemplate>
                <FooterTemplate>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
           <br />
        </div>
    </div>
</asp:Content>
