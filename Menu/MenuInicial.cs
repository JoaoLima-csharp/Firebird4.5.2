using Firebird4._5._2.Cadastro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Firebird4._5._2.Menu
{
    public class MenuInicial
    {
        public void Menu()
        {
            Console.WriteLine("Digite 1 para cliente \r\n" +
                              "Digite 2 para produto: ");

            var opcaoMenu2 = Console.ReadLine();


            IsDigitsOnly(opcaoMenu2);

            void IsDigitsOnly(string str)
            {
                foreach (char c in str)
                {
                    if (c <= '0' || c >= '3')
                    {
                        Console.WriteLine("Digite uma das opcoes do menu");
                        Console.ReadKey();
                        Console.Clear();
                        Menu();
                    }
                    else
                    {
                        Menu2(opcaoMenu2);
                    }
                }
            }
        }
        public void Menu2(string opcaoMenu2)
        {
            var caseSwitch = Convert.ToInt16(opcaoMenu2);


            switch (caseSwitch)
            {
                case 1:
                    CadastrarCliente cadastrarCliente = new CadastrarCliente();
                    Console.Clear();
                    Console.WriteLine("1 para cadastrar cliente \r\n" +
                                      "2 para listar cliente \r\n" +
                                      "3 para atualizar cliente");

                    var opcaoMenuCliente = Console.ReadLine();

                    IsDigitsOnlyCliente(opcaoMenuCliente);

                    void IsDigitsOnlyCliente(string str)
                    {
                        foreach (char c in str)
                        {
                            if (c <= '0' || c >= '4' || c == null)
                            {
                                Console.WriteLine("Digite uma das opcoes do menu");
                                Console.ReadKey();
                                Console.Clear();
                                Menu2(opcaoMenu2);
                            }
                            else
                            {
                                var opcaoSwitch = Convert.ToInt16(str);
                                switch (opcaoSwitch)
                                {
                                    case 1:
                                        cadastrarCliente.CadastroCliente();
                                        Console.Clear();
                                        Menu2(opcaoMenu2);
                                        break;
                                    case 2:
                                        cadastrarCliente.ListarCliente();
                                        Console.Clear();
                                        Menu2(opcaoMenu2);
                                        break;
                                    case 3:
                                        cadastrarCliente.AtualizarCliente();
                                        Console.Clear();
                                        Menu2(opcaoMenu2);
                                        break;
                                    default:
                                        Console.WriteLine("Digite uma das opcoes");
                                        break;
                                }
                            }
                        }
                    }
                    break;

                case 2:
                    CadastrarProduto cadastrarProduto = new CadastrarProduto();
                    Console.Clear();
                    Console.WriteLine("1 para cadastrar produto \r\n" +
                                      "2 para listar produto \r\n" +
                                      "3 para atualizar produto");

                    var opcaoMenuProduto = Console.ReadLine();

                    IsDigitsOnlyProduto(opcaoMenuProduto);

                    void IsDigitsOnlyProduto(string str)
                    {
                        foreach (char c in str)
                        {
                            if (c <= '0' || c >= '4' || c == null)
                            {
                                Console.WriteLine("Digite uma das opcoes do menu");
                                Console.ReadKey();
                                Console.Clear();
                                Menu2(opcaoMenu2);
                            }
                            else
                            {
                                var opcaoSwitch = Convert.ToInt16(str);
                                switch (opcaoSwitch)
                                {
                                    case 1:
                                        cadastrarProduto.CadastroProduto();
                                        Console.Clear();
                                        Menu2(opcaoMenu2);
                                        break;
                                    case 2:
                                        cadastrarProduto.ListarProduto();
                                        Console.Clear();
                                        Menu2(opcaoMenu2);
                                        break;
                                    case 3:
                                        cadastrarProduto.AtualizarProduto();
                                        Console.Clear();
                                        Menu2(opcaoMenu2);
                                        break;
                                    default:
                                        Console.WriteLine("Digite uma das opcoes");
                                        break;
                                }
                            }
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Digite uma das opcoes");
                    Menu2(opcaoMenu2);
                    break;
            }
        }
    }
}
