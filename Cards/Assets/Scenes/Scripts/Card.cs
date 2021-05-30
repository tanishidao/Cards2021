using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card
{
    public Suit CardSuit;
    public int CardNumber;

    /// <summary>
    /// クラブやダイヤなどの数字
    /// </summary>
    public Card(Suit suit, int cardNumber)
    {
        this.CardSuit = suit;
        this.CardNumber = cardNumber;
    }

    ///public GameObject ScoreText;
    public enum Suit
    {
        Invalid = -1,
        Crub,
        Dia,
        Heart,
        Spade,
        Max

    }
    /// <summary>
    /// ほかのスクリプトからアクセスしやすくするために自分で作成したSuit型の変数
    /// </summary>
    public static Suit CardSuitJudge(int cardNum)
    {
        int suitNumber = 0;
        //CardNumを割った余りを除去した数字をenum型のSuitにキャストして返します
        for (int i = 0; i < (int)Suit.Max; i++)
        {
            if (cardNum / 13 == i)
            {
                suitNumber = i;
            }

        }
        return (Suit)suitNumber;
    }

    public static int CardNumJudge(int cardNum)
    {
        int cardNumber = 0;
        //CardNumberを割ったあまりを表示します
        for (int i = 0; i < 13; i++)
        {
            if (cardNum % 13 == i)
            {
                cardNumber = i + 1;
            }
        }
        return cardNumber;
    }

}
