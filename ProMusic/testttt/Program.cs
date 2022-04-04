using System;
using System.Collections.Generic;
using System.Linq;

namespace testttt
{
    class Program
    {
        static void Main(string[] args)
        {
            Categoiry guitar = new Categoiry(1, "Git", false);
            Categoiry keys = new Categoiry(2, "keys", false);
            Categoiry acustinc = new Categoiry(3, "acustinc", true);
            acustinc.CategoryId = 1;
            Categoiry classic = new Categoiry(4, "classic", true);
            classic.CategoryId = 1;
            Categoiry piano = new Categoiry(5, "piano", true);
            piano.CategoryId = 2;


            List<Categoiry> categories = new List<Categoiry>()
            {
                guitar, keys, acustinc, classic, piano
            };

            List<Categoiry> catDtos = new List<Categoiry>();

            catDtos.AddRange(categories.AsQueryable().Where(n => !n.IsSub).ToList());

            foreach (var item in catDtos)
            {
                item.Subs.AddRange(categories.AsQueryable().Where(n => n.CategoryId == item.Id && n.IsSub));
            }

            foreach (var item in catDtos)
            {
                Console.WriteLine(item.Subs.Count);
            }

        }
    }

    public class Categoiry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsSub { get; set; }
        public int? CategoryId { get; set; }
        public List<Categoiry> Subs { get; set; } = new List<Categoiry>();


        public Categoiry(int id, string name, bool isSub)
        {
            Id = id;
            Name = name;
            IsSub = isSub;
        }
    }

    public class CatDto
    {
        public int CatId { get; set; }
        public string CatName { get; set; }
        public bool IsSub { get; set; }
        public List<Categoiry> Subs { get; set; }
    }
}
