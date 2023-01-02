namespace ProcQuest;

public class Human : Actor
{
    private readonly int MaxBaseHealth = 9;
    private readonly int MinBaseHealth = 5;
    private readonly int MaxBaseSpeed = 4;
    private readonly int MinBaseSpeed = 2;
    private readonly int MaxBaseStrength = 4;
    private readonly int MinBaseStrength = 1;
    private readonly int MaxBasePerception = 6;
    private readonly int MinBasePerception = 1;
    private readonly int MaxBaseEndurance = 5;
    private readonly int MinBaseEndurance = 2;
    private readonly int MaxBaseCharisma = 6;
    private readonly int MinBaseCharisma = 1;
    private readonly int MaxBaseIntelligence = 5;
    private readonly int MinBaseIntelligence = 2;
    private readonly int MaxBaseAgility = 5;
    private readonly int MinBaseAgility = 1;
    private readonly int MaxBaseLuck = 10;
    private readonly int MinBaseLuck = 1;
    private readonly int MaxBaseWisdom = 6;
    private readonly int MinBaseWisdom = 1;
    private readonly int MaxBaseToughness = 8;
    private readonly int MinBaseToughness = 3;
    private readonly int MaxBaseFortitude = 7;
    private readonly int MinBaseFortitude = 2;
    private readonly double ExpIncreaseAmount = 1.02;

    public Human(string name, int level)
    {
        this.Race = "Human";
        this.Name = name;
        this.Level = level;
        this.Health = RandomPyramid(MinBaseHealth, MaxBaseHealth);
        this.Speed = RandomPyramid(MinBaseSpeed, MaxBaseSpeed);
        this.Strength = RandomPyramid(MinBaseStrength, MaxBaseStrength);
        this.Perception = RandomPyramid(MinBasePerception, MaxBasePerception);
        this.Endurance = RandomPyramid(MinBaseEndurance, MaxBaseEndurance);
        this.Charisma = RandomPyramid(MinBaseCharisma, MaxBaseCharisma);
        this.Intelligence = RandomPyramid(MinBaseIntelligence, MaxBaseIntelligence);
        this.Agility = RandomPyramid(MinBaseAgility, MaxBaseAgility);
        this.Luck = RandomPyramid(MinBaseLuck, MaxBaseLuck);
        this.Wisdom = RandomPyramid(MinBaseWisdom, MaxBaseWisdom);
        this.Toughness = RandomPyramid(MinBaseToughness, MaxBaseToughness);
        this.Fortitude = RandomPyramid(MinBaseFortitude, MaxBaseFortitude);
    }
}