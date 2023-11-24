public class ScoreCard 
{
    private Dictionary<string, int> Scores { get; set; } // Dictionary wird als lokale Variable(?) initiallisiert, Aufbau verstehen..
    public int TotalScore => Scores.Values.Sum(); // Gesamtsumme > Summe Wurfwert

    public ScoreCard() // 3. Methode / 7. Methode
    {
        Scores = new Dictionary<string, int>();
    }

    public void AddScore(string category, int score)// 12. Methode
    {
        if (!Scores.ContainsKey(category))
        {
            Scores.Add(category, score);
        }
        else
        {
            Console.WriteLine("Diese Kategorie wurde bereits gewählt.");
        }
    }
}