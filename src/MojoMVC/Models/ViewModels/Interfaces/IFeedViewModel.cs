using System.Collections;
using System.Collections.Generic;

namespace MojoMVC.Models.ViewModels.Interfaces
{
    public interface IFeedViewModel
    {
        string Title { get; set; }
        string Description { get; set; }
        string Link { get; set; }
        List<IFeedItemViewModel> FeedItems { get; set; }
    }
}