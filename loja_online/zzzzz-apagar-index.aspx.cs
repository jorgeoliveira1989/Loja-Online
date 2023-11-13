using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;

namespace loja_online
{
    public partial class index1 : System.Web.UI.Page
    {
        string query="";
        protected void Page_Load(object sender, EventArgs e)
        {
            if(ddl_opcoes.SelectedItem.ToString() == "Nome Produto")
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
    }
}