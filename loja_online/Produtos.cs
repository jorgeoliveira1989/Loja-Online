using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace loja_online
{
    public class Produtos
    {
        public int id_produto { get; set; }
        public string produto { get; set; }
        public string designacao { get; set; }
        public decimal preco { get; set; }
        public byte[] foto { get; set; }
        public string Contenttype { get; set; }
        public string imagemSrc { get; set; }
    }
}