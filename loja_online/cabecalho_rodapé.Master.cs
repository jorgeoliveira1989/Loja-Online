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
    public partial class cabecalho_rodapé : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lb_valor_Click(object sender, EventArgs e)
        {
            Response.Redirect("carrinho.aspx");
        }

        protected void txt_pesquisar_TextChanged(object sender, EventArgs e)
        {
            string query = "SELECT id_produto,produto, designacao, preco, foto, contenttype FROM produtos WHERE produto LIKE '%" + txt_pesquisar.Text+"%'";


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
        }
    }
}