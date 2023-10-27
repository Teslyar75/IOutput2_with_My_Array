/*Завдання 2
Створіть інтерфейс IOutput2. У ньому мають бути
два методи:
■ void ShowEven() — відображає парні значення контейнера з даними;
■ void ShowOdd() — відображає непарні значення контейнера з даними.
Клас, створений раніше у практичному завданні Array,
має імплементувати інтерфейс IOutput2.
Метод ShowEven — відображає парні значення з
масиву.
Метод ShowOdd — відображає непарні значення
масиву.
Напишіть код для тестування отриманої функціональності.*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOutput2_with_My_Array
{
    interface ICalc
    {
        int Less(int valueToCompare);
        int Greater(int valueToCompare);
    }

    interface IOutput2
    {
        void ShowEven();
        void ShowOdd();
    }

    class MyArray2D : ICalc, IOutput2
    {
        private int[,] array;

        public int Rows { get; }
        public int Columns { get; }

        public MyArray2D(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
            array = new int[Rows, Columns];
        }

        public int this[int i, int j]
        {
            get
            {
                if (i >= 0 && i < Rows && j >= 0 && j < Columns)
                {
                    return array[i, j];
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
            set
            {
                if (i >= 0 && i < Rows && j >= 0 && j < Columns)
                {
                    array[i, j] = value;
                }
                else
                {
                    throw new IndexOutOfRangeException();
                }
            }
        }

        public void FillRandom()
        {
            Random random = new Random();
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    array[i, j] = random.Next(1, 101);
                }
            }
        }

        public void Print()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }

        public void SetElement(int i, int j, int value)
        {
            this[i, j] = value;
        }

        public int Less(int valueToCompare)
        {
            int count = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (array[i, j] < valueToCompare)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public int Greater(int valueToCompare)
        {
            int count = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (array[i, j] > valueToCompare)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        public void ShowEven()
        {
            Console.WriteLine("Четные элементы массива:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (array[i, j] % 2 == 0)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
        }

        public void ShowOdd()
        {
            Console.WriteLine("Нечетные элементы массива:");
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    if (array[i, j] % 2 != 0)
                    {
                        Console.Write(array[i, j] + "\t");
                    }
                }
                Console.WriteLine();
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество строк: ");
            int rows = int.Parse(Console.ReadLine());

            Console.Write("Введите количество столбцов: ");
            int columns = int.Parse(Console.ReadLine());

            MyArray2D my_Massive = new MyArray2D(rows, columns);
            my_Massive.FillRandom();
            my_Massive.Print();

            Console.WriteLine("\nВведите координаты элемента и его новое значение:");
            Console.Write("i: ");
            int i = int.Parse(Console.ReadLine());
            Console.Write("j: ");
            int j = int.Parse(Console.ReadLine());
            Console.Write("Значение: ");
            int value = int.Parse(Console.ReadLine());

            my_Massive.SetElement(i, j, value);

            Console.WriteLine("\nМассив после изменения:");
            my_Massive.Print();

            Console.Write("Введите значение для сравнения: ");
            int valueToCompare = int.Parse(Console.ReadLine());

            int lessCount = my_Massive.Less(valueToCompare);
            int greaterCount = my_Massive.Greater(valueToCompare);

            Console.WriteLine($"Количество элементов меньше {valueToCompare}: {lessCount}");
            Console.WriteLine($"Количество элементов больше {valueToCompare}: {greaterCount}");

            my_Massive.ShowEven();
            my_Massive.ShowOdd();

            Console.ReadKey();
        }
    }
}
