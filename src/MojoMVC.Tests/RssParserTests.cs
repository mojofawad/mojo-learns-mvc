using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MojoMVC.Infrastructure;

namespace MojoMVC.Tests
{
    [TestClass]
    public class RssParserTests
    {
        private static readonly string testData = Path.Combine(
            Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? "",
            "test-data",
            "sample-file.xml");

        [TestMethod]
        public void GetRssFeedConvertStreamToRssFeed()
        {
            // Arrange
            var parser = new RssParser();
            using (var stream = new FileStream(testData, FileMode.Open))
            {
                // Act
                var feed = parser.DeserializeFeedFromStream(stream);

                // Assert
                Assert.AreEqual(feed.Title, "RSS Title");
                Assert.AreEqual(feed.Description, "This is an example of an RSS feed");
                Assert.AreEqual(feed.Link, "http://www.example.com/main.html");
            }
        }
    }
}