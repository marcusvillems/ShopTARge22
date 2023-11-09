using System.ComponentModel.DataAnnotations;

namespace ShopTARge22.Models.ChuckNorris
{
    public class SearchChuckNorrisJokeViewModel
    {
        [Required(ErrorMessage = "You must enter a valid category.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Only text is allowed.")]
        [StringLength(20,MinimumLength =2, ErrorMessage = "Enter a category, what is greater than 2 and lesser than 20 letters")]
        [Display(Name ="ChuckNorris")]

        public string JokeName { get; set; }
    }
}
