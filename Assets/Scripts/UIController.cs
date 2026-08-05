using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEditor.Rendering.LookDev;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI[] cells;
    [SerializeField] private string xText = "X";
    [SerializeField] private string oText = "O";

    [SerializeField] private Dictionary<Image, string> strikeDict;

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
        foreach (KeyValuePair<Image, string> strike in strikeDict)
        {
            strike.Key.gameObject.SetActive(false);
        }
    }

    public void SetCellX(TextMeshProUGUI cell)
    {
        cell.text = xText;
    }

    public void SetCellO(TextMeshProUGUI cell)
    {
        cell.text = oText;
    }

    public void SetStrike(string strikeValue)
    {
        GameObject strikeToEnable = strikeDict.FirstOrDefault(x => x.Value == strikeValue).Key.gameObject;
        strikeToEnable.SetActive(true);
    }
}