using System.Threading.Tasks;

interface Player
{
    public void AssignWeapon(string weapon);
    public void mission();
}

// Terrorist must have weapon and mission
class Terrorist : Player
{
    // Intrinsic Attribute
    private readonly string _task = "PLANT A BOMB";

    // Extrinsic Attribute
    private string _weapon = "EMPTY";


    public void AssignWeapon(string weapon)
    {
        // Assign a weapon
        this._weapon = weapon;
    }
    public void mission()
    {
        //Work on the Mission
        Console.WriteLine($"Terrorist with weapon {_weapon} | Task is {_task}");
    }
}

// CounterTerrorist must have weapon and mission
class CounterTerrorist : Player
{
    // Intrinsic Attribute
    private readonly string _task = "DIFFUSE BOMB";
    // Extrinsic Attribute
    private string _weapon = "EMPTY";


    public void AssignWeapon(string weapon)
        => this._weapon = weapon;
    
    public void mission()
        => Console.WriteLine($"Counter Terrorist with weapon {_weapon} | Task is {_task}");

}

// Class used to get a player using HashMap (Returns
// an existing player if a player of given type exists.
// Else creates a new player and returns it.
class PlayerFactory
{
    /* HashMap stores the reference to the object
       of Terrorist(TS) or CounterTerrorist(CT).  */
    private static Dictionary<string, Player> hm =
                         new Dictionary<string, Player>();

    // Method to get a player
    public static Player getPlayer(string type)
    {
        Player p = null!;

        /* If an object for TS or CT has already been
           created simply return its reference */
        if (hm.ContainsKey(type))
            p = hm.GetValueOrDefault(type)!;
        else
        {
            /* create an object of TS/CT  */
            switch (type)
            {
                case "Terrorist":
                    Console.WriteLine("Terrorist Created");
                    p = new Terrorist();
                    break;
                case "CounterTerrorist":
                    Console.WriteLine("Counter Terrorist Created");
                    p = new CounterTerrorist();
                    break;

                default:
                    Console.WriteLine("Unreachable code!");
                    break;
            }

            // Once created insert it into the HashMap
            hm.Add(type, p);
        }
        return p;
    }
}

// Driver class
public class CounterStrike
{
    // All player types and weapon (used by getRandPlayerType()
    // and getRandWeapon()
    private static string[] playerType =
                    {"Terrorist", "CounterTerrorist"};
    private static string[] weapons =
      {"AK-47", "Maverick", "Gut Knife", "Desert Eagle"};


    // Driver code
    static void Main(string[] args)
    {
        /* Assume that we have a total of 10 players
   in the game. */
        for (int i = 0; i < 10; i++)
        {
            /* getPlayer() is called simply using the class
               name since the method is a static one */
            Player p = PlayerFactory.getPlayer(getRandPlayerType());

            /* Assign a weapon chosen randomly uniformly
               from the weapon array  */
            p.AssignWeapon(getRandWeapon());

            // Send this player on a mission
            p.mission();
        }
    }

    // Utility methods to get a random player type and
    // weapon
    public static string getRandPlayerType()
        => playerType[Random.Shared.Next(playerType.Length)];

    public static string getRandWeapon()
        => weapons[Random.Shared.Next(playerType.Length)];

}