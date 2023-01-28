namespace Sorting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] arr = { 18, 18, 12, 46, 20, 78 };

            selectionSort(arr, arr.Length);
            printArray(arr, arr.Length);

            insertionSort(arr, arr.Length);
            printArray(arr, arr.Length);

            bubbleSort(arr, arr.Length);
            printArray(arr, arr.Length);

            shellSort(arr, arr.Length);
            printArray(arr, arr.Length);

            quickSort(arr, 0, arr.Length - 1);
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }

            heapSort(arr, arr.Length);
            printArray(arr, arr.Length); 
        }

        private static int[] heapSort(int[] array, int size)
        {
            if (size <= 1)
                return array;
            for (int i = size / 2 - 1; i >= 0; i--)
            {
                Heapify(array, size, i);
            }
            for (int i = size - 1; i >= 0; i--)
            {
                var tempVar = array[0];
                array[0] = array[i];
                array[i] = tempVar;
                Heapify(array, i, 0);
            }

            return array;
        }

        static void Heapify(int[] array, int size, int index)
        {
            var largestIndex = index;
            var leftChild = 2 * index + 1;
            var rightChild = 2 * index + 2;
            if (leftChild < size && array[leftChild] > array[largestIndex])
            {
                largestIndex = leftChild;
            }
            if (rightChild < size && array[rightChild] > array[largestIndex])
            {
                largestIndex = rightChild;
            }
            if (largestIndex != index)
            {
                var tempVar = array[index];
                array[index] = array[largestIndex];
                array[largestIndex] = tempVar;
                Heapify(array, size, largestIndex);
            }
        }

        private static void mergeSort(int[] array, int left, int right)
        {
            if (left < right)
            {
                int middle = left + (right - left) / 2;
                mergeSort(array, left, middle);
                mergeSort(array, middle + 1, right);
                MergeArray(array, left, middle, right);
            }
        }

        private static void MergeArray(int[] array, int left, int middle, int right)
        {
            var leftArrayLength = middle - left + 1;
            var rightArrayLength = right - middle;
            var leftTempArray = new int[leftArrayLength];
            var rightTempArray = new int[rightArrayLength];
            int i, j;
            for (i = 0; i < leftArrayLength; ++i)
                leftTempArray[i] = array[left + i];
            for (j = 0; j < rightArrayLength; ++j)
                rightTempArray[j] = array[middle + 1 + j];
            i = 0;
            j = 0;
            int k = left;
            while (i < leftArrayLength && j < rightArrayLength)
            {
                if (leftTempArray[i] <= rightTempArray[j])
                {
                    array[k++] = leftTempArray[i++];
                }
                else
                {
                    array[k++] = rightTempArray[j++];
                }
            }
            while (i < leftArrayLength)
            {
                array[k++] = leftTempArray[i++];
            }
            while (j < rightArrayLength)
            {
                array[k++] = rightTempArray[j++];
            }
        }

        private static void quickSort(int[] array, int leftIndex, int rightIndex)
        {
            var i = leftIndex;
            var j = rightIndex;
            var pivot = array[leftIndex];
            while (i <= j)
            {
                while (array[i] < pivot)
                {
                    i++;
                }

                while (array[j] > pivot)
                {
                    j--;
                }
                if (i <= j)
                {
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    i++;
                    j--;
                }
            }

            if (leftIndex < j)
                quickSort(array, leftIndex, j);

            if (i < rightIndex)
                quickSort(array, i, rightIndex);
        }

        private static void selectionSort(int[] numbers, int size)
        {
            int min;
            int temp;

            for (int i = 0; i < size - 1; i++)
            {
                min = i;

                for (int j = i + 1; j < size; j++)
                {
                    if (numbers[j] < numbers[min])
                    {
                        min = j;
                    }
                }
                    temp = numbers[i];
                    numbers[i] = numbers[min];
                    numbers[min] = temp;
            }
        }

        private static void insertionSort(int[] numbers, int size)
        {
            int j;
            int temp;

            for (int i = 1; i < size; i++)
            {
                temp = numbers[i];
                j = i;

                while ((j > 0) && (numbers[j - 1] > temp))
                {
                    numbers[j] = numbers[j - 1];
                    j = j - 1;
                }

                numbers[j] = temp;
            }
        }

        private static void bubbleSort(int[] numbers, int size)
        {
            int temp;
            for (int i = size - 1; i >= 0; i--)
            {
                for (int j = 1; j < i; j++)
                {
                    if (numbers[j - 1] > numbers[j])
                    {
                        temp = numbers[j - 1];
                        numbers[j - 1] = numbers[j];
                        numbers[j] = temp;
                    }
                }
            }
        }

        private static void shellSort(int[] numbers, int size)
        {
            for (int i = size/2; i > 0; i/=2)
            {
                for (int j = i; j < size; j++)
                {
                    int temp = numbers[j];
                    int k;

                    for (k = j; k >= i && numbers[k-i] > temp; k -= i)
                    {
                        numbers[k] = numbers[k - i];
                    }

                    numbers[k] = temp;
                }
            }
        }

        private static void printArray(int[] numbers, int size)
        {
            for (int i = 0; i < size; i++) 
            {
                Console.WriteLine(numbers[i]);
            } 
        }
    }
}