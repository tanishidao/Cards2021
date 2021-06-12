using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Dealer : MonoBehaviour///‚±‚ê‚ª‚ ‚é‚Æ’Pˆê‚Å“®ì‚Å‚«‚é‚à‚Ì‚Ñ
{

    public const int PlayerDealNum = 5;
    public List<Card> GameDeck = new List<Card>();
    public List<Card> PlayerHand = new List<Card>();

    public Image[] cards = new Image[5];
    public SpriteAtlas spriteAtlas;
    
    private void Start()
    {
        GameDeck = Deck.ShuffleDeck(Deck.GetDeck());


    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CardDeal();
        }
    }

    private void CardDeal()
    {
        PlayerHand.Clear();
        if(GameDeck.Count > PlayerDealNum)
        {
            GameDeck.Clear();
            GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
        }
        for(int i = 0; i < PlayerDealNum; i++)
        {
            PlayerHand.Add(Deck.GetCard(GameDeck));
        }
        for(int i = 0; i < PlayerHand.Count; i++)
        {
           cards[i].sprite = spriteAtlas.GetSprite($"Card_{(int)PlayerHand[i].CardSuit * 13 + PlayerHand[i].CardNumber - 1}");
            Debug.Log($"{PlayerHand[i].CardSuit}:{PlayerHand[i].CardNumber}");
        }
        Debug.Log(PokerHand.CardHand(PlayerHand));
    }

}
