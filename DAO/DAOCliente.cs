using Firebird4._5._2.Entidade;
using Firebird4._5._2.Menu;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Firebird4._5._2.DAO
{
    public class DAOCliente
    {
        MenuInicial menu = new MenuInicial();
        public void CadastrarClienteDAO(Cliente c)
        {
            using (var connection = new FbConnection("database=localhost:c:\\repos\\Firebird\\DATABASE.FDB;user=SYSDBA;password=masterke"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = new FbCommand("insert into cliente (codcli, nome, cnpj, telefone, endereco) " +
                                                            $"values (GEN_ID(GEN_CLIENTE_ID, 1), '{c.Nome}', '{c.Cnpj}',  '{c.Telefone}', '{c.Endereco}')",
                                                            connection, transaction))
                    {

                        command.ExecuteNonQuery();

                        try
                        {
                            transaction.Commit();
                            Console.WriteLine($"O cliente {c.Nome} foi cadastrado");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"O cliente {c.Nome} não foi cadastrado");
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
        public void ListarClienteDAO(int codCli)
        {
            using (var connection = new FbConnection("database=localhost:c:\\repos\\Firebird\\DATABASE.FDB;user=SYSDBA;password=masterke"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    var codProdStr = Convert.ToString(codCli);
                    if (int.TryParse(codProdStr, out codCli) == true)
                    {


                        if (codCli == 0)
                        {
                            using (var command = new FbCommand("select * from cliente", connection, transaction))
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
                            using (var command = new FbCommand($"select * from cliente where codcli = {codCli}", connection, transaction))
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
        public void AtualizarClienteDAO(Cliente c)
        {
            using (var connection = new FbConnection("database=localhost:c:\\repos\\Firebird\\DATABASE.FDB;user=SYSDBA;password=masterke"))
            {
                connection.Open();
                using (var transaction = connection.BeginTransaction())
                {
                    using (var command = new FbCommand($"update cliente set nome = '{c.Nome}', cnpj = '{c.Cnpj}', telefone = '{c.Telefone}', endereco = '{c.Endereco}' where codcli = {c.Id}",
                                                        connection, transaction))
                    {

                        command.ExecuteNonQuery();

                        try
                        {
                            transaction.Commit();
                            Console.WriteLine($"O cliente {c.Nome} foi atualizado");
                            Console.ReadKey();
                            Console.Clear();
                        }
                        catch (Exception e)
                        {
                            transaction.Rollback();
                            Console.WriteLine($"O cliente {c.Nome} não foi atualizado");
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
