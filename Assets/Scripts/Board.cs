using UnityEngine;

public class Board
{
    private CellState[,] gameBoard = new CellState[3,3];
    private int[][] winPatterns =
    {
        new[] {0,1,2}, // RowTop
        new[] {3,4,5}, // RowMiddle
        new[] {6,7,8}, // RowBottom

        new[] {0,3,6}, // ColumnLeft
        new[] {1,4,7}, // ColumnMiddle
        new[] {2,5,8}, // ColumnRight

        new[] {0,4,8}, // DiagonalMain
        new[] {2,4,6} // DiagonalAnti
    };

    public void ResetBoard()
    {
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                gameBoard[row, col] = CellState.Empty;
            }
        }
    }

    private void DebugBoard()
    {
        string output = "";
        for (int row = 0; row < 3; row++)
        {
            for (int col = 0; col < 3; col++)
            {
                if (gameBoard[row, col] == CellState.Empty) output += "[]";
                else output += $"[{gameBoard[row, col]}]";
            }

            output += "\n";
        }

        Debug.Log(output);
    }

    public CellState GetCell(int row, int col)
    {
        return gameBoard[row, col];
    }

    public void SetCell(int row, int col, CellState state)
    {
        gameBoard[row, col] = state;
        DebugBoard();
    }

    public StrikeType? CheckWin(CellState player)
    {
        for (int i = 0; i < winPatterns.Length; i++)
        {
            int[] pattern = winPatterns[i];

            CellState a = gameBoard[pattern[0] / 3, pattern[0] % 3];
            CellState b = gameBoard[pattern[1] / 3, pattern[1] % 3];
            CellState c = gameBoard[pattern[2] / 3, pattern[2] % 3];

            if (a == player && b == player && c == player)
                return (StrikeType)i;
        }

        return null;
    }
}
