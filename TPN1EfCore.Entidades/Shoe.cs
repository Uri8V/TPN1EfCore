using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TPN1EfCore.Entidades
{
    public class Shoe
    {
        public int ShoeId { get; set; }
        public int BrandId { get; set; }
        public Brand? Brands { get; set; }
        public int SportId { get; set; }
        public Sport? Sports { get; set; }
        public int GenreId { get; set;}
        public Genre? Genres { get; set; }
        public int ColorId { get; set; }
        public Colour? Color { get; set; }
        public string Model { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public decimal Price { get; set; }
    }
}
