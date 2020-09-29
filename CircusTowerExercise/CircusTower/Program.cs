using System;
using System.Collections.Generic;
using System.Linq;

namespace CircusTower
{
    class Program
    {
        static void Main(string[] args)
        {

            //var arrPersons = new int[,] { { 64, 120 }, { 65, 100 }, { 70, 150 }, { 56, 90 }, { 75, 190 }, { 60, 95 }, { 68, 110 } };

            //for (int i = 0; i < arrPersons.Length / 2; i++)
            //{
            //    lstPeople.Add(new Person { Height = arrPersons[i, 0], Weight = arrPersons[i, 1] });
            //}


            List<Person> lstPeople = new List<Person>();
            lstPeople.Add(new Person(64, 120));
            lstPeople.Add(new Person(65, 100));
            lstPeople.Add(new Person(70, 150));
            lstPeople.Add(new Person(56, 90));
            lstPeople.Add(new Person(75, 190));
            lstPeople.Add(new Person(60, 95));
            lstPeople.Add(new Person(68, 110));


            var result = GetTowerOrganized(lstPeople.OrderBy(x => x.Height).ToList());

            Console.WriteLine("Circus Tower");
            Console.WriteLine("");

            foreach (var item in result)
            {
                Console.WriteLine(item.Height + "," + item.Weight);
            }

            Console.ReadKey();
        }

        public static List<Person> GetTowerOrganized(List<Person> lstPeople)
        {
            List<Person> lstResult = new List<Person>();
            lstResult.AddRange(lstPeople);
            int indexAsc = 0;
            int countToCheckIfDiff = 0;

            for (int i = 0; i < lstPeople.Count; i++)
            {
                if (i + 1 < lstPeople.Count)
                {
                    if (lstPeople[i].Weight >= lstPeople[i + 1].Weight)
                    {
                        for (int j = i + 1; j < lstPeople.Count; j++)
                        {
                            if (lstPeople[i].Weight >= lstPeople[j].Weight)
                            {
                                countToCheckIfDiff++;
                            }
                            else
                            {
                                break;
                            }
                        }
                        if (countToCheckIfDiff > 1)
                        {
                            lstResult.Remove(lstPeople.FirstOrDefault(x => x.Height == lstPeople[i].Height && x.Weight == lstPeople[i].Weight));
                        }
                        else
                        {
                            lstResult.Remove(lstPeople.FirstOrDefault(x => x.Height == lstPeople[i + 1].Height && x.Weight == lstPeople[i + 1].Weight));
                        }
                        countToCheckIfDiff = 0;
                    }
                }
                indexAsc++;
            }
            return lstResult;
        }
    }

    public class Person
    {
        public int Weight { get; set; }
        public int Height { get; set; }

        public Person(int height, int weight)
        {
            Height = height;
            Weight = weight;
        }
    }
}