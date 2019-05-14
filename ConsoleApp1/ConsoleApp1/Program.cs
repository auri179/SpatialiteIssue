using System;
using System.Linq;
using Microsoft.Data.Sqlite;
using NetTopologySuite.Geometries;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {

            //SQLitePCL.raw.SetProvider(new SQLitePCL.SQLite3Provider_e_sqlite3());
            //SqliteConnection conn = new SqliteConnection("Data Source=e:\\Cadastre\\Cadastre33.sqlite");

            //conn.Open();

            //SqliteCommand comm = new SqliteCommand("select * from geo_parcelle", conn);
            //var reader = comm.ExecuteReader();

            //while(reader.Read())
            //{
            //    var test = string.Empty;
            //    Console.WriteLine(reader.GetString(0));
            //}

            //using (GISContext ctx = new GISContext())
            //{
            //    var list = ctx.GeoParcelle.Take(100).ToList();
            //    foreach (var item in list)
            //    {
            //        Console.WriteLine(item.Tex);
            //    }
            //}

            using (GISContext ctx = new GISContext())
            {
                Point referenceLocation = new Point(966598.0, 446583.0);
                var polygon = (Geometry)referenceLocation.Buffer(100);

                var entities = ctx.GeoParcelle.Where(c => c.Geom.Intersects(polygon));

                foreach (var item in entities)
                {
                    Console.WriteLine(item.Tex);
                }
            }
        }
    }
}
