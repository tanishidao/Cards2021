using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class Dealer : MonoBehaviour///Ç±ÇÍÇ™Ç†ÇÈÇ∆íPàÍÇ≈ìÆçÏÇ≈Ç´ÇÈÇ‡ÇÃÇ—
{

    public const int DealNum = 5;
    public List<Card> GameDeck = new List<Card>();
    
    public List<Card> PlayerHand = new List<Card>();
    public List<Card> EnemyHand = new List<Card>();
   
    public Image[] Playercards = new Image[5];
    public Image[] EnemyCards = new Image[5];
    
    public SpriteAtlas spriteAtlas;
    public GameResult GameResult;
    public GameObject ShowDeal = null ;
    
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
        if(GameDeck.Count < DealNum)
        {
            GameDeck.Clear();
            GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
        }
        for(int i = 0; i < DealNum; i++)
        {
            PlayerHand.Add(Deck.GetCard(GameDeck));
        }
        for(int i = 0; i < PlayerHand.Count; i++)
        {
           Playercards[i].sprite = spriteAtlas.GetSprite($"Card_{(int)PlayerHand[i].CardSuit * 13 + PlayerHand[i].CardNumber - 1}");
            Debug.Log($"{PlayerHand[i].CardSuit}:{PlayerHand[i].CardNumber}");
        }
        Debug.Log($"é©ï™ÇÃéËéDÇÕ{PokerHand.CardHand(PlayerHand)}");
        Text ShowDealText = ShowDeal.GetComponent<Text>();
        ShowDealText.text = "ShowÅc";

        EnemyHand.Clear();
        if(GameDeck.Count > DealNum)
        {
            GameDeck.Clear();
            GameDeck = Deck.ShuffleDeck(Deck.GetDeck());
        }
        for(int i = 0; i < DealNum; i++)
        {
            EnemyHand.Add(Deck.GetCard(GameDeck));
        }
    for(int i = 0; i < EnemyHand.Count; i++)
        {
            EnemyCards[i].sprite = spriteAtlas.GetSprite(
                $"Card_{(int)EnemyHand[i].CardSuit * 13 + EnemyHand[i].CardNumber - 1}");
        Debug.Log($"{EnemyHand[i].CardSuit}:{EnemyHand[i].CardNumber}");
        }
        Debug.Log($"ëäéËÇÃéËíiÇÕ{ PokerHand.CardHand(EnemyHand)}");
        GameResult.GameResultTextView(PokerHand.CardHand(EnemyHand) < PokerHand.CardHand(PlayerHand));///éÆÇæÇØÇ≈Ç‡boolïœêîÇÕê¨ÇËóßÇ¬
    }

}
