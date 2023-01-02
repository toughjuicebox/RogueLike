namespace ProcQuest
{
    class Game
    {
        static void Main()
        {
            Actor debug = new Actor();
            Console.WriteLine(debug.ToString());

            Human player = new Human("player", 2);
            Console.WriteLine(player.ToString());
        }
    }
}