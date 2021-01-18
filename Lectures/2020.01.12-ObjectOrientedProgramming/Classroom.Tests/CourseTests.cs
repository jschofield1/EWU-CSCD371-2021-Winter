using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Classroom.Tests
{
    [TestClass]
    public class CourseTests
    {
        [TestMethod]
        public void Name_GivenCalculus_ReturnCalculus()
        {
            Course course = new ("Calculus");
            Assert.AreEqual("Calculus", course.Name);
        }

        [TestMethod]
        public void Name_ChangeName_Success()
        {
#pragma warning disable IDE0017 // We want to change the name so not initializing it correctly
#pragma warning disable IDE0090 // Left for demo purposes
            Course course = new Course("Calculus");
#pragma warning restore IDE0090 // Left for demo purposes
#pragma warning restore IDE0017 // We want to change the name so not initializing it correctly
            course.Name = "History 101";
            Assert.AreEqual("History 101", course.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_SetToNullInConstructor_ThrowArgumentNullException()
        {
            try
            {
                _ = new Course(null!);
            }
            catch(ArgumentNullException exception)
            {
                Assert.AreEqual("value", exception.ParamName);
                throw;
            }
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Name_SetToNullViaProperty_ThrowArgumentNullException()
        {
            try
            {
                Course course = new ("Calculus");
                course.Name = null!;
            }
            catch (ArgumentNullException exception)
            {
                Assert.AreEqual("value", exception.ParamName);
                throw;
            }
        }

        [TestMethod]
        public void Description_SetDescription_Success()
        {
            Course course = new("Essential C#");
            course.Description = "The bestest course given Mike and Kevin are the instructors.";
        }

        [TestMethod]
        public void StringStuff()
        {
            string text1 = string.Format("The Method Name is {0}", nameof(StringStuff));
            string text2 = $"The Method Name is { nameof(StringStuff) }";
            Assert.AreEqual(text1, text2);
        }
    }
}
