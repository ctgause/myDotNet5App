using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using myDotNet5App.DataAccess;
using myDotNet5App.Models;
using Microsoft.AspNet.Mvc;
using Npgsql;

namespace myDotNet5App.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            NpgsqlConnection conn = new NpgsqlConnection("Server=ec2-54-227-254-152.compute-1.amazonaws.com;Port=5432;User Id=jhhviqwsvradpv;Password=FhnEg04i2FbvYcILy60R-1bAAX;Database=de2nf2u0r9g983;");
            //NpgsqlConnection conn = new NpgsqlConnection("SERVER=ec2-54-227-254-152.compute-1.amazonaws.com;PORT=5432;TIMEOUT=30;POOLING=True;MINPOOLSIZE=1;MAXPOOLSIZE=20;COMMANDTIMEOUT=20;APPLICATIONNAME=AG;DATABASE=de2nf2u0r9g983;HOST=ec2-54-227-254-152.compute-1.amazonaws.com;USER ID=jhhviqwsvradpv;PASSWORD=FhnEg04i2FbvYcILy60R-1bAAX;sslfactory=org.postgresql.ssl.NonValidatingFactory; ");
            // NpgsqlConnection conn =
            // new NpgsqlConnection("Server=ec2-54-227-254-152.compute-1.amazonaws.com;Port=5432;Database=de2nf2u0r9g983;User Id=jhhviqwsvradpv;Password = FhnEg04i2FbvYcILy60R-1bAAX; ");
            
            //NpgsqlConnection conn =
            //   new NpgsqlConnection(
            //       "jdbc: postgresql://ec2-54-221-232-104.compute-1.amazonaws.com:5432/d5l5agum3a597n?user=uc8g3qurs41tam&password=pemq9248rhpkthcnrtrihbuipl5&ssl=true&sslfactory=org.postgresql.ssl.NonValidatingFactory");



            conn.Open();
               var da = new NpgsqlDataAdapter();
            var cmd = new NpgsqlCommand("SELECT table_schema,table_name FROM information_schema.tables", conn);
            var ds = new DataSet();
            var dt = new DataTable();
            var tables = new List<Schema>();
            try
            {
                  da = new NpgsqlDataAdapter(cmd);
                ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables.Count > 0)
                {
                    for (var i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        var table = new Schema
                        {
                            schema = ds.Tables[0].Rows[i]["table_schema"].ToString(),
                            name = ds.Tables[0].Rows[i]["table_name"].ToString()
                        };
                        tables.Add(table);

                    }
                }
            }
            catch (Exception ex)
            {
                
                throw ex;
            }
           
            
            //NpgsqlCommand command = new NpgsqlCommand("SELECT table_schema,table_name FROM information_schema.tables", conn);
            //NpgsqlDataReader results = (Schema)command.ExecuteReader();
            

           
            // MainClass.Main();
            return View(tables);
        }

       
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
