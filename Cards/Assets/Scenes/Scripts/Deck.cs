using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Deck : MonoBehaviour
{
    ///<summary>
    ///������Deck���Q�b�g
    /// </summary>
    public static List<Card> GetDeck()
    {
        var deck = new List<Card>();

        for (int i = 0; i < 52; i++)
        {
            deck.Add(new Card(Card.CardSuitJudge(i), Card.CardNumJudge(i)));
        }
        return deck;
    }

    ///<summary>
    ///�J�[�h��Deck������擾
    /// </summary>
    public static Card GetCard(List<Card> deck)
    {
        Card card = deck.First();
        deck.RemoveAt(0);
        return card;
    }
}
