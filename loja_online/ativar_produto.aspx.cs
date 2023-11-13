using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace loja_online
{
    public partial class ativar_produto : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                // A sessão é nula, redireciona para loja_online.aspx
                Response.Redirect("loja_online.aspx");
            }

            if (ddl_id.Items.Count == 1)
            {
                btn_ativar_produto.Enabled = false;
            }
            else
            {
                btn_ativar_produto.Enabled = true;
            }
        }

        protected void ddl_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_id.Items.Count == 1)
            {
                btn_ativar_produto.Enabled = false;
            }
            else
            {
                btn_ativar_produto.Enabled = true;
            }

            if (ddl_id.SelectedValue.ToString() == "-----")
            {
                lbl_produto.Text = "";
                btn_ativar_produto.Enabled = false;
            }
            else
            {

                int idSelecionado = Convert.ToInt32(ddl_id.SelectedValue);

                // Chamar a stored procedure para obter o nome
                string produto = ObterNomePorID(idSelecionado); // Método para chamar a stored procedure

                // Preencher a TextBox com o nome
                lbl_produto.Text = produto;
            }
        }
        private string ObterNomePorID(int id)
        {
            string produto = string.Empty;

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            {
                using (SqlCommand command = new SqlCommand("ObterDadosPorID", myconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    myconn.Open();
                    produto = (string)command.ExecuteScalar();
                }
            }

            return produto;
        }

        protected void btn_ativar_produto_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "ativar_produto";

            mycomm.Connection = myconn;

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);
            mycomm.Parameters.AddWithValue("id_produto", ddl_id.Text);
            mycomm.Parameters.AddWithValue("@produto", lbl_produto.Text);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Produto ativado com sucesso!!!";
            }
            else
            {
                lbl_mensagem.Text = "Produto não foi ativado!!!";
            }
        }
    }
}