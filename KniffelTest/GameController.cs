public class GameController 
{
    private List<Player> Players { get; set; } 
    private Dice[] Dice { get; set; } 
    private const int MaxRounds = 13;
    private const int DiceCount = 5;

    public GameController()// 1. Methode
    {
        Players = new List<Player>();//2. Methode, Liste wird aufgerufen
        Dice = new Dice[DiceCount];
        for (int i = 0; i < DiceCount; i++)
        {
            Dice[i] = new Dice();//4. Methode

        }

        SetupPlayers();//5. Methode
    }

    private void SetupPlayers()//5.Methode
    {
        Console.Write("Anzahl der Spieler: ");
        int playerCount = int.Parse(Console.ReadLine()); // Eingabe wird playerCount hinzugefuegt

        for (int i = 1; i <= playerCount; i++) // playerCount wird durchgegangen, um jeden Spieler einen Namen zu geben
        {
            Console.Write($"Name des Spielers {i}: ");
            string name = Console.ReadLine();
            Players.Add(new Player(name));//6. Methode
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
                player.ShowScoreCard();//8. Methode
                RollDice();//9.Methode
                ScoreRound(player);//11. Methode
            }
        }

        AnnounceWinner();//13. Methode
    }

    private void RollDice()// 9.Methode
    {
        foreach (Dice die in Dice)
        {
            die.Roll();//10. Methode
        }

        Console.ForegroundColor = ConsoleColor.Red; // Hebt die Würfel farblich hervor
        Console.WriteLine($"\r\nWürfelergebnisse:\t{string.Join(" ", Dice.Select(d => d.Value))}");
        Console.ResetColor(); // Setzt die Farbe zurück
    }

    private void ScoreRound(Player player) //11. Methode
    {
        Console.Write($"\r\nWähle eine Kategorie zum Punkte Eintragen: \r\n1. Einer\t7. Dreierpasch\r\n2. Zweier\t8. Viererpasch\r\n3. Dreier\t9. FullHouse\r\n4. Vierer\t10. Kleine Straße\r\n5. Fünfer\t11. Große Straße\r\n6. Sechser\t12. Kniffel\r\n\t\t13. Chance");
        string category = Console.ReadLine();
        int score = Dice.Sum(d => d.Value); // Vereinfachte Punkteberechnung fürs Beispiel
        player.ScoreCard.AddScore(category, score);//12. Methode
    }// irgendwo hier soll man den gewuerfelten Wurf in eine Kategorie zu ordnen

    private void AnnounceWinner() // 13. Methode
    {
        var winner = Players.OrderByDescending(p => p.ScoreCard.TotalScore).First();
        Console.WriteLine($"\n{winner.Name} hat gewonnen mit {winner.ScoreCard.TotalScore} Punkten!");
    }
}