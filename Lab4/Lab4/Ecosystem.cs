namespace Lab4;

public class Ecosystem
{
    private List<EcosystemEntity> _entities = [];
    private readonly Map _map;
    private List<Animal> _animals;
    private List<Plant> _plants;
    private readonly IReportBuilder _reportBuilder;

    /// <summary>
    /// Initializes a new instance of the Ecosystem class.
    /// </summary>
    /// <param name="map">The map representing the ecosystem's environment.</param>
    /// <param name="animals">A list of animals in the ecosystem.</param>
    /// <param name="plants">A list of plants in the ecosystem.</param>
    /// <param name="reportBuilder"></param>
    public Ecosystem(Map map, List<Animal> animals, List<Plant> plants, IReportBuilder reportBuilder)
    {
        _map = map;
        _animals = animals;
        _plants = plants;
        _entities.AddRange(plants);
        _entities.AddRange(animals);
        _reportBuilder = reportBuilder;
    }

    /// <summary>
    /// Starts the ecosystem simulation for 20 iterations.
    /// </summary>
    /// <returns>A Report object containing the simulation results.</returns>
    public Report Start()
    {
        for (int i = 0; i < 20; i++)
        {
            Map.ClearMap();

            foreach (var entity in _entities)
            {
                if (Map.CanSetEntityOnMap(entity))
                {
                    Map.SetEntityOnMap(entity);
                }
                else
                {
                    var prey = _entities.First(e => e != entity && e.Position == entity.Position);

                    if (TryEat((entity as Animal)!, prey))
                    {
                        Console.WriteLine($"Entity {entity.Name} has ate {prey.Name}!!!");
                        _reportBuilder.AddEatProcess((entity as Animal)!, prey);
                    }
                }
            }

            Console.WriteLine($"Iteration {i + 1}");
            Console.WriteLine(_map.ToString());

            SimulateStep();
        }

        Console.WriteLine(_map.ToString());

        return _reportBuilder.GetReport();
    }

    /// <summary>
    /// Attempts to make a hunter animal eat a prey entity.
    /// </summary>
    /// <param name="hunter">The animal attempting to eat.</param>
    /// <param name="prey">The potential prey entity.</param>
    /// <returns>True if the hunter successfully eats the prey, false otherwise.</returns>
    private bool TryEat(Animal hunter, EcosystemEntity prey)
    {
        if (!hunter.CanEat(prey))
        {
            return false;
        }

        Eat(hunter, prey);
        return true;
    }

    /// <summary>
    /// Executes the eating process between a hunter and its prey.
    /// </summary>
    /// <param name="hunter">The entity eating the prey.</param>
    /// <param name="prey">The entity being eaten.</param>
    private void Eat(EcosystemEntity hunter, EcosystemEntity prey)
    {
        hunter.GrowEntity();
        _reportBuilder.AddGrowProcess(hunter);
        DeleteEntity(prey);
    }

    /// <summary>
    /// Removes an entity from all relevant lists in the ecosystem.
    /// </summary>
    /// <param name="entity">The entity to be deleted.</param>
    private void DeleteEntity(EcosystemEntity entity)
    {
        _entities = _entities.FindAll(e => e != entity);
        _animals = _animals.FindAll(e => e != entity);
        _plants = _plants.FindAll(e => e != entity);
    }

    /// <summary>
    /// Simulates a single step in the ecosystem, including animal movement, plant growth, and entity death.
    /// </summary>
    private void SimulateStep()
    {
        foreach (var animal in _animals)
        {
            animal.Move();
        }

        foreach (Plant ecosystemEntity in _plants)
        {
            ecosystemEntity.GrowEntity();
            _reportBuilder.AddGrowProcess(ecosystemEntity);
        }

        foreach (var entity in _entities.Where(entity => entity.IsDie()))
        {
            DeleteEntity(entity);
            _reportBuilder.AddDyingProcess(entity);
        }
    }
}
