using System.IO;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;

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
        public void GetFeedTitle()
        {
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location));
            
            // Arrange
            var parser = new RssParser();
            
            // Act
            var title = parser.GetFeedTitle(testData);
            
            // Assert
            Assert.AreEqual("RSS Title", title);
        }

        [TestMethod]
        public void GetFeedItems()
        {
            // Arrange
            var parser = new RssParser();
            
            // Act
            var items= parser.GetFeedItems(testData);
            
            // Assert
            Assert.AreEqual(2, items.Count);
            Assert.AreEqual(items[0].Title, "Example entry");
            Assert.AreEqual(items[1].Title, "Mojo's entry");
        }

        [TestMethod]
        public void GetRssFeed()
        {
            // Arrange
            var parser = new RssParser();
            
            // Act
            var feed = parser.GetRssFeed(testData);
            
            // Assert
            Assert.AreEqual(feed.Title, "RSS Title");
            Assert.AreEqual(feed.Description, "This is an example of an RSS feed");
            Assert.AreEqual(feed.Link, "http://www.example.com/main.html");
        }
    }
}