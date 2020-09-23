using Firebird4._5._2.DAO;
using Firebird4._5._2.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebird4._5._2.Cadastro
{
    public class CadastrarCliente
    {
        public void CadastroCliente()
        {
            Cliente c = new Cliente();

            Console.WriteLine("Digite o nome do cliente: ");
            c.Nome = Console.ReadLine();
            if (string.IsNullOrEmpty(c.Nome))
            {
                Console.WriteLine("O nome do cliente nao pode ser nulo");
                c = null;
                Console.ReadKey();
                Console.Clear();
                CadastroCliente();
            }
            Console.WriteLine("Digite o cnpj: ");
            c.Cnpj = Console.ReadLine();
            if (string.IsNullOrEmpty(c.Cnpj))
            {
                Console.WriteLine("O cnpj não pode ser nulo");
                c = null;
                Console.ReadKey();
                Console.Clear();
                CadastroCliente();
            }
            Console.WriteLine("Digite o telefone: ");
            c.Telefone = Console.ReadLine();
            if (string.IsNullOrEmpty(c.Telefone))
            {
                Console.WriteLine("O telefone não pode ser nulo");
                c = null;
                Console.ReadKey();
                Console.Clear();
                CadastroCliente();
            }
            Console.WriteLine("Digite o endereco: ");
            c.Endereco = Console.ReadLine();
            if (string.IsNullOrEmpty(c.Endereco))
            {
                Console.WriteLine("O endereco do cliente nao pode ser nulo");
                c = null;
                Console.ReadKey();
                Console.Clear();
                CadastroCliente();
            }

            DAOCliente dAOCliente = new DAOCliente();
            dAOCliente.CadastrarClienteDAO(c);
        }
        public void ListarCliente()
        {
            Console.WriteLine("Digite o codigo do cliente ou zero para todos: ");
            var codCli = Convert.ToString(Console.ReadLine());

            if (string.IsNullOrEmpty(codCli))
            {
                Console.WriteLine("O valor não pode ser nulo");
                Console.ReadKey();
                Console.Clear();
                ListarCliente();

            }
            DAOCliente dAOCliente = new DAOCliente();
            dAOCliente.ListarClienteDAO(Convert.ToInt32(codCli));
        }
        public void AtualizarCliente()
        {
            Cliente c = new Cliente();

            Console.WriteLine("Digite o codigo do cliente");
            var idStr = Console.ReadLine();


            while (!int.TryParse(idStr, out int id))
            {
                Console.WriteLine("Insira apenas numeros inteiros");
                Console.ReadKey();
                Console.Clear();
                AtualizarCliente();
            }

            c.Id = Convert.ToInt32(idStr);
            if(c.Id == 0)
            {
                Console.WriteLine("O codigo nao pode ser zero");
                Console.ReadKey();
                c = null;
                Console.Clear();
                AtualizarCliente();
            }


            Console.WriteLine("Digite o nome do cliente: ");
            c.Nome = Console.ReadLine();
            if (string.IsNullOrEmpty(c.Nome))
            {
                Console.WriteLine("O nome do cliente nao pode ser nulo");
                c = null;
                Console.ReadKey();
                Console.Clear();
                AtualizarCliente();
            }
            Console.WriteLine("Digite o cnpj: ");
            c.Cnpj = Console.ReadLine();
            if (string.IsNullOrEmpty(c.Cnpj))
            {
                Console.WriteLine("O cnpj não pode ser nulo");
                c = null;
                Console.ReadKey();
                Console.Clear();
                AtualizarCliente();
            }

            Console.WriteLine("Digite o telefone: ");
            c.Telefone = Console.ReadLine();
            if (string.IsNullOrEmpty(c.Telefone))
            {
                Console.WriteLine("O telefone nao pode ser nulo");
                c = null;
                Console.ReadKey();
                Console.Clear();
                AtualizarCliente();
            }
            Console.WriteLine("Digite o endereco: ");
            c.Endereco = Console.ReadLine();
            if (string.IsNullOrEmpty(c.Endereco))
            {
                Console.WriteLine("O endereco do cliente nao pode ser nulo");
                c = null;
                Console.ReadKey();
                Console.Clear();
                AtualizarCliente();
            }


            DAOCliente dAOCliente = new DAOCliente();
            dAOCliente.AtualizarClienteDAO(c);
        }
    }
}
