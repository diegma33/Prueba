using SQLite;
using System;

namespace Prueba.Models
{
    public class Team
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public String name { get; set; }
        public String imgPath { get; set; }
    }
}
