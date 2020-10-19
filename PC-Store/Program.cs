using System;
using System.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Npgsql;
using PC_Store.Models;

namespace PC_Store
{
    public class Program
    {
       // static NpgsqlConnection npgsqlConnection;

        public static void Main(string[] args)
        {
/*            npgsqlConnection = GetConnection();
            npgsqlConnection.Open();*/
           CreateHostBuilder(args).Build().Run();
        }

/*        public static NpgsqlConnection GetConnection()
        {
            return new NpgsqlConnection(@"Server=localhost;Port=5432;User Id=postgres;Password=postgres;Database=postgres");
        }

        private static void TestConnection()
        {
            using(NpgsqlConnection con =GetConnection())
            {
                con.Open();
                if(con.State==ConnectionState.Open)
                {
                    Console.WriteLine("Connected");
                }
            }
        }*/

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
