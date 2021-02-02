using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLibrary.Writer;
using System.IO;
using System;

namespace MyLibrary.Tests.Writer
{
    [TestClass]
    public class SetWriterTests
    {
        [TestMethod]
        public void StreamWriter_PassesFilePath_CreatesNewStreamWriter()
        {
            //Assign
            string filePath = Path.GetTempFileName();
            SetWriter setWriter = new SetWriter(filePath);

            //Act

            //Assert
            Assert.IsNotNull(setWriter.FileWriter);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetWriter_PassesNullNumSet_ThrowsArgumentNullException()
        {
            //Assign

            //Act
            _ = new SetWriter(null!);

            //Assert
        }

        [TestMethod]
        public void WriteSet_WritesNumSetToFile_NumSetOnFileMatches()
        {
            //Assign
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            NumSet numSet = new NumSet(array);
            string filePath = Path.GetTempFileName();
            SetWriter setWriter = new SetWriter(filePath);

            //Act
            setWriter.WriteSet(numSet);
            setWriter.Dispose();

            //Assert
            Assert.AreEqual(File.ReadAllText(filePath), "1, 2, 3, 4, 5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteSet_PassesNullArgument_ThrowsArgumentNullException()
        {
            //Assign
            string filePath = Path.GetTempFileName();
            SetWriter setWriter = new SetWriter(filePath);
            NumSet numSet = new NumSet
            {
                MySet = null
            };

            //Act
            setWriter.WriteSet(numSet);

            //Assert
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WriteSet_TakesNullFileWriter_ThrowsArgumentNullException()
        {
            //Assign
            string filePath = Path.GetTempFileName();
            int[] testArray = new int[] { 1, 2, 3, 4, 5 };
            SetWriter setWriter = new SetWriter(filePath);
            NumSet numSet = new NumSet(testArray);
            
            //Act
            setWriter.FileWriter = null;
            setWriter.WriteSet(numSet);

            //Assert
        }
    }
}
