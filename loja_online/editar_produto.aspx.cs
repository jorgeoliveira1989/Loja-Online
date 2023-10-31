using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loja_online
{
    public partial class editar_produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                // A sessão é nula, redireciona para index.aspx
                Response.Redirect("index.aspx");
            }
        }

        protected void btn_editar_produto_Click(object sender, EventArgs e)
        {

        }

        protected void ddl_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSelecionado = Convert.ToInt32(ddl_id.SelectedValue);

            // Obter dados da base de dados com a stored procedure
            Tuple<string, string, string, decimal, int> dados = ObterDadosPorID(idSelecionado);

            if (dados != null)
            {
                txt_produto.Text = dados.Item1;
                txt_designacao.Text = dados.Item2;
                txt_descricao.Text = dados.Item3;
                txt_preco.Text = dados.Item4.ToString();
                txt_quantidade.Text = dados.Item5.ToString();
            }

        }

        private Tuple<string, string, string, decimal, int> ObterDadosPorID(int id)
        {
            string produto = string.Empty;
            string designacao = string.Empty;
            string descricao = string.Empty;
            decimal preco = 0.0m;
            int quantidade = 0;

            SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);
            {
                using (SqlCommand command = new SqlCommand("ObterDadosPorID", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            produto = reader.GetString(0);
                            designacao = reader.GetString(1);
                            descricao = reader.GetString(2);
                            preco = reader.GetDecimal(3);
                            quantidade = reader.GetInt32(4);
                        }
                    }
                }
            }
            if (!string.IsNullOrEmpty(produto) && !string.IsNullOrEmpty(designacao) && !string.IsNullOrEmpty(descricao))
            {
                return Tuple.Create(produto, designacao, descricao, preco, quantidade);
            }
            else
            {
                return null;
            }
        }
    }
}