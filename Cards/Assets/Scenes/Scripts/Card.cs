using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Card
{
    public Suit CardSuit;
    public int CardNumber;

    /// <summary>
    /// �N���u��_�C���Ȃǂ̐���
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
    /// �ق��̃X�N���v�g����A�N�Z�X���₷�����邽�߂Ɏ����ō쐬����Suit�^�̕ϐ�
    /// </summary>
    public static Suit CardSuitJudge(int cardNum)
    {
        int suitNumber = 0;
        //CardNum���������]�����������������enum�^��Suit�ɃL���X�g���ĕԂ��܂�
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
        //CardNumber�����������܂��\�����܂�
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
