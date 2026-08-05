using TMPro;
using UnityEngine;

public class BoardCell : MonoBehaviour
{
    public int row;
    public int col;
    public TextMeshProUGUI content;

    public void Click()
    {
        GameManager.Instance.ClickCell(content, row, col);
    }
}
