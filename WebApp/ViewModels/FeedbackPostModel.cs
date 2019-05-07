using System.ComponentModel.DataAnnotations;

namespace WebApp.ViewModels
{
    public class FeedbackPostModel
    {
        [Required(ErrorMessage = "Please write something...")]
        [MinLength(5, ErrorMessage = "Please write just a little bit more...")]
        public string Description { get; set; }
    }
}