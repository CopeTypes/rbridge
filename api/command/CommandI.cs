using rbridge.api.command.commands;

namespace rbridge.api.command;

public class CommandI
{
    

    public static async Task start()
    {
        Console.WriteLine("Starting command interpreter.");
        var cmd = String.Empty;
        while (cmd != "quit")
        {
            Console.WriteLine("\nCommand?\n");
            cmd = Console.ReadLine();
            Console.WriteLine("\nProcessing.\n");
            if (cmd != null) await ParseCmd(cmd);
        }
        Console.WriteLine("\nShutting down.");
    }

    private static async Task ParseCmd(string cmd)
    {
        if (cmd.Contains("quit")) return;
        if (cmd.StartsWith("keyboard ")) await KeyboardC.parseKBC(cmd);
    }
}