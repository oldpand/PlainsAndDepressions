using System;
using System.Collections.Generic;
using System.Linq;

namespace PlainsAndDepressions
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[][]
            {
                new int[] {0,1,0,1,0,0,1},
                new int[] {0,0,1,1,1},
                new int[] {1,0,0,1,0,1,0,0,0,0},
                new int[] {1,0,0,1,0,0,0,0,0,0},
                new int[] {0,0,1,1,0,0,0},
                new int[] {1,0,1,1,0,0,1,0}
            };

            var depressions = FindDepressions(arr);

            foreach (var depression in depressions)
                Console.Write(depression.Size + " ");

            Console.ReadKey();
        }

        private static IOrderedEnumerable<Depression> FindDepressions(int[][] arr)
        {
            //max teoretical length 
            int maxLength = arr.Max(i => i.Length);

            List<Depression> depressions = new List<Depression>();
            Depression depression = new Depression();

            for (int i = 0; i < maxLength; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    //detect empty place of array
                    if (arr[j].Length-1 < i)
                    {
                        if(depression.InProc)
                            depressions.Add(depression);
                        depression.InProc = false;
                        continue;
                    }

                    if (arr[j][i] == 0)
                    {
                        if (depression.InProc)
                            depression++;
                        else
                        {
                            depression = new Depression();
                            depression++;
                        }

                        if (j == arr.Length - 1)
                        {
                            depression.InProc = false;
                            depressions.Add(depression);
                        }
                    } 
                    else
                    {
                        if (depression.InProc)
                        {
                            depression.InProc = false;
                            depressions.Add(depression);
                        }
                    }
                }
            }

            return depressions.OrderBy(d => d.Size);
        }
    }
}
