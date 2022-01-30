using System;
using System.Collections.Generic;

#nullable disable

namespace Peliculas.Models
{
    public partial class Peli
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Director { get; set; }
        public string Genero { get; set; }
        public string Puntuacion { get; set; }
        public string Rating { get; set; }
        public DateTime FechaPublicacion { get; set; }
    }
}
