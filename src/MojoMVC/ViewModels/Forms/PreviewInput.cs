using System.ComponentModel.DataAnnotations;

namespace MojoMVC.ViewModels.Forms
{
    public class PreviewInput
    {
        [Required]
        [DataType(DataType.Url)]
        public string FeedUrl { get; set; }
    }
}