using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PokerManager : MonoBehaviour
{
   public  enum GameState
    {
        Init = 0,
        Start,
        Deal,
        Bet,
        CardChange,
        ShowDown,
        Result
    }

    public GameState gameState = GameState.Init;

    public Dealer Dealer;
    public Player Player;
    public CPUPlayer CPUPlayer;
    public Chip chip;
    private void Update()
    {
        switch (gameState)
        {
            case GameState.Init:
                //初期化するものがあれば初期化してStartへ
                gameState = GameState.Start;
                break;
            case GameState.Start:
                //Startの時にしたいことを書く、終わればDealへ
                gameState = GameState.Deal;
                break;
            case GameState.Deal:
                //Dealの時にしたいこと書く終わればBetへ
                Dealer.CardDeal();
                Dealer.CardView();
                gameState = GameState.Bet;
                break;
            case GameState.Bet:
                //Betの時にしたいこと書く終わればCardChangeへ
                Player.PlayerChipBet(1);
                CPUPlayer.CPUChipBet(1);
                gameState = GameState.CardChange;
                break;
            case GameState.CardChange:
                //CardChangeのときにしたいこと書く終わればShowDown
               if(Player.CardChange)
                {
                    Dealer.CardChange(Player.CardChanges);
                    Dealer.CardView();
                    gameState = GameState.ShowDown;
                }
               
                break;
            case GameState.ShowDown:
                //ShowDownの時にしたいこと書く終わればResultへ
                Dealer.GameJudge();
                gameState = GameState.Result;
                break;
            case GameState.Result:
                break;



        }
    }
}
