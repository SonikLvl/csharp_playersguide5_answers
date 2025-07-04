//191 The Card
Console.Title = "The Card";

Card[] deck = Card.CreateDeck();

foreach(var card in deck)
{
    card.Showcard();
}

deck[5].IsFace();

class Card
{
    public CardRank _rank { get; init; }
    public CardColor _color { get; init; }

    public static Card[] CreateDeck()
    {
        Card[] cards = new Card[56];
        int iterator=0;
        foreach (var cr in Enum.GetValues(typeof(CardRank)))
        {
            foreach(var cc in Enum.GetValues(typeof(CardColor)))
            {
                cards[iterator] = new Card() { _rank = (CardRank)cr, _color = (CardColor)cc };
                iterator++;
            }
        }
        return cards;
    }
    public void Showcard()
    {
        Console.WriteLine($"This card is {_color} {_rank}");
    }
    public bool IsFace()
    {
        if ((int)_rank >= 9)
        {
            Console.WriteLine($"This card is face");
            return true;
        }
        else
        {
            Console.WriteLine($"This card is number");
            return false;
        }
    }
}

enum CardRank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSing, Persantage, Circumflexus, Ampersand}
enum CardColor { Red, Green, Blue, Yellow}