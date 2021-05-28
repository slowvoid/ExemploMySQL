using System;
using MySql.Data.MySqlClient;

namespace Remote_MySQL
{
    class Program
    {
        static void Main( string[] args )
        {
            string connStr = "server=localhost;user=dev;database=dev;port=3306;password=123456";
            MySqlConnection conn = new MySqlConnection( connStr );

            try
            {
                Console.WriteLine( "Conectando..." );
                conn.Open();

                string sql = "SELECT id, nome, idade FROM pessoa;";
                MySqlCommand cmd = new MySqlCommand( sql, conn );
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Console.WriteLine( $"{rdr[ 0 ]} --- {rdr[ 1 ]} --- {rdr[ 2 ]}" );
                }
                rdr.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine( ex.ToString() );
            }

            conn.Close();
        }
    }
}
