using System;

namespace IndexRange.Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            //Indices

            //The System.Index provides feature to provide index of a sequence.
            //And it is represented by new operator ^
            //For an array ^ 0 = array.Length

            //So, for the index of last item in the array, we will use ^ 1 which is equal to array.Length - 1
            var arr = new[] { 1, 3, 5, 7, 9, 11, 13, 15 };

            //Traditional way of access the last item of a array
            Console.WriteLine($"Last item: {arr[arr.Length - 1]}");

            //The new way
            Console.WriteLine($"Last item: {arr[^1]}");


            //Ranges

            //The System.Range is used to extract part of an array
            //And it is represented by new range operator ..

            //A range specifies the start index and the end index of an array
            //The start index is inclusive, where as the end index is not

            //var newArr = arr[3..];
            //var newArr = arr[3..7];
            //var newArr = arr[..7];
            //var newArr = arr[..];
            var newArr = arr[^5..5];

            foreach (var item in newArr)
            {
                Console.WriteLine($"Item in the new array: {item}");
            }

        }
    }
}
