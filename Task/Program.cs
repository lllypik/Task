using System;
using System.Threading;

namespace Task
{
    class Program
    {
        const int stringArray = 20;
        const int columnArray = 20;
        static int[,] gardenScheme = new int[stringArray, columnArray];

        static void Main(string[] args)
        {
            ThreadStart threadStart = new ThreadStart(Gardner2);
            Thread thread = new Thread(threadStart);
            thread.Start();

            Gardner1();

            PrintArray(gardenScheme, stringArray, columnArray);

            Console.ReadKey();
        }


        static void PrintArray(int[,] array, int stringArray, int columnArray) //Метод печати массива

        {
            for (int i = 0; i < stringArray; i++)
            {
                for (int j = 0; j < columnArray; j++)
                {
                    Console.Write(array[i, j]);
                }
                Console.WriteLine();
            }
        }

        static void Gardner2() //Садовник 2 идет снизу-вверх-влево-вниз-влево-вверх

        {
            int i, j;
            bool up = true;
            for (j = columnArray - 1; j >= 0; j--)
            {
                if (up == true)
                {
                    for (i = stringArray - 1; i >= 0; i--)
                    {
                        if (gardenScheme[i, j] == 0) gardenScheme[i, j] = 2;
                        Thread.Sleep(10);
                        //PrintArray(gardenScheme, stringArray, columnArray);
                        //Console.WriteLine();
                    };
                    up = !up;
                }
                else
                {
                    for (i = 0; i < stringArray; i++)
                    {
                        if (gardenScheme[i, j] == 0) gardenScheme[i, j] = 2;
                        Thread.Sleep(10);
                        //PrintArray(gardenScheme, stringArray, columnArray);
                        //Console.WriteLine();
                    };
                    up = !up;
                }
            }
        }

        static void Gardner1() //садовник 1 слева-направ-вниз-налево-вниз-направо...

        {
            int i, j;
            for (i = 0; i <= stringArray - 1; i++)
            {
                if (i % 2 == 0)
                    for (j = 0; j <= columnArray - 1; j++)
                    {
                        if (gardenScheme[i, j] == 0) gardenScheme[i, j] = 1;
                        Thread.Sleep(10);
                        //PrintArray(gardenScheme, stringArray, columnArray);
                        //Console.WriteLine();
                    }
                if (i % 2 == 1)
                    for (j = columnArray - 1; j >= 0; j--)
                    {
                        if (gardenScheme[i, j] == 0) gardenScheme[i, j] = 1;
                        Thread.Sleep(10);
                        //PrintArray(gardenScheme, stringArray, columnArray);
                        //Console.WriteLine();
                    }
            }
        }
    }
}
