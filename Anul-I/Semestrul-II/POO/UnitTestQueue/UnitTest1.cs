using Microsoft.VisualStudio.TestTools.UnitTesting;
using Queue;
using System;

namespace UnitTestQueue
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void QueueCircular_EnqueuesCorrectly()
        {
            // Arrange

            QueueCircular<string> myQueue = new QueueCircular<string>();

            // Act

            myQueue.Enqueue("Test");

            // Assert

            Assert.AreEqual("Test", myQueue.GetQueue()[0]);
        }

        [TestMethod]
        public void QueueCircular_DequeuesCorrectly()
        {
            // Arrange

            QueueCircular<string> myQueue = new QueueCircular<string>();

            // Act

            myQueue.Enqueue("Test1");
            myQueue.Enqueue("Test2");
            myQueue.Dequeue();

            // Assert

            Assert.AreEqual("Test2", myQueue.GetQueue()[0]);
        }

        [TestMethod]
        public void QueueCircular_EnqueueLimit()
        {
            // Arrange

            QueueCircular<string> myQueue = new QueueCircular<string>();

            // Act

            myQueue.Enqueue("Test1");
            myQueue.Enqueue("Test2");
            myQueue.Enqueue("Test3");
            myQueue.Enqueue("Test4");
            myQueue.Enqueue("Test5");
            myQueue.Enqueue("Test6");

            // Assert

            Assert.AreEqual(myQueue.GetQueue().Count, 5);
        }

        [TestMethod]
        public void QueueCircular_DequeueLimit()
        {
            // Arrange

            QueueCircular<string> myQueue = new QueueCircular<string>();

            // Act

            myQueue.Dequeue();

            // Assert

            Assert.AreEqual(0, myQueue.GetQueue().Count);
        }

        [TestMethod]
        public void QueueChained_EnqueuesCorrectly_BeforeLimit()
        {
            // Arrange

            QueueChained<int> myQueue = new QueueChained<int>();

            // Act

            myQueue.Enqueue(4);

            // Assert

            Assert.AreEqual(4, myQueue.GetQueue()[0]);
        }

        [TestMethod]
        public void QueueChained_DequeuesCorrectly_BeforeLimit()
        {
            // Arrange

            QueueChained<int> myQueue = new QueueChained<int>();

            // Act

            myQueue.Enqueue(4);
            myQueue.Enqueue(64);
            myQueue.Dequeue();

            // Assert

            Assert.AreEqual(0, myQueue.GetQueue()[0]);
        }

        [TestMethod]
        public void QueueChained_EnqueuesCorrectly_AfterLimit()
        {
            // Arrange

            QueueChained<int> myQueue = new QueueChained<int>();

            // Act

            myQueue.Enqueue(4);
            myQueue.Enqueue(64);
            myQueue.Enqueue(4);
            myQueue.Enqueue(64);
            myQueue.Enqueue(4);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Enqueue(5);

            // Assert

            Assert.AreEqual(5, myQueue.GetQueue()[0]);
        }

        [TestMethod]
        public void QueueChained_DequeuesCorrectly_AfterLimit()
        {
            // Arrange

            QueueChained<int> myQueue = new QueueChained<int>();

            // Act

            myQueue.Enqueue(4);
            myQueue.Enqueue(64);
            myQueue.Enqueue(4);
            myQueue.Enqueue(64);
            myQueue.Enqueue(4);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Enqueue(5);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();

            // Assert

            Assert.AreEqual(0, myQueue.GetQueue()[0]);
        }

        [TestMethod]
        public void QueueChained_EnqueueLimit_BeforeLimit()
        {
            // Arrange

            QueueChained<int> myQueue = new QueueChained<int>();

            // Act

            myQueue.Enqueue(4);
            myQueue.Enqueue(64);
            myQueue.Enqueue(45);
            myQueue.Enqueue(641);
            myQueue.Enqueue(21);
            myQueue.Enqueue(7);

            // Assert

            Assert.AreEqual(4, myQueue.GetQueue()[0]);
            Assert.AreEqual(64, myQueue.GetQueue()[1]);
            Assert.AreEqual(45, myQueue.GetQueue()[2]);
            Assert.AreEqual(641, myQueue.GetQueue()[3]);
            Assert.AreEqual(21, myQueue.GetQueue()[4]);
        }

        [TestMethod]
        public void QueueChained_DequeueLimit_BeforeLimit()
        {
            // Arrange

            QueueChained<int> myQueue = new QueueChained<int>();

            // Act

            myQueue.Dequeue();

            // Assert

            Assert.AreEqual(0, myQueue.GetQueue()[0]);
            Assert.AreEqual(0, myQueue.GetQueue()[1]);
            Assert.AreEqual(0, myQueue.GetQueue()[2]);
            Assert.AreEqual(0, myQueue.GetQueue()[3]);
            Assert.AreEqual(0, myQueue.GetQueue()[4]);
        }

        [TestMethod]
        public void QueueChained_EnqueueLimit_AfterLimit()
        {
            // Arrange

            QueueChained<int> myQueue = new QueueChained<int>();

            // Act

            myQueue.Enqueue(4);
            myQueue.Enqueue(64);
            myQueue.Enqueue(4);
            myQueue.Enqueue(64);
            myQueue.Enqueue(21);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);
            myQueue.Enqueue(7);

            // Assert
      
            Assert.AreEqual(4, myQueue.GetQueue()[2]);
            Assert.AreEqual(64, myQueue.GetQueue()[3]);
            Assert.AreEqual(21, myQueue.GetQueue()[4]);
            Assert.AreEqual(5, myQueue.GetQueue()[0]);
            Assert.AreEqual(6, myQueue.GetQueue()[1]);
        }

        [TestMethod]
        public void QueueChained_DequeueLimit_AfterLimit()
        {
            // Arrange

            QueueChained<int> myQueue = new QueueChained<int>();

            // Act

            myQueue.Enqueue(4);
            myQueue.Enqueue(64);
            myQueue.Enqueue(4);
            myQueue.Enqueue(64);
            myQueue.Enqueue(4);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Enqueue(5);
            myQueue.Enqueue(6);
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();
            myQueue.Dequeue();

            // Assert

            Assert.AreEqual(0, myQueue.GetQueue()[0]);
            Assert.AreEqual(0, myQueue.GetQueue()[1]);
            Assert.AreEqual(0, myQueue.GetQueue()[2]);
            Assert.AreEqual(0, myQueue.GetQueue()[3]);
            Assert.AreEqual(0, myQueue.GetQueue()[4]);
        }
    }
}
