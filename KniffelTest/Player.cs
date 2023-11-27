public class Player
{
    public string Name { get; private set; }
    public ScoreCard ScoreCard { get; private set; }

    public Player(string name) //2. Metode, die aufgerufen wird / 6.Methode / GameController() wird beendet, PlayGame() beginnt
    {
        Name = name;
        ScoreCard = new ScoreCard(); // 3. Methode, die aufgerufen wird / 7. Methode
    }

    public void ShowScoreCard()//8. Methode
    {
        // Anzeige des Gesamtscore
        Console.WriteLine($"{Name}'s Scorecard: {ScoreCard.TotalScore} Punkte\r\n");

        // Die Titelzeile
        Console.WriteLine("\t\t| Werte\t\t| 1. Spiel\t| 2. Spiel\t| 3. Spiel\t| 4. Spiel\t| 5. Spiel\t| 6. Spiel");

        // Die Zeilen für einzelne Würfe
        Console.WriteLine("1er\t\t| Nur 1er\t| ");
        Console.WriteLine("2er\t\t| Nur 2er\t| ");
        Console.WriteLine("3er\t\t| Nur 3er\t| ");
        Console.WriteLine("4er\t\t| Nur 4er\t| ");
        Console.WriteLine("5er\t\t| Nur 5er\t| ");
        Console.WriteLine("6er\t\t| Nur 6er\t| ");
        Console.WriteLine("Gesamtpunktzahl\t| ############# | ");
        Console.WriteLine("Bonus (bei 63+)\t| +35 Punkte\t| ");
        Console.WriteLine("Gesamt (Oben)\t| ############# | ");
        Console.WriteLine();

        // Die Zeilen für die Serien
        Console.WriteLine("Dreierpasch\t| Alle Augen\t| ");
        Console.WriteLine("Viererpasch\t| Alle Augen\t| ");
        Console.WriteLine("Full House\t| 25 Punkte\t| ");
        Console.WriteLine("Kleine Straße\t| 30 Punkte\t| ");
        Console.WriteLine("Große Straße\t| 40 Punkte\t| ");
        Console.WriteLine("Kniffel\t\t| 50 Punkte\t| ");
        Console.WriteLine("Chance\t\t| Alle Augen\t| ");
        Console.WriteLine("Gesamt (Unten)\t| ############# | ");
        Console.WriteLine("Gesamt (Oben)\t| ############# | ");
        Console.WriteLine("Endsumme\t| ############# | ");        
    }
}            