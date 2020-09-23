using Firebird4._5._2.DAO;
using Firebird4._5._2.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Firebird4._5._2.Cadastro
{
    public class CadastrarProduto
    {
        public void CadastroProduto()
        {
            Produto p = new Produto();

            Console.WriteLine("Digite o nome do produto: ");
            p.Nome = Console.ReadLine();
            if (string.IsNullOrEmpty(p.Nome))
            {
                Console.WriteLine("O nome do produto nao pode ser nulo");
                p = null;
                Console.ReadKey();
                Console.Clear();
                CadastroProduto();
            }
            Console.WriteLine("Digite a quantidade: ");
            string qtdStr = Console.ReadLine();

            while (!int.TryParse(qtdStr, out int qtd))
            {
                Console.WriteLine("Insira apenas números inteiros");
                p = null;
                Console.ReadKey();
                Console.Clear();
                CadastroProduto();
            }
            p.Quantidade = Convert.ToInt32(qtdStr);

            Console.WriteLine("Digite o nome da embalagem: ");
            p.Embalagem = Console.ReadLine();
            Console.WriteLine("Digite o preço: ");
            string precoStr = Console.ReadLine();
            while (!decimal.TryParse(precoStr, out decimal preco))
            {
                Console.WriteLine("Insira apenas numeros decimais");
                p = null;
                Console.ReadKey();
                Console.Clear();
                CadastroProduto();
            }
            p.Preco = Convert.ToDecimal(precoStr);

            DAOProduto daoProduto = new DAOProduto();
            daoProduto.CadastrarProdutoDAO(p);
        }
        public void ListarProduto()
        {
            Console.WriteLine("Digite o codigo do produto ou zero para todos: ");
            string codProdStr = Console.ReadLine();

            while(!int.TryParse(codProdStr, out int codProd))
            {
                Console.WriteLine("Insira apenas numeros inteiros");
                Console.ReadKey();
                Console.Clear();
                ListarProduto();
            }


            if (string.IsNullOrEmpty(codProdStr))
            {
                Console.WriteLine("O valor não pode ser nulo");
                Console.ReadKey();
                Console.Clear();
                ListarProduto();

            }

            DAOProduto dAOProduto = new DAOProduto();
            dAOProduto.ListarProdutoDAO(Convert.ToInt32(codProdStr));
        }
        public void AtualizarProduto()
        {
            Produto p = new Produto();

            Console.WriteLine("Digite o codigo do produto");
            var codProdStr = Console.ReadLine();
            
            while(!int.TryParse(codProdStr, out int codProd))
            {
                Console.WriteLine("Insira apenas numeros inteiros");
                p = null;
                Console.ReadKey();
                Console.Clear();
                AtualizarProduto();
            }

            Console.WriteLine("Digite o nome do produto: ");
            p.Nome = Console.ReadLine();
            if (string.IsNullOrEmpty(p.Nome))
            {
                Console.WriteLine("O nome do produto nao pode ser nulo");
                p = null;
                Console.ReadKey();
                Console.Clear();
                AtualizarProduto();
            }
            Console.WriteLine("Digite a quantidade: ");
            string qtdStr = Console.ReadLine();

            while (!int.TryParse(qtdStr, out int qtd))
            {
                Console.WriteLine("Insira apenas números inteiros");
                p = null;
                Console.ReadKey();
                Console.Clear();
                AtualizarProduto();
            }
            p.Quantidade = Convert.ToInt32(qtdStr);

            Console.WriteLine("Digite o nome da embalagem: ");
            p.Embalagem = Console.ReadLine();

            Console.WriteLine("Digite o preço: ");
            string precoStr = Console.ReadLine();
            while (!decimal.TryParse(precoStr, out decimal preco))
            {
                Console.WriteLine("Insira apenas numeros decimais");
                p = null;
                Console.ReadKey();
                Console.Clear();
                AtualizarProduto();
            }
            p.Preco = Convert.ToDecimal(precoStr);

            DAOProduto daoProduto = new DAOProduto();
            daoProduto.AtualizarProdutoDAO(p);
        }
    }
}