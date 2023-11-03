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
        }

        protected void rptCarrinho_ItemCommand(object source, System.Web.UI.WebControls.RepeaterCommandEventArgs e)
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
                ListaProdutosCarrinho[index].Quantidade--;
        }

        private void AdicionarQuantidade(int index)
        {
            ListaProdutosCarrinho[index].Quantidade = ListaProdutosCarrinho[index].Quantidade + 1;
        }

        private void AtualizarCarrinho()
        {
            rptCarrinho.DataSource = ListaProdutosCarrinho;
            rptCarrinho.DataBind();
        }

    }
}