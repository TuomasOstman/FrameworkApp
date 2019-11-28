using System;
using System.Configuration;
using System.Diagnostics;

namespace FrameworkApp
{
    class Program
    {
        private static readonly int Rows = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Rows"));
        private static readonly int SeedId = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Seed"));
        private static readonly int Repeats = Convert.ToInt32(ConfigurationManager.AppSettings.Get("Repeats"));

        static void Main(string[] args)
        {
            Console.WriteLine("SeedId is: " + SeedId + ", number of rows is: " + Rows + " and Repeat count is: " + Repeats);

            // ADO.Net

            var adosw = new Stopwatch();

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("ADO.Net starts!\n");
            Console.WriteLine("------------------------------------\n");

            adosw.Start();

            for (int i = 0; i < Repeats; i++)
            {
                ADONetDAL.InsertData(SeedId, Rows);
                ADONetDAL.GetData();
                ADONetDAL.DeleteData();
            }

            adosw.Stop();

            // Dapper

            var dappersw = new Stopwatch();

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Dapper starts!\n");
            Console.WriteLine("------------------------------------\n");

            dappersw.Start();

            for (int i = 0; i < Repeats; i++)
            {
                DapperDAL.InsertData(SeedId, Rows);
                DapperDAL.GetData();
                DapperDAL.DeleteData();
            }

            dappersw.Stop();

            // EF
            var efsw = new Stopwatch();

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Entity Framework starts!\n");
            Console.WriteLine("------------------------------------\n");

            efsw.Start();

            for (int i = 0; i < Repeats; i++)
            {
                EntityFrameworkDAL.InsertData(SeedId, Rows);
                EntityFrameworkDAL.GetData();
                EntityFrameworkDAL.DeleteData();
            }

            efsw.Stop();

            Console.WriteLine("------------------------------------\n");
            Console.WriteLine("Entity Framework time: " + efsw.Elapsed);
            Console.WriteLine("Dapper time:           " + dappersw.Elapsed);
            Console.WriteLine("ADO.Net time:          " + adosw.Elapsed);

            Console.WriteLine("Press any key to close this window.");
            Console.ReadKey();
        }
    }
}
