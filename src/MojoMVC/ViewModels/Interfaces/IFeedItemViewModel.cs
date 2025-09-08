namespace MojoMVC.ViewModels.Interfaces
{
    public interface IFeedItemViewModel
    {
        string Title { get; set; }
        string Description { get; set; }
        string Link { get; set; }
        string Guid { get; set; }
        string PublishedDate { get; set; }
    }
}