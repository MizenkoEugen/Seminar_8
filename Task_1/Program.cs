// Задайте двумерный массив. Напишите программу, которая упорядочит 
// по убыванию элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 7 4 2 1
// 9 5 3 2
// 8 4 4 2

int Prompt(string message)
{
    Console.WriteLine(message);
    int number = Convert.ToInt32(Console.ReadLine());
    return number;
}

int[,] CreateArray(int rows, int columns, int min, int max)
{
    int[,] array = new int[rows, columns];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            array[i, j] = new Random().Next(min, max + 1);
        }
    }
    return array;
}

void PrintArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            Console.Write($"{array[i, j]} ");
        }
        Console.WriteLine();
    }
    Console.WriteLine();
}

int[,] SortArray(int[,] array)
{
    for (int i = 0; i < array.GetLength(0); i++)
    {
        for (int j = 0; j < array.GetLength(1); j++)
        {
            for (int k = 0; k < array.GetLength(1) - 1; k++)
            {
                if (array[i, k] < array[i, k + 1])
                {
                    // int temp = array[i, k];
                    // array[i, k] = array[i, k + 1];
                    // array[i, k + 1] = temp;
                    (array[i, k], array[i, k + 1]) = (array[i, k + 1], array[i, k]);
                }
            }
        }
    }
    return array;
}

void Runner()
{
    int rows = Prompt("Введите количество строк массива: ");
    int columns = Prompt("Введите количество столбцов массива: ");
    int min = Prompt("Введите минимальное число массива: ");
    int max = Prompt("Введите максимальное число массива: ");
    int[,] array = CreateArray(rows, columns, min, max);
    PrintArray(array);
    Console.WriteLine($"В итоге получается вот такой массив:\n");
    int[,] sortArray = SortArray(array);
    PrintArray(sortArray);
}

Runner();