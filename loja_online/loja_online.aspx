<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loja_online.aspx.cs" Inherits="loja_online.loja_online" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Loja Online</title>
        <style>
            .whatsapp-icon {
                color: #FF0000; /* Vermelho */
            }
            .custom-link {
                color: black; /* Define a cor do texto como preto */
                text-decoration: none; /* Remove o sublinhado */
                font-size: 1.2em; /* Define o tamanho da fonte (ajuste conforme necessário) */
            }
            #meuCarrossel {
                width: 100%;
                max-width: none;
                height: 600px;
            }  
        </style>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <link href="css/bootstrap.min.css" rel="stylesheet" />
    <link href="css/all.min.css" rel="stylesheet" />
</head>
<body>

    <form id="form1" runat="server">
        <div class="bg-dark p-3">
            <div class="container">
                <div class="row">
                    <div class="col-12">
                        <div class="d-flex justify-content-between align-items-center">
                    <!-- Ícones de redes sociais na esquerda -->
                            <div class="d-flex">
                                <a href="#" class="ms-2"><i class="fab fa-facebook fa-2x text-white"></i></a>
                                <a href="#" class="ms-2"><i class="fab fa-twitter fa-2x text-white"></i></a>
                            </div>

                    <!-- Caixa de pesquisa centralizada -->
                            <div class="input-group mb-3" style="max-width: 500px; margin: 0 auto;">
                                <asp:TextBox ID="txt_pesquisar" runat="server" CssClass="form-control" placeholder="Pesquisar produtos" OnTextChanged="txt_pesquisar_TextChanged"></asp:TextBox>
                                <div class="input-group-append">
                                    <asp:Button ID="btn_procurar" runat="server" Text="Pesquisar" CssClass="btn btn-danger" />
                                </div>
                            </div>

                    <!-- Botão de Login/Minha Conta -->
                            
                            <i class="fas fa-user fa-2x me-2 whatsapp-icon"></i><asp:LinkButton ID="lb_minhaConta" class="btn btn-link text-white text-decoration-none" runat="server" OnClick="lb_minhaConta_Click">Login/Minha Conta</asp:LinkButton>

                    <!-- Ícone do WhatsApp e número de telefone -->
&nbsp;<asp:LinkButton ID="lbl_nome" runat="server" OnClick="lbl_nome_Click" class="btn btn-link text-white text-decoration-none" Visible="False"></asp:LinkButton>
                            <div class="d-flex align-items-center">
                                <i class="fab fa-whatsapp fa-2x whatsapp-icon me-2"></i>
                                <label class="mb-0 text-white">910000000</label>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="bg-gray text-center py-3 h-105">
            <a href="loja_online.aspx" class="mx-3 custom-link"><i class="fa-solid fa-house" style="color: #ff0000;"></i> <b>HOME</b></a>
            <asp:LinkButton ID="Lb_menos100" class="mx-3 custom-link" runat="server" OnClick="Lb_menos100_Click"><b> < 100€</b></asp:LinkButton>
            <asp:LinkButton ID="lb_entre100e300" class="mx-3 custom-link" runat="server" OnClick="lb_entre100e300_Click"><b>100€ - 300€</b></asp:LinkButton>
            <asp:LinkButton ID="lb_mais300" class="mx-3 custom-link" runat="server" OnClick="lb_mais300_Click"><b> > 300€</b></asp:LinkButton>
            <b><asp:Label ID="lbl_valor" runat="server" class="mx-3 custom-link" style="color: #ff0000;" Text="0,00€"></asp:Label></b>
            <a href="carrinho.aspx" class="mx-3 custom-link"><i class="fa-solid fa-cart-shopping" style="color: #ff0000;"></i></a>
            <asp:Button ID="btn_sair" runat="server" Text="SAIR" class="btn btn-danger" Visible="false" OnClick="btn_sair_Click" Font-Bold="True" Font-Size="Medium" Width="75px" />
        </div>
        
        <!-- Adicionado carrossel com imagens -->
        <div id="meuCarrossel" class="carousel slide w-100 h-700" data-ride="carousel">
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="image/image1.jpg" alt="Imagem 1" class="w-100"/>
                </div>
                <div class="carousel-item">
                    <img src="image/image2.jpg" alt="Imagem 2" class="w-100"/>
                </div>
                <div class="carousel-item">
                    <img src="image/image3.jpg" alt="Imagem 3" class="w-100"/>
                </div>
            </div>
                <a class="carousel-control-prev" href="#meuCarrossel" role="button" data-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="sr-only">Anterior</span>
                </a>
                <a class="carousel-control-next" href="#meuCarrossel" role="button" data-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="sr-only">Próximo</span>
                </a>
        </div>

        <!-- Local onde coloco a informação dos serviços de entrega rápida, garantia, etc -->
        <div class="bg-white text-center py-4">
            <div class="container">
                <div class="row">
                    <div class="col-md-3 mb-4">
                        <div class="bg-dark p-4 rounded text-white">
                            <img src="image/entrega-rapida.png" alt="Logo 1" class="mb-3" width="50"/>
                            <p><b>Envio Grátis Portugal Continental</b></p>
                        </div>
                    </div>
                    <div class="col-md-3 mb-4">
                        <div class="bg-dark p-4 rounded text-white">
                            <img src="image/escudo.png" alt="Logo 2" class="mb-3" width="50"/>
                            <p><b>Garantia de 30 dias</b></p>
                        </div>
                    </div>
                    <div class="col-md-3 mb-4">
                        <div class="bg-dark p-4 rounded text-white">
                            <img src="image/customer-support.png" alt="Logo 3" class="mb-3" width="50"/>
                            <p><b>Suporte Especializado</b></p>
                        </div>
                    </div>
                    <div class="col-md-3 mb-4">
                        <div class="bg-dark p-4 rounded text-white">
                            <img src="image/relogio.png" alt="Logo 4" class="mb-3" width="50"/>
                            <p><b>Entrega Rápida</b></p>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Parte do repeater onde apresenta os produtos que estão ativos -->
        <div id="Div1" runat="server">
            <div class="container text-center">
                <asp:Label ID="lbl_cargo" runat="server" Text=""></asp:Label>
                <h1 style="color: rgb(255, 0, 0); font-weight: bold;">Produtos</h1>
                    <label __designer:mapid="196">
                        <b>Ordenar:</b> <asp:DropDownList ID="ddl_opcoes" runat="server" AutoPostBack="True">
                                            <asp:ListItem>-----------------</asp:ListItem>
                                            <asp:ListItem>Nome Produto</asp:ListItem>
                                            <asp:ListItem>Preço Ascendente</asp:ListItem>
                                            <asp:ListItem>Preço Descendente</asp:ListItem>
                                        </asp:DropDownList>
                    </label>
                    <br />
                    <br />
        <div class="row" id="productContainer">
            <asp:Repeater ID="rptProdutos" runat="server">
                <ItemTemplate>
                    <div class="col-md-3 mb-4 productCard">
                        <div class="card">
                            <asp:Image ID="foto_produto" runat="server" ImageUrl='<%# Eval("imagemSrc") %>' AlternateText="Pré-visualização" />
                                <div class="card-body">
                                    <h4 class="card-title"><b><%# Eval("produto") %></b></h4>
                                    <p class="card-text"><%# Eval("designacao") %></p>
                                    <% if (Session["cargo"] != null && Session["cargo"].ToString().Equals("Revendedor", StringComparison.OrdinalIgnoreCase)) { %>
                        <p class="card-text" style="text-decoration: line-through;">Preço: <%# Eval("preco", "{0:C}") %></p>
                        <p class="card-text">Preço Revenda: <%# Eval("preco_revenda", "{0:C}") %></p>
                    <% } else { %>
                        <p class="card-text">Preço: <%# Eval("preco", "{0:C}") %></p>
                    <% } %>
                                    <asp:Button ID="btnAdicionar" runat="server" Text="Adicionar ao Carrinho" CssClass="btn btn-danger" OnClick="btnAdicionar_Click" CommandArgument='<%# Eval("id_produto") + "|" + Eval("produto") + "|" + Eval("Preco") + "|" + Eval("imagemSrc") + "|" + Eval("preco_revenda") %>' CausesValidation="False" />
                                </div>
                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>
                <!-- Botões de paginação -->
                <div class="text-center">
                    <button id="prevPage" class="btn btn-danger">Página Anterior</button>
                    <button id="nextPage" class="btn btn-danger">Próxima Página</button>
                </div>
                <br />
                <br />
            </div>  
        </div>
        <div class="footer">
            <div class="bg-dark text-white text-center py-3">
                @lojaOnline - Teste de avaliação cet74
            </div>
       </div>


    </form>   
    

  <!--Start of Tawk.to Script-->
<script type="text/javascript">
var Tawk_API=Tawk_API||{}, Tawk_LoadStart=new Date();
(function(){
var s1=document.createElement("script"),s0=document.getElementsByTagName("script")[0];
s1.async=true;
s1.src='https://embed.tawk.to/65492b72a84dd54dc4890f8a/1heit3dsh';
s1.charset='UTF-8';
s1.setAttribute('crossorigin','*');
s0.parentNode.insertBefore(s1,s0);
})();
</script>
<!--End of Tawk.to Script-->

<!-- JS para a páginação-->
<script>
    document.addEventListener('DOMContentLoaded', function () {
        const products = document.querySelectorAll('.productCard');
        const prevPageButton = document.getElementById('prevPage');
        const nextPageButton = document.getElementById('nextPage');
        const productsPerPage = 12;
        let currentPage = 1;

        function showProducts() {
            products.forEach((product, index) => {
                if (index >= (currentPage - 1) * productsPerPage && index < currentPage * productsPerPage) {
                    product.style.display = 'block';
                } else {
                    product.style.display = 'none';
                }
            });
        }

        function updateButtons() {
            if (currentPage === 1) {
                prevPageButton.disabled = true;
            } else {
                prevPageButton.disabled = false;
            }

            if (currentPage * productsPerPage >= products.length) {
                nextPageButton.disabled = true;
            } else {
                nextPageButton.disabled = false;
            }
        }

        prevPageButton.addEventListener('click', function () {
            if (currentPage > 1) {
                currentPage--;
                showProducts();
                updateButtons();
            }
        });

        nextPageButton.addEventListener('click', function () {
            if (currentPage * productsPerPage < products.length) {
                currentPage++;
                showProducts();
                updateButtons();
            }
        });

        showProducts();
        updateButtons();
    });
</script>

// Adicione o jQuery na sua página, se ainda não estiver carregado
<script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>

    <!--Guardar produtos ao carregar no devido botão-->



</body>
    <script src="https://code.jquery.com/jquery-3.5.1.slim.min.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.0.9/dist/umd/popper.min.js"></script>
    <script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/js/bootstrap.min.js"></script>
</html>
