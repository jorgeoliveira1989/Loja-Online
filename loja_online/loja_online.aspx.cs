using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loja_online
{
    public partial class loja_online : System.Web.UI.Page
    {
        string query = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (ddl_opcoes.SelectedItem.ToString() == "Nome Produto")
            {
                query = "SELECT id_produto,produto, designacao, preco, foto, contenttype FROM produtos WHERE ativo = 'True' ORDER BY produto";
            }
            else if (ddl_opcoes.SelectedItem.ToString() == "Preço Ascendente")
            {
                query = "SELECT id_produto,produto, designacao, preco, foto, contenttype FROM produtos WHERE ativo = 'True' ORDER BY preco ASC";
            }
            else if (ddl_opcoes.SelectedItem.ToString() == "Preço Descendente")
            {
                query = "SELECT id_produto,produto, designacao, preco, foto, contenttype FROM produtos WHERE ativo = 'True' ORDER BY preco DESC";
            }
            else
            {
                query = "SELECT id_produto,produto, designacao, preco, foto, contenttype FROM produtos Where ativo = 'True'";
            }

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Produtos> lst_produtos = new List<Produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                Produtos produto = new Produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.designacao = reader.GetString(2);
                produto.preco = reader.GetDecimal(3);
                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produtos.Add(produto);
            }

            myconn.Close();
            rptProdutos.DataSource = lst_produtos;
            rptProdutos.DataBind();
        }

        protected void txt_pesquisar_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT id_produto,produto, designacao, preco, foto, contenttype FROM produtos WHERE produto LIKE '%" + txt_pesquisar.Text + "%' And ativo = 'True'";


            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Produtos> lst_produtos = new List<Produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                Produtos produto = new Produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.designacao = reader.GetString(2);
                produto.preco = reader.GetDecimal(3);
                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produtos.Add(produto);
            }

            myconn.Close();
            rptProdutos.DataSource = lst_produtos;
            rptProdutos.DataBind();
        }

        protected void Lb_menos100_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_produto,produto, designacao, preco, foto, contenttype FROM produtos WHERE preco < 100 AND ativo = 'True'";


            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Produtos> lst_produtos = new List<Produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                Produtos produto = new Produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.designacao = reader.GetString(2);
                produto.preco = reader.GetDecimal(3);
                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produtos.Add(produto);
            }

            myconn.Close();
            rptProdutos.DataSource = lst_produtos;
            rptProdutos.DataBind();
        }

        protected void lb_entre100e300_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_produto,produto, designacao, preco, foto, contenttype FROM produtos WHERE preco >= 100 AND preco <= 300 AND ativo = 'True'";


            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Produtos> lst_produtos = new List<Produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                Produtos produto = new Produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.designacao = reader.GetString(2);
                produto.preco = reader.GetDecimal(3);
                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produtos.Add(produto);
            }

            myconn.Close();
            rptProdutos.DataSource = lst_produtos;
            rptProdutos.DataBind();
        }

        protected void lb_mais300_Click(object sender, EventArgs e)
        {
            string query = "SELECT id_produto,produto, designacao, preco, foto, contenttype FROM produtos WHERE preco > 300 AND ativo = 'True'";


            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand(query, myconn);

            List<Produtos> lst_produtos = new List<Produtos>();

            myconn.Open();

            var reader = mycomm.ExecuteReader();

            while (reader.Read())
            {
                Produtos produto = new Produtos();

                produto.id_produto = reader.GetInt32(0);
                produto.produto = reader.GetString(1);
                produto.designacao = reader.GetString(2);
                produto.preco = reader.GetDecimal(3);
                byte[] imagemBytes = (byte[])reader["foto"];
                string contentType = reader.GetString(reader.GetOrdinal("ContentType"));

                // Convertendo os bytes da imagem em uma string base64
                string imagemBase64 = Convert.ToBase64String(imagemBytes);
                string imagemSrc = $"data:{contentType};base64,{imagemBase64}";

                produto.imagemSrc = imagemSrc;


                lst_produtos.Add(produto);
            }

            myconn.Close();
            rptProdutos.DataSource = lst_produtos;
            rptProdutos.DataBind();
        }

        protected void btnAdicionar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string[] argumentos = btn.CommandArgument.ToString().Split('|');

            int produtoID = Convert.ToInt32(argumentos[0]);
            string nomeProduto = argumentos[1];
            decimal preco = Convert.ToDecimal(argumentos[2]);
            string imagemSrc = argumentos[3];

            // Obtém o valor acumulado da sessão (ou 0 se for a primeira vez)
            decimal valorAcumulado = (Session["ValorAcumulado"] != null) ? (decimal)Session["ValorAcumulado"] : 0;

            // Soma o novo preço ao valor acumulado
            valorAcumulado = valorAcumulado + preco;

            // Atualiza o valor na label
            lbl_valor.Text = valorAcumulado.ToString("C");

            // Atualiza o valor acumulado na sessão
            Session["ValorAcumulado"] = valorAcumulado;

           string produtoid = Convert.ToString(btn.CommandArgument);
            
            Produtos item = new Produtos
            {
                imagemSrc=imagemSrc,
                id_produto = produtoID,
                produto = nomeProduto,
                preco = preco, // Usando o preço do botão
                Quantidade = 1 // Quantidade inicial
            };

            List<Produtos> carrinho;

            if (Session["Carrinho"] == null)
            {
                carrinho = new List<Produtos>();
            }
            else
            {
                carrinho = (List<Produtos>)Session["Carrinho"];
            }

            carrinho.Add(item);

            Session["Carrinho"] = carrinho;

        }
    }
}