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
                // A sessão é nula, redireciona para loja_online
                Response.Redirect("loja_online.aspx");
            }

            if (ddl_id.Items.Count == 1)
            {
                btn_editar_produto.Enabled = false;
            }
            else
            {
                btn_editar_produto.Enabled = true;
            }
        }

        protected void btn_editar_produto_Click(object sender, EventArgs e)
        {
            float preco_revenda = float.Parse(txt_preco.Text) / 1.20f;
            decimal preco = decimal.Parse(txt_preco.Text);

            Stream imgstream = FileUpload1.PostedFile.InputStream;
            int tamanhoFicheiro = FileUpload1.PostedFile.ContentLength;
            string contentType = FileUpload1.PostedFile.ContentType;


            byte[] imgBinaryData = new byte[tamanhoFicheiro];
            imgstream.Read(imgBinaryData, 0, tamanhoFicheiro);

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "alterar_produto";



            mycomm.Connection = myconn;
            mycomm.Parameters.AddWithValue("id_produto", ddl_id.Text);
            mycomm.Parameters.AddWithValue("@produto", txt_produto.Text);
            mycomm.Parameters.AddWithValue("@designacao", txt_designacao.Text);
            mycomm.Parameters.AddWithValue("@descricao", txt_descricao.Text);
            mycomm.Parameters.AddWithValue("@preco", preco);
            mycomm.Parameters.AddWithValue("@revenda", preco_revenda);
            mycomm.Parameters.AddWithValue("@quantidade", txt_quantidade.Text);
            mycomm.Parameters.AddWithValue("@ct", contentType);
            mycomm.Parameters.AddWithValue("@foto", imgBinaryData);


            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Produto alterado com sucesso!!!";
            }
            else
            {
                lbl_mensagem.Text = "Produto não foi alterado!!!";
            }
        }
    

        protected void ddl_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_id.Items.Count == 1)
            {
               btn_editar_produto.Enabled = false;
            }
            else
            {
                btn_editar_produto.Enabled = true;
            }

            if (ddl_id.SelectedValue.ToString() == "-----")
            {
                txt_produto.Text = "";
                txt_descricao.Text = "";
                txt_designacao.Text = "";
                txt_preco.Text = "";
                txt_quantidade.Text = "";
                btn_editar_produto.Enabled = false;
            }
            else
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