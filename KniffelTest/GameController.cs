public class GameController
{
    private List<Player> Players { get; set; }
    private Dice[] Dice { get; set; }
    private const int MaxRounds = 13;
    private const int DiceCount = 5;

    public GameController()
    {
        Players = new List<Player>();//Player Liste wird aufgerufen
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
        int playerCount = int.Parse(Console.ReadLine()); // Eingabe wird playerCount hinzugefuegt

        for (int i = 1; i <= playerCount; i++) // playerCount wird durchgegangen, um jeden Spieler einen Namen zu geben
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
        List<Dice> savedDices = new List<Dice>();
        int roundsCount = 3;
        string[] choosenNumbers = new string[3];
        for (int i = 0; i < roundsCount; i++)
        {
            foreach (Dice die in Dice) // hier werden die zahlen gewuerfelt; so bearbeitet, dass 3mal gewuerfelt wird
            {
                die.Roll();//Stellenwert abziehen von den angegebenen Zahlen  
            }

            
            Console.ForegroundColor = ConsoleColor.Red; // Hebt die Würfel farblich hervor
            Console.WriteLine($"\r\n{i + 1}. Würfelergebnisse:\t{string.Join(" ", Dice.Select(d => d.Value))}");
            Console.ResetColor(); // Setzt die Farbe zurück
            Console.WriteLine($"Welchen Wuerfel moechtest du speichern? 1-5 mit Komma getrennt.");
            var eingabe = Console.ReadLine().ToString().Split(',');

            foreach(string s in eingabe)
            {
                var arrayIndex = Convert.ToInt32(s) - 1;
                savedDices.Add(Dice[arrayIndex]);
                savedDices.RemoveAt(arrayIndex);
            }

        }
        
        
        //fragen welche zahl gespeichert werden soll und diese auch speichern
        // darauf aufbauend wuerfeln, aber so, dass die gespeicherten werte nicht verloren gehen
        //(insgesamt duerfen nicht mehr als 5 zahlen eingegeben werden)
        //dice methode umaendern, sodass die angegebenen stellen vergeben sind, also wenn man zB 2 und 5 auswaehlt, sollen nur noch 3 zahlen gewuerfelt werden
       
    }

    private void ScoreRound(Player player) //methode erst aufrufen, wenn dreimal gewuerfelt wurde und die ausgewaehlt zahl gespeichert wurde
    {
        Console.Write($"\r\nWähle eine Kategorie zum Punkte Eintragen: \r\n1. Einer\t7. Dreierpasch\r\n2. Zweier\t8. Viererpasch\r\n3. Dreier\t9. FullHouse\r\n4. Vierer\t10. Kleine Straße\r\n5. Fünfer\t11. Große Straße\r\n6. Sechser\t12. Kniffel\r\n\t\t13. Chance");
        string category = Console.ReadLine();
        int score = Dice.Sum(d => d.Value); // Vereinfachte Punkteberechnung fürs Beispiel
        player.ScoreCard.AddScore(category, score);
    }// irgendwo hier soll man den gewuerfelten Wurf in eine Kategorie zu ordnen

    private void AnnounceWinner()
    {
        var winner = Players.OrderByDescending(p => p.ScoreCard.TotalScore).First();
        Console.WriteLine($"\n{winner.Name} hat gewonnen mit {winner.ScoreCard.TotalScore} Punkten!");
    }
}