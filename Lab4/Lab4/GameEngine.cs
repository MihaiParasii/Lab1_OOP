namespace Lab4;

public static class GameEngine
{
    /// <summary>
    /// Initializes and starts a new game simulation of an ecosystem.
    /// </summary>
    /// <remarks>
    /// This method creates a new map, populates it with plants and animals,
    /// initializes an ecosystem, starts the simulation, and prints the report.
    /// </remarks>
    public static void InitGame()
    {
        Map map = new Map(20, 20);

        List<Plant> plants =
        [
            new Plant("P1", new Position(2, 2), 30, 0.55f),
            new Plant("P2", new Position(2, 3), 30, 0.55f),
            new Plant("P3", new Position(2, 4), 30, 0.55f),
            new Plant("P4", new Position(2, 5), 30, 0.55f),
        ];

        List<Animal> animals =
        [
            new CarnivoreAnimal("C1", new Position(3, 3), 30, 0.55f, 10),
            new CarnivoreAnimal("C2", new Position(4, 6), 30, 0.55f, 10),
            new HerbivoreAnimal("H1", new Position(5, 4), 30, 0.55f, 10),
            new HerbivoreAnimal("H2", new Position(5, 6), 30, 0.55f, 10),
            new OmnivoreAnimal("O1", new Position(6, 4), 30, 0.55f, 10),
            new OmnivoreAnimal("O2", new Position(6, 6), 30, 0.55f, 10),
        ];

        Ecosystem ecosystem = new(map, animals, plants, new ReportBuilder());
        var report = ecosystem.Start();
        Console.WriteLine(report);
    }
}