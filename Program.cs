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

            List<Depression> depressions = FindDepressions(arr);

            depressions.ForEach(d => {
                Console.Write(d.Size+ " ");
            });

            Console.ReadKey();
        }

        private static List<Depression> FindDepressions(int[][] arr)
        {
            List<Depression> depressions = new List<Depression>();

            //max teoretical length 
            int maxLength = arr.Max(i => i.Length);
            //we will detect the process of creating depression
            bool inProcess = false;

            Depression depression = new Depression();

            for (int i = 0; i < maxLength; i++)
            {
                for (int j = 0; j < arr.Length; j++)
                {
                    //detect empty place of array
                    if (arr[j].Length-1 < i)
                    {
                        if(inProcess)
                            depressions.Add(depression);
                        inProcess = false;
                        continue;
                    }

                    if (arr[j][i] == 0)
                    {
                        if (inProcess)
                            depression.Increase();
                        else
                            depression = new Depression(1);

                        inProcess = true;

                        if (j == arr.Length - 1)
                        {
                            inProcess = false;
                            depressions.Add(depression);
                        }
                    } 
                    else
                    {
                        if (inProcess)
                        {
                            inProcess = false;
                            depressions.Add(depression);
                        }
                    }
                }
            }

            return depressions.OrderBy(d => d.Size).ToList();
        }
    }
}
