using UnityEngine;

public class PlaceCellCommand : ICommand
{
    private Board board;
    private int row;
    private int col;
    private CellState newState;
    private CellState oldState;

    public PlaceCellCommand(Board board, int row, int col, CellState state)
    {
        this.board = board;
        this.row = row;
        this.col = col;
        newState = state;

        oldState = board.GetCell(row, col);
    }

    public void Execute()
    {
        oldState = board.GetCell(row, col);
        board.SetCell(row, col, newState);
    }

    public void Undo()
    {
        board.SetCell(row, col, oldState);
    }
}
