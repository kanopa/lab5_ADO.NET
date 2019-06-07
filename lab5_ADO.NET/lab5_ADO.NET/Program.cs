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
            string connect = "Server=127.0.0.1;Port=5432;Database=test;User Id=postgres;Password = 7654321d;";
            NpgsqlConnection connection = new NpgsqlConnection(connect);
            connection.Open();
            string sql = "select* from InfoChemicals";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);
            DataSet dataSet = new DataSet();
            DataTable dt = new DataTable();
            
            adapter.Fill(dataSet, "InfoChemicals");
            dt = dataSet.Tables["InfoChemicals"];
            foreach (DataRow dataRow in dt.Rows)
            {
                Console.WriteLine("{0} {1}",dataRow["NameChemicals"].ToString(),
                    dataRow["TypeChemical"].ToString());
            }

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
