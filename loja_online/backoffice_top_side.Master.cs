using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Media.Animation;

namespace loja_online
{
    public partial class backoffice_top_side : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lbl_user.Text = (string)Session["username"];
        }

        protected void btn_sair_Click(object sender, EventArgs e)
        {
            
            Session.Clear();
            Session.Abandon();
            Response.Redirect("loja_online.aspx");
        }
        protected void Timer1_Tick(object sender, EventArgs e)
        {
            // Atualizar o conteúdo do relógio a cada tick do Timer
            clock.InnerText = DateTime.Now.ToString("HH:mm:ss");
        }
    }
}