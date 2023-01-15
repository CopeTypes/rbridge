using Colore.Data;

namespace rbridge.api.device;

public class MouseI
{

    public static async Task Solid(Color color)
    {
        await RGBI.getM().SetAllAsync(color);
    }
}