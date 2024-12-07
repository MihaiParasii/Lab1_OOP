using Lab3.CommandResults;
using Lab3.Commands;
using Lab3.Exceptions;

namespace Lab3;

public class GitEngine
{
    protected GitEngine()
    {
        AddNewCommand("info", new InfoCommand());
        AddNewCommand("commit", new CommitCommand());
        AddNewCommand("checkout", new CheckoutCommand());
        AddNewCommand("status", new StatusCommand());
    }

    private readonly Dictionary<string, ICommand> _commands = new();

    protected void AddNewCommand(string command, ICommand commandClass)
    {
        _commands.TryAdd(command, commandClass);
    }

    public CommandResult ExecuteCommand(GitInputDto gitInputDto)
    {
        if (_commands.TryGetValue(gitInputDto.Command, out var currentCommand))
        {
            return currentCommand.Execute(gitInputDto.Argument ?? "");
        }

        ConsoleExceptionThrower.Throw(InvalidGitCommandError.GetError(_commands));
        return new BadCommandResult($"Invalid command '{gitInputDto.Command}'");
    }

    public static bool IsGitCommand(string command)
    {
        return command.StartsWith("git ", StringComparison.CurrentCultureIgnoreCase);
    }

    public static GitInputDto ParseCommand(string command)
    {
        // "git    commit                              my_first_commit    "
        // "git commit my first commit"
        // "git" "commit" "my_first_commit v1"

        string[] s = command.Replace('\t', ' ').Split(' ');

        var commandParts = s.Where(c => !string.IsNullOrWhiteSpace(c)).ToList();

        if (commandParts.Count < 2)
        {
            ConsoleExceptionThrower.Throw(EmptyCommandError.GetError());
        }


        return new GitInputDto(commandParts[1],
            commandParts.Count >= 3 ? string.Join(" ", commandParts[2..]) : string.Empty);
    }
}
