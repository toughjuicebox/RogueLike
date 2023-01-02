namespace ProcQuest;

public class Actor
{
    //Actor Attributes
    public string Race { get; set; }
    public string Name { get; set; }
    public int Level { get; set; }
    public int Experience { get; set; }
    public int ExpNeeded { get; set; }
    public int Health { get; set; }
    public int Speed { get; set; }
    public int Strength { get; set; }
    public int Perception { get; set; }
    public int Endurance { get; set; }
    public int Charisma { get; set; }
    public int Intelligence { get; set; }
    public int Agility { get; set; }
    public int Luck { get; set; }
    public int Wisdom { get; set; }
    public int Toughness { get; set; }
    public int Fortitude { get; set; }

    //Pyramid RNG Smoother
    protected int RandomPyramid(int low, int high)
    {
        Random rng = new Random();
        return (rng.Next(low, high) + rng.Next(low, high)) / 2;
    }

    //Constructors
    public Actor()
    {
        this.Race = "Debug";
        this.Name = "Something Went Wrong";
        this.Level = 1;
        this.Experience = 0;
        this.Health = 1;
        this.Speed = 1;
        this.Strength = 1;
        this.Perception = 1;
        this.Endurance = 1;
        this.Charisma = 1;
        this.Intelligence = 1;
        this.Agility = 1;
        this.Luck = 1;
        this.Wisdom = 1;
        this.Toughness = 1;
        this.Fortitude = 1;
    }

    //Class Methods
    public override string ToString()
    {
        return $"The {this.Race} {this.Name} is level {this.Level}.\n" +
               $"They have {this.Health} health, {this.Speed} speed, {this.Strength} strength, " +
               $"{this.Perception} perception, {this.Endurance} endurance,\n" +
               $"{this.Charisma} charisma, {this.Intelligence} intelligence, {this.Agility} agility " +
               $"{this.Luck} luck, {this.Wisdom} Wisdom, \n" +
               $"{this.Toughness} toughness, and {this.Fortitude} fortitude.\n\n\n";
    }
}