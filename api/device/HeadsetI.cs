using Colore.Data;

namespace rbridge.api.device;

public class HeadsetI
{

    public static async Task Solid(Color color)
    {
        await RGBI.getH().SetAllAsync(color);
    }
}