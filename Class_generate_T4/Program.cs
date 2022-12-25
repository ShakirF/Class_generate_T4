using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Microsoft.Data.SqlClient;
using System.Globalization;
using System.Threading.Tasks.Dataflow;
using Pluralize.NET;

namespace Class_generate_T4
{
    public class Proqram

    {
        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string strcon = @" Data Source=DESKTOP-DUE6JJJ; 
                                Initial Catalog=Northwind; 
                                    Integrated Security=True; 
                                            Encrypt=True; 
                                    TrustServerCertificate=True;";
            SqlConnection sqlConnection = new SqlConnection(strcon);
            sqlConnection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", sqlConnection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            List<string> tables = new List<string>();
            foreach (DataRow row in dataTable.Rows)
            {
                IPluralize pluralizer = new Pluralizer();
                string tablename = pluralizer.Singularize((string)row[0]);
                tables.Add(tablename);
                Console.WriteLine(tablename);
            }

            //            foreach (string tableName in tables)
            //            {
            //                adapter = new SqlDataAdapter($@"SELECT CONCAT(
            //                 'public ',
            //                 IIF(DATA_TYPE = 'nvarchar', 'string' +         (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'uniqueidentifier', 'string' + (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'ntext', 'string' +            (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'nchar', 'string' +            (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'int', 'int' +                 (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'smallint', 'short' +          (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'tinyint', 'byte' +            (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'money', 'decimal' +           (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'float', 'float' +             (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'decimal', 'decimal' +         (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'bit', 'bool' +                (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'datetime', 'DateTime' +       (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'date', 'DateTime' +           (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'datetime2', 'DateTime' +      (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 IIF(DATA_TYPE = 'image', 'byte[]' +            (IIF(IS_NULLABLE = 'YES', '?', '')), ''),
            //                 ' ',
            //                 COLUMN_NAME,'{{ get; set; }}' + (IIF((DATA_TYPE = 'nvarchar' or DATA_TYPE = 'nchar') and (IS_NULLABLE = 'NO'), ' = null!;', ''))
            //             )
            //FROM INFORMATION_SCHEMA.COLUMNS
            //WHERE TABLE_NAME = N'{tableName}'
            //      and TABLE_SCHEMA = 'dbo'", sqlConnection);
            //                DataTable dtable = new DataTable();
            //                adapter.Fill(dtable);
            //                List<string> columns = new List<string>();
            //                foreach (DataRow row in dtable.Rows)
            //                {
            //                    string columnName = (string)row[0];
            //                    columns.Add(columnName);
            //                    Console.WriteLine(columnName);

            //                }


            //                sqlConnection.Close();
            //            }

            
        }

    }
}












