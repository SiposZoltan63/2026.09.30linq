using System;
using System.Collections.Generic;
using System.Linq;

namespace LinqGyakorlo
{
    class Program
    {
        static void Main(string[] args)
        {
            // A feladatok leírását a Feladatlap.md fájlban találod.
            // Minden feladathoz tartozik egy Feladat##() metódus itt lent.
            // Írd meg a LINQ lekérdezést a metódus törzsében, majd
            // vedd ki a kommentet a hívása elől, hogy lásd az eredményt.


            //1.Szűrés — Where
            //Listázd ki azokat a hallgatókat, akiknek 4.0 fölötti a tanulmányi átlaguk
            Feladat01();
            Feladat02();
            Feladat03();
            Feladat04();
            Feladat05();
            Feladat06();
            Feladat07();
            Feladat08();
            Feladat09();
            Feladat10();
            Feladat11();
            Feladat12();
            Feladat13();
            Feladat14();
            Feladat15();
            // Feladat16();
            // Feladat17();
            // Feladat18();
            // Feladat19();
            // Feladat20();
            // Feladat21();
            // Feladat22();
            // Feladat23();
            // Feladat24();
            // Feladat25();
            // Feladat26();
            // Feladat27();
            // Feladat28();
            // Feladat29();
            // Feladat30();
            // Feladat31();
            // Feladat32();
            // Feladat33();
            // Feladat34();
            // Feladat35();
            // Feladat36();
            // Feladat37();
            // Feladat38();
            // Feladat39();
            // Feladat40();
        }

        // ---------- 1. Szűrés — Where ----------

        // 1. Hallgatók, akiknek 4.0 fölötti az átlaga.
        static void Feladat01()
        {
            Console.WriteLine("---------------------------------------");
            var result = SampleData.Students.Where(atlag => atlag.GradeAverage > 4);
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }

        // 2. Budapesti hallgatók.
        static void Feladat02()
        {
            Console.WriteLine("------------------------------------------");
            var result = SampleData.Students.Where(varos => varos.City == "Budapest");
            foreach (var item in result)
            {
                Console.WriteLine(item.Name);
            }
        }

        // 3. Kurzusok, amelyek kreditértéke legalább 5.
        static void Feladat03()
        {
            Console.WriteLine("--------------------------------------------");
            var result = SampleData.Courses.Where(kredit => kredit.Credit >= 5);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // 4. Hallgatók 20-23 év között (határokkal), akik nem budapestiek.
        static void Feladat04()
        {
            Console.WriteLine("-----------------------------------------------");
            var result = SampleData.Students.Where(tanulo => tanulo.Age >= 20 && tanulo.Age < 23 && tanulo.City != "Budapest");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // ---------- 2. Vetítés — Select, SelectMany ----------

        // 5. Csak a hallgatók nevei.
        static void Feladat05()
        {
            Console.WriteLine("------------------------------------------------");
            var result = SampleData.Students.Select(name => name.Name);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // 6. Anonim típusú lista: Name, GradeAverage.
        static void Feladat06()
        {
            Console.WriteLine("---------------------------------------------------");
            var result = SampleData.Students.Select(tanulo => new { Név = tanulo.Name, Átlag = tanulo.GradeAverage});
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // 7. Kurzus neve + a kurzust tartó tanár neve (Select, Join nélkül).
        static void Feladat07()
        {
            Console.WriteLine("----------------------------------------------");
            var result = SampleData.Courses.Select(c => new {KurzusNév = c.Name, Tanárnév = SampleData.Teachers.First(t => t.Id == c.TeacherId).Name});
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }
        // 8. SelectMany: beiratkozások lapos listája hallgató névvel.
        static void Feladat08()
        {
            Console.WriteLine("---------------------------------------------------");
            var result = SampleData.Students.SelectMany(tanulo => SampleData.Enrollments.Where(e => e.StudentId == tanulo.Id),(tanulo,e) => new {Tanulónév = tanulo.Name, KurzusId = e.CourseId, Jegy = e.Grade});
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // ---------- 3. Rendezés — OrderBy, ThenBy, Reverse ----------

        // 9. Hallgatók átlag szerint csökkenő sorrendben.
        static void Feladat09()
        {
            Console.WriteLine("---------------------------------------------------");
            var result = SampleData.Students.OrderByDescending(hallgatok => hallgatok.GradeAverage);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // 10. Hallgatók város szerint, majd név szerint növekvő sorrendben.
        static void Feladat10()
        {
            Console.WriteLine("-----------------------------------------");
            var result = SampleData.Students.OrderBy(h => h.City).ThenBy(h => h.Name);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // 11. Kurzusok eredeti sorrendjének megfordítása (Reverse).
        static void Feladat11()
        {
            Console.WriteLine("---------------------------------------------");
            var result = SampleData.Courses.AsEnumerable().Reverse();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // ---------- 4. Csoportosítás — GroupBy ----------

        // 12. Hallgatók száma városonként.
        static void Feladat12()
        {
            Console.WriteLine("------------------------------------------------");
            var result = SampleData.Students.GroupBy(citygroup => citygroup.City).Select(g => new {Város = g.Key, Darab = g.Count()});
            foreach (var item in result) { Console.WriteLine(item);}
        }

        // 13. Átlagos tanulmányi átlag városonként.
        static void Feladat13()
        {
            Console.WriteLine("------------------------------------------------");
            var result = SampleData.Students.GroupBy(citygroup => citygroup.City).Select(g => new { Város = g.Key, Átlag = g.Average(avg => avg.GradeAverage) });
            foreach (var item in result) { Console.WriteLine(item); }
        }

        // 14. Kurzusnevek kategóriánként.
        static void Feladat14()
        {
            Console.WriteLine("--------------------------------------------------");
            var result = SampleData.Courses.GroupBy(ca => ca.Category).Select(cu => new {Kategóriák = cu.Key, Nevek = cu.Select(cat => cat.Name)});
            foreach (var item in result) 
            {
                Console.WriteLine("---------------------------------------------");
                Console.WriteLine(item.Kategóriák);
                foreach (var item1 in item.Nevek)
                {
                    Console.WriteLine(item1);
                }
            }
        }

        // ---------- 5. Összekapcsolás — Join, GroupJoin ----------

        // 15. Enrollments + Students Join: hallgató neve minden beiratkozáshoz.
        static void Feladat15()
        {
            Console.WriteLine("--------------------------------------------------");
            var result = SampleData.Enrollments.Join(
                SampleData.Students,
                e => e.StudentId,
                s => s.Id,
                (e, s) => new { Tanulónév = s.Name, e.CourseId, e.Grade }
            );
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // 16. Háromtáblás Join: hallgató neve, kurzus neve, érdemjegy.
        static void Feladat16()
        {
            Console.WriteLine("--------------------------------------------------");
            var result = SampleData.Enrollments
                .Join(SampleData.Students, e => e.StudentId, s => s.Id, (e, s) => new { e, s })
                .Join(SampleData.Courses, es => es.e.CourseId, c => c.Id, (es, c) => new {
                    Tanulónév = es.s.Name,
                    Kurzusnév = c.Name,
                    Jegy = es.e.Grade
                });

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // 17. GroupJoin: hallgatónként a beiratkozásai (azok is, akiknek nincs).
        static void Feladat17()
        {
            Console.WriteLine("--------------------------------------------------");
            var result = SampleData.Students.GroupJoin(
                SampleData.Enrollments,
                s => s.Id,
                e => e.StudentId,
                (s, enrollments) => new {
                    Tanulónév = s.Name,
                    Beiratkozások = enrollments
                }
            );

            foreach (var item in result)
            {
                Console.WriteLine($"Hallgató: {item.Tanulónév}");
                foreach (var e in item.Beiratkozások)
                {
                    Console.WriteLine($"  - Kurzus ID: {e.CourseId}, Jegy: {e.Grade}");
                }
            }
        }

        // ---------- 6. Halmazműveletek — Distinct, Union, Intersect, Except, Concat, Zip ----------

        // 18. Hány különböző város van a hallgatók között (Distinct).
        static void Feladat18()
        {
            Console.WriteLine("--------------------------------------------------");
            var result = SampleData.Students.Select(s => s.City).Distinct();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // 19. Különböző kurzuskategóriák (Distinct).
        static void Feladat19()
        {
            Console.WriteLine("--------------------------------------------------");
            var result = SampleData.Courses.Select(c => c.Category).Distinct();
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // 20. Union, Intersect, Except a "kiváló" (átlag >= 4.5) és "budapesti" hallgatók nevei között.
        static void Feladat20()
        {
            Console.WriteLine("--------------------------------------------------");
            var kivalo = SampleData.Students.Where(s => s.GradeAverage >= 4.5).Select(s => s.Name);
            var budapesti = SampleData.Students.Where(s => s.City == "Budapest").Select(s => s.Name);

            Console.WriteLine("Unió (kiváló VAGY budapesti):");
            foreach (var item in kivalo.Union(budapesti)) Console.WriteLine("  " + item);

            Console.WriteLine("Metszet (kiváló ÉS budapesti):");
            foreach (var item in kivalo.Intersect(budapesti)) Console.WriteLine("  " + item);

            Console.WriteLine("Különbség (kiváló, DE NEM budapesti):");
            foreach (var item in kivalo.Except(budapesti)) Console.WriteLine("  " + item);
        }

        // 21. Concat: Matematika + Informatika kurzusnevek.
        static void Feladat21()
        {
            Console.WriteLine("--------------------------------------------------");
            var matek = SampleData.Courses.Where(c => c.Category == "Matematika").Select(c => c.Name);
            var info = SampleData.Courses.Where(c => c.Category == "Informatika").Select(c => c.Name);

            var result = matek.Concat(info);
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // 22. Zip: első 4 hallgató neve + első 4 kurzus neve párban.
        static void Feladat22()
        {
            Console.WriteLine("--------------------------------------------------");
            var hallgatok = SampleData.Students.Take(4).Select(s => s.Name);
            var kurzusok = SampleData.Courses.Take(4).Select(c => c.Name);

            var result = hallgatok.Zip(kurzusok, (h, k) => $"{h} -> {k}");
            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
        }

        // ---------- 7. Aggregálás — Count, Sum, Average, Min, Max, Aggregate ----------

        // 23. Hallgatók száma összesen, illetve akiknek átlaga > 4.0 (Count).
        static void Feladat23()
        {
            Console.WriteLine("--------------------------------------------------");
            int osszes = SampleData.Students.Count();
            int negyFeletti = SampleData.Students.Count(s => s.GradeAverage > 4.0);

            Console.WriteLine($"Összes hallgató: {osszes}");
            Console.WriteLine($"4.0 feletti átlagúak: {negyFeletti}");
        }

        // 24. Az összes kurzus kredit-összege (Sum).
        static void Feladat24()
        {
            Console.WriteLine("--------------------------------------------------");
            int osszKredit = SampleData.Courses.Sum(c => c.Credit);
            Console.WriteLine($"Összes kredit: {osszKredit}");
        }

        // 25. Hallgatók átlagéletkora (Average).
        static void Feladat25()
        {
            Console.WriteLine("--------------------------------------------------");
            double atlagKor = SampleData.Students.Average(s => s.Age);
            Console.WriteLine($"Átlagéletkor: {atlagKor:F2}");
        }

        // 26. Legfiatalabb és legidősebb hallgató életkora (Min, Max).
        static void Feladat26()
        {
            Console.WriteLine("--------------------------------------------------");
            int minKor = SampleData.Students.Min(s => s.Age);
            int maxKor = SampleData.Students.Max(s => s.Age);

            Console.WriteLine($"Legfiatalabb: {minKor} év");
            Console.WriteLine($"Legidősebb: {maxKor} év");
        }

        // 27. Aggregate: hallgatónevek vesszővel elválasztva egy stringbe.
        static void Feladat27()
        {
            Console.WriteLine("--------------------------------------------------");
            var result = SampleData.Students
                .Select(s => s.Name)
                .Aggregate((current, next) => current + ", " + next);

            Console.WriteLine(result);
        }

        // ---------- 8. Elemkiválasztás — First, Last, Single, ElementAt ----------

        // 28. Első szegedi hallgató (First/FirstOrDefault).
        static void Feladat28()
        {
            Console.WriteLine("--------------------------------------------------");
            var elsoSzegedi = SampleData.Students.FirstOrDefault(s => s.City == "Szeged");
            Console.WriteLine(elsoSzegedi != null ? elsoSzegedi.Name : "Nincs szegedi hallgató.");
        }

        // 29. Az egyetlen "Lakatos Kata" nevű hallgató (Single/SingleOrDefault),
        //     majd egy olyan eset kipróbálása try-catch-csel, ahol több találat van.
        static void Feladat29()
        {
            Console.WriteLine("--------------------------------------------------");
            var kata = SampleData.Students.SingleOrDefault(s => s.Name == "Lakatos Kata");
            Console.WriteLine($"Találat: {kata?.Name}");

            try
            {
                // Szándékosan hibára futunk: több hallgató átlaga is > 3.0
                var tobbTalalat = SampleData.Students.Single(s => s.GradeAverage > 3.0);
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Kivétel elkapva (Single hibára futott): {ex.Message}");
            }
        }

        // 30. A 3. indexű (0-tól) hallgató (ElementAt).
        static void Feladat30()
        {
            Console.WriteLine("--------------------------------------------------");
            var harmadikIndexu = SampleData.Students.ElementAtOrDefault(3);
            Console.WriteLine($"A 3. indexű hallgató: {harmadikIndexu?.Name}");
        }

        // ---------- 9. Particionálás — Skip, Take, SkipWhile, TakeWhile, Chunk ----------

        // 31. TOP 3 hallgató átlag szerint (Take).
        static void Feladat31()
        {
            Console.WriteLine("--------------------------------------------------");
            var top3 = SampleData.Students.OrderByDescending(s => s.GradeAverage).Take(3);
            foreach (var item in top3)
            {
                Console.WriteLine(item);
            }
        }

        // 32. Az első 3 utáni hallgatók (Skip).
        static void Feladat32()
        {
            // TODO
        }

        // 33. Életkor szerint rendezve: TakeWhile (21 évnél fiatalabbak), majd SkipWhile (a többi).
        static void Feladat33()
        {
            // TODO
        }

        // 34. Hallgatók felbontása 4 fős csoportokra (Chunk).
        static void Feladat34()
        {
            // TODO
        }

        // ---------- 10. Egyéb — Any, All, Contains, ToDictionary, ToHashSet, DefaultIfEmpty ----------

        // 35. Van-e hallgató 2.5 alatti átlaggal (Any).
        static void Feladat35()
        {
            // TODO
        }

        // 36. Minden hallgató 18 évesnél idősebb-e (All).
        static void Feladat36()
        {
            // TODO
        }

        // 37. Szerepel-e "Pécs" a városok között (Contains).
        static void Feladat37()
        {
            // TODO
        }

        // 38. Dictionary<int, string> a hallgatók Id-je és neve alapján (ToDictionary).
        static void Feladat38()
        {
            // TODO
        }

        // 39. HashSet<string> a kurzuskategóriákból (ToHashSet).
        static void Feladat39()
        {
            // TODO
        }

        // 40. Nem létező kurzushoz tartozó beiratkozások, DefaultIfEmpty kezeléssel.
        static void Feladat40()
        {
            // TODO
        }
    }
}
