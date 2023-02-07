/*Задача 55: Задайте двумерный массив. Напишите программу, 
которая заменяет строки на столбцы. В случае, если это невозможно, 
программа должна вывести сообщение для пользователя.
*/

int GetNumber(string message)
{
    int result =0;

    while (true)
    {
        Console.WriteLine(message);

        if(int.TryParse(Console.ReadLine(), out result) && result > 0)
            break;
        else
            Console.WriteLine("Вы ввелин не корректное число. Повторите ввод"); 
    }

    return result;
}

int [,] InitMatrix(int rows, int columns)
{
    int [,] matrix = new int [rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = rnd.Next(0, 10);
        }
    }
    return matrix;
}

void PrintMatrix(int [,] matrix)
{
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            Console.Write($"{matrix[i,j]} ");
        }
        Console.WriteLine();
    }
}

int [,] TransporationMatrix(int [,] matrix)
{
    int[,] newMatrix = new int[matrix.GetLength(1), matrix.GetLength(0)];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            newMatrix [j, i] = matrix[i,j];
        }
    }
    return newMatrix;
}

int rows = GetNumber("Введите количество строк: ");
int columns = GetNumber("Введите количество столбцов: ");
int [,] matrix = InitMatrix(rows, columns);
PrintMatrix(matrix);
Console.WriteLine();
int [,] finalMatrix = TransporationMatrix(matrix);
PrintMatrix(finalMatrix);