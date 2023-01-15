using Colore.Data;

namespace rbridge.api.device;

public class MousepadI
{

    public static async Task Solid(Color color)
    {
        await RGBI.getMP().SetAllAsync(color);
    }
    
}