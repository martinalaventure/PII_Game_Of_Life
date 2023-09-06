using System;
using System.Text;

namespace PII_Game_Of_Life 
{
    public class Printer //Structurer
{
    public void Print(bool[,] board)
    {
        StringBuilder output = new StringBuilder();

        for (int y = 0; y < board.GetLength(1); y++)
        {
            for (int x = 0; x < board.GetLength(0); x++)
            {
                if (board[x, y])
                {
                    output.Append("|X|");
                }
                else
                {
                    output.Append("___");
                }
            }
            output.AppendLine();
        }

        Console.WriteLine(output);
    }
}
}