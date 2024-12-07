namespace Lab4;

/// <summary>
/// Defines the contract for building reports that track ecosystem processes such as eating, dying, and growing.
/// </summary>
public interface IReportBuilder
{
    /// <summary>
    /// Retrieves the current report and resets the builder for subsequent report creation.
    /// </summary>
    /// <returns>
    /// A <see cref="Report"/> object containing the details of the current processes.
    /// </returns>
    public Report GetReport();

    /// <summary>
    /// Adds a record of an eat process to the report.
    /// </summary>
    /// <param name="hunter">The animal that performed the eating action.</param>
    /// <param name="prey">The entity that was consumed during the eating process.</param>
    public void AddEatProcess(Animal hunter, EcosystemEntity prey);

    /// <summary>
    /// Adds a record of a dying process to the report.
    /// </summary>
    /// <param name="entity">The entity that has died.</param>
    public void AddDyingProcess(EcosystemEntity entity);

    /// <summary>
    /// Adds a record of a growing process to the report.
    /// </summary>
    /// <param name="entity">The entity that has grown.</param>
    public void AddGrowProcess(EcosystemEntity entity);
}
