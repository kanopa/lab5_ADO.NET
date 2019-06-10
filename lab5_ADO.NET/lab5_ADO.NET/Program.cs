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
            string sql2 = "select* from InfoManufacturing";
            string sql3 = "select* from ContractChemicals";
            string sql4 = "select* from PurchaseChemicals";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);
            DataSet dataSet = new DataSet();
            DataTable dataTable = new DataTable();
            DataTable dataTable2 = new DataTable();
            DataTable dataTable3 = new DataTable();
            DataTable dataTable4 = new DataTable();

            adapter.Fill(dataSet, "InfoChemicals");
            dataTable = dataSet.Tables["InfoChemicals"];
            Console.WriteLine("Таблица InfoChemicals");
            Console.WriteLine(new string('-', 100));
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.WriteLine("{0} \t{1}\t{2}\t{3}\t{4}    \t{5} ", dataRow["NameChemicals"].ToString(),
                    dataRow["TypeChemical"].ToString(), dataRow["opportunities"].ToString(), dataRow["ChemicalComposition"].ToString(),
                    dataRow["ManufacturingCompany"].ToString(),dataRow["price"].ToString());
            }
            Console.WriteLine(new string('-', 100));
            NpgsqlDataAdapter adapter2 = new NpgsqlDataAdapter(sql2, connection);
            adapter2.Fill(dataSet, "InfoManufacturing");
            dataTable2 = dataSet.Tables["InfoManufacturing"];
            Console.WriteLine("\nТаблица InfoManufacturing");
            Console.WriteLine(new string('-', 100));
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                Console.WriteLine("{0} \t{1} \t{2}", dataRow["NumberContract"].ToString(),dataRow["ManufacturingCompany"].ToString(),dataRow["CountChemicals"].ToString());
            }
            Console.WriteLine(new string('-', 100));
            NpgsqlDataAdapter adapter3 = new NpgsqlDataAdapter(sql3, connection);
            adapter3.Fill(dataSet, "ContractChemicals");
            dataTable3 = dataSet.Tables["ContractChemicals"];
            Console.WriteLine("\nТаблица ContractChemicals");
            Console.WriteLine(new string('-', 100));
            foreach (DataRow dataRow in dataTable3.Rows)
            {
                Console.WriteLine("{0} \t{1}", dataRow["NumberContract"].ToString(), dataRow["EnterpriseBuyer"].ToString());
            }
            NpgsqlDataAdapter adapter4 = new NpgsqlDataAdapter(sql4, connection);
            adapter4.Fill(dataSet, "PurchaseChemicals");
            dataTable4 = dataSet.Tables["PurchaseChemicals"];
            Console.WriteLine("\nТаблица PurchaseChemicals");
            Console.WriteLine(new string('-', 100));
            foreach (DataRow dataRow in dataTable4.Rows)
            {
                Console.WriteLine("{0}   \t{1} \t{2}", dataRow["NameChemicals"].ToString(), dataRow["NumberContract"].ToString(), dataRow["CountChemicals"].ToString());
            }
            Console.WriteLine(new string('-', 100));
            /*int id1 = 3;
            string EnterpriseBuyer = "Yura";
            var sql5 = new NpgsqlCommand("insert into ContractChemicals values(@NumberContract,@EnterpriseBuyer)", connection);
            sql5.Parameters.AddWithValue("@NumberContract", id1);
            sql5.Parameters.AddWithValue("@EnterpriseBuyer", EnterpriseBuyer);
            sql5.ExecuteNonQuery(); */

        }
    }
}/*create table InfoChemicals
(
	NameChemicals varchar(50) not null,
	TypeChemical varchar(50) not null,	
	Opportunities varchar(50) not null,
	ChemicalComposition varchar(50) not null,
	ManufacturingCompany  varchar(50) primary key not null,
	Price int not null
);
insert into InfoChemicals values('Amiak','Poison','123','14','Apple',20);
insert into InfoChemicals values('Poison','Poison2','1234','14','Strawberry',21);
insert into InfoChemicals values('Prednison','lekarstvo','12345','145','Cherry',21);
select* from InfoChemicals;
create table InfoManufacturing
(
	NumberContract serial primary key not null,
	ManufacturingCompany  varchar(50) not null,
	CountChemicals int not null,
	FOREIGN KEY (ManufacturingCompany) REFERENCES InfoChemicals (ManufacturingCompany)
);
insert into InfoManufacturing values(1,'Apple',100);
insert into InfoManufacturing values(2,'Strawberry',100);
insert into InfoManufacturing values(3,'Cherry',150);
select* from InfoChemicals,InfoManufacturing;
create table ContractChemicals
(
	NumberContract serial primary key not null,
	EnterpriseBuyer varchar(50) not null,
	FOREIGN KEY (NumberContract) REFERENCES InfoManufacturing (NumberContract)
);
insert into ContractChemicals values(1,'Dima');
insert into ContractChemicals values(2,'Vlad');
insert into ContractChemicals values(3,'Yura');
select* from ContractChemicals;
create table PurchaseChemicals
(
	NameChemicals varchar(50) not null,
	NumberContract serial not null,
	CountChemicals int not null,
	FOREIGN KEY (NumberContract) REFERENCES ContractChemicals (NumberContract)
);
insert into PurchaseChemicals values('Amiak',1,100);
insert into PurchaseChemicals values('Poison',2,100);
insert into PurchaseChemicals values('Prednison',3,150);
select* from ContractChemicals,PurchaseChemicals;*/
