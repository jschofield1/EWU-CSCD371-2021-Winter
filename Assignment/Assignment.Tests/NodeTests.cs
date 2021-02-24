using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Assignment.Tests
{
    [TestClass]
    public class NodeTests
    {
        [TestMethod]
        public void GetArrayLength_CreateMultipleNodes_ArrayEqualsExpectedLength()
        {
            Node<int> node = new Node<int>(1);

            node.Insert(2);

            Assert.AreEqual<int>(2, node.Count);
        }

        [TestMethod]
        public void IsReadOnly_ChecksIfNodeIsReadOnly_ReturnsFalse_()
        {
            Node<int> node = new Node<int>(1);

            Assert.IsFalse(node.IsReadOnly);
        }

        [TestMethod]
        public void Node_PassesDifferentDataTypes_NodesWithDifferentTypesAreCreated()
        {
            Node<int> first = new Node<int>(1);
            Node<double> second = new Node<double>(2.0);
            Node<string> third = new Node<string>("three");
            Node<char> fourth = new Node<char>('4');

            Assert.AreEqual<int>(1, first.Value);
            Assert.AreEqual<double>(2.0, second.Value);
            Assert.AreEqual<string>("three", third.Value);
            Assert.AreEqual<char>('4', fourth.Value);
        }

        [TestMethod]
        public void Node_CreateTwoNodesWithDifferentValues_NodesAreNotEqual()
        {
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);

            Assert.AreNotEqual<Node<int>>(first, second);
        }

        [TestMethod]
        public void Node_ConstructNewNodeWithNext_ConstructsNextNodeAfterHead()
        {
            Node<int> node = new Node<int>(1);
            Node<int> nextNode = node.Next;

            Assert.AreEqual<Node<int>>(node, nextNode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ToString_PassesNullNode_ThrowsArgumentNullException()
        {
            Node<string> node = new Node<string>(null!);

            node.ToString();
        }

        [TestMethod]
        public void ToString_PassesDifferentDataTypes_ReturnsValuesAsStrings()
        {
            int intNum = 1;
            double dblNum = 2.0;
            string strNum = "three";
            char chrNum = '4';

            Node<int> first = new Node<int>(intNum);
            Node<double> second = new Node<double>(dblNum);
            Node<string> third = new Node<string>(strNum);
            Node<char> fourth = new Node<char>(chrNum);

            Assert.AreEqual<string>(intNum.ToString(), first.ToString());
            Assert.AreEqual<string>(dblNum.ToString(), second.ToString());
            Assert.AreEqual<string>(strNum.ToString(), third.ToString());
            Assert.AreEqual<string>(chrNum.ToString(), fourth.ToString());
        }

        [TestMethod]
        public void Insert_InsertNewNodeOnHead_NextOnLastNodeLoopsToHead()
        {
            Node<int> node = new Node<int>(1);

            node.Insert(2);

            Assert.AreEqual<int>(1, node.Value);
            Assert.AreEqual<int>(2, node.Next.Value);
            Assert.AreEqual<int>(1, node.Next.Next.Value);
        }

        [TestMethod]
        public void ChildItems_InsertsNumberOfNodesExceedingMaximum_ReturnsEnumerableSizeOfMaximum()
        {
            Node<int> node = new(0);
            int count = 0;

            for (int i = 1; i < 10; i++)
                node.Insert(i);

            IEnumerable<int> child = node.ChildItems(7);

            foreach (int num in child)
            {
                Assert.AreEqual<int>(count, num);
                count++;
            }
            Assert.AreEqual(count, 7);
        }

        [TestMethod]
        public void ChildItems_InsertsNumberOfNodesLessThanMaximum_ReturnsEnumerableSmallerThanMaximum()
        {
            Node<int> node = new(0);
            int count = 0;

            for (int i = 1; i < 10; i++)
                node.Insert(i);

            IEnumerable<int> child = node.ChildItems(42);

            foreach (int num in child)
            {
                Assert.AreEqual<int>(count, num);
                count++;
            }
            Assert.AreEqual(count, 10);
        }

        [TestMethod]
        public void Clear_ClearsArrayOnHead_OnlyHeadRemains()
        {
            Node<int> node = new Node<int>(1);

            node.Insert(2);
            node.Insert(3);
            node.Clear();

            Assert.AreEqual<int>(1, node.Value);
            Assert.AreEqual<int>(1, node.Next.Value);
        }

        [TestMethod]
        public void Contains_ChecksNodeForSpecificValue_ReturnsTrue()
        {
            Node<int> node = new Node<int>(1);

            Assert.IsTrue(node.Contains(1));
        }

        [TestMethod]
        public void CopyTo_CopyValuesToArray_ArrayHoldsExpectedValues()
        {
            int[] copiedArray = new int[3];
            int[] expectedArray = { 1, 2, 3 };

            Node<int> node = new Node<int>(1);

            node.Insert(2);
            node.Insert(3);
            node.CopyTo(copiedArray, 0);

            Assert.AreEqual<string>($"{expectedArray}", $"{copiedArray}");
        }

        [TestMethod]
        public void GetEnumerator_ForeachToIterate_AddsExpectedValues()
        {
            Node<int> first = new Node<int>(1);
            Node<int> second = new Node<int>(2);

            foreach (int item in first)
            {
                second.Insert(item);
            }
            Assert.AreEqual<string>("2 1", $"{second} {second.Next}");
        }
    }
}
