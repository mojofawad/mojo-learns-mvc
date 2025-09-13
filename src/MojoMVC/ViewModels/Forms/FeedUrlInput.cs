using System.ComponentModel.DataAnnotations;

namespace MojoMVC.ViewModels.Forms
{
    public class FeedUrlInput
    {
        [Required]
        [DataType(DataType.Url)]
        public string FeedUrl { get; set; }
    }
}