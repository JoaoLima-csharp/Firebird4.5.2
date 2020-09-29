using Firebird;
using Firebird4._5._2.Entidade;
using Firebird4._5._2.Menu;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;

namespace Firebird4._5._2.DAO
{
    public class DAOProduto
    {
        MenuInicial menu = new MenuInicial();
        public void CadastrarProdutoDAO(Produto p)
        {
            using (var connection = new FbConnection("database=localhost:c:\\firebird.fdb;user=SYSDBA;password=masterke"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = new FbCommand("insert into produto (codprod, nome, quantidade, embalagem, preco) " +
                                                        $"values (GEN_ID(GEN_PRODUTO_ID, 1), '{p.Nome}', '{p.Quantidade}',  '{p.Embalagem}', '{p.Preco}')",
                                                        connection, transaction))
                    {

                        command.ExecuteNonQuery();

                        try
                        {
                            transaction.Commit();
                            Console.WriteLine($"O produto {p.Nome} foi cadastrado");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"O produto {p.Nome} não foi cadastrado");
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                            Console.Clear(); ;
                            throw;
                        }
                        finally
                        {
                            command.Dispose();
                            connection.Close();
                        }

                    }
                }

            }
            menu.Menu();
        }
        public void ListarProdutoDAO(int codProd)
        {
            using (var connection = new FbConnection("database=localhost:c:\\firebird.fdb;user=SYSDBA;password=masterke"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var codProdStr = Convert.ToString(codProd);
                    if (int.TryParse(codProdStr, out codProd) == true)
                    {


                        if (codProd == 0)
                        {
                            using (var command = new FbCommand("select * from produto", connection, transaction))
                            {
                                using (var reader = command.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        var values = new object[reader.FieldCount];
                                        reader.GetValues(values);
                                        Console.WriteLine(String.Join(" || ", values));
                                    }
                                }
                            }
                            Console.ReadKey();
                            Console.Clear();
                        }
                        else
                        {
                            using (var command = new FbCommand($"select * from produto where codprod = {codProd}", connection, transaction))
                            {
                                using (var reader = command.ExecuteReader())
                                {
                                    var values = new object[0];
                                    while (reader.Read())
                                    {
                                        values = new object[reader.FieldCount];
                                        reader.GetValues(values);
                                        Console.WriteLine(String.Join(" || ", values));
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                    if (values.Count() == 0)
                                    {
                                        Console.WriteLine("Nao existe produto com o codigo digitado");
                                        Console.ReadKey();
                                        Console.Clear();
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Codigo invalido");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }
            }
            menu.Menu();
        }

        public void AtualizarProdutoDAO(Produto p)
        {
            using (var connection = new FbConnection("database=localhost:c:\\firebird.fdb;user=SYSDBA;password=masterke"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = new FbCommand($"update produto set nome = '{p.Nome}', quantidade = {p.Quantidade}, embalagem = '{p.Embalagem}', preco = {p.Preco} where codprod = {p.Codprod}",
                                                        connection, transaction))
                    {

                        command.ExecuteNonQuery();

                        try
                        {
                            transaction.Commit();
                            Console.WriteLine($"O produto {p.Nome} foi atualizado");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"O produto {p.Nome} não foi atualizado");
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                            Console.Clear(); ;
                            throw;
                        }
                        finally
                        {
                            command.Dispose();
                            connection.Close();
                            menu.Menu();
                        }

                    }
                }

            }
        }
    }
}
