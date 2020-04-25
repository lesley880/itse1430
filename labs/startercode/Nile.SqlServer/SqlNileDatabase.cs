using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nile.Stores;
/*
 * Lesley Reller
 * ITSE 1430
 * 04/25/2020
 */

namespace Nile.SqlServer
{
    public class SqlNileDatabase : ProductDatabase
    {
        public SqlNileDatabase ( string connectionString )
        {
            _connectionString = connectionString;
        }

        protected override Product AddCore ( Product product )
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("AddProduct", conn) {
                    CommandType = System.Data.CommandType.StoredProcedure
                };

                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                // Executes the command returns back the first value of the first row
                var result = cmd.ExecuteScalar();

                var id = Convert.ToInt32(result);
                product.Id = id;

                return product;
            }
        }


        protected override void RemoveCore ( int id )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "RemoveProduct";
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@id", id);

                // ignore return value
                cmd.ExecuteNonQuery();
            }
        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            var items = new List<Product>();

            var ds = new DataSet();

            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetProducts";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                // Intermediary
                var da = new SqlDataAdapter {
                    SelectCommand = cmd
                };

                // populate data
                da.Fill(ds);
            }

            var table = ds.Tables.OfType<DataTable>().FirstOrDefault(); // IEnumerable -> IEnumerable <T>
            if (table != null)
            {
                // reading data using dataset
                foreach (var row in table.Rows.OfType<DataRow>())
                {
                    var product = new Product() {
                        Id = Convert.ToInt32(row[0]),                           // row object ordinal
                        Name = row.Field<string>("Name"),                       // feild mehtod with type and column name
                        Description = row.Field<string>("Description"),         
                        Price = row.Field<int>("Price"),            
                        IsDiscontinued = row.Field<bool>("IsDiscontinued")
                    };

                    items.Add(product);
                };
            }
            return items;
        }

        protected override void UpdateCore (int id, Product product)
        {
            using (var conn = OpenConnection())
            {
                var cmd = new SqlCommand("UpdateProduct", conn);

                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@name", product.Name);
                cmd.Parameters.AddWithValue("@description", product.Description);
                cmd.Parameters.AddWithValue("@price", product.Price);
                cmd.Parameters.AddWithValue("@isDiscontinued", product.IsDiscontinued);

                cmd.ExecuteNonQuery();
            }
        }

        private SqlConnection OpenConnection ()
        {
            //DbConnection
            var conn = new SqlConnection(_connectionString);
            conn.Open();

            return conn;
        }

        protected override Product FindName ( string name )
        {
            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "FindName";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@name", name);

                // Error - clean up reader
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product() {
                            Id = Convert.ToInt32(reader[0]),                // Dictionary with zero based ordinal
                            Name = reader["Name"]?.ToString(),              // Dictionary with column name
                            Description = reader.GetString(2),              // GetType ordinal
                            Price = reader.GetFieldValue<int>(4),           // Generic (ordinal)
                            IsDiscontinued = reader.GetBoolean(5)
                        };

                        return product;
                    };
                };
            };
            return null;
        }

        protected override Product FindProduct ( int id )
        {

            using (var conn = OpenConnection())
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "GetProduct";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);

                // Error - clean up reader
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var product = new Product() {
                            Id = Convert.ToInt32(reader[0]),                // Dictionary with zero based ordinal
                            Name = reader["Name"]?.ToString(),              // Dictionary with column name
                            Description = reader.GetString(2),              // GetType ordinal
                            Price = reader.GetFieldValue<int>(4),           // Generic (ordinal)
                            IsDiscontinued = reader.GetBoolean(5)
                        };

                        return product;
                    };
                };
            };
            return null;
        }

        protected override Product GetCore ( int id ) => FindProduct(id);

        private readonly string _connectionString;
    }
}