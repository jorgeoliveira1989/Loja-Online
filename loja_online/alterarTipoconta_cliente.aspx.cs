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
    public partial class alterarTipoconta_cliente : System.Web.UI.Page
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
            string tipoConta = ObterNomePorID(idSelecionado); // Método para chamar a stored procedure

            // Preencher a TextBox com o nome
            lbl_tipoConta.Text = tipoConta;

            if(lbl_tipoConta.Text == "Cliente")
            {
                lbl_altera_conta.Text = "Revendedor";
            }
            else
            {
                lbl_altera_conta.Text = "Cliente";
            }
        }

        private string ObterNomePorID(int id)
        {
            string tipoconta = string.Empty;

            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);
            {
                using (SqlCommand command = new SqlCommand("dadosTipoConta", myconn))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@ID", id);

                    myconn.Open();
                    tipoconta = (string)command.ExecuteScalar();
                }
            }

            return tipoconta;
        }

        protected void btn_alterar_tipo_conta_Click(object sender, EventArgs e)
        {
            SqlConnection myconn = new SqlConnection(ConfigurationManager.ConnectionStrings["lojaOnline_aulaTesteConnectionString"].ConnectionString);

            SqlCommand mycomm = new SqlCommand();
            mycomm.CommandType = CommandType.StoredProcedure;
            mycomm.CommandText = "alterar_tipo_conta";

            mycomm.Connection = myconn;

            SqlParameter valor = new SqlParameter();
            valor.ParameterName = "@retorno";
            valor.Direction = ParameterDirection.Output;
            valor.SqlDbType = SqlDbType.Int;

            mycomm.Parameters.Add(valor);
            mycomm.Parameters.AddWithValue("@id_cliente", ddl_id.Text);
            mycomm.Parameters.AddWithValue("@tipo_cliente", lbl_altera_conta.Text);

            myconn.Open();
            mycomm.ExecuteNonQuery();

            int resposta = Convert.ToInt32(mycomm.Parameters["@retorno"].Value);
            myconn.Close();
            if (resposta == 1)
            {
                lbl_mensagem.Text = "Tipo de cliente alterado!!!";
            }
            else
            {
                lbl_mensagem.Text = "Tipo de Cliente não foi alterado!!!";
            }
        }
    }
}