// Задайте две матрицы. Напишите программу, которая будет 
// находить произведение двух матриц.
// Например, даны 2 матрицы:
// 2 4 | 3 4
// 3 2 | 3 3
// Результирующая матрица будет:
// 18 20
// 15 18

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

int[,] MultArray(int[,] a, int[,] b)
{

    int[,] c = new int[a.GetLength(0), b.GetLength(1)];
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < b.GetLength(1); j++)
        {
            for (int k = 0; k < b.GetLength(0); k++)
            {
                c[i, j] += a[i, k] * b[k, j];
            }
        }
    }
    return c;
}

void Runner()
{
    int rows = Prompt("Введите количество строк массива: ");
    int columns = Prompt("Введите количество столбцов массива: ");
    int[,] array1 = CreateArray(rows, columns, 1, 9);
    int[,] array2 = CreateArray(rows, columns, 1, 9);
    PrintArray(array1);
    PrintArray(array2);
    if (array1.GetLength(1) != array2.GetLength(0))
    {
        Console.WriteLine("Матрицы нельзя перемножить");
    }
    else
    {
        int[,] multArray = MultArray(array1, array2);
        Console.WriteLine($"Результирующая матрица:\n");
        PrintArray(multArray);
    }
}

Runner();