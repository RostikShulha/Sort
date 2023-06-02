using System;
using System.Text;


namespace Sort
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int K = 5; // Номер студента

            int N = (int)(20 + 0.6 * K); // Розмір масиву

            int[] array = new int[N];// Заповнення масиву
            Random random = new Random();
            for (int i = 0; i < N; i++)
            {
                array[i] = random.Next(10, 100);
            }

            Console.Write("Початковий масив: "); // Виведення початкового масиву
            for (int i=0; i < N; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            InsertionSort(array);

            Console.Write("Відсортований масив: "); // Виведення відсортованого масиву
            for (int i = 0; i < N; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            Console.Write("Введіть ключове значення: "); // Кключове значення
            int key = int.Parse(Console.ReadLine());

            int binary = BinarySearch(array, key);
            Console.Write("Кількість ключових значень за допомогою бінарного пошуку: " + binary);
            Console.WriteLine();

            int poslidov = PoslidovSearch(array, key);
            Console.Write("Кількість ключових значень за допомогою послідовного пошуку: " + poslidov);
            Console.WriteLine();

            Console.ReadKey();
        }

        static void InsertionSort(int[] array) // Код сортування
        {
            for (int i = 0; i < array.Length; i++)
            {
                int key = array[i];
                int j = i - 1;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;
                }

                array[j + 1] = key;
            }
        }

        static int BinarySearch(int[] array, int key) // Код бінарного пошуку
        {
            int count = 0;
            int left = 0;
            int right = array.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                if (array[mid] == key)
                {
                    count++;
                    left = mid + 1;
                }
                else if (array[mid] < key)
                {
                    left = mid + 1; 
                }
                else
                {
                    right = mid - 1;
                }
            }

            return count;
        }

        static int PoslidovSearch(int[] array, int key)  // Код послідовного
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == key)
                {
                    count++;
                }
            }

            return count;
        }
    }
}
