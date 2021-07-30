using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace Einkaufsliste
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        [MaxLength(255)]
        public string Name { get; set; }
        public int Age { get; set; }
    }
}