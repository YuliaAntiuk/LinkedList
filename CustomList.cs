#pragma warning disable IDE0090 

namespace LinkedList
{
    public class CustomLinkedList
    {
        private Node head;
        private int _count;
        public int Count
        {
            get
            {
                if (_count <= 0) return 0;
                else return _count;
            }
            private set
            {
                _count = value;
            }
        }
        public CustomLinkedList()
        {
            head = null;
            Count = 0;
        }

        public CustomLinkedList(short[] elements)
        {
            foreach (short element in elements)
            {
                AddToEnd(element);
            }
        }
        public short this[int index]
        {
            get
            {
                int currentIndex = 0;
                Node current = head;
                while (current != null)
                {
                    if (currentIndex == index)
                    {
                        return current.Data;
                    }
                    current = current.Next;
                    currentIndex++;
                }
                throw new IndexOutOfRangeException();
            }
        }
        public Node GetLastNode()
        {
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            return current;
        }
        public void AddToEnd(short data)
        {
            Node newNode = new Node(data);
            Count++;
            if (head == null)
            {
                head = newNode;
                return;
            }
            else
            {
                Node last = GetLastNode();
                last.Next = newNode;
            }
        }

        public void Remove(short data)
        {
            if (head == null)
                return;

            if (head.Data == data)
            {
                head = head.Next;
                Count--;
                return;
            }

            Node current = head;
            while (current.Next != null)
            {
                if (current.Next.Data == data)
                {
                    current.Next = current.Next.Next;
                    Count--;
                    return;
                }
                current = current.Next;
            }
        }

        public int FindFirstMultiple(short multipleOf)
        {
            if (multipleOf == 0)
            {
                throw new ArgumentException("Parameter 'multipleOf' cannot be zero.", nameof(multipleOf));
            }
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (current.Data != multipleOf && current.Data % multipleOf == 0)
                {
                    return index;
                }
                current = current.Next;
                index++;
            }
            return -1;
        }
        public void ReplaceEvenPositions()
        {
            Node current = head;
            int index = 0;
            while (current != null)
            {
                if (index % 2 == 0)
                {
                    current.Data = 0;
                }
                current = current.Next;
                index++;
            }
        }
        public CustomLinkedList GetValuesGreaterThan(short value)
        {
            CustomLinkedList newList = new CustomLinkedList();
            Node current = head;
            while (current != null)
            {
                if (current.Data > value)
                {
                    newList.AddToEnd(current.Data);
                }
                current = current.Next;
            }
            return newList;
        }
        public void RemoveOddPositions()
        {
            if (head == null || head.Next == null)
                return;

            Node current = head.Next;
            Node previous = head;
            int index = 1;

            while (current != null)
            {
                if (index % 2 != 0)
                {
                    previous.Next = current.Next;
                    current = current.Next;
                    Count--;
                }
                else
                {
                    previous = current;
                    current = current.Next;
                }
                index++;
            }
        }
    }
}