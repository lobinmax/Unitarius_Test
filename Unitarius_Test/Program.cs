using System;
using System.Collections.Generic;
using System.Linq;

namespace Unitarius_Test
{
    internal static class Program
    {
        private const int ArraySize = 15;

        private static void Main()
        {
            var array = new int[ArraySize];
            array.FillArray();

            array.ConsoleArray();

            array.ShiftToLeft(4);

            Console.ReadLine();
        }

        public static void ShiftToLeft(this IList<int> array, int shiftSize)
        {
            if (array == null)
            {
                throw new ArgumentNullException(nameof(array));
            }

            shiftSize %= array.Count();
            if (!array.Any() || array.Count() <= shiftSize || shiftSize < 1)
            {
                return;
            }

            Console.WriteLine($"\nЦикл - 1");
            ReverseArrayPart(array, 0, shiftSize - 1);

            Console.WriteLine($"\nЦикл - 2");
            ReverseArrayPart(array, shiftSize, array.Count - 1);

            Console.WriteLine($"\nЦикл - 3");
            ReverseArrayPart(array, 0, array.Count - 1);
        }

        private static void ReverseArrayPart(this IList<int> array, int startIndex, int endIndex)
        {
            for (var curIndex = startIndex; curIndex <= (startIndex + endIndex) / 2; curIndex++)
            {
                var interationIndex = (startIndex + endIndex) - curIndex;
                if (interationIndex == curIndex) { break; }

                var tempValue = array[interationIndex];
                array[interationIndex] = array[curIndex];
                array[curIndex] = tempValue;

                ConsoleArray(array);
            }
        }

        private static void FillArray(this IList<int> list, bool isRandom = false)
        {
            for (var i = 0; i < list.Count; i++)
            {
                list[i] = isRandom 
                    ? new Random().Next(10, 100) 
                    : i + 1;
            }
        }

        private static void ConsoleArray(this IEnumerable<int> a)
        {
            a.ToList().ForEach(x => Console.Write($"{x} "));
            Console.WriteLine();
        }

    }
}
