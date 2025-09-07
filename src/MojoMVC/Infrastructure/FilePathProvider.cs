using System.Web;

namespace MojoMVC.Infrastructure
{
    public class FilePathProvider : IFilePathProvider
    {
        public string MapPath(string path)
        {
            return HttpContext.Current.Server.MapPath(path);
        }
    }
}