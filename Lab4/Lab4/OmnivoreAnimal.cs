namespace Lab4;

/// <summary>
/// Represents an omnivorous animal in the ecosystem.
/// </summary>
public class OmnivoreAnimal : Animal
{
    /// <summary>
    /// Initializes a new instance of the <see cref="OmnivoreAnimal"/> class with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the omnivorous animal.</param>
    /// <param name="position">The position of the animal on the map.</param>
    /// <param name="energy">The initial energy level of the animal.</param>
    /// <param name="surviveRate">The survival rate of the animal (a value between 0 and 1).</param>
    /// <param name="speed">The speed of the animal.</param>
    public OmnivoreAnimal(string name, Position position, int energy, float surviveRate, int speed)
        : base(name, position, energy, surviveRate, speed, 'o')
    {
    }
}
