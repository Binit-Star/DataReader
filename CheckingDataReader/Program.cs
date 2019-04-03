using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace CheckingDataReader
{
    class Program
    {
        static void CheckMultiResults()
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("MultiResult",con);
            cmd.CommandType = CommandType.StoredProcedure;
            IDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Console.WriteLine(reader["ShopName"].ToString());
            }

            if(reader.NextResult())
            {
                while (reader.Read())
                {
                    Console.WriteLine(reader["CategoryName"].ToString());
                }
                
            }

            con.Close();
            Console.ReadLine();
        }
        
        static void Main(string[] args)
        {
            CheckMultiResults();
        }
    }
}
