namespace MojoMVC.Infrastructure
{
    public interface IFilePathProvider
    {
        string MapPath(string path);
    }
}