using System.Text;

namespace Lab4;

/// <summary>
/// Represents a report containing details about various ecosystem processes such as eating, dying, and growing.
/// </summary>
public class Report
{
    /// <summary>
    /// The timestamp when the report is generated.
    /// Defaults to the current date and time.
    /// </summary>
    private readonly DateTime _dateTime = DateTime.Now;

    /// <summary>
    /// A list of processes related to eating actions in the ecosystem.
    /// </summary>
    public readonly List<Process> EatProcess = [];

    /// <summary>
    /// A list of processes related to dying actions in the ecosystem.
    /// </summary>
    public readonly List<Process> DieProcess = [];

    /// <summary>
    /// A list of processes related to growing actions in the ecosystem.
    /// </summary>
    public readonly List<Process> GrowProcess = [];

    /// <summary>
    /// Returns a string representation of the report, including the timestamp and details of all processes.
    /// </summary>
    /// <returns>
    /// A string representation of the report, detailing the timestamp and all processes (eat, die, grow).
    /// </returns>
    public override string ToString()
    {
        StringBuilder result = new();
        
        result.AppendLine("Report:");
        result.AppendLine($"Report generated at: {_dateTime}");

        result.AppendLine("Eat Process:");
        foreach (var process in EatProcess)
        {
            result.AppendLine($"- {process.Name}");
        }

        result.AppendLine("\nDie Process:");
        foreach (var process in DieProcess)
        {
            result.AppendLine($"- {process.Name}");
        }

        result.AppendLine("\nGrow Process:");
        foreach (var process in GrowProcess)
        {
            result.AppendLine($"- {process.Name}");
        }

        return result.ToString();
    }
}