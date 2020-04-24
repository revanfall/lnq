using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace lynq
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] names = {"Илья", "Андрей", "Денис", "Никитос", "Димон"};
            var selectedNames = from name in names
                where name.ToUpper().StartsWith("Д")
                orderby name
                select name;
            foreach (var name in selectedNames)
            {
                Console.WriteLine(name);
            }

            int number = names.Where(names => names.ToUpper().StartsWith("Д")).Count();
            Console.WriteLine(number);
            Console.WriteLine();
            int[] numbers = {1, 24, 23, 6143, 10, 8};
            // //  IEnumerable<int> evens = from i in numbers where i % 2 == 0 select i;
            //   foreach (var VARIABLE in evens)
            //       Console.WriteLine(VARIABLE);
            // IEnumerable<int> orderedNums = numbers.OrderBy(i => i);
            IEnumerable<int> desOrderNums = numbers.OrderByDescending(i => i);
            foreach (var VARIABLE in desOrderNums)
            {
                Console.WriteLine("=");
                Console.WriteLine(VARIABLE);
            }

            List<User> users = new List<User>
            {
                new User("Illia", 20),
                new User("Nanako", 7),
                new User("Ivan", 45),
                new User("Dmitriy", 13),
                new User("Hitomi", 15)
            };
            // var selectedUsers = from user in users where user.Age <= 15 select user;
            var selectedUsers = users.Where(user => user.Age >= 15 && user.Name.StartsWith("I"));
            foreach (var user in selectedUsers)
                Console.WriteLine($"Name:{user.Name} Age:{user.Age}");
            Console.WriteLine("================================");
            var orderAge = from user in users orderby user.Age descending select user;
            foreach (var user in orderAge)
                Console.WriteLine($"Name:{user.Name} Age:{user.Age}");
            Console.WriteLine("================================");
            var nameSelection = users.OrderBy(user => user.Name).ThenBy(user => user.Age);
            foreach (var u in nameSelection)
            {
                Console.WriteLine(u.Age + " " + u.Name);
            }

            string[] girlsNames = {"Sveta", "Sasha", "Marina", "Vova"};
            string[] boysNames = {"Illia", "Sasha", "Marina", "Denis"};
            Console.WriteLine("====================");
            var unNames = boysNames.Except(girlsNames).OrderBy(i => i);
            foreach (var nnames in unNames)
            {
                Console.WriteLine(nnames);
            }

            Console.WriteLine("==========================");
            var allNames = girlsNames.Concat(boysNames);
            foreach (var allName in allNames)
            {
                Console.WriteLine(allName);
            }

            Console.WriteLine("============================");
            var distNames = allNames.Distinct();
            foreach (var distName in distNames)
            {
                Console.WriteLine(distName);
            }

            Console.WriteLine("===================");
            var agrFunc = numbers.Aggregate((x, y) => x * y);
            Console.WriteLine(agrFunc);
            Console.WriteLine("===================");
            var sumNum = numbers.Sum();
            Console.WriteLine(sumNum);
            Console.WriteLine("===================");
            var ageSelection = users.Min(u => u.Age);
            Console.WriteLine(ageSelection);
            Console.WriteLine("===================");
            var ageAverage = users.Average(u => u.Age);
            Console.WriteLine((int) ageAverage);
            Console.WriteLine("==========================");
            var getLastElems = numbers.Skip(3);
            foreach (var els in getLastElems)
            {
                Console.WriteLine(els);
            }

            Console.WriteLine("============================");
           // var getNamesByI = users.TakeWhile(u => u.Name.StartsWith("I"));
            foreach (var sortNames in users.TakeWhile(u=>u.Name.StartsWith("I")))
            {
                Console.WriteLine($"{sortNames.Name}");
            }
            Console.WriteLine("========================");
            List<Tablets> tablist=new List<Tablets>
            {
                new Tablets("Ipad 4","Apple"),
                new Tablets("Tab 4","Samsung"),
                new Tablets("Ipad mini","Apple"),
                new Tablets("J1 mini","Samsung"),
                new Tablets("TabPad","Lenovo"),
                new Tablets("Ipad pro","Apple")
                
            };
            var groupedTablList = from t in tablist group t by t.Brand;
            foreach (IGrouping<string,Tablets> t in groupedTablList)
            {
                foreach (var tabletse in t)
                    Console.WriteLine($"{tabletse.Brand} {tabletse.Model}");
                {
                    
                }
            }
            Console.WriteLine("=====================");
            var countBrands = from t in tablist
                group t by t.Brand
                into tb
                select new
                {
                    Name = tb.Key, Count = tb.Count(),
                    Tablets=from tabl in tb select tabl
                };
            foreach (var grouped in countBrands)
            {
                Console.WriteLine($"{grouped.Name}-{grouped.Count} ");
                foreach (Tablets tablets in grouped.Tablets)
                    Console.WriteLine($"{tablets.Model}");
                
            }
            List<Country> countries=new List<Country>
            {
                new Country("France","Paris"),
                new Country("Italy","Rome"),
                new Country("Britain", "London"),
                new Country("Germany","Munich")
            };
            List<City> cities =new List<City>
            {
                new City("Paris","Eiffel tower"),
                new City("Rome", "Colliseum"),
                new City("London","Big Ben"),
                new City("Munich","Octoberfest")
            };
            var joined = from country in countries
                join city in cities on country.City equals city.Name
                select new
                    {cName = city.Name, Monum = city.Monuments, Countr = country.CountryName};
            Console.WriteLine("===============================");
            foreach (var res in joined)
            {
                Console.WriteLine($"{res.Monum}--{res.cName}--{res.Countr}");
            }

            Console.WriteLine("================================");
            var usersAge = users.All(u => u.Age > 8);
            Console.WriteLine(usersAge);
            Console.WriteLine("================================");
            var isAgeMinimum = users.Any(u => u.Age < 8);
            Console.WriteLine(isAgeMinimum);
            Console.WriteLine("================================");
            
        }
    }
}