using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Logger.Tests
{
    [TestClass]
    public class LogFactoryTests
    {
        [TestMethod]
        public void ConfigureFileLogger_AssignBadFilePath_ReturnsNull()
        {
            //Arrange
            LogFactory logFactory = new LogFactory();

            //Act
            BaseLogger? logger = logFactory.CreateLogger("BadFilePath");

            //Assert
            Assert.IsNull(logger);
        }
    }
}
