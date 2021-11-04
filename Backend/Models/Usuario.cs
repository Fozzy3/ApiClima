using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Backend.Models
{
    public class Usuario
    { 
        public int ID { get; set; }
        public string Ciudad { get; set; }

    }

    public class Inicio
    {
        public int idCiudad { get; set; }
        public string Ciudad { get; set; }
        public string Otro { get; set; }


    }

    public class Guardar
    {
        public string Ciudad { get; set; }
        public string Otro { get; set; }

    }
}