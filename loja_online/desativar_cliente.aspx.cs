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
    public partial class desativar_cliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"] == null)
            {
                // A sessão é nula, redireciona para index.aspx
                Response.Redirect("index.aspx");
            }
        }

        protected void ddl_id_SelectedIndexChanged(object sender, EventArgs e)
        {
            int idSelecionado = Convert.ToInt32(ddl_id.SelectedValue);

            // Chamar a stored procedure para obter o nome
            string cliente = ObterNomePorID(idSelecionado); // Método para chamar a stored procedure

            // Preencher a TextBox com o nome
            lbl_cliente.Text = cliente;
        }

        private string ObterNomePorID(int id)
        {
            string cliente = string.Empty;

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            {
                using (SqlCommand command = new SqlCommand("ObterDadosCliente", myconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    myconn.Open();
                    cliente = (string)command.ExecuteScalar();
                }
            }

            return cliente;
        }

        protected void btn_desativar_cliente_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "desativar_cliente";

            mycomm.Connection = myconn;

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);
            mycomm.Parameters.AddWithValue("id_cliente", ddl_id.Text);
            mycomm.Parameters.AddWithValue("@nome", lbl_cliente.Text);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Cliente desativado com sucesso!!!";
            }
            else
            {
                lbl_mensagem.Text = "Cliente não foi desativado!!!";
            }
        }
    }
}