using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;

namespace RazorMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [EnumDataType(typeof(MovieGenre))]
        public MovieGenre Genre { get; set; }
        [EnumDataType(typeof(MovieRating))]
        public MovieRating Rating { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        
        public enum MovieGenre
        {
            Action,
            Fantasy,
            [Display(Name = "Sci-Fi/Adventure")]
            SciFiAdventure,
            [Display(Name = "Fantasy/Sci-Fi")]
            FantasySciFi,
            Horror,
            Thriller,
            Western,
            Comedy,
            [Display(Name = "Romatic Comedy")]
            RomanticComedy
        }

        public enum MovieRating
        {
            R,
            PG,
            [Display(Name = "PG-13")]
            PG13
        }
    }
}
