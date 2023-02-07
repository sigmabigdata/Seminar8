/* Задача 59: Задайте двумерный массив из целых чисел. 
Напишите программу, которая удалит строку и столбец, 
на пересечении которых расположен наименьший элемент массива.
Например, задан массив:
1 4 7 2
5 9 2 3
8 4 2 4
5 2 6 7
Наименьший элемент - 1, на выходе получим 
следующий массив:
9 4 2
2 2 6
3 4 7
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

(int, int) FindIndexMinElement(int [,] matrix)
{
    int minI = 0;
    int minJ = 0;
    int minElement = matrix[0,0];

    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(matrix[i,j] < minElement)
            {
                minElement = matrix[i,j];
                minI = i;
                minJ = j;
            }
        }
        
    }
    return (minI, minJ);
}

int [,] FinalMatrix(int [,] matrix, int minI, int minJ)
{
    int [,] newMatrix = new int[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];
    int m = 0;
    int n = 0;
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        if(i == minI) continue;
        n = 0;
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            if(j == minJ) continue;
            else
            {
                newMatrix[m, n] = matrix [i, j];
                n++;
            }
        }
        m++;
    }
    return newMatrix;
}

int rows = GetNumber("Введите количество строк: ");
int columns = GetNumber("Введите количество столбцов: ");
int [,] matrix = InitMatrix(rows, columns);
PrintMatrix(matrix);
Console.WriteLine();

(int minI, int minJ) = FindIndexMinElement(matrix);
int [,] finalMatrix = FinalMatrix(matrix, minI, minJ);
PrintMatrix(finalMatrix);