using System.ComponentModel.DataAnnotations;

namespace CinemaManager.Common.Enums
{
    //Genres of movies
    public enum MovieGenre
    {
        [Display(Name = "Animation")]
        Animation,
        [Display(Name = "Horror")]
        Horror,
        [Display(Name = "Comedy")]
        Comedy,
        [Display(Name = "Action")]
        Action,
        [Display(Name = "Science Fiction")]
        ScienceFiction,
        [Display(Name = "Drama")]
        Drama,
        [Display(Name = "Fantasy")]
        Fantasy,
        [Display(Name = "Thriller")]
        Thriller,
        [Display(Name = "Romance")]
        Romance,
        [Display(Name = "Documentary")]
        Documentary
    }
}
