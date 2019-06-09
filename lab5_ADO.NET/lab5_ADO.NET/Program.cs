using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace lab5_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            string connect = "Server=127.0.0.1;Port=5432;Database=test;User Id=postgres;Password = 7654321dpostgresql;";
            NpgsqlConnection connection = new NpgsqlConnection(connect);
            connection.Open();
            string sql = "select* from InfoChemicals";
            string sql2 = "select* from ContractChemicals";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            DataTable dataTable2 = new DataTable();
            
            adapter.Fill(dataSet, "InfoChemicals");
            dataTable = dataSet.Tables["InfoChemicals"];
            Console.WriteLine("Таблица InfoChemicals");
            Console.WriteLine(new string('-', 100));
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.WriteLine("{0} {1} {2} {3} {4} {5} {6}",dataRow["NameChemicals"].ToString(),
                    dataRow["TypeChemical"].ToString(), dataRow["opportunities"].ToString(), dataRow["ChemicalComposition"].ToString(),
                    dataRow["ManufacturingCompany"].ToString(),dataRow["CountChemicals"].ToString(),dataRow["price"].ToString());
            }
            Console.WriteLine(new string('-', 100));
            NpgsqlDataAdapter adapter2 = new NpgsqlDataAdapter(sql2, connection);
            adapter2.Fill(dataSet, "ContractChemicals");
            dataTable2 = dataSet.Tables["ContractChemicals"];
            Console.WriteLine("\nТаблица ContractChemicals");
            Console.WriteLine(new string('-', 100));
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                Console.WriteLine("{0} {1} {2}", dataRow["NumberContract"].ToString(),dataRow["Enterprise"].ToString(),dataRow["CountProcured"].ToString());
            }
            Console.WriteLine(new string('-', 100));
        }
    }
}/*create table InfoChemicals(

	NameChemicals varchar(50) not null,
	TypeChemical varchar(50) not null,
	opportunities varchar(50) not null,
	ChemicalComposition varchar(50) not null,
	ManufacturingCompany varchar(50) not null,
	CountChemicals int,
	price int
)
insert into InfoChemicals values('Amiak','Poison','123','lfkf','jdkfjd',10,20);
insert into InfoChemicals values('Poison','Poison','123','lfkf','jdkfjd',10,20);
select* from InfoChemicals;*/
