namespace MojoMVC.Infrastructure
{
    public class FilePathProvider : IFilePathProvider
    {
        public string MapPath(string path)
        {
            return System.Web.HttpContext.Current.Server.MapPath(path);
        }
    }
}