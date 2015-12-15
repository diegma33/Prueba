using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
