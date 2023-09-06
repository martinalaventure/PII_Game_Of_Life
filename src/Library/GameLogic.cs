namespace PII_Game_Of_Life
{
    public class GameLogic //Information Holder
    {
        public bool[,] CalculateNextGeneration(bool[,] currentGeneration)
        {
            int width = currentGeneration.GetLength(0);
            int height = currentGeneration.GetLength(1);
            bool[,] nextGeneration = new bool[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    int aliveNeighbors = CountAliveNeighbors(currentGeneration, x, y);

                    if (currentGeneration[x, y])
                    {
                        if (aliveNeighbors < 2 || aliveNeighbors > 3)
                        {
                            nextGeneration[x, y] = false; // Muere por baja población o sobrepoblación
                        }
                        else
                        {
                            nextGeneration[x, y] = true; // Sobrevive
                        }
                    }
                    else
                    {
                        if (aliveNeighbors == 3)
                        {
                            nextGeneration[x, y] = true; // Nace por reproducción
                        }
                        else
                        {
                            nextGeneration[x, y] = false; // Sigue muerta
                        }
                    }
                }
            }

            return nextGeneration;
        }

        private int CountAliveNeighbors(bool[,] board, int x, int y)
        {
            int count = 0;
            int width = board.GetLength(0);
            int height = board.GetLength(1);

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (i >= 0 && i < width && j >= 0 && j < height && board[i, j])
                    {
                        count++;
                    }
                }
            }

            if (board[x, y])
            {
                count--; // Descuenta la propia célula si está viva
            }

            return count;
        }
    }
}