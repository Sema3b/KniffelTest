public class GameController // 1. Methode
{
    private List<Player> Players { get; set; } //1. Liste wird aufgerufen
    private Dice[] Dice { get; set; } 
    private const int MaxRounds = 13;
    private const int DiceCount = 5;

    public GameController()
    {
        Players = new List<Player>();
        Dice = new Dice[DiceCount];

        for (int i = 0; i < DiceCount; i++)
        {
            Dice[i] = new Dice();
        }

        SetupPlayers();
    }

    private void SetupPlayers()
    {
        Console.Write("Anzahl der Spieler: ");
        int playerCount = int.Parse(Console.ReadLine());

        for (int i = 1; i <= playerCount; i++)
        {
            Console.Write($"Name des Spielers {i}: ");
            string name = Console.ReadLine();
            Players.Add(new Player(name));
        }
    }

    public void PlayGame()
    {
        for (int round = 1; round <= MaxRounds; round++)
        {
            foreach (Player player in Players)
            {
                Console.Clear();
                Console.WriteLine($"{player.Name} ist an der Reihe. (Runde {round} von {MaxRounds}.)");
                player.ShowScoreCard();
                RollDice();
                ScoreRound(player);
            }
        }

        AnnounceWinner();
    }

    private void RollDice()
    {
        foreach (Dice die in Dice)
        {
            die.Roll();
        }

        Console.ForegroundColor = ConsoleColor.Red; // Hebt die Würfel farblich hervor
        Console.WriteLine($"\r\nWürfelergebnisse:\t{string.Join(" ", Dice.Select(d => d.Value))}");
        Console.ResetColor(); // Setzt die Farbe zurück
    }

    private void ScoreRound(Player player)
    {
        Console.Write($"\r\nWähle eine Kategorie zum Punkte Eintragen: \r\n1. Einer\t7. Dreierpasch\r\n2. Zweier\t8. Viererpasch\r\n3. Dreier\t9. FullHouse\r\n4. Vierer\t10. Kleine Straße\r\n5. Fünfer\t11. Große Straße\r\n6. Sechser\t12. Kniffel\r\n\t\t13. Chance");
        string category = Console.ReadLine();
        int score = Dice.Sum(d => d.Value); // Vereinfachte Punkteberechnung fürs Beispiel
        player.ScoreCard.AddScore(category, score);
    }

    private void AnnounceWinner()
    {
        var winner = Players.OrderByDescending(p => p.ScoreCard.TotalScore).First();
        Console.WriteLine($"\n{winner.Name} hat gewonnen mit {winner.ScoreCard.TotalScore} Punkten!");
    }
}