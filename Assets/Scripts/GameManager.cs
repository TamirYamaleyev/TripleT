using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private UIController interfaceManager;

    [SerializeField] private string playerX = "X";
    [SerializeField] private string playerO = "O";

    private string currentPlayer;
    public string CurrentPlayer => currentPlayer;

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
    }

    public void ClickCell(TextMeshProUGUI cell)
    {
        interfaceManager.SetCell(cell, currentPlayer);
    }
}
