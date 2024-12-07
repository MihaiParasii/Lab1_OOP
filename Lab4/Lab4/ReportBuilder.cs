namespace Lab4;

/// <summary>
/// Provides functionality for building reports that track processes such as eating, dying, and growing in an ecosystem.
/// Implements the <see cref="IReportBuilder"/> interface.
/// </summary>
public class ReportBuilder : IReportBuilder
{
    private Report _report = new();

    /// <summary>
    /// Initializes a new instance of the <see cref="ReportBuilder"/> class and resets the internal report.
    /// </summary>
    public ReportBuilder()
    {
        Reset();
    }

    /// <summary>
    /// Resets the internal report instance, clearing all data.
    /// </summary>
    private void Reset()
    {
        _report = new Report();
    }

    /// <summary>
    /// Retrieves the current report and resets the builder for future use.
    /// </summary>
    /// <returns>
    /// A <see cref="Report"/> instance containing the current state of the report.
    /// </returns>
    public Report GetReport()
    {
        Report result = _report;
        Reset();
        return result;
    }

    /// <summary>
    /// Adds an eat process to the report, describing an interaction where an animal (hunter) eats another entity (prey).
    /// </summary>
    /// <param name="hunter">The animal that performed the eating action.</param>
    /// <param name="prey">The entity that was eaten.</param>
    public void AddEatProcess(Animal hunter, EcosystemEntity prey)
    {
        _report.EatProcess.Add(new Process(
            $"Hunter {hunter.Name} which is {hunter.GetType().ToString().Remove(0, 5)} has ate {prey.Name}."));
    }

    /// <summary>
    /// Adds a dying process to the report, describing an entity's death.
    /// </summary>
    /// <param name="entity">The entity that has died.</param>
    public void AddDyingProcess(EcosystemEntity entity)
    {
        _report.DieProcess.Add(new Process(
            $"Entity {entity.Name} which is {entity.GetType().ToString().Remove(0, 5)} has died."));
    }

    /// <summary>
    /// Adds a growing process to the report, describing an entity's growth.
    /// </summary>
    /// <param name="entity">The entity that has grown.</param>
    public void AddGrowProcess(EcosystemEntity entity)
    {
        _report.GrowProcess.Add(new Process(
            $"Entity {entity.Name} which is {entity.GetType().ToString().Remove(0, 5)} has gained."));
    }
}
