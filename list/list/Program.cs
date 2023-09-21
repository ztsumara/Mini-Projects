

using System.Collections;
ArrayList arrayList = new ArrayList();
arrayList.Add(100);
arrayList.Add("string");
arrayList.Add(1.265);
List<string> cities = new () { "Moscow", "Nalchik", "Voronezh" };
cities.Add("Omsk");
cities.AddRange(new string[] { "sevastopol", "Yalta" });
cities.RemoveAt(1);
Console.WriteLine(String.Join('_',cities));
cities.Sort();
Console.WriteLine(String.Join('_', cities));