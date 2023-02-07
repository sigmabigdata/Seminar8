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

Dictionary<int, int> Slovar = new Dictionary<int, int>();
int[,] matrix = InitMatrix(4, 4);
for (int i = 0; i < matrix.GetLength(0); i++)
{
    for (int j = 0; j < matrix.GetLength(1); j++)
    {
        if(Slovar.ContainsKey(matrix[i,j]))
            Slovar[matrix[i,j]] = Slovar[matrix[i,j]] + 1;
        else
            Slovar.Add(matrix[i,j], 1);
    }
}

PrintMatrix(matrix);

foreach (var item in Slovar.OrderBy(x=>x.Key))
{
    Console.WriteLine($"{item.Key} встречается {item.Value} раз");
}