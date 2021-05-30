using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dealer : MonoBehaviour///これがあると単一で動作できるものび
{
    
    public const int PlayerDealNum = 5;
    public List<Card> GameDeck;
    private void Start()
    {
        GameDeck = Deck.GetDeck();
        for(int i = 0; i < PlayerDealNum; i++)
        {
            Card TakeCard = Deck.GetCard(GameDeck);
            Debug.Log($"{TakeCard.CardSuit}:{TakeCard.CardNumber}");
        }

    }
    
}
