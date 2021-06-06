using System.Collections.Generic;
using System.Linq;

public class PokerHand
{
    ///<summary>
    ///ポーカー役
    /// </summary>
    public enum Hand
    {
        None = -1,　  //nasi
        OnePair,　　　//ワンペア
        TwoPair,　　　//ツーペア
        ThreeOfKind,　//スリーカード
        Straght,　　　//ストレート
        Flush,　　　　//フラッシュ
        FullHouse,　　//フルハウス
        FourOfKind,   //フォーカード
        StraightFlush,//ストレートフラッシュ
        RoyalFlush　　//ロイヤルストレートフラッシュ

    }
    public static Hand CardHand(List<Card> cards)
    {
        cards.Sort((a, b) => a.CardNumber - b.CardNumber);
        var kinds = 0;
        var cardsElement = 0;
        foreach (var card in cards.ToLookup(s => s.CardNumber))
        {
            if (card.Count() > 1)
            {
                cardsElement++;
                kinds += card.Count();
            }

        }
        var clubRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Crub);
        var diaRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Dia);
        var heartRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Heart);
        var spadeRoyal = cards.TrueForAll(s => s.CardSuit == Card.Suit.Spade);

        var firstCardNo = cards[0].CardNumber;
        #region ロイヤルストレートフラッシュ(1,10,11,12,13)Suitがすべて一緒
        if (firstCardNo.Equals(1))
        {
            if (cards[1].CardNumber.Equals(10))
            {
                var count = 0;
                for (int i = 2; i < cards.Count; i++)
                {
                    if (cards[i].CardNumber.Equals(9 + i))
                    {
                        count++;
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
                //Straightは確定
                if (count.Equals(3))
                {
                    if (clubRoyal || diaRoyal || heartRoyal || spadeRoyal)
                    {
                        return Hand.RoyalFlush;
                    }
                    else
                    {
                        return Hand.Straght;
                    }
                }
            }
        }
        #endregion

        #region straightFullash
        var straightCount = 0;
        for (int i = 1; i < cards.Count; i++)
        {
            var straightCardNo = firstCardNo;
            if (cards[i].CardNumber.Equals(straightCardNo + i))
            {
                straightCount++;
                continue;
            }
            else
            {
                break;
            }
        }
        if (straightCount.Equals(4))
        {
            if (clubRoyal || diaRoyal || heartRoyal || spadeRoyal)
            {
                return Hand.StraightFlush;
            }
            else
            {
                return Hand.Straght;
            }
        }
        #endregion
        #region フォーカード
        if (cardsElement.Equals(1) && kinds.Equals(4))
        {
            return Hand.FourOfKind;
        }
        #endregion
        #region フルハウス
        if (cardsElement.Equals(2) && kinds.Equals(5))
        {
            return Hand.FullHouse;
        }
        #endregion
        #region フラッシュ
        if (clubRoyal || diaRoyal || heartRoyal || spadeRoyal)
        {
            return Hand.Flush;
        }
        #endregion
        #region ワンペアorツーペアorスリーカード
      if(kinds.Equals(3))
        {
            return Hand.ThreeOfKind;
        }
      if(cardsElement.Equals(2) && kinds.Equals(4))
             
        {
            return Hand.TwoPair;
        }
      if(kinds.Equals(2))
        {
            return Hand.OnePair;
        }
        #endregion
        return Hand.None;
    }
}
