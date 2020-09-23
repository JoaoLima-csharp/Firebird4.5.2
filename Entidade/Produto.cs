using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebird4._5._2.Entidade
{
    public class Produto
    {
        public int Codprod { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public string Embalagem { get; set; }
        public decimal Preco { get; set; }
    }
}
