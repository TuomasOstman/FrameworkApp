using System;
using System.Diagnostics;

namespace FrameworkApp
{
    class Program
    {
        private static readonly int Rows = 100;
        private static readonly int SeedId = 2;

        static void Main()
        {
            Console.WriteLine("SeedId is: " + SeedId + " and number of rows is: " + Rows);

            // ADO.Net

            var adosw = new Stopwatch();

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("ADO.Net starts!\n");
            Console.WriteLine("------------------------------------\n");

            adosw.Start();

            ADONetDAL.InsertData(SeedId, Rows);
            ADONetDAL.GetData();
            ADONetDAL.DeleteData();

            adosw.Stop();

            // Dapper

            var dappersw = new Stopwatch();

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Dapper starts!\n");
            Console.WriteLine("------------------------------------\n");

            dappersw.Start();

            DapperDAL.InsertData(SeedId, Rows);
            DapperDAL.GetData();
            DapperDAL.DeleteData();

            dappersw.Stop();

            // EF
            var efsw = new Stopwatch();

            Console.WriteLine("\n------------------------------------\n");
            Console.WriteLine("Entity Framework starts!\n");
            Console.WriteLine("------------------------------------\n");

            efsw.Start();

            EntityFrameworkDAL.InsertData(SeedId, Rows);
            EntityFrameworkDAL.GetData();
            EntityFrameworkDAL.DeleteData();

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
