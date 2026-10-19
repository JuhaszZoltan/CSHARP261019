using System.Text;

#nullable disable

const string FilePath = "..\\..\\..\\data\\viraguzlet.csv";

List<Order> orders = [];

using StreamReader sr = new(FilePath, Encoding.UTF8);
_ = sr.ReadLine();
while (!sr.EndOfStream) orders.Add(new(sr.ReadLine()));

Console.WriteLine($"1. feladat: megrendelések száma: {orders.Count} db");

var f2 = orders.Count(o => o.FlowerOriginCounty == "Hollandia");
Console.WriteLine($"2. feladat:  Hollandiából származó virágokra leadott megrendelések száma: {f2} db");

Console.Write("3. feladat: írja be egy virág nevét: ");
var f3kw = Console.ReadLine();
var f3 = orders.Any(o => o.FlowerName == f3kw);
Console.WriteLine($"\t{(f3 ? "VOLT" : "NEM VOLT")} megrendelés {f3kw} virágra!");

var f4 = orders.MaxBy(o => o.Price);
Console.WriteLine($"4. feladat: legnagyobb értékű megrendelés: \n{f4}");

var f5 = orders.GroupBy(o => o.CustomerName).Where(g => g.Count() > 1).Select(g => g.Key);
Console.WriteLine("5. feladat: több megrendelést leadó vásárlók nevei:");
foreach (var name in f5) Console.WriteLine($"\t- {name}");