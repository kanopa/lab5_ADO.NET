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
            bool menu = true;
            string key;
            Program program = new Program();
            NpgsqlConnection connection = new NpgsqlConnection(connect);
            connection.Open();
            DataSet dataSet = new DataSet();
            while(menu)
            {
                Console.WriteLine("1. Вывести все таблицы");
                Console.WriteLine("2. Вывести таблицу InfoChemicals");
                Console.WriteLine("3. Вывести таблицу InfoManufacturing");
                Console.WriteLine("4. Вывести таблицу ContractChemicals");
                Console.WriteLine("5. Вывести таблицу PurchaseChemicals");
                Console.WriteLine("6. Добавить строку в InfoChemicals");
                Console.WriteLine("7. Добавить строку в InfoManufacturing");
                Console.WriteLine("8. Добавить строку в ContractChemicals");
                Console.WriteLine("9. Добавить строку в PurchaseChemicals");
                Console.WriteLine("10. Изменить строку в InfoChemicals");
                Console.WriteLine("11. Изменить строку в InfoManufacturing");
                Console.WriteLine("12. Изменить строку в ContractChemicals");
                Console.WriteLine("13. Изменить строку в PurchaseChemicals");
                Console.WriteLine("14. Удалить строку в InfoChemicals");
                Console.WriteLine("15. Удалить строку в InfoChemicals");
                Console.WriteLine("16. Удалить строку в InfoChemicals");
                Console.WriteLine("17. Удалить строку в InfoChemicals");
                Console.WriteLine("18. Операции с таблицами");
                Console.WriteLine("19. Выход\n");
                Console.WriteLine("Ввод: ");
                key = Console.ReadLine();
                Console.Clear();
                switch (key)
                {
                    case "1":
                        program.OutputInfoChemicals(connection, dataSet);
                        program.OutputInfoManufacturing(connection, dataSet);
                        program.OutputContractChemicals(connection, dataSet);
                        program.OutputPurchaseChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "2":
                        program.OutputInfoChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "3":
                        program.OutputInfoManufacturing(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "4":
                        program.OutputContractChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "5":
                        program.OutputPurchaseChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "6":
                        program.AddRowInfoChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "7":
                        program.AddRowInfoManufacturing(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "8":
                        program.AddRowContractChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "9":
                        program.AddRowPurchaseChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "10":
                        program.UpdateInfoChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "11":
                        program.UpdateInfoManufacturing(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "12":
                        program.UpdateContractChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "13":
                        program.UpdatePurchaseChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "14":
                        program.DeleteInfoChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "15":
                        program.DeleteInfoManufacturing(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "16":
                        program.DeleteContractChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "17":
                        program.DeletePurchaseChemicals(connection, dataSet);
                        Console.ReadKey();
                        break;
                    case "18":
                        Console.ReadKey();
                        break;
                    case "19":
                        menu = false;
                        break;
                    default:
                        Console.WriteLine("Неккоректный ввод");
                        break;

                }
                Console.Clear();
            }
            connection.Close();
        }
        public void OutputInfoChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            dataSet.Reset();
            string sql = "select* from InfoChemicals";
            NpgsqlDataAdapter adapter = new NpgsqlDataAdapter(sql, connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataSet, "InfoChemicals");
            dataTable = dataSet.Tables["InfoChemicals"];
            Console.WriteLine("Таблица InfoChemicals");
            Console.WriteLine(new string('-', 100));
            foreach (DataRow dataRow in dataTable.Rows)
            {
                Console.WriteLine("{0}    \t{1}   \t{2}\t{3}\t{4}    \t{5} ", dataRow["NameChemicals"].ToString(),
                    dataRow["TypeChemical"].ToString(), dataRow["opportunities"].ToString(), dataRow["ChemicalComposition"].ToString(),
                    dataRow["ManufacturingCompany"].ToString(), dataRow["price"].ToString());
            }
            Console.WriteLine(new string('-', 100));
        }
        public void OutputInfoManufacturing(NpgsqlConnection connection, DataSet dataSet)
        {
            dataSet.Reset();
            string sql2 = "select* from InfoManufacturing";
            DataTable dataTable2 = new DataTable();
            NpgsqlDataAdapter adapter2 = new NpgsqlDataAdapter(sql2, connection);
            adapter2.Fill(dataSet, "InfoManufacturing");
            dataTable2 = dataSet.Tables["InfoManufacturing"];
            Console.WriteLine("\nТаблица InfoManufacturing");
            Console.WriteLine(new string('-', 100));
            foreach (DataRow dataRow in dataTable2.Rows)
            {
                Console.WriteLine("{0} \t{1}    \t{2}", dataRow["NumberContract"].ToString(), dataRow["ManufacturingCompany"].ToString(), dataRow["CountChemicals"].ToString());
            }
            Console.WriteLine(new string('-', 100));
        }
        public void OutputContractChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            dataSet.Reset();
            string sql3 = "select* from ContractChemicals";
            DataTable dataTable3 = new DataTable();
            NpgsqlDataAdapter adapter3 = new NpgsqlDataAdapter(sql3, connection);
            adapter3.Fill(dataSet, "ContractChemicals");
            dataTable3 = dataSet.Tables["ContractChemicals"];
            Console.WriteLine(dataTable3);
            Console.WriteLine("\nТаблица ContractChemicals");
            Console.WriteLine(new string('-', 100));
            foreach (DataRow dataRow in dataTable3.Rows)
            {
                Console.WriteLine("{0} \t{1}", dataRow["NumberContract"].ToString(), dataRow["EnterpriseBuyer"].ToString());
            }
        }
        public void OutputPurchaseChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            dataSet.Reset();
            string sql4 = "select* from PurchaseChemicals";
            DataTable dataTable4 = new DataTable();
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
        }
        public void AddRowInfoChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            string column1, column2, column3, column4,column5;
            int column6;
            Console.WriteLine("Введите название химиката: ");
            column1 = Console.ReadLine();
            Console.WriteLine("Введите тип химиката: ");
            column2 = Console.ReadLine();
            Console.WriteLine("Введите возможнсть употребления: ");
            column3 = Console.ReadLine();
            Console.WriteLine("Введите химический состав");
            column4 = Console.ReadLine();
            Console.WriteLine("Введите компанию производителя: ");
            column5 = Console.ReadLine();
            Console.WriteLine("Введите цену химиката: ");
            column6 = Convert.ToInt32(Console.ReadLine());
            var sql = new NpgsqlCommand("insert into InfoChemicals values(@NameChemicals,@TypeChemical,@Opportunities,@ChemicalComposition,@ManufacturingCompany,@Price)", connection);
            sql.Parameters.AddWithValue("@NameChemicals", column1);
            sql.Parameters.AddWithValue("@TypeChemical", column2);
            sql.Parameters.AddWithValue("@Opportunities", column3);
            sql.Parameters.AddWithValue("@ChemicalComposition", column4);
            sql.Parameters.AddWithValue("@ManufacturingCompany", column5);
            sql.Parameters.AddWithValue("@Price", column6);
            sql.ExecuteNonQuery();
        }
        public void AddRowInfoManufacturing(NpgsqlConnection connection, DataSet dataSet)
        {
            int column1, column3;
            string column2;
            Console.WriteLine("Введите номер договора");
            column1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите Введите компанию производителя: ");
            column2 = Console.ReadLine();
            Console.WriteLine("Введите количество химиката: ");
            column3 = Convert.ToInt32(Console.ReadLine());
            var sql = new NpgsqlCommand("insert into InfoManufacturing values(@NumberContract,@ManufacturingCompany,@CountChemicals)", connection);
            sql.Parameters.AddWithValue("@NumberContract", column1);
            sql.Parameters.AddWithValue("@ManufacturingCompany", column2);
            sql.Parameters.AddWithValue("@CountChemicals", column3);
            sql.ExecuteNonQuery();
        }
        public void AddRowContractChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            int column1;
            string column2;
            Console.WriteLine("Введите номер договора");
            column1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите предприятие покупатель: ");
            column2 = Console.ReadLine();
            var sql = new NpgsqlCommand("insert into ContractChemicals values(@NumberContract,@EnterpriseBuyer)", connection);
            sql.Parameters.AddWithValue("@NumberContract", column1);
            sql.Parameters.AddWithValue("@EnterpriseBuyer", column2);
            sql.ExecuteNonQuery();
        }
        public void AddRowPurchaseChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            string column1;
            int column2, column3;
            Console.WriteLine("Введите название химиката: ");
            column1 = Console.ReadLine();
            Console.WriteLine("Введите номер договора: ");
            column2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество химикатов: ");
            column3 = Convert.ToInt32(Console.ReadLine());
            var sql = new NpgsqlCommand("insert into PurchaseChemicals values(@NameChemicals,@NumberContract,@CountChemicals)", connection);
            sql.Parameters.AddWithValue("@NameChemicals", column1);
            sql.Parameters.AddWithValue("@NumberContract", column2);
            sql.Parameters.AddWithValue("@CountChemicals", column3);
            sql.ExecuteNonQuery();
        }
        public void DeleteInfoChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            string temp;
            Console.WriteLine("Удалить строку по производителю: ");
            temp = Console.ReadLine();
            string command = string.Format("delete from InfoChemicals where ManufacturingCompany = '{0}'", temp);
            var sql = new NpgsqlCommand(command, connection);
            sql.ExecuteNonQuery();
        }
        public void DeleteInfoManufacturing(NpgsqlConnection connection, DataSet dataSet)
        {
            int temp;
            Console.WriteLine("Удалить строку по номеру договора: ");
            temp = Convert.ToInt32(Console.ReadLine());
            string command = string.Format("delete from InfoManufacturing where NumberContract = {0}", temp);
            var sql = new NpgsqlCommand(command, connection);
            sql.ExecuteNonQuery();
        }
        public void DeleteContractChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            int temp;
            Console.WriteLine("Удалить строку по номеру договора: ");
            temp = Convert.ToInt32(Console.ReadLine());
            string command = string.Format("delete from ContractChemicals where NumberContract = {0}", temp);
            var sql = new NpgsqlCommand(command, connection);
            sql.ExecuteNonQuery();
            
        }
        public void DeletePurchaseChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            int temp;
            Console.WriteLine("Удалить строку по номеру договора: ");
            temp = Convert.ToInt32(Console.ReadLine());
            string command = string.Format("delete from PurchaseChemicals where NumberContract = {0}", temp);
            var sql = new NpgsqlCommand(command, connection);
            sql.ExecuteNonQuery();
        }
        public void UpdatePurchaseChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            string temp1, temp2;
            int temp3;
            Console.WriteLine("Столбец: ");
            temp1 = Console.ReadLine();
            Console.WriteLine("Значение столбца");
            temp2 = Console.ReadLine();
            Console.WriteLine("Номер договора: ");
            temp3 = Convert.ToInt32(Console.ReadLine());
            string command = string.Format("update PurchaseChemicals set {0} = '{1}' where NumberContract = {2}", temp1, temp2, temp3);
            var sql = new NpgsqlCommand(command, connection);
            sql.ExecuteNonQuery();
        }
        public void UpdateContractChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            string temp1, temp2;
            int temp3;
            Console.WriteLine("Столбец: ");
            temp1 = Console.ReadLine();
            Console.WriteLine("Значение столбца");
            temp2 = Console.ReadLine();
            Console.WriteLine("Номер договора: ");
            temp3 = Convert.ToInt32(Console.ReadLine());
            string command = string.Format("update ContractChemicals set {0} = '{1}' where NumberContract = {2}", temp1, temp2, temp3);
            var sql = new NpgsqlCommand(command, connection);
            sql.ExecuteNonQuery();
        }
        public void UpdateInfoManufacturing(NpgsqlConnection connection, DataSet dataSet)
        {
            string temp1, temp2;
            int temp3;
            Console.WriteLine("Столбец: ");
            temp1 = Console.ReadLine();
            Console.WriteLine("Значение столбца");
            temp2 = Console.ReadLine();
            Console.WriteLine("Номер договора: ");
            temp3 = Convert.ToInt32(Console.ReadLine());
            string command = string.Format("update InfoManufacturing set {0} = '{1}' where NumberContract = {2}", temp1, temp2, temp3);
            var sql = new NpgsqlCommand(command, connection);
            sql.ExecuteNonQuery();
        }
        public void UpdateInfoChemicals(NpgsqlConnection connection, DataSet dataSet)
        {
            string temp1, temp2, temp3;
            Console.WriteLine("Столбец: ");
            temp1 = Console.ReadLine();
            Console.WriteLine("Значение столбца");
            temp2 = Console.ReadLine();
            Console.WriteLine("Номер договора: ");
            temp3 = Console.ReadLine();
            string command = string.Format("update InfoChemicals set {0} = '{1}' where ManufacturingCompany = '{2}'", temp1, temp2, temp3);
            var sql = new NpgsqlCommand(command, connection);
            sql.ExecuteNonQuery();
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
