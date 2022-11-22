// Задайте прямоугольный двумерный массив. Напишите программу, 
// которая будет находить строку с наименьшей суммой элементов.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// Программа считает сумму элементов в каждой строке и выдаёт
// номер строки с наименьшей суммой элементов: 1 строка

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

int[,] SumStrArray(int[,] array)
{
    int[,] newArray = new int[array.GetLength(0), 1];
    for (int i = 0; i < array.GetLength(0); i++)
    {
        int sum = 0;
        for (int j = 0; j < array.GetLength(1); j++)
        {
            sum += array[i, j];
        }
        newArray[i, 0] = sum;
    }
    return newArray;
}

int NumberMinStr(int[,] array)
{
    int min = 0;
    for (int i = 0; i < array.GetLength(0); i++)
    {
        if (array[min, 0] > array[i, 0])
        {
            min = i;
        }
    }
    return min + 1;
}

void Runner()
{
    int rows = Prompt("Введите количество строк массива: ");
    int columns = Prompt("Введите количество столбцов массива: ");
    int min = Prompt("Введите минимальное число массива: ");
    int max = Prompt("Введите максимальное число массива: ");
    Console.WriteLine();
    int[,] array = CreateArray(rows, columns, min, max);
    int[,] sumStrArray = SumStrArray(array);
    PrintArray(array);
    // Console.WriteLine($"Суммы строк массива:\n");
    // PrintArray(sumStrArray);
    Console.Write($"Номер строки с наименьшей суммой элементов: {NumberMinStr(sumStrArray)} строка");
}

Runner();