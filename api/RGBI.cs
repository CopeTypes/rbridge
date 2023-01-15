using System;
using System.Threading;
using System.Threading.Tasks;
using Colore;
using Colore.Data;
using rbridge.api.command;

namespace rbridge.api;

public class RGBI
{
   

    private static IChroma _rgbi;
    
    public static async Task init()
    {
        _rgbi = await ColoreProvider.CreateNativeAsync();
        Thread.Sleep(2500);
        await Solid(Color.Black);
        Thread.Sleep(500);
        await Solid(Program.DefaultColor);
        Console.WriteLine("Connected to SDK " + _rgbi.SdkVersion + "\n");
        await CommandI.start();
    }

    public static IChroma getRgb() { return _rgbi; }
    
    public static IKeyboard getKB() { return _rgbi.Keyboard; }
    public static IMouse getM() { return _rgbi.Mouse; }
    public static IMousepad getMP() { return _rgbi.Mousepad; }
    public static IHeadset getH()
    { return _rgbi.Headset; }
    
    
    // Global
    public static async Task Solid(Color color)
    {
        await _rgbi.SetAllAsync(color);
    }

}