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
            if (Session["cargo"] != null && Session["username"] !=null )
            {
                string username = (string)Session["username"];
                lb_minhaConta.Visible = false;
                lbl_nome.Visible = true;
                lbl_nome.Text = "Bem-vindo/a, " + username;
            }

            string cargo = (string)Session["cargo"];
        }

        protected void lb_valor_Click(object sender, EventArgs e)
        {
            Response.Redirect("carrinho.aspx");
        }

        protected void lb_minhaConta_Click(object sender, EventArgs e)
        {
            Response.Redirect("login.aspx");
        }

        protected void lbl_nome_Click(object sender, EventArgs e)
        {
            Response.Redirect("conta.aspx");
        }

        protected void btn_procurar_Click(object sender, EventArgs e)
        {
            Response.Redirect("loja_online.aspx");
        }

        protected void txt_pesquisar_TextChanged(object sender, EventArgs e)
        {
            Response.Redirect("loja_online.aspx");
        }

        protected void Lb_menos100_Click(object sender, EventArgs e)
        {
            Response.Redirect("loja_online.aspx");
        }
        protected void lb_entre100e300_Click(object sender, EventArgs e)
        {
            Response.Redirect("loja_online.aspx");
        }
        protected void lb_mais300_Click(object sender, EventArgs e)
        {
            Response.Redirect("loja_online.aspx");
        }
    }
}