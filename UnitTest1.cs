namespace LinkedList
{
    using System;
    using NUnit.Framework;

    namespace List.Tests
    {
        [TestFixture]
        public class CustomLinkedListTests
        {
            private CustomLinkedList CreateList(params short[] values)
            {
                return new CustomLinkedList(values);
            }

            [Test]
            public void ReplaceEvenPositions_WorksCorrectly()
            {
                CustomLinkedList list = CreateList(1, 2, 3, 4, 5);
                list.ReplaceEvenPositions();

                Assert.Multiple(() =>
                {
                    Assert.That(list[0], Is.EqualTo(0));
                    Assert.That(list[1], Is.EqualTo(2));
                    Assert.That(list[2], Is.EqualTo(0));
                    Assert.That(list[3], Is.EqualTo(4));
                    Assert.That(list[4], Is.EqualTo(0));
                    Assert.That(list.Count, Is.EqualTo(5));
                });

            }

            [Test]
            public void ReplaceEvenPositions_EmptyList_NotChange()
            {
                CustomLinkedList list = CreateList();
                list.ReplaceEvenPositions();
                Assert.That(list.Count, Is.EqualTo(0)); 
            }

            [Test]
            public void ReplaceEvenPositions_NegativeElements_WorksCorrectly()
            {
                CustomLinkedList list = CreateList(-1, -2, -3, -4, -5, -6);
                list.ReplaceEvenPositions();
                Assert.Multiple(() =>
                {
                    Assert.That(list[0], Is.EqualTo(0));
                    Assert.That(list[1], Is.EqualTo(-2));
                    Assert.That(list[2], Is.EqualTo(0));
                    Assert.That(list[3], Is.EqualTo(-4));
                    Assert.That(list[4], Is.EqualTo(0));
                    Assert.That(list[5], Is.EqualTo(-6));
                    Assert.That(list.Count, Is.EqualTo(6));
                });
            }

            [Test]
            public void FindFirstMultiple_ReturnsCorrectIndex()
            {
                CustomLinkedList list = CreateList(1, 2, 3, 4, 5);
                short mult = 2;
                int index = list.FindFirstMultiple(mult);

                Assert.That(index, Is.EqualTo(3));
            }

            [Test]
            public void FindFirstMultiple_ReturnsCorrectIndex_NegativeNumber()
            {
                CustomLinkedList list = CreateList(5, -8, 50, 40, -9, 32, -12, 0);
                short mult = -3;
                int index = list.FindFirstMultiple(mult);

                Assert.That(index, Is.EqualTo(4));
            }

            [Test]
            public void FindFirstMultiple_ReturnsCorrectIndex_PositiveNumber()
            {
                CustomLinkedList list = CreateList(5, -8, 50, 40, -9, 32, -12, 0);
                short mult = 3;
                int index = list.FindFirstMultiple(mult);

                Assert.That(index, Is.EqualTo(4));
            }

            [Test]
            public void FindFirstMultiple_ThrowsException_WhenMultipleOfIsZero()
            {
                CustomLinkedList list = CreateList(5, -8, 50, 40, -9, 32, -12, 0);
                short mult = 0;
                Assert.Throws<ArgumentException>(() =>
                {
                    list.FindFirstMultiple(mult);
                });
            }

            [Test]
            public void FindFirstMultiple_WorksCorrectly_NoMultipleFound()
            {
                CustomLinkedList list = CreateList(1, 3, 5, 7, 9);
                short mult = 2;
                int index = list.FindFirstMultiple(mult);

                Assert.That(index, Is.EqualTo(-1));
            }

            [Test]
            public void GetGetValuesGreaterThan_WorksCorrectly()
            {
                CustomLinkedList list = CreateList(-10, 84, 3, 11, -78, 0, 1, 45);
                CustomLinkedList newList = list.GetValuesGreaterThan(3);

                Assert.Multiple(() =>
                {
                    Assert.That(newList[0], Is.EqualTo(84));
                    Assert.That(newList[1], Is.EqualTo(11));
                    Assert.That(newList[2], Is.EqualTo(45));
                    Assert.That(newList.Count, Is.EqualTo(3));
                });
            }

            [Test]
            public void GetGetValuesGreaterThan_WorksCorrectly_WithEmptyList()
            {
                CustomLinkedList list = CreateList();
                list.GetValuesGreaterThan(0);

                Assert.That(list.Count, Is.EqualTo(0));
            }

            [Test]
            public void GetGetValuesGreaterThan_WorksCorrectly_ItemNotInList()
            {
                CustomLinkedList list = CreateList(-10, 84, 3, 11, -78, 0, 1, 45);
                CustomLinkedList newList = list.GetValuesGreaterThan(-5);
                Assert.Multiple(() =>
                {
                    Assert.That(newList[0], Is.EqualTo(84));
                    Assert.That(newList[1], Is.EqualTo(3));
                    Assert.That(newList[2], Is.EqualTo(11));
                    Assert.That(newList[3], Is.EqualTo(0));
                    Assert.That(newList[4], Is.EqualTo(1));
                    Assert.That(newList[5], Is.EqualTo(45));
                    Assert.That(newList.Count, Is.EqualTo(6));
                });
            }

            [Test]
            public void Remove_WorksCorrectly()
            {
                CustomLinkedList list = CreateList(1, 2, 3, 4, 5);
                list.Remove(list[2]);
                Assert.Multiple(() =>
                {
                    Assert.That(list[1], Is.EqualTo(2));
                    Assert.That(list[2], Is.EqualTo(4));
                    Assert.That(list[3], Is.EqualTo(5));
                });
            }

            [Test]
            public void RemoveOddPositions_WorksCorrectly()
            {
                CustomLinkedList list = CreateList(1, 2, 3, 4, 5);
                list.RemoveOddPositions();
                Assert.Multiple(() =>
                {
                    Assert.That(list[0], Is.EqualTo(1));
                    Assert.That(list[1], Is.EqualTo(3));
                    Assert.That(list[2], Is.EqualTo(5));
                    Assert.That(list.Count, Is.EqualTo(3));
                });
            }
        }
    }

}