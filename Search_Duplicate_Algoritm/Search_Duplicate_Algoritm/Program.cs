using System;
using System.Collections.Generic;
using System.Linq;

namespace Search_Duplicate_Algoritm
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] { 1,1,2,2,3,4,4,5,5,6,7,7,8,8,9,10,11,12,13,14,15,15,16,16,17,17,18,19,20 };
            var duplicate = Search_Duplicate(arr);
            foreach (var item in duplicate)
            {
                Console.WriteLine(item);
            }
        }

        public static IEnumerable<int> Search_Duplicate(int [] arr)
        {
            HashSet<int> duplicate = new HashSet<int>();
            HashSet<int> all = new HashSet<int>();
            for (int i = 0; i < arr.Length; i++)
            {
                var check = all.Add(arr[i]);
                if (!check)
                    duplicate.Add(arr[i]);

            }

            return duplicate;
        }
    }
}
