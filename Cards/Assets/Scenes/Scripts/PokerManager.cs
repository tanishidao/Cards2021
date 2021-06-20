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
                //������������̂�����Ώ���������Start��
                gameState = GameState.Start;
                break;
            case GameState.Start:
                //Start�̎��ɂ��������Ƃ������A�I����Deal��
                gameState = GameState.Deal;
                break;
            case GameState.Deal:
                //Deal�̎��ɂ��������Ə����I����Bet��
                Dealer.CardDeal();
                Dealer.CardView();
                gameState = GameState.Bet;
                break;
            case GameState.Bet:
                //Bet�̎��ɂ��������Ə����I����CardChange��
                Player.PlayerChipBet(1);
                CPUPlayer.CPUChipBet(1);
                gameState = GameState.CardChange;
                break;
            case GameState.CardChange:
                //CardChange�̂Ƃ��ɂ��������Ə����I����ShowDown
               if(Player.CardChange)
                {
                    Dealer.CardChange(Player.CardChanges);
                    Dealer.CardView();
                    gameState = GameState.ShowDown;
                }
               
                break;
            case GameState.ShowDown:
                //ShowDown�̎��ɂ��������Ə����I����Result��
                Dealer.GameJudge();
                gameState = GameState.Result;
                break;
            case GameState.Result:
                break;



        }
    }
}
