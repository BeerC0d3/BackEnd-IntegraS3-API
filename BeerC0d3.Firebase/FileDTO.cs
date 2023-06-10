using System.ComponentModel.DataAnnotations;

namespace BeerC0d3.Firebase
{
    public class FileDTO
    {
        [Required(ErrorMessage = "This field is required")]
        [MinLength(5, ErrorMessage = "A minimum of 5 characters is required")]
        public string File { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(5, ErrorMessage = "A minimum of 5 characters is required")]
        public string FileName { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [MinLength(5, ErrorMessage = "A minimum of 5 characters is required")]
        public string FolderName { get; set; }
    }
}