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

    }
}