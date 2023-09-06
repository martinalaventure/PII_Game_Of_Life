using System;
using System.Threading;

namespace PII_Game_Of_Life
{
    public class GameOfLife //Coordinator
{
    private bool[,] currentGeneration;
    private readonly BoardLoader boardLoader;
    private readonly GameLogic gameLogic;
    private readonly Printer consoleRenderer;

    public GameOfLife(BoardLoader boardLoader, GameLogic gameLogic, Printer consoleRenderer)
    {
        this.boardLoader = boardLoader;
        this.gameLogic = gameLogic;
        this.consoleRenderer = consoleRenderer;
    }

    public void Start(string filePath)
    {
        currentGeneration = boardLoader.LoadBoardFromFile(filePath);

        while (true)
        {
            Console.Clear();
            consoleRenderer.Print(currentGeneration);

            currentGeneration = gameLogic.CalculateNextGeneration(currentGeneration);

            Thread.Sleep(300);
        }
    }
}
}