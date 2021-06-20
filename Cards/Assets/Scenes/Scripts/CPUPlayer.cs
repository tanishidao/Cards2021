using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CPUPlayer : MonoBehaviour
{
    public Bet Bet;//Bet関数にBetのスクリプトぶちこんだる
    public List<Card> CPUHand = new List<Card>();
    public int[] CardChanges = new int[5];

    public bool CardDone= false;

     private void Start()
    {
        ResetCardChanges();// メソッド呼び出し
    }

public void CardChangeChoice(int changeNUm)
    {
        for(int i = 0; i < CardChanges.Length; i++) 
        {
            if(CardChanges[i] == -1)
            {
                CardChanges[i] = changeNUm;
                break;
            }
        }
    }

    public void ResetCardChanges()
    {
        for (int i = 0; i < CardChanges.Length; i++)
        {
            CardChanges[i] = -1;
        }
    
    
    }
    public void CPUChipBet(int BetNum)
    {
        Bet.ChipBet(BetNum, false);
    }

}
