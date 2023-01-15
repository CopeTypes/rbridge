using Colore.Data;
using Colore.Effects.Keyboard;

namespace rbridge.api.device;

public class KeyboardI
{

    private static CustomKeyboardEffect _baseKb = CustomKeyboardEffect.Create();

    public static async Task Default()
    {
        _baseKb.Set(Program.DefaultColor);
        await Custom(_baseKb);
    }
    
    public static async Task Solid(Color color)
    {
        await RGBI.getKB().SetAllAsync(color);
    }


    public static async Task Scroll(Color first, Color second, int times, KDir dir, int delay = 1)
    {
        while (times > 0)
        {
            await smoothKb(_baseKb, first, dir, delay);
            await smoothKb(_baseKb, second, dir, delay);
            times--;
        }
        
    }

    public static async Task Flash(Color color, int times, int delay = 280)
    {
        while (times > 0)
        {
            await Solid(color);
            Thread.Sleep(delay);
            await Solid(Color.Black);
            Thread.Sleep(delay);
            times--;
        }

        await Default();
    }
    

    public static async Task Custom(CustomKeyboardEffect effect)
    {
        _baseKb = effect;
        await RGBI.getKB().SetCustomAsync(_baseKb);
    }
    
    
    
    
    
    
 
    private enum KSide { Left, Right, Top, Bottom }
    
    private static async Task setSide(CustomKeyboardEffect effect, Color color, KSide side)
    {
        if (effect == null) effect = CustomKeyboardEffect.Create();
        int r = 0, c = 0;
        switch (side)
        {
            case KSide.Left:
            {
                c = 1;
                while (r < KeyboardConstants.MaxRows)
                {
                    try { effect[r, c] = color; }
                    catch { }
                    r++;
                }
            } break;
            case KSide.Right:
            {
                c = KeyboardConstants.MaxColumns - 1;
                while (r < KeyboardConstants.MaxRows)
                {
                    try { effect[r, c] = color; }
                    catch { }
                    r++;
                }
            } break;
            case KSide.Top:
            {
                while (c < KeyboardConstants.MaxColumns)
                {
                    {
                        try { effect[r, c] = color; }
                        catch { }
                        c++;
                    }
                }
            } break;
            case KSide.Bottom:
            {
                r = KeyboardConstants.MaxRows - 1;
                while (c < KeyboardConstants.MaxColumns)
                {
                    {
                        try { effect[r, c] = color; }
                        catch { }
                        c++;
                    }
                }
            } break;
        }
        await Custom(effect);
    }
    
    public enum KDir { TopToBottom, BottomToTop, LeftToRight, RightToLeft }

    private static async Task smoothKb(CustomKeyboardEffect effect, Color color, KDir dir, int delay)
    {
        if (effect == null) effect = CustomKeyboardEffect.Create();
        int r = 0, c = 0;
        switch (dir)
        {
            case KDir.BottomToTop:
            {
                if (delay == 1) delay = 90;
                r = KeyboardConstants.MaxRows;
                while (r >= 0)
                {
                    while (c < KeyboardConstants.MaxColumns)
                    {
                        try { effect[r, c] = color; }
                        catch{}
                        c++;
                    }
                    c = 0;
                    r--;
                    await Custom(effect);
                    Thread.Sleep(delay);
                } break;
            }
            case KDir.TopToBottom:
            {
                if (delay == 1) delay = 90;
                while (r < KeyboardConstants.MaxRows)
                {
                    while (c < KeyboardConstants.MaxColumns)
                    {
                        try { effect[r, c] = color; }
                        catch{}
                        c++;
                    }
                    c = 0;
                    r++;
                    await Custom(effect);
                    Thread.Sleep(delay);
                } break;
            }
            case KDir.RightToLeft:
            {
                if (delay == 1) delay = 45;
                while (c < KeyboardConstants.MaxColumns)
                {
                    while (r < KeyboardConstants.MaxRows)
                    {
                        try { effect[r, c] = color;}
                        catch{}
                        r++;
                    }
                    r = 0;
                    c++;
                    await Custom(effect);
                    Thread.Sleep(delay);

                } break;
            }
            case KDir.LeftToRight:
            {
                if (delay == 1) delay = 45;
                c = KeyboardConstants.MaxColumns - 1;
                while (c >= 0)
                {
                    while (r < KeyboardConstants.MaxRows)
                    {
                        try { effect[r, c] = color; }
                        catch {}
                        r++;
                    }
                    r = 0;
                    c--;
                    await Custom(effect);
                    Thread.Sleep(delay);
                } break;
            }
        }
    }
}