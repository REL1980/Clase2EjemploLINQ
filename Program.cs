// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;
using LinqFaroShuffle;

public class Program
{
    static void Main(string[] args)
    {
        var startingDeck = from s in Suits()
                           from r in Ranks()
                           select new { Suit = s, Rank = r };

        // Muestre cada tarjeta que hemos generado y colocado en startDeck en la consola
        foreach (var card in startingDeck)
        {
            Console.WriteLine(card);
        }
        //52 cartas en una baraja, por lo que 52/2 = 26
        var top = startingDeck.Take(26);
        var bottom = startingDeck.Skip(26);
        var shuffle = top.InterleaveSequenceWith(bottom);

        foreach (var c in shuffle)
        {
            Console.WriteLine(c);
        }

        // Query for building the deck

        // Shuffling using InterleaveSequenceWith<T>();

        var times = 0;
        // We can re-use the shuffle variable from earlier, or you can make a new one
        shuffle = startingDeck;
        do
        {
            shuffle = shuffle.Take(26).InterleaveSequenceWith(shuffle.Skip(26));

            foreach (var card in shuffle)
            {
                Console.WriteLine(card);
            }
            Console.WriteLine();
            times++;

        }while(!startingDeck.SequenceEquals(shuffle));

        Console.WriteLine(times);

    }
    static IEnumerable<string> Suits()
    {
        yield return "clubs";
        yield return "diamonds";
        yield return "hearts";
        yield return "spades";
    }

    static IEnumerable<string> Ranks()
    {
        yield return "two";
        yield return "three";
        yield return "four";
        yield return "five";
        yield return "six";
        yield return "seven";
        yield return "eight";
        yield return "nine";
        yield return "ten";
        yield return "jack";
        yield return "queen";
        yield return "king";
        yield return "ace";
    }
}