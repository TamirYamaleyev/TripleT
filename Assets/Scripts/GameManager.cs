using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private CommandInvoker commandInvoker;

    [SerializeField] private UIController interfaceManager;
    private Board gameBoard;

    [SerializeField] private string playerX = "X";
    [SerializeField] private string playerO = "O";

    private string currentPlayer;
    public string CurrentPlayer => currentPlayer;

    private int xWinCount = 0;
    private int oWinCount = 0;

    public static GameManager Instance { get; private set; }

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        currentPlayer = playerX;
        gameBoard = new Board();
    }

    public void ResetWins()
    {
        xWinCount = 0;
        oWinCount = 0;
        interfaceManager.UpdateOWins(xWinCount);
        interfaceManager.UpdateXWins(oWinCount);
    }

    public void ResetGame()
    {
        gameBoard.ResetBoard();
        commandInvoker.ClearHistory();

        interfaceManager.Reset();
        currentPlayer = playerX;
    }

    public void UndoMove()
    {
        commandInvoker.UndoLastCommand();

        currentPlayer = currentPlayer == playerX ? playerO : playerX;

        interfaceManager.RefreshBoard(gameBoard);
    }

    public void RedoMove()
    {
        commandInvoker.RedoLastCommand();

        currentPlayer = currentPlayer == playerX ? playerO : playerX;

        interfaceManager.RefreshBoard(gameBoard);
    }

    public void ClickCell(TextMeshProUGUI cell, int row, int col)
    {
        CellState state = currentPlayer == playerX ? CellState.X : CellState.O;

        //gameBoard.SetCell(row, col, state);

        PlaceCellCommand command = new PlaceCellCommand(gameBoard, row, col, state);
        commandInvoker.ExecuteCommand(command);

        interfaceManager.SetCell(cell, currentPlayer);

        StrikeType? strike = gameBoard.CheckWin(state);

        if (strike.HasValue)
        {
            interfaceManager.SetStrike(strike.Value);
            SetWinner(currentPlayer);
        }

        EndTurn();
    }

    private void EndTurn()
    {
        if (currentPlayer == playerX)
            currentPlayer = playerO;
        else
            currentPlayer = playerX;
    }

    private void SetWinner(string winner)
    {
        if (winner == playerX)
        {
            xWinCount++;
            interfaceManager.UpdateXWins(xWinCount);
        }

        else
        {
            oWinCount++;
            interfaceManager.UpdateOWins(oWinCount);
        }

        interfaceManager.ShowWinMessage(winner);
    }
}
