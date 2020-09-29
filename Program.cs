
using Firebird4._5._2.Cadastro;
using Firebird4._5._2.DAO;
using Firebird4._5._2.Menu;
using FirebirdSql.Data.FirebirdClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Firebird
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                MenuInicial menu = new MenuInicial();
                CreateDbDAO createDb = new CreateDbDAO();
                createDb.CreateDBDAO();
                menu.Menu();
                Console.Clear();
            }
        }
    }
}
