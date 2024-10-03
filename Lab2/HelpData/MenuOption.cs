namespace Lab2.HelpData;

public class MenuOption(string label, Enum enumValue)
{
    public string Label { get; set; } = label;
    public Enum Option { get; set; } = enumValue;
}
