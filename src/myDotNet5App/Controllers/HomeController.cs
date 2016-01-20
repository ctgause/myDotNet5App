using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using myDotNet5App.DataAccess;
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

            NpgsqlCommand command = new NpgsqlCommand("select version()", conn);
            String serverversion;
            serverversion = (String)command.ExecuteScalar();
            ViewData["Version"] = "PostgreSQL server version: " +  serverversion;// = serverversion;
            // MainClass.Main();
            return View();
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
