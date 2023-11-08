using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace loja_online
{
    public partial class carrinho : System.Web.UI.Page
    {

        decimal valorTotal = 0;
        private List<Produtos> ListaProdutosCarrinho
        {
            get
            {
                if (Session["Carrinho"] == null)
                    Session["Carrinho"] = new List<Produtos>();
                return (List<Produtos>)Session["Carrinho"];
            }
            set { Session["Carrinho"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                AtualizarCarrinho();
                
            }

            if (Session["username"] == null)
            {
                btnFinalizarEncomenda.Visible = false;
                lbl_mail.Visible = false;
                txt_email.Visible = false;
                btnlogin.Visible = true;
                btncriarconta.Visible = true;
            }
            else
            {
                btnFinalizarEncomenda.Visible = true;
                lbl_mail.Visible = true;
                txt_email.Visible = true;
                btnlogin.Visible = false;
                btncriarconta.Visible = false;
            }

        }

        protected void rptCarrinho_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Subtrair":
                    SubtrairQuantidade(index);
                    break;
                case "Adicionar":
                    AdicionarQuantidade(index);
                    break;
            }
            AtualizarCarrinho();
            
        }

        private void SubtrairQuantidade(int index)
        {
             if (ListaProdutosCarrinho[index].Quantidade > 0)
             {
                 ListaProdutosCarrinho[index].Quantidade--;
                 if (ListaProdutosCarrinho[index].Quantidade == 0)
                 {
                     ListaProdutosCarrinho.RemoveAt(index);
                    
                }
             }

             // Atualiza o valor total do carrinho após subtrair a quantidade
             AtualizarValorTotal();
            Session["ValorTotal"] = valorTotal;
            AtualizarValorAcumulado();
        }

        private void AdicionarQuantidade(int index)
        {
            ListaProdutosCarrinho[index].Quantidade++;
            if (ListaProdutosCarrinho[index].Quantidade == 0)
            {
                ListaProdutosCarrinho.RemoveAt(index);
            }

            // Atualiza o valor total do carrinho após adicionar a quantidade
            AtualizarValorTotal();
        }

        private void AtualizarCarrinho()
        {
            rptCarrinho.DataSource = ListaProdutosCarrinho;
            rptCarrinho.DataBind();

            // Atualiza o valor total do carrinho
            AtualizarValorTotal();
        }

        private void AtualizarValorTotal()
        {
            valorTotal = 0;

            foreach (var produto in ListaProdutosCarrinho)
            {
                valorTotal += produto.preco * produto.Quantidade;
            }

            lbl_valor.Text = valorTotal.ToString("C");

            Session["ValorTotal"] = valorTotal;
        }
        public int CalcularTotalArtigos()
        {
            int totalArtigos = 0;

            foreach (var item in ListaProdutosCarrinho)
            {
                totalArtigos += item.Quantidade;

            }

            if (totalArtigos == 0)
            {
                txt_email.Enabled = false;
                btnFinalizarEncomenda.Enabled = false;
            }
            else
            {
                txt_email.Enabled = true;
                btnFinalizarEncomenda.Enabled = true;
            }

            return totalArtigos;
        }

        private void AtualizarValorAcumulado()
        {
            decimal valorAcumulado = 0;

            foreach (var produto in ListaProdutosCarrinho)
            {
                valorAcumulado += produto.preco * produto.Quantidade;
            }

            Session["ValorAcumulado"] = valorAcumulado;
        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void btncriarconta_Click(object sender, EventArgs e)
        {
            Response.Redirect("criar_conta.aspx");
        }

        protected void btn_avançar_Click(object sender, EventArgs e)
        {
            Panel1.Enabled = false;
            Panel2.Visible = true;
        }
    }
}