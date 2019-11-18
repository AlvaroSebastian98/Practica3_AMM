using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Practica3
{
    public class PersonaItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Dni { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string FechaNac { get; set; }
    }
}