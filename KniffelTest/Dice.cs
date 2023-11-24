public class Dice
{
    public int Value { get; private set; }
    private Random Random { get; set; }
    
    public Dice()//4. Methode / 9.Methode
    {
        Random = new Random();
    }

    public void Roll()// 10. Methode
    {
        Value = Random.Next(1, 7);
    }



    public string[] StringDices = new string[]
            {
            // Würfel 1
            " ------- \n" +
            "|       |\n" +
            "|   *   |\n" +
            "|       |\n" +
            " ------- ",

            // Würfel 2
            " ------- \n" +
            "| *     |\n" +
            "|       |\n" +
            "|     * |\n" +
            " ------- ",

            // Würfel 3
            " ------- \n" +
            "| *     |\n" +
            "|   *   |\n" +
            "|     * |\n" +
            " ------- ",

            // Würfel 4
            " ------- \n" +
            "| *   * |\n" +
            "|       |\n" +
            "| *   * |\n" +
            " ------- ",

            // Würfel 5
            " ------- \n" +
            "| *   * |\n" +
            "|   *   |\n" +
            "| *   * |\n" +
            " ------- ",

            // Würfel 6
            " ------- \n" +
            "| *   * |\n" +
            "| *   * |\n" +
            "| *   * |\n" +
            " ------- "
            };
}