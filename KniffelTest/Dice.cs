public class Dice
{
    public int Value { get; private set; }
    private Random Random { get; set; }
    
    public Dice()
    {
        Random = new Random();
    }

    public void Roll()// 10. Methode
    {
        Value = Random.Next(1, 7);//den Stellenwert von den angegebenen zahl subtrahieren
    }



    public string[] StringDices = new string[] // switch cases, die die Wuerfeln zeigen
            {
                // void WhichDice{
                //switch(Dice){
            //case "Würfel 1"
            //Console.Write(" ------- \n" +"|       |\n" +"|   *   |\n" +"|       |\n" +" ------- ");
            //break;

            // case "Würfel 2"
            //Console.Write(" ------- \n" + "| *     |\n" +"|       |\n" +"|     * |\n" +" ------- ");
            //break;

            // case "Würfel 3"
            //Console.Write("------ - \n" + "| *     |\n" + "|   *   |\n" +"|     * |\n" + " ------- ");
            // break;

            // case "Würfel 4"
            //Console.Write(" ------- \n" +"| *   * |\n" + "|       |\n" + "| *   * |\n" + " ------- ");
            //break;

            // case "Würfel 5"
            //Console.Write(" ------- \n" + "| *   * |\n" + "|   *   |\n" + "| *   * |\n" + " ------- ");
            // break;

            // case "Würfel 6"
            //Console.Write(" ------- \n" + "| *   * |\n" + "| *   * |\n" + "| *   * |\n" + " ------- ");
                //break;
                //}
                //}
            };
}