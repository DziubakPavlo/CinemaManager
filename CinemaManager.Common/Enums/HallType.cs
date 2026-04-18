using System.ComponentModel.DataAnnotations;

namespace CinemaManager.Common.Enums
{
    //Types of cinema halls
    public enum HallType
    {
        [Display(Name = "2D")]
        TwoD,
        [Display(Name = "3D")]
        ThreeD,
        [Display(Name = "IMAX")]
        IMAX
    }
}
