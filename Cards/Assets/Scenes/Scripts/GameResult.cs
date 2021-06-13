using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class GameResult : MonoBehaviour
{
    public TextMeshProUGUI ResultText;

    public void GameResultTextView(bool IsWin)
    {
        if(IsWin)
        {
            ResultText.SetText($"YOU WIN");
        }
        else
        {
            ResultText.SetText($"YOU LOSE...");
        }
    }
}
