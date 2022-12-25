using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Threading.Tasks.Dataflow;
using System.Data.Entity.Design.PluralizationServices;
using PluralizationService;

using System.Security.Cryptography;
using System.Runtime.CompilerServices;

namespace Class_generate_T4
{
    public class Proqram

    {

        public static void Main()
        {

            //          

            Console.OutputEncoding = Encoding.UTF8;
            string strcon = @" Data Source=DESKTOP-DUE6JJJ; 
                                Initial Catalog=Northwind; 
                                    Integrated Security=True; 
                                            Encrypt=True; 
                                    TrustServerCertificate=True;";
            SqlConnection sqlConnection = new SqlConnection(strcon);
            sqlConnection.Open();
            var sqlData = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
            SqlCommand sqlCommand= new SqlCommand(sqlData,sqlConnection);
            var tableNames = sqlCommand.ExecuteReader();
            while(tableNames.Read())
            {
                
                Console.WriteLine(tableNames[0].ToString().Replace(" ", ""));
            }
            
            
            
            
            
            //SqlDataAdapter adapter = new SqlDataAdapter("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", sqlConnection);
            //DataTable dataTable = new DataTable();
            //adapter.Fill(dataTable);
            //List<string> tables = new List<string>();
            //foreach (DataRow row in dataTable.Rows)
            //{

            //    string tablename = (string)row[0];
            //    tables.Add(tablename);
            //    Console.WriteLine(tablename);
            //}


            //foreach (string tableName in tables)
            //{
            //    adapter = new SqlDataAdapter($@"SELECT CONCAT(
            //                     'public ',
            //                     IIF(DATA_TYPE = 'nvarchar', 'string' +         (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'uniqueidentifier', 'string' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'ntext', 'string' +            (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'nchar', 'string' +            (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'int', 'int' +                 (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'smallint', 'short' +          (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'tinyint', 'byte' +            (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'money', 'decimal' +           (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'float', 'float' +             (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'decimal', 'decimal' +         (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'bit', 'bool' +                (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'datetime', 'DateTime' +       (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'date', 'DateTime' +           (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'datetime2', 'DateTime' +      (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     IIF(DATA_TYPE = 'image', 'byte[]' +            (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                     ' ',
            //                     COLUMN_NAME,'{{ get; set; }}' + (IIF((DATA_TYPE = 'nvarchar' or DATA_TYPE = 'nchar') and (IS_NULLABLE = 'NO'), ' = null!;', ''))
            //                 )
            //    FROM INFORMATION_SCHEMA.COLUMNS
            //    WHERE TABLE_NAME = N'{tableName}'
            //          and TABLE_SCHEMA = 'dbo'", sqlConnection);
            //    DataTable dtable = new DataTable();
            //    adapter.Fill(dtable);
            //    List<string> columns = new List<string>();
            //    foreach (DataRow row in dtable.Rows)
            //    {
            //        string columnName = (string)row[0];
            //        columns.Add(columnName);
            //        Console.WriteLine(columnName);

            //    }


            //    sqlConnection.Close();
            }


        }

    }
    


 //           {
 //               var Singular = PluralizationService.CreateService(new System.Globalization.CultureInfo("en-us"));

//               return Singular.Singularize(tablename);
//           }
//           string connectionString = @"Server=MACHINE; Database=Northwind; Trusted_Connection=True;";
//           SqlConnection sqlConnection = new SqlConnection(connectionString);
//           sqlConnection.Open();
//           var sql = "SELECT TABLE_NAME\r\n                FROM INFORMATION_SCHEMA.TABLES\r\n                WHERE TABLE_TYPE = 'BASE TABLE' AND TABLE_CATALOG='Northwind'";
//           SqlCommand command = new SqlCommand(sql, sqlConnection);
//           var data = command.ExecuteReader();
//           while (data.Read())

//Singularize(data[0].ToString()).Replace(" ", "");


//               var propertySql = $"SELECT CONCAT(\r\n                 'public ',\r\n     IIF(DATA_TYPE = 'nvarchar', 'string' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n     IIF(DATA_TYPE = 'real', 'Single' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n             IIF(DATA_TYPE = 'uniqueidentifier', 'string' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'ntext', 'string' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'nchar', 'string' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'int', 'int' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'smallint', 'short' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'tinyint', 'byte' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'money', 'decimal' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'float', 'float' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'decimal', 'decimal' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'bit', 'bool' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'datetime', 'DateTime' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'date', 'DateTime' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'datetime2', 'DateTime' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 IIF(DATA_TYPE = 'image', 'byte[]' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),\r\n                 ' ',\r\n                 COLUMN_NAME,\r\n                 '  “{{“ get; set; “}}” '\r\n                 + (IIF((DATA_TYPE = 'nvarchar' or DATA_TYPE = 'nchar') and (IS_NULLABLE = 'NO'), ' = null!;', ''))\r\n             )\r\nFROM INFORMATION_SCHEMA.COLUMNS\r\nWHERE TABLE_NAME = N'{data[0]}'     \r\n      and TABLE_SCHEMA = 'dbo'\r\n--SELECT  * FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = N'Northwind'"; #>

//		SqlConnection sqlConnection2 = new SqlConnection(connectionString);
//               sqlConnection2.Open();
//               SqlCommand command2 = new SqlCommand(propertySql, sqlConnection2);
//               var properties = command2.ExecuteReader();
//               while (properties.Read())

//                   properties[0].ToString().Replace("“", " ").Replace("”", " ");

//               sqlConnection.Close();












