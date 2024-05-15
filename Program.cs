using LinkedList;

namespace ListManual
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CustomLinkedList lst = new CustomLinkedList(new short[] { 2, 8, 5, 9, 7, 1 });
            PrintList(lst);
            int multIndex = lst.FindFirstMultiple(2);
            Console.WriteLine(multIndex);

            short mult = lst[multIndex];
            Console.WriteLine(mult);

            //lst.ReplaceEvenPositions();
            //lst.RemoveOddPositions();
            //PrintList(lst);

            CustomLinkedList greater = lst.GetValuesGreaterThan(5);
            PrintList(greater);
        }
        static void PrintList(CustomLinkedList lst)
        {
            for(int i = 0; i < lst.Count; i++)
            {
                Console.Write(lst[i] + " ");
            }
            Console.WriteLine();
        }
    }
}