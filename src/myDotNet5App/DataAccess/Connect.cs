using System;
using Npgsql;

namespace myDotNet5App.DataAccess
{
    public class MainClass
    {
        public static void PostgresConnect()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=ec2-54-227-254-152.compute-1.amazonaws.com;Port=5432;User Id=jhhviqwsvradpv;Password=FhnEg04i2FbvYcILy60R-1bAAX;Database=de2nf2u0r9g983;SSL=True;Sslmode=require;");
            conn.Open();

            NpgsqlCommand command = new NpgsqlCommand("select version()", conn);
            String serverversion;

            try
            {
                serverversion = (String)command.ExecuteScalar();
                Console.WriteLine("PostgreSQL server version: {0}", serverversion);
            }


            finally
            {
                conn.Close();
            }
        }
    }
}