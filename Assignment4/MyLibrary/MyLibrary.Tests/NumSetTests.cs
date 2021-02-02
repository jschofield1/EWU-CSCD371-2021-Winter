using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace MyLibrary.Tests
{
    [TestClass]
    public class NumSetTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void NumSet_PassesNullArgumentsToConstructor_ThrowsArgumentNullException()
        {
            //Assign

            //Act
            _ = new NumSet(null!);

            //Assert
        }

        [TestMethod]
        public void NumSet_PassesArrayToConstructor_AssignsArrayToHashSet()
        {
            //Assign
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            NumSet numSet = new NumSet(array);

            //Act
            _ = new HashSet<int>(array);

            //Assert
            Assert.IsNotNull(numSet.MySet);
        }

        [TestMethod]
        public void ToString_TakesHashSet_ReturnsStringOfHashSet()
        {
            //Assign
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            NumSet numSet = new NumSet(array);

            //Act
            string arrayToString = numSet.ToString();

            //Assert
            Assert.AreEqual(arrayToString, "1, 2, 3, 4, 5");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToString_TakesNullHashSet_ThrowsArgumentNullException()
        {
            //Assign
            NumSet? numSet = new NumSet
            {
                MySet = null
            };

            //Act
            _ = numSet.ToString();

            //Assert
        }

        [TestMethod]
        public void Equals_PassesDifferentNumSets_ReturnsFalse()
        {
            //Assign
            int[] array1 = new int[] { 1, 2, 3, 4, 5 };
            int[] array2 = new int[] { 6, 7, 8, 9, 10 };
            NumSet numSet1 = new NumSet(array1);
            NumSet numSet2 = new NumSet(array2);

            //Act

            //Assert
            Assert.IsFalse(numSet1.Equals(numSet2));
        }

        [TestMethod]
        public void Equals_PassesTheSameNumSet_ReturnsTrue()
        {
            //Assign
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            NumSet numSet = new NumSet(array);

            //Act

            //Assert
            Assert.IsTrue(numSet.Equals(numSet));
        }

        [TestMethod]
        public void Equals_PassesNonNumSetObject_ReturnsFalse()
        {
            //Assign
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            NumSet numSet = new NumSet(array);
            object obj = new object();

            //Act

            //Assert
            Assert.IsFalse(numSet.Equals(obj));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Equals_PassesNullArray_ThrowsArgumentNullException()
        {
            //Assign
            int[] array1 = new int[] { 1, 2, 3, 4, 5 };
            int[] array2 = new int[] { 6, 7, 8, 9, 10 };
            NumSet numSet1 = new NumSet(array1);
            NumSet numSet2 = new NumSet(array2);
            numSet1.MySet = null;

            //Act
            _ = numSet1.Equals(numSet2);

            //Assert
        }

        [TestMethod]
        public void GetHashCode_TakesNumSet_ReturnsCorrectHashCode()
        {
            //Assign
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            NumSet numSet1 = new NumSet(array);
            NumSet numSet2 = numSet1;

            //Act
            int hashCode1 = numSet1.GetHashCode();
            int hashCode2 = numSet2.GetHashCode();

            //Assert
            Assert.IsTrue(hashCode1 == hashCode2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetHashCode_TakesNullNumSet_ThrowsArgumentNullException()
        {
            //Assign
            NumSet numSet = new NumSet
            {
                MySet = null
            };

            //Act
            _ = numSet.GetHashCode();

            //Assert
        }

        [TestMethod]
        public void EqualityOperators_ComparesEqualAndUnequalNumSets_ReturnsExpectedBools()
        {
            //Assign
            int[] array1 = new int[] { 1, 2, 3, 4, 5 };
            int[] array2 = new int[] { 6, 7, 8, 9, 10 };
            
            NumSet numSet1 = new NumSet(array1);
            NumSet numSet2 = new NumSet(array2);
            NumSet? numSet3 = null;
            NumSet? numSet4 = null;

            //Act

            //Assert
            Assert.IsTrue(numSet3! == numSet4!);
            Assert.IsTrue(numSet1 != numSet2);
            Assert.IsFalse(null! == numSet1);
            Assert.IsFalse(numSet1! == null!);
        }

        [TestMethod]
        public void ReturnArray_TakesHashSet_ReturnsIntArray()
        {
            //Assign
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            NumSet numSet = new NumSet(array);

            //Act
            int[] returnArray = numSet.ReturnArray();

            //Assert
            CollectionAssert.AreEqual(array, returnArray);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ReturnArray_TakesNullHashSet_ThrowsArgumentNullException()
        {
            //Assign
            int[] array = new int[] { 1, 2, 3, 4, 5 };
            NumSet numSet = new NumSet(array)
            {
                MySet = null
            };

            //Act
            numSet.ReturnArray();

            //Assert
        }
    }
}
