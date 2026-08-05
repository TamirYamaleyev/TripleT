using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] cells;
    [SerializeField] private List<Strike> strikes = new();

    void Start()
    {
        Reset();
    }

    public void Reset()
    {
        ResetCells();
        ResetStrikes();
    }

    private void ResetCells()
    {
        foreach (var cell in cells)
        {
            cell.text = "";
        }
    }

    private void ResetStrikes()
    {
        foreach (Strike strike in strikes)
        {
            strike.image.gameObject.SetActive(false);
        }
    }

    public void SetCell(TextMeshProUGUI cell, string text)
    {
        cell.text = text;
    }

    public void SetStrike(StrikeType strikeType)
    {
        foreach (var strike in strikes)
        {
            if (strike.type == strikeType)
            {
                strike.image.gameObject.SetActive(true);
                return;
            }
        }
    }
}