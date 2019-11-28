using FrameworkApp.Entities;
using FrameworkApp.Model;
using System;
using System.Diagnostics;
using System.Linq;

namespace FrameworkApp
{
    public class EntityFrameworkDAL
    {
        #region EntityFramework

        /// <summary>
        /// Inserts data with EntityFramework
        /// </summary>
        /// <param name="seed">Randomnumber generators seed</param>
        public static void InsertData(int seedID, int rows)
        {
            try
            {
                var sw = new Stopwatch();

                Console.WriteLine("--Inserting data!");

                sw.Start();

                var i = 0;
                var result = false;
                var seed = 0;

                using (var db = new ThesisEntities())
                {
                    seed = (from sd in db.Seed
                            where sd.SeedID == seedID
                            select sd.SeedValue).FirstOrDefault();

                    Console.WriteLine("--Seed is : " + seed);

                    var gen = new Random(seed);

                    while (i < rows)
                    {
                        var row = new RandomObject()
                        {
                            RandomObjectID = i,
                            RandomString = RandomStringGenerator.RandomString(gen, 15),
                            RandomDateTimeOffset = RandomDateTimeOffsetGenerator.RandomDateTimeOffset(gen),
                            RandomInt = gen.Next(),
                            SeedId = seedID
                        };

                        db.RandomObject.Add(row);

                        i++;
                    }

                    db.SaveChanges();

                    result = true;

                    sw.Stop();
                }

                Console.WriteLine("--Result was: " + result);
                Console.WriteLine("--Time Elapsed: " + sw.Elapsed + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Gets data from database with EntityFramework
        /// </summary>
        /// <returns></returns>
        public static void GetData()
        {
            try
            {
                var sw = new Stopwatch();

                Console.WriteLine("--Fetching data!");

                sw.Start();

                RandomObjectModel result = null;

                using (var db = new ThesisEntities())
                {
                    result = (from ro in db.RandomObject
                              orderby ro.RandomDateTimeOffset descending
                              select new RandomObjectModel
                              {
                                  RandomObjectID = ro.RandomObjectID,
                                  RandomString = ro.RandomString,
                                  RandomDateTimeOffset = ro.RandomDateTimeOffset,
                                  RandomInt = ro.RandomInt,
                                  SeedId = ro.SeedId
                              }).FirstOrDefault();
                }

                sw.Stop();

                Console.WriteLine("--Result was: " + result.RandomObjectID + ", " + result.RandomString + ", " + result.RandomDateTimeOffset + ", " + result.RandomInt + ", " + result.SeedId);
                Console.WriteLine("--Time Elapsed: " + sw.Elapsed + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        /// <summary>
        /// Truncates table
        /// </summary>
        /// <returns></returns>
        public static void DeleteData()
        {
            try
            {
                var sw = new Stopwatch();

                Console.WriteLine("--Truncating table!");

                sw.Start();

                using (var db = new ThesisEntities())
                {
                    db.Database.ExecuteSqlCommand("TRUNCATE TABLE RandomObject");
                }

                sw.Stop();

                Console.WriteLine("--Time Elapsed: " + sw.Elapsed + "\n");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception occured: " + ex);
                Console.WriteLine("Press any key to continue.");
                Console.ReadKey();
            }
        }

        #endregion
    }
}
