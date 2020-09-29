using FirebirdSql.Data.FirebirdClient;
using FirebirdSql.Data.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Firebird4._5._2.DAO
{
    public class CreateDbDAO
    {
        public void CreateDBDAO()
        {
            if (File.Exists(@"c:\firebird.fdb"))
            {
                Console.WriteLine("Banco de dados já existe");
            }
            else
            {
                try
                {
                    var connectionStr = "database=localhost:c:\\firebird.fdb;user=SYSDBA;password=masterke";
                    FbConnection.CreateDatabase(connectionStr, pageSize: 16384, forcedWrites: true, overwrite: false);

                    using (var connection = new FbConnection("database=localhost:c:\\firebird.fdb;user=SYSDBA;password=masterke"))
                    {
                        connection.Open();
                        using (var transaction = connection.BeginTransaction())
                        {
                            using (var command = new FbCommand("CREATE TABLE CLIENTE (" +
                                                                "CODCLI    INTEGER NOT NULL," +
                                                                "NOME      VARCHAR(30) NOT NULL," +
                                                                "CNPJ      VARCHAR(15) NOT NULL," +
                                                                "TELEFONE  VARCHAR(15) NOT NULL," +
                                                                "ENDERECO  VARCHAR(100) NOT NULL);",
                                                            connection, transaction))
                            {
                                command.ExecuteNonQuery();
                                var command2 = new FbCommand("ALTER TABLE CLIENTE ADD CONSTRAINT PK_CLIENTE PRIMARY KEY (CODCLI);",
                                                            connection, transaction);
                                command2.ExecuteNonQuery();

                                var command3 = new FbCommand("CREATE TABLE PRODUTO (" +
                                                              "CODPROD     INTEGER NOT NULL," +
                                                              "NOME        VARCHAR(50) NOT NULL," +
                                                              "QUANTIDADE  INTEGER NOT NULL," +
                                                              "EMBALAGEM   VARCHAR(30)," +
                                                              "PRECO       FLOAT NOT NULL);",
                                                            connection, transaction);
                                command3.ExecuteNonQuery();
                                var command4 = new FbCommand("ALTER TABLE PRODUTO ADD CONSTRAINT PK_PRODUTO PRIMARY KEY (CODPROD);",
                                                            connection, transaction);
                                command4.ExecuteNonQuery();

                                var command5 = new FbCommand("CREATE SEQUENCE GEN_CLIENTE_ID;",
                                                            connection, transaction);
                                command5.ExecuteNonQuery();

                                var command6 = new FbCommand("CREATE SEQUENCE GEN_PRODUTO_ID;",
                                                            connection, transaction);
                                command6.ExecuteNonQuery();

                                try
                                {
                                    transaction.Commit();
                                    Console.WriteLine($"Banco de dados criado");
                                    Console.ReadKey();
                                    Console.Clear();
                                }
                                catch (Exception e)
                                {
                                    transaction.Rollback();
                                    Console.WriteLine($"Banco de dados já existe");
                                    Console.WriteLine(e.Message);
                                    Console.ReadKey();
                                    Console.Clear(); ;
                                    throw;
                                }
                                finally
                                {
                                    command.Dispose();
                                    command2.Dispose();
                                    command3.Dispose();
                                    command4.Dispose();
                                    command5.Dispose();
                                    command6.Dispose();
                                    connection.Close();
                                }

                            }
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Console.ReadKey();
                }
            }
        }
    }
}
