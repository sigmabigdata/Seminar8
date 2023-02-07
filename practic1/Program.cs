int[,] InitMatrix(int rows, int columns)
{
    int[,] matrix = new int[rows, columns];
    Random rnd = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i,j] = rnd.Next(1, 10);
        }
    }

    return matrix;
}

void PrintMatrix(int[,] matrix)
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

void SwapRows(int [,] matrix)
{
    int i = 0;
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        i = matrix[0,j];
        matrix[0, j] = matrix[matrix.GetLength(0)-1, j];
        matrix[matrix.GetLength(0)-1, j] = i;
    }
}
int rows = 4;
int columns = 4;
int [,] matrix = InitMatrix(rows,columns);
PrintMatrix(matrix);
SwapRows(matrix);
Console.WriteLine();
PrintMatrix(matrix);