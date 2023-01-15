using Colore.Data;
using rbridge.api.device;

namespace rbridge.api.command.commands;

public class KeyboardC
{

    public static async Task parseKBC(string cmd)
    {
        cmd = cmd.Replace("keyboard ", "");
        if (cmd.StartsWith("solid ")) await ParseSolid(cmd);
        if (cmd.StartsWith("flash ")) await ParseFlash(cmd);
        if (cmd.StartsWith("scroll ")) await ParseScroll(cmd);
    }


    private static async Task ParseSolid(string cmd)
    {
        string[] temp = cmd.Replace("solid ", "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Color c = Utils.colorFromString(temp[0]);
        await KeyboardI.Solid(c);
    }

    private static async Task ParseFlash(string cmd)
    {
        string[] temp = cmd.Replace("blink ", "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Color c = Utils.colorFromString(temp[0]);
        var times = int.Parse(temp[1]);
        if (cmd.Contains("delay ")) await KeyboardI.Flash(c, times, int.Parse(temp[3]));
        else await KeyboardI.Flash(c, times);
    }

    private static async Task ParseScroll(string cmd)
    {
        string[] temp = cmd.Replace("scroll ", "").Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        Color first = Utils.colorFromString(temp[0]);
        Color second = Utils.colorFromString(temp[1]);
        var times = int.Parse(temp[2]);
        var dir = temp[3] switch
        {
            "TopToBottom" => KeyboardI.KDir.TopToBottom,
            "BottomToTop" => KeyboardI.KDir.BottomToTop,
            "LeftToRight" => KeyboardI.KDir.LeftToRight,
            "RightToLeft" => KeyboardI.KDir.TopToBottom,
            _ => KeyboardI.KDir.TopToBottom
        };
        if (cmd.Contains("delay ")) await KeyboardI.Scroll(first, second, times, dir, int.Parse(temp[5]));
        else await KeyboardI.Scroll(first, second, times, dir);
    }
     
    
}