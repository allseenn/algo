using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArraySortTests
{
    public class SortUtils
    {

        /**
         * Сортировка выбором
         *
         *
         * 0 1 2 3 4
         *
         * 5 4 1 0 1
         *
         */
        public static void directSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int saveIndex = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[saveIndex])
                    {
                        saveIndex = j;
                    }
                }

                if (saveIndex != i)
                {
                    int buf = array[i];
                    array[i] = array[saveIndex];
                    array[saveIndex] = buf;
                }

            }
        }

        public static void quickSort(int[] array)
        {
            quickSort(array, 0, array.Length - 1);
        }

        private static void quickSort(int[] array, int start, int end)
        {
            int left = start;
            int right = end;
            int middle = array[(start + end) / 2];

            do
            {

                while (array[left] < middle)
                {
                    left++;
                }

                while (array[right] > middle)
                {
                    right--;
                }

                if (left <= right)
                {
                    if (left < right)
                    {
                        int buf = array[left];
                        array[left] = array[right];
                        array[right] = buf;
                    }
                    left++;
                    right--;
                }
            }
            while (left <= right);

            if (left < end)
            {
                quickSort(array, left, end);
            }
            if (start < right)
            {
                quickSort(array, start, right);
            }

        }

        // Метод для реализации пирамидальной сортировки
        public static void piramidSort(int[] array)
        {
            // Получаем размер массива
            int n = array.Length;

            // Строим кучу из массива
            for (int i = n / 2 - 1; i >= 0; i--)
                heapify(array, n, i);

            // Извлекаем элементы из кучи по одному и помещаем их в конец массива
            for (int i = n - 1; i > 0; i--)
            {
                // Меняем местами первый и последний элементы
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;

                // Восстанавливаем свойства кучи для поддерева с корнем в первом элементе
                heapify(array, i, 0);
            }
        }

        // Метод для преобразования поддерева с корнем в i-м элементе в кучу
        public static void heapify(int[] array, int n, int i)
        {
            // Инициализируем индексы самого большого элемента, левого и правого потомков
            int largest = i;
            int left = 2 * i + 1;
            int right = 2 * i + 2;

            // Если левый потомок больше текущего самого большого элемента, обновляем индекс самого большого элемента
            if (left < n && array[left] > array[largest])
                largest = left;

            // Если правый потомок больше текущего самого большого элемента, обновляем индекс самого большого элемента
            if (right < n && array[right] > array[largest])
                largest = right;

            // Если самый большой элемент не является корнем, меняем местами корень и самый большой элемент
            if (largest != i)
            {
                int swap = array[i];
                array[i] = array[largest];
                array[largest] = swap;

                // Рекурсивно применяем метод к поддереву с корнем в самом большом элементе
                heapify(array, n, largest);
            }
        }



    }

}
