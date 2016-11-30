using System;
using System.Collections.Generic;
using Task02.Logic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            //Test Int32 binary
            int[] testDataInt32Default = new int[] {10, 18, 48, 2, 3, 4, 21, 36, 54, 11, 17, 20};
            BinarySearchTree<int> testInt32Default = new BinarySearchTree<int>(testDataInt32Default);
            Console.WriteLine($"Is empty - {testInt32Default.IsEmpty}");
            Console.WriteLine($"Contains '21' - {testInt32Default.Contains(21)}");
            Console.WriteLine("InOrder");
            foreach (var item in testInt32Default.InOrderEnumerator())
            {
                Console.WriteLine(item);
            }
            foreach (var item in testDataInt32Default)
            {
                testInt32Default.Remove(item);
            }
            Console.WriteLine($"Is empty - {testInt32Default.IsEmpty}");
            //

            string[] testDataStringDefault = new[] {"a", "h", "f", "g", "t", "b", "c", "y"};
            BinarySearchTree<string> testStringDefault = new BinarySearchTree<string>(testDataStringDefault,
                Comparer<string>.Default);
            Console.WriteLine(testStringDefault.IsEmpty);
            foreach (var item in testStringDefault.PreOrderEnumerator())
            {
                Console.WriteLine(item);
            }

            Book[] testDataBookComparision = new Book[]
            {
                new Book("clr Via c#", "Richter", "program", 2015, 6),
                new Book("Net pro perfomance", "Goldshtein", "program", 2016, 5),
                new Book("Solaris", "Lem", "Fantastic", 1961, 1),
                new Book("TLOTR", "Tolkien", "Fantasy", 1940, 1),
                new Book("fake", "fake", "fake", 5, 5)
            };
            BinarySearchTree<Book> testBookComparision = new BinarySearchTree<Book>(testDataBookComparision,BookComparision);
            foreach (var item in testBookComparision.InOrderEnumerator())
            {
                Console.WriteLine(item);
            }
            IComparer<Point> test = null;
            Point[] testPoints = new Point[] {new Point(5,5),new Point(8,8),new Point(1,1),new Point(3,3),new Point(9,9),new Point(7,7),new Point(6,6),new Point(2,2),new Point(4,4)};
            BinarySearchTree<Point> testPointSearchTree = new BinarySearchTree<Point>(testPoints,PointComparision);
            foreach (var item in testPointSearchTree.InOrderEnumerator())
            {
                Console.WriteLine(item.X);
            }
            Console.ReadLine();
        }

        public static int BookComparision(Book x, Book y)
        {
            if (x.Year > y.Year) return 1;
            if (x.Year < y.Year) return -1;
            return 0;
        }

        public static int PointComparision(Point x, Point y)
        {
            if (x.X > y.Y) return 1;
            if (x.X < y.Y) return -1;
            return 0;
        }
    }
}
